'Title:         Inter County Transfer Thresholds
'Purpose:       To manage progress reports and thresholds for inter-county transfers
'Created:       October 31, 2025
'By:            Shon Garrison
'Last Updated:  June 2026
'Version: 1.0.1.0

Option Explicit On
Imports System.Globalization

Imports System.IO
Imports System.Text
Imports System.Windows

Public Class frmMain

    Private title As String = "Inter County Transfer Thresholds"
    Public Shared ReadOnly tdirectory As String = Path.Combine("D:\Temp", "Transfers")
    Public Shared ReadOnly ictfile As String = Path.Combine(tdirectory, "ICT_Thresholds.txt")
    Public Shared ReadOnly icjfile As String = Path.Combine(tdirectory, "ICJ_Thresholds.txt")

    '------------------------------ Form Events --------------------------------------------------

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim dteToday As Date = Date.Today
        Dim dteNinety As Date = dteToday.AddDays(90)
        Dim dteOneEighty As Date = dteToday.AddDays(180)

        lblToday.Text = dteToday.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
        lblNinety.Text = dteNinety.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
        lblOneEighty.Text = dteOneEighty.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)

        Dim button As DialogResult

        ' --- ICT File Check ---
        If Not My.Computer.FileSystem.FileExists(ictfile) Then

            button = MessageBox.Show("Thresholds file not found." & vbCrLf &
                                     "Would you like to Create it?",
                                     title, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                     MessageBoxDefaultButton.Button1)

            If button = DialogResult.Yes Then
                Me.Hide()
                Using f As New frmEntry()
                    f.ShowDialog()
                End Using
            Else
                Me.Close()
            End If
        Else
            If RefreshFile(ictfile, isInterstate:=False) Then
                PullICTData()
            End If
        End If

        ' --- Interstate File Check ---
        If Not My.Computer.FileSystem.FileExists(icjfile) Then

            button = MessageBox.Show("Interstate Thresholds file not found." & vbCrLf &
                                     "Would you like to create it?",
                                     title, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                     MessageBoxDefaultButton.Button1)

            If button = DialogResult.Yes Then
                Me.Hide()
                Using f As New frmEntry()
                    f.ShowDialog()
                End Using
            End If

            ' If No, simply continue — Interstate section stays empty
        Else
            If RefreshFile(icjfile, isInterstate:=True) Then
                PullICJData()
            End If
        End If
    End Sub

    '------------------------------ Private Subroutines  ---------------------------------------

    Private Function RefreshFile(filepath As String, isInterstate As Boolean) As Boolean

        Dim tempPath As String = Path.Combine(Path.GetDirectoryName(filepath),
                                              Path.GetFileNameWithoutExtension(filepath) & ".tmp" &
                                              Path.GetExtension(filepath))

        Dim idxThreshold As Integer = If(isInterstate, 5, 6)
        Dim idxProgRpt As Integer = If(isInterstate, 6, 7)
        Dim idxProgDays As Integer = If(isInterstate, 7, 8)
        Dim idxThreshDays As Integer = If(isInterstate, 8, 9)

        Try

            Dim readtxt As String = File.ReadAllText(filepath)
            Dim lines() As String = Split(readtxt, vbCrLf)

            ' Remove temp file if one already exists from a previous failed run
            If File.Exists(tempPath) Then
                File.Delete(tempPath)
            End If

            For Each line As String In lines

                If line.Contains("Pending") Then
                    ' This is a header line — write as-is
                    My.Computer.FileSystem.WriteAllText(tempPath, line & vbCrLf, True)

                ElseIf line.Contains("/"c) Then

                ' This is a data line — parse and refresh days remaining
                Dim words() As String = Split(line, vbTab)

                    ' Parse both threshold dates — abort with error if either is malformed
                    Dim dteICTThresh As Date
                    Dim dteProgRptThresh As Date

                    If Not Date.TryParse(words(idxThreshold).TrimEnd, dteICTThresh) Then

                        MessageBox.Show("Invalid ICT Threshold date found in record: " & words(0).Trim & vbCrLf &
                                        "Value: " & words(idxThreshold).TrimEnd & vbCrLf & vbCrLf &
                                        "File refresh has been aborted. Please correct the record and try again.",
                                        title, MessageBoxButtons.OK, MessageBoxIcon.Error)

                        ' Clean up temp file if partially written
                        If File.Exists(tempPath) Then File.Delete(tempPath)
                        Return False

                    End If

                    If Not Date.TryParse(words(idxProgRpt).TrimEnd, dteProgRptThresh) Then

                        MessageBox.Show("Invalid Progress Report date found in record: " & words(0).Trim & vbCrLf &
                                        "Value: " & words(idxProgRpt).TrimEnd & vbCrLf & vbCrLf &
                                        "File refresh has been aborted. Please correct the record and try again.",
                                        title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ' Clean up temp file if partially written
                        If File.Exists(tempPath) Then File.Delete(tempPath)
                        Return False

                    End If

                    ' Recalculate both days remaining values
                    Dim progRptDaysRefresh As Integer = dteProgRptThresh.Subtract(Date.Now).Days
                    Dim ictDaysRefresh As Integer = dteICTThresh.Subtract(Date.Now).Days

                    ' Inject refreshed values back into the word array
                    words(idxProgDays) = progRptDaysRefresh.ToString.PadLeft(3) & " days"
                    words(idxThreshDays) = ictDaysRefresh.ToString.PadLeft(3) & " days"

                    ' Rebuild the updated line and write to temp file
                    Dim updatedLine As String = String.Join(vbTab, words)
                    My.Computer.FileSystem.WriteAllText(tempPath, updatedLine & vbCrLf, True)

                ElseIf line.Length > 0 Then

                    ' This is a header or separator line — write as-is
                    My.Computer.FileSystem.WriteAllText(tempPath, line & vbCrLf, True)

                End If
            Next

            ' Replace original file with updated temp file
            File.Delete(filepath)
            File.Move(tempPath, filepath)

            Return True

        Catch ex As Exception

            MessageBox.Show("Error refreshing file: " & ex.Message,
                            title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' Clean up temp file if partially written
            If File.Exists(tempPath) Then File.Delete(tempPath)
            Return False

        End Try

    End Function

    Private Sub PullICTData()
        Try
            Dim myText As String = My.Computer.FileSystem.ReadAllText(ictfile)
            Dim mySentence() As String = Split(myText, vbCrLf)
            Dim listing As Integer = 1  ' Counter for each record
            Dim recieve As Integer = 0  ' Counter for receiving County
            Dim sent As Integer = 0     ' Counter for sending County
            Dim dteICTThresh As Date
            Dim dteProgRptThresh As Date
            Dim display As String

            For Each sentence As String In mySentence

                If sentence.Contains("Pending") Then
                    Dim words() = Split(sentence, vbTab)

                    display = String.Join(" ".PadRight(5), words)

                    'Compute numbers of sending/receiving counties for summary at bottom of form
                    If words(1).TrimEnd = "Orange" Then
                        recieve += 1
                    End If

                    If words(2).TrimEnd = "Orange" Then
                        sent += 1
                    End If

                    lblICTListing.Text &= listing.ToString & ".)  " & display & vbCrLf

                ElseIf sentence.Contains("/"c) Then

                    Dim words() = Split(sentence, vbTab)

                    'Extract two dates to compute refresh on data pull
                    dteICTThresh = CDate(words(6).TrimEnd)
                    dteProgRptThresh = CDate(words(7).TrimEnd)

                    'get updated days remaining in progress report and program
                    Dim progRptDaysRefresh As Integer = dteProgRptThresh.Subtract(Date.Now).Days
                    Dim ictDaysRefresh As Integer = dteICTThresh.Subtract(Date.Now).Days

                    'inject refreshed days remaining into the appropriate array index for display on form
                    words(8) = progRptDaysRefresh.ToString.PadLeft(3) & " days"
                    words(9) = ictDaysRefresh.ToString.PadLeft(3) & " days"

                    'Put the words back together with padding for display on form
                    display = String.Join(" ".PadRight(5), words)

                    'Compute numbers of sending/receiving counties for summary at bottom of form
                    If words(1).TrimEnd = "Orange" Then
                        recieve += 1
                    End If

                    If words(2).TrimEnd = "Orange" Then
                        sent += 1
                    End If

                    lblICTListing.Text &= listing.ToString & ".)  " & display & vbCrLf
                    listing += 1

                End If
            Next

            lblTotICTChildren.Text = (listing - 1).ToString
            lblTotICTReceived.Text = recieve.ToString
            lblTotICTSent.Text = sent.ToString

        Catch ex As Exception
            MessageBox.Show("An error occurred while pulling data: " &
                            ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PullICJData()
        Try

            Dim myText As String = My.Computer.FileSystem.ReadAllText(icjfile)
            Dim mySentence() As String = Split(myText, vbCrLf)
            Dim listing As Integer = 1
            Dim receive As Integer = 0
            Dim sent As Integer = 0
            Dim dteThreshold As Date
            Dim dteProgRpt As Date
            Dim display As String

            For Each sentence As String In mySentence

                If sentence.Contains("Pending") Then
                    Dim words() = Split(sentence, vbTab)

                    display = String.Join(" ".PadRight(5), words)

                    'Compute numbers of sending/receiving states for summary at bottom of form
                    If words(1).TrimEnd = "Texas" Then
                        receive += 1
                    End If

                    If words(2).TrimEnd = "Texas" Then
                        sent += 1
                    End If

                    lblICJListing.Text &= listing.ToString & ".)  " & display & vbCrLf

                ElseIf sentence.Contains("/"c) Then

                    Dim words() = Split(sentence, vbTab)

                    ' Interstate column indices are shifted left by one (no Type of Transfer)
                    dteThreshold = CDate(words(5).TrimEnd)
                    dteProgRpt = CDate(words(6).TrimEnd)

                    Dim progDaysRefresh As Integer = dteProgRpt.Subtract(Date.Now).Days
                    Dim threshDaysRefresh As Integer = dteThreshold.Subtract(Date.Now).Days

                    words(7) = progDaysRefresh.ToString.PadLeft(3) & " days"
                    words(8) = threshDaysRefresh.ToString.PadLeft(3) & " days"

                    display = String.Join(" ".PadRight(5), words)

                    If words(1).TrimEnd.Equals("Texas", StringComparison.OrdinalIgnoreCase) Then
                        receive += 1
                    End If

                    If words(2).TrimEnd.Equals("Texas", StringComparison.OrdinalIgnoreCase) Then
                        sent += 1
                    End If

                    lblICJListing.Text &= listing.ToString & ".)  " & display & vbCrLf
                    listing += 1

                End If
            Next

            lblTotICJChildren.Text = (listing - 1).ToString
            lblTotICJReceived.Text = receive.ToString
            lblTotICJSent.Text = sent.ToString

        Catch ex As Exception
            MessageBox.Show("Error reading Interstate data: " & ex.Message, title,
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '------------------------------ Button Events ----------------------------------------------

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Hide()

        Using f As New frmEntry
            f.ShowDialog()
        End Using

    End Sub

    Private Sub brnClose_Click(sender As Object, e As EventArgs) Handles brnClose.Click

        Me.Close()

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Hide()

        Using f As New frmSearch
            f.ShowDialog()
        End Using

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click

        ' Clear form before each pull to prevent duplication of listings.
        lblICTListing.Text = String.Empty
        lblICJListing.Text = String.Empty

        ' Refresh and reload ICT File Data
        If RefreshFile(ictfile, isInterstate:=False) Then
            PullICTData()
        End If

        ' Refresh and reload ICJ File Data
        If RefreshFile(icjfile, isInterstate:=True) Then
            PullICJData()
        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Hide()

        Using f As New frmDelete
            f.ShowDialog()
        End Using
    End Sub

End Class
