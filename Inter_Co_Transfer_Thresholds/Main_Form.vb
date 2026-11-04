'Title:         Inter County Transfer Thresholds
'Purpose:       To manage progress reports and thresholds for inter-county transfers
'Created:       October 31, 2025
'By:            Shon Garrison
'Last Updated:  October 2026
'Version: 3.1.2

Option Explicit On
Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO

Public Class frmMain

    Private Const appTitle As String = "Inter County Transfer Thresholds"

    ' Names counted in the Received/Sent summary labels
    Private Const homeCounty As String = "Orange"   ' ICT records
    Private Const homeState As String = "Texas"     ' Interstate records

    Public Shared ReadOnly tdirectory As String = Path.Combine("C:\", "Transfers")
    Public Shared ReadOnly ictfile As String = Path.Combine(tdirectory, "ICT_Thresholds.txt")
    Public Shared ReadOnly icjfile As String = Path.Combine(tdirectory, "Interstate_Thresholds.txt")

    ' Column layouts (tab-delimited file)
    ' ICT:         0=Name 1=Recv 2=Send 3=Type 4=Officer 5=Start 6=Threshold 7=ProgRpt 8=ProgDays 9=ThreshDays
    ' Interstate:  0=Name 1=Recv 2=Send 3=Officer 4=Start 5=Threshold 6=ProgRpt 7=ProgDays 8=ThreshDays
    Private Const ictFieldCount As Integer = 10
    Private Const icjFieldCount As Integer = 9

#Region "Form Events"

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        lblToday.Text = Date.Today.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
        lblNinety.Text = Date.Today.AddDays(90).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)
        lblOneEighty.Text = Date.Today.AddDays(180).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)

        SetupListView(lvICT, True)
        SetupListView(lvInterstate, False)

        ' --- ICT file check ---
        If Not File.Exists(ictfile) Then

            Dim button As DialogResult = MessageBox.Show("ICT Thresholds file not found." & vbCrLf &
                                                         "Would you like to create it?",
                                                         appTitle, MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                OpenEntryForm()
            Else
                Me.Close()
                Return
            End If

        End If

        ' --- Interstate file check ---
        If Not File.Exists(icjfile) Then

            Dim button As DialogResult = MessageBox.Show("Interstate Thresholds file not found." & vbCrLf &
                                                         "Would you like to create it?",
                                                         appTitle, MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                OpenEntryForm()
            End If

        End If

        RefreshAll()

    End Sub

#End Region

    '------------------------------ List Setup / Loading -----------------------------------------

    Private Sub SetupListView(lv As ListView, isICT As Boolean)

        lv.View = View.Details
        lv.FullRowSelect = True
        lv.MultiSelect = False
        lv.HideSelection = False   ' Keep the selected row highlighted when a button has focus
        lv.GridLines = True

        lv.Columns.Clear()
        lv.Columns.Add("#", 35)
        lv.Columns.Add("Child Name", 140)
        lv.Columns.Add(If(isICT, "Receiving County", "Receiving State"), 120)
        lv.Columns.Add(If(isICT, "Sending County", "Sending State"), 120)
        If isICT Then lv.Columns.Add("Type of Transfer", 150)
        lv.Columns.Add("Officer", 80)
        lv.Columns.Add("Start Date", 80)
        lv.Columns.Add("Threshold", 80)
        lv.Columns.Add("Prog Rpt", 80)
        lv.Columns.Add("Prog Rpt Days", 95)
        lv.Columns.Add("Threshold Days", 100)

    End Sub

    ' Refreshes the days remaining in both files, then reloads both lists
    Private Sub RefreshAll()

        lvICT.Items.Clear()
        lvInterstate.Items.Clear()

        lblTotICTChildren.Text = "0"
        lblTotICTReceived.Text = "0"
        lblTotICTSent.Text = "0"
        lblTotICJChildren.Text = "0"
        lblTotICJReceived.Text = "0"
        lblTotICJSent.Text = "0"

        If File.Exists(ictfile) Then
            If RefreshFile(ictfile, True) Then LoadList(lvICT, ictfile, True)
        End If

        If File.Exists(icjfile) Then
            If RefreshFile(icjfile, False) Then LoadList(lvInterstate, icjfile, False)
        End If

    End Sub

    ' A data line is anything that is not blank, a header ("Child Name:") or a separator ("-----")
    Private Function IsDataLine(line As String) As Boolean

        If String.IsNullOrWhiteSpace(line) Then Return False

        Dim words() As String = line.Split(ControlChars.Tab)
        If words.Length < 3 Then Return False
        If words(0).Contains(":"c) OrElse words(0).Trim().StartsWith("-"c) Then Return False

        Return True

    End Function

    ' Safe array accessor — prevents out-of-bounds on short or Pending records
    Private Function SafeWord(words() As String, index As Integer) As String

        If index >= 0 AndAlso index < words.Length Then
            Return words(index).TrimEnd()
        End If
        Return String.Empty

    End Function

    Private Sub LoadList(lv As ListView, filepath As String, isICT As Boolean)

        Try

            Dim fieldCount As Integer = If(isICT, ictFieldCount, icjFieldCount)
            Dim homeName As String = If(isICT, homeCounty, homeState)
            Dim rowNumber As Integer = 0
            Dim receiveCount As Integer = 0
            Dim sentCount As Integer = 0

            lv.BeginUpdate()

            For Each line As String In File.ReadAllLines(filepath)

                If Not IsDataLine(line) Then Continue For

                Dim words() As String = line.Split(ControlChars.Tab)
                rowNumber += 1

                Dim item As New ListViewItem(rowNumber.ToString())

                For i As Integer = 0 To fieldCount - 1
                    item.SubItems.Add(SafeWord(words, i))
                Next

                ' The raw file line identifies this exact record for update and delete
                item.Tag = line

                lv.Items.Add(item)

                If SafeWord(words, 1).Trim().Equals(homeName, StringComparison.OrdinalIgnoreCase) Then receiveCount += 1
                If SafeWord(words, 2).Trim().Equals(homeName, StringComparison.OrdinalIgnoreCase) Then sentCount += 1

            Next

            lv.EndUpdate()

            If isICT Then
                lblTotICTChildren.Text = rowNumber.ToString()
                lblTotICTReceived.Text = receiveCount.ToString()
                lblTotICTSent.Text = sentCount.ToString()
            Else
                lblTotICJChildren.Text = rowNumber.ToString()
                lblTotICJReceived.Text = receiveCount.ToString()
                lblTotICJSent.Text = sentCount.ToString()
            End If

        Catch ex As Exception
            lv.EndUpdate()
            MessageBox.Show("Error reading " & If(isICT, "ICT", "Interstate") & " data: " & ex.Message,
                            appTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ' Recalculates days remaining and rewrites the file through a temp file. Returns True on success.
    ' Pending records (no start date yet) are left untouched.
    ' A prog rpt value of "Completed" is preserved.
    Private Function RefreshFile(filepath As String, isICT As Boolean) As Boolean

        Dim idxStart As Integer = If(isICT, 5, 4)
        Dim idxThreshold As Integer = If(isICT, 6, 5)
        Dim idxProgRpt As Integer = If(isICT, 7, 6)
        Dim idxProgDays As Integer = If(isICT, 8, 7)
        Dim idxThreshDays As Integer = If(isICT, 9, 8)

        Dim tempPath As String = Path.Combine(Path.GetDirectoryName(filepath),
                                              Path.GetFileNameWithoutExtension(filepath) & ".tmp" &
                                              Path.GetExtension(filepath))

        Try

            Dim output As New List(Of String)

            For Each line As String In File.ReadAllLines(filepath)

                ' Header, separator and blank lines
                If Not IsDataLine(line) Then
                    If line.Length > 0 Then output.Add(line)
                    Continue For
                End If

                Dim words() As String = line.Split(ControlChars.Tab)

                ' Short records and Pending records (no real start date) need no recalculation
                Dim dteStart As Date
                If words.Length <= idxThreshDays OrElse
                   Not Date.TryParse(words(idxStart).Trim(), dteStart) Then
                    output.Add(line)
                    Continue For
                End If

                Dim preserveProgDays As Boolean = words(idxProgDays).Trim().Equals(
                    "Completed", StringComparison.OrdinalIgnoreCase)

                ' Threshold date is always required
                Dim dteThreshold As Date
                If Not Date.TryParse(words(idxThreshold).Trim(), dteThreshold) Then
                    MessageBox.Show("Invalid Threshold date found in record: " & words(0).Trim() & vbCrLf &
                                    "Value: " & words(idxThreshold).Trim() & vbCrLf & vbCrLf &
                                    "File refresh has been aborted. Please correct the record and try again.",
                                    appTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                words(idxThreshDays) = dteThreshold.Subtract(Date.Now).Days.ToString().PadLeft(3) & " days"

                ' Prog rpt date is only needed when not Completed
                If preserveProgDays Then
                    words(idxProgDays) = "Completed"
                Else
                    Dim dteProgRpt As Date
                    If Not Date.TryParse(words(idxProgRpt).Trim(), dteProgRpt) Then
                        MessageBox.Show("Invalid Progress Report date found in record: " & words(0).Trim() & vbCrLf &
                                        "Value: " & words(idxProgRpt).Trim() & vbCrLf & vbCrLf &
                                        "File refresh has been aborted. Please correct the record and try again.",
                                        appTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                    words(idxProgDays) = dteProgRpt.Subtract(Date.Now).Days.ToString().PadLeft(3) & " days"
                End If

                output.Add(String.Join(vbTab, words))

            Next

            File.WriteAllLines(tempPath, output)
            File.Delete(filepath)
            File.Move(tempPath, filepath)
            Return True

        Catch ex As Exception

            MessageBox.Show("Error refreshing file: " & ex.Message,
                            appTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            If File.Exists(tempPath) Then File.Delete(tempPath)
            Return False

        End Try

    End Function

    '------------------------------ Selection Helpers --------------------------------------------

    ' Returns the raw file line of the selected row and which list it came from
    Private Function TryGetSelection(ByRef line As String, ByRef isICT As Boolean) As Boolean

        If lvICT.SelectedItems.Count > 0 Then
            line = CStr(lvICT.SelectedItems(0).Tag)
            isICT = True
            Return True
        End If

        If lvInterstate.SelectedItems.Count > 0 Then
            line = CStr(lvInterstate.SelectedItems(0).Tag)
            isICT = False
            Return True
        End If

        Return False

    End Function

    ' Only one record can be active — selecting in one list clears the other
    Private Sub lvICT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvICT.SelectedIndexChanged
        If lvICT.SelectedItems.Count > 0 Then lvInterstate.SelectedItems.Clear()
    End Sub

    Private Sub lvInterstate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvInterstate.SelectedIndexChanged
        If lvInterstate.SelectedItems.Count > 0 Then lvICT.SelectedItems.Clear()
    End Sub

    Private Sub lvICT_DoubleClick(sender As Object, e As EventArgs) Handles lvICT.DoubleClick
        EditSelected()
    End Sub

    Private Sub lvInterstate_DoubleClick(sender As Object, e As EventArgs) Handles lvInterstate.DoubleClick
        EditSelected()
    End Sub

    '------------------------------ Edit / Delete ------------------------------------------------

    Private Sub OpenEntryForm()

        Me.Hide()
        Using f As New frmEntry()
            f.ShowDialog()
        End Using
        Me.Show()

    End Sub

    Private Sub EditSelected()

        Dim line As String = Nothing
        Dim isICT As Boolean = True

        If Not TryGetSelection(line, isICT) Then
            MessageBox.Show("Please select a record first.",
                            appTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Me.Hide()
        Using f As New frmEdit()
            PopulateEditForm(f, line.Split(ControlChars.Tab), isICT, line)
            f.ShowDialog()
        End Using
        Me.Show()

        RefreshAll()

    End Sub

    ' Sets frmEdit's public staging properties before ShowDialog.
    ' frmEdit.Shown applies them after its own Load event has finished.
    Private Sub PopulateEditForm(f As frmEdit, words() As String, isICT As Boolean, originalLine As String)

        f.IsEditMode = True
        f.IncomingIsICT = isICT
        f.IncomingOriginalLine = originalLine

        f.IncomingChildName = SafeWord(words, 0)
        f.IncomingReceiving = SafeWord(words, 1)
        f.IncomingSending = SafeWord(words, 2)

        If isICT Then
            f.IncomingType = SafeWord(words, 3)
            f.IncomingOfficer = SafeWord(words, 4)
            f.IncomingProgRptDays = SafeWord(words, 8)
            DetermineAndSetDates(f, words, 5, 6)
        Else
            f.IncomingType = String.Empty
            f.IncomingOfficer = SafeWord(words, 3)
            f.IncomingProgRptDays = SafeWord(words, 7)
            DetermineAndSetDates(f, words, 4, 5)
        End If

    End Sub

    ' Determines Pending vs Supervision and sets the incoming date properties
    Private Sub DetermineAndSetDates(f As frmEdit, words() As String, startIdx As Integer, endIdx As Integer)

        Dim parsedStart As DateTime

        If DateTime.TryParse(SafeWord(words, startIdx), parsedStart) Then

            f.IncomingIsPending = False
            f.IncomingStartDate = parsedStart

            Dim parsedEnd As DateTime
            f.IncomingEndDate = If(DateTime.TryParse(SafeWord(words, endIdx), parsedEnd),
                                   parsedEnd,
                                   DateTime.Today.AddDays(180))
        Else

            f.IncomingIsPending = True
            f.IncomingStartDate = DateTime.Today
            f.IncomingEndDate = DateTime.Today.AddDays(180)

        End If

    End Sub

    ' Removes the one line that exactly matches exactLine. No UI — callers report problems.
    ' The file is only replaced when the line was found.
    Public Shared Function TryDeleteLine(filepath As String, exactLine As String, ByRef problem As String) As Boolean

        Dim tempPath As String = Path.Combine(Path.GetDirectoryName(filepath),
                                              Path.GetFileNameWithoutExtension(filepath) & ".tmp" &
                                              Path.GetExtension(filepath))

        Try

            If Not File.Exists(filepath) Then
                problem = "The file does not exist."
                Return False
            End If

            Dim lines As New List(Of String)(File.ReadAllLines(filepath))
            Dim target As String = exactLine.Trim()
            Dim index As Integer = lines.FindIndex(Function(l) l.Trim() = target)

            If index < 0 Then
                problem = "The record could not be found in the file. It may have been changed since the list was loaded."
                Return False
            End If

            lines.RemoveAt(index)

            File.WriteAllLines(tempPath, lines)
            File.Delete(filepath)
            File.Move(tempPath, filepath)

            problem = String.Empty
            Return True

        Catch ex As Exception
            If File.Exists(tempPath) Then File.Delete(tempPath)
            problem = ex.Message
            Return False
        End Try

    End Function

    '------------------------------ Button Events ------------------------------------------------

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        OpenEntryForm()
        RefreshAll()

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        EditSelected()

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim line As String = Nothing
        Dim isICT As Boolean = True

        If Not TryGetSelection(line, isICT) Then
            MessageBox.Show("Please select a record first.",
                            appTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim childName As String = SafeWord(line.Split(ControlChars.Tab), 0).Trim()

        Dim confirm As DialogResult = MessageBox.Show(
            "Are you sure you want to delete the record for: " & childName & "?",
            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2)

        If confirm <> DialogResult.Yes Then Return

        Dim problem As String = String.Empty
        Dim targetFile As String = If(isICT, ictfile, icjfile)

        If TryDeleteLine(targetFile, line, problem) Then
            MessageBox.Show("Record for " & childName & " has been deleted.",
                            appTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Record was not deleted:" & vbCrLf & problem,
                            appTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        RefreshAll()

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click

        RefreshAll()

    End Sub

    Private Sub brnClose_Click(sender As Object, e As EventArgs) Handles brnClose.Click

        Me.Close()

    End Sub

End Class
