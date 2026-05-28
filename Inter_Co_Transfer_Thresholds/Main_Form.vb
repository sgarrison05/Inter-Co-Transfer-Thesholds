'Title:         Inter County Transfer Thresholds
'Purpose:       To manage progress reports and thresholds for inter-county transfers
'Created:       October 31, 2025
'By:            Shon Garrison
'Last Updated:  April 2026
'Version: 1.0.1.0

Option Explicit On
Imports System.Globalization

Imports System.IO
Imports System.Text
Imports System.Windows

Public Class frmMain

    Private title As String = "Inter County Transfer Thresholds"
    Public Shared ReadOnly tdirectory As String = Path.Combine("D:\Temp", "Transfers")
    Public Shared ReadOnly tfile As String = Path.Combine(tdirectory, "ICT_Thresholds.txt")

    '------------------------------ Form Events --------------------------------------------------

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim dteToday As Date = Date.Today
        Dim dteNinety As Date = dteToday.AddDays(90)
        Dim dteOneEighty As Date = dteToday.AddDays(180)

        dtpNinety.Text = dteNinety.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
        dtpOneEighty.Text = dteOneEighty.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)

        Dim button As DialogResult

        If Not My.Computer.FileSystem.FileExists(tfile) Then

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
            If RefreshFile() Then
                PullData()

            End If
        End If
    End Sub

    '------------------------------ Private Subroutines  ---------------------------------------

    Private Function RefreshFile() As Boolean

        Dim tempPath As String = Path.Combine(Path.GetDirectoryName(tfile),
                                              Path.GetFileNameWithoutExtension(tfile) & ".tmp" &
                                              Path.GetExtension(tfile))

        Try

            Dim readtxt As String = File.ReadAllText(tfile)
            Dim lines() As String = Split(readtxt, vbCrLf)

            ' Remove temp file if one already exists from a previous failed run
            If File.Exists(tempPath) Then
                File.Delete(tempPath)
            End If

            For Each line As String In lines

                If line.Contains("/"c) Then

                    ' This is a data line — parse and refresh days remaining
                    Dim words() As String = Split(line, vbTab)

                    ' Parse both threshold dates — abort with error if either is malformed
                    Dim dteICTThresh As Date
                    Dim dteProgRptThresh As Date

                    If Not Date.TryParse(words(6).TrimEnd, dteICTThresh) Then

                        MessageBox.Show("Invalid ICT Threshold date found in record: " & words(0).Trim & vbCrLf &
                                        "Value: " & words(6).TrimEnd & vbCrLf & vbCrLf &
                                        "File refresh has been aborted. Please correct the record and try again.",
                                        title, MessageBoxButtons.OK, MessageBoxIcon.Error)

                        ' Clean up temp file if partially written
                        If File.Exists(tempPath) Then File.Delete(tempPath)
                        Return False

                    End If

                    If Not Date.TryParse(words(7).TrimEnd, dteProgRptThresh) Then

                        MessageBox.Show("Invalid Progress Report date found in record: " & words(0).Trim & vbCrLf &
                                        "Value: " & words(7).TrimEnd & vbCrLf & vbCrLf &
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
                    words(8) = progRptDaysRefresh.ToString.PadLeft(3) & " days"
                    words(9) = ictDaysRefresh.ToString.PadLeft(3) & " days"

                    ' Rebuild the updated line and write to temp file
                    Dim updatedLine As String = String.Join(vbTab, words)
                    My.Computer.FileSystem.WriteAllText(tempPath, updatedLine & vbCrLf, True)

                ElseIf line.Length > 0 Then

                    ' This is a header or separator line — write as-is
                    My.Computer.FileSystem.WriteAllText(tempPath, line & vbCrLf, True)

                End If

            Next

            ' Replace original file with updated temp file
            File.Delete(tfile)
            File.Move(tempPath, tfile)

            Return True

        Catch ex As Exception

            MessageBox.Show("Error refreshing file: " & ex.Message,
                            title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' Clean up temp file if partially written
            If File.Exists(tempPath) Then File.Delete(tempPath)
            Return False

        End Try

    End Function

    Private Sub PullData()
        Try
            Dim myText As String = My.Computer.FileSystem.ReadAllText(tfile)
            Dim mySentence() As String = Split(myText, vbCrLf)
            Dim listing As Integer = 1  ' Counter for each record
            Dim recieve As Integer = 0  ' Counter for receiving County
            Dim sent As Integer = 0     ' Counter for sending County
            Dim dteICTThresh As Date
            Dim dteProgRptThresh As Date
            Dim display As String

            For Each sentence As String In mySentence
                If sentence.Contains("/"c) Then

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

        If RefreshFile() Then
            PullData()
        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Hide()

        Using f As New frmDelete
            f.ShowDialog()
        End Using
    End Sub

    Private Sub btnICJAdd_Click(sender As Object, e As EventArgs) Handles btnICJAdd.Click

        Hide()
        Using f As New frmICJEntry
            f.ShowDialog()
        End Using

    End Sub
End Class
