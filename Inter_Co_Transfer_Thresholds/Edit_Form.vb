Public Class frmEdit

    ' --- Public staging properties set by frmMain before ShowDialog ---
    Public Property IncomingChildName As String = String.Empty
    Public Property IncomingReceiving As String = String.Empty
    Public Property IncomingSending As String = String.Empty
    Public Property IncomingType As String = String.Empty
    Public Property IncomingOfficer As String = String.Empty
    Public Property IncomingIsICT As Boolean = True
    Public Property IncomingIsPending As Boolean = True
    Public Property IncomingStartDate As DateTime = DateTime.Today
    Public Property IncomingEndDate As DateTime = DateTime.Today.AddDays(180)
    Public Property IncomingProgRptDays As String = String.Empty
    ' The exact file line of the record being edited — used to remove the original after saving
    Public Property IncomingOriginalLine As String = String.Empty
    Public Property IsEditMode As Boolean = False

    ' --- Internal fields ---
    Public childName As String
    Public sendingText As String
    Public receivingText As String
    Public typeOfTransfer As String
    Public officer As String
    Public isProgRptCompleted As Boolean
    Private dteStart As Date
    Private dteEnd As Date
    Private dteProgress As Date

    '------------------------------ Form Events --------------------------------------------------

    Private Sub frmEntry_Load(sender As Object, e As EventArgs) Handles Me.Load

        RefillCombo()
        rdbICT.Checked = True
        rdbPending.Checked = True
        lblICTFormID.Visible = True
        lblICJFormID.Visible = False
        ckbProgRpt.Checked = False
        FillData()

    End Sub

    ' Shown fires AFTER Load completes — safe to apply incoming data here
    Private Sub frmEdit_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        If Not IsEditMode Then Return

        ' Apply ICT vs ICJ
        If IncomingIsICT Then
            rdbICT.Checked = True
            rdbICT_Click(Nothing, Nothing)
        Else
            rdbICJ.Checked = True
            rdbICJ_Click(Nothing, Nothing)
        End If

        ' Apply basic fields
        txbChildName.Text = IncomingChildName
        txbReceiveCo.Text = IncomingReceiving
        txbSendCo.Text = IncomingSending

        ' Apply type and officer
        If IncomingIsICT Then
            Dim typeIdx As Integer = cmbType.FindStringExact(IncomingType)
            cmbType.SelectedIndex = If(typeIdx >= 0, typeIdx, 0)
        End If

        Dim officerIdx As Integer = cmbOfficer.FindStringExact(IncomingOfficer)
        cmbOfficer.SelectedIndex = If(officerIdx >= 0, officerIdx, 0)

        ' Apply pending vs supervision
        If IncomingIsPending Then
            rdbPending.Checked = True
            rdbPending_Click(Nothing, Nothing)
        Else
            rdbSupervision.Checked = True
            dtpStart.Enabled = True
            dtpEnd.Enabled = True
            dtpStart.Value = IncomingStartDate
            dtpEnd.Value = IncomingEndDate
            rdbSupervision_Click(Nothing, Nothing)
        End If

        ' Restore progress report completed checkbox state
        If IncomingProgRptDays.Trim().Equals("Completed", StringComparison.OrdinalIgnoreCase) Then
            ckbProgRpt.Checked = True
            ckbProgRpt_CheckedChanged(Nothing, Nothing)
        Else
            ckbProgRpt.Checked = False
        End If

    End Sub

    '------------------------------ Button Events ------------------------------------------------

    ' frmMain refreshes itself when this dialog closes, so Return only needs to close
    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click

        If Not String.IsNullOrWhiteSpace(txbChildName.Text) Then
            Dim confirm As DialogResult = MessageBox.Show(
                "You have unsaved data. Are you sure you want to return?",
                "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.No Then Return
        End If

        Me.Close()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        CreateEntry()
        ClearForm()
        Me.Close()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        ClearForm()
        txbChildName.Focus()

    End Sub

    '------------------------------ Private Subroutines ------------------------------------------

    Private Sub CreateEntry()

        If String.IsNullOrWhiteSpace(txbChildName.Text) Then
            MessageBox.Show("Please enter a child name.",
                            "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txbChildName.Focus()
            Return
        End If

        Dim locationLabel As String = If(rdbICT.Checked, "counties", "states")
        If String.IsNullOrWhiteSpace(txbReceiveCo.Text) OrElse
           String.IsNullOrWhiteSpace(txbSendCo.Text) Then
            MessageBox.Show("Please enter both sending and receiving " &
                            locationLabel & ".",
                            "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If rdbICT.Checked AndAlso cmbType.SelectedIndex = 0 Then
            MessageBox.Show("Please select a transfer type.",
                            "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbType.Focus()
            Return
        End If

        If cmbOfficer.SelectedIndex = 0 Then
            MessageBox.Show("Please select an officer.",
                            "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbOfficer.Focus()
            Return
        End If

        ' Assign field values
        childName = txbChildName.Text
        receivingText = txbReceiveCo.Text
        sendingText = txbSendCo.Text
        officer = cmbOfficer.Text
        typeOfTransfer = If(rdbICT.Checked, cmbType.Text, String.Empty)
        isProgRptCompleted = ckbProgRpt.Checked

        Dim targetFile As String = If(rdbICT.Checked, frmMain.ictfile, frmMain.icjfile)

        Try

            ' Write the updated record FIRST so a failure can never lose data
            If Not My.Computer.FileSystem.FileExists(targetFile) Then
                My.Computer.FileSystem.CreateDirectory(frmMain.tdirectory)
                WriteHeader(targetFile)
            End If

            WriteDataLine(targetFile)

            Dim savedMessage As String = "Record for " & childName & " has been saved."

            ' Edit mode — remove the original line (exact match). It may live in the other file
            ' if the user switched between ICT and Interstate while editing.
            If IsEditMode AndAlso Not String.IsNullOrWhiteSpace(IncomingOriginalLine) Then

                Dim originalFile As String = If(IncomingIsICT, frmMain.ictfile, frmMain.icjfile)
                Dim problem As String = String.Empty

                If Not frmMain.TryDeleteLine(originalFile, IncomingOriginalLine, problem) Then
                    savedMessage = "The updated record for " & childName & " was saved, but the original " &
                                   "entry could not be removed:" & vbCrLf & problem & vbCrLf & vbCrLf &
                                   "Please delete the old entry from the main screen."
                End If

                ' This edit is finished — a second save on this form must not try to remove it again
                IsEditMode = False
                IncomingOriginalLine = String.Empty

            End If

            MessageBox.Show(savedMessage, "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ClearForm()

        Catch ex As Exception
            MessageBox.Show("Error saving record: " & ex.Message,
                            "Entry", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub WriteDataLine(filepath As String)

        ' "Completed" carries no trailing padding; numeric values keep the original spacing
        Dim progRptValue As String
        Dim progRptSuffix As String

        If isProgRptCompleted Then
            progRptValue = "Completed"
            progRptSuffix = String.Empty
        Else
            progRptValue = lblDaysRemainProg.Text.Replace(" days", "").Trim().PadLeft(3) & " days"
            progRptSuffix = Space(4)
        End If

        Dim threshValue As String = lblDaysRemainTrns.Text.Replace(" days", "").Trim().PadLeft(3) & " days"

        If rdbPending.Checked Then

            If rdbICT.Checked Then
                My.Computer.FileSystem.WriteAllText(filepath,
                    childName.PadRight(20) & vbTab &
                    receivingText.PadRight(17) & vbTab &
                    sendingText.PadRight(17) & vbTab &
                    typeOfTransfer.PadRight(22) & vbTab &
                    officer.PadRight(10) & vbTab &
                    "Pending".PadRight(10) & vbTab &
                    "N/A".PadRight(10) & vbTab &
                    "N/A".PadRight(10) & vbTab &
                    "N/A".PadLeft(7) & " days" & Space(4) & vbTab &
                    "N/A".PadLeft(7) & " days" & vbCrLf, True)
            Else
                My.Computer.FileSystem.WriteAllText(filepath,
                    childName.PadRight(20) & vbTab &
                    receivingText.PadRight(17) & vbTab &
                    sendingText.PadRight(17) & vbTab &
                    officer.PadRight(10) & vbTab &
                    "Pending".PadRight(10) & vbTab &
                    "N/A".PadRight(10) & vbTab &
                    "N/A".PadRight(10) & vbTab &
                    "N/A".PadLeft(7) & " days" & Space(4) & vbTab &
                    "N/A".PadLeft(7) & " days" & vbCrLf, True)
            End If

        Else

            If rdbICT.Checked Then
                My.Computer.FileSystem.WriteAllText(filepath,
                    childName.PadRight(20) & vbTab &
                    receivingText.PadRight(17) & vbTab &
                    sendingText.PadRight(17) & vbTab &
                    typeOfTransfer.PadRight(22) & vbTab &
                    officer.PadRight(10) & vbTab &
                    dteStart.ToString("MM/dd/yyyy") & vbTab &
                    dteEnd.ToString("MM/dd/yyyy") & vbTab &
                    dteProgress.ToString("MM/dd/yyyy") & vbTab &
                    progRptValue & progRptSuffix & vbTab &
                    threshValue & vbCrLf, True)
            Else
                My.Computer.FileSystem.WriteAllText(filepath,
                    childName.PadRight(20) & vbTab &
                    receivingText.PadRight(17) & vbTab &
                    sendingText.PadRight(17) & vbTab &
                    officer.PadRight(10) & vbTab &
                    dteStart.ToString("MM/dd/yyyy") & vbTab &
                    dteEnd.ToString("MM/dd/yyyy") & vbTab &
                    dteProgress.ToString("MM/dd/yyyy") & vbTab &
                    progRptValue & progRptSuffix & vbTab &
                    threshValue & vbCrLf, True)
            End If

        End If

    End Sub

    Private Sub WriteHeader(filepath As String)

        If rdbICT.Checked Then
            My.Computer.FileSystem.WriteAllText(filepath,
                                                "Child Name:".PadRight(20) & vbTab &
                                                "Receiving County:" & vbTab &
                                                "Sending County:".PadRight(18) & vbTab &
                                                "Type of Transfer:".PadRight(20) & vbTab &
                                                "Officer:".PadRight(2) & vbTab &
                                                "Start Date:" & vbTab &
                                                "Threshold:" & vbTab &
                                                "Prog Rpt:" & vbTab &
                                                "Prog Rpt Days:" & vbTab &
                                                "Threshold Days:" & vbCrLf &
                                                "-----------".PadRight(20) & vbTab &
                                                "---------------".PadRight(18) & vbTab &
                                                "------------".PadRight(18) & vbTab &
                                                "--------------".PadRight(20) & vbTab &
                                                "----------" & vbTab &
                                                "----------" & vbTab &
                                                "----------" & vbTab &
                                                "----------" & vbTab &
                                                "----------".PadRight(14) & vbTab &
                                                "----------" & ControlChars.NewLine,
                                                True)
        Else
            My.Computer.FileSystem.WriteAllText(filepath,
                                                "Child Name:".PadRight(20) & vbTab &
                                                "Receiving State:" & vbTab &
                                                "Sending State:".PadRight(18) & vbTab &
                                                "Officer:".PadRight(2) & vbTab &
                                                "Start Date:" & vbTab &
                                                "Threshold:" & vbTab &
                                                "Prog Rpt:" & vbTab &
                                                "Prog Rpt Days:" & vbTab &
                                                "Threshold Days:" & vbCrLf &
                                                "-----------".PadRight(20) & vbTab &
                                                "---------------".PadRight(18) & vbTab &
                                                "------------".PadRight(18) & vbTab &
                                                "----------" & vbTab &
                                                "----------" & vbTab &
                                                "----------" & vbTab &
                                                "----------" & vbTab &
                                                "----------".PadRight(14) & vbTab &
                                                "----------" & ControlChars.NewLine,
                                                True)
        End If

    End Sub

    Private Sub ClearForm()

        txbChildName.Clear()
        txbReceiveCo.Clear()
        txbSendCo.Clear()
        lblProgRptDate.Text = ""
        lblTransThreshold.Text = ""
        lblDaysRemainProg.Text = ""
        lblDaysRemainTrns.Text = ""
        cmbOfficer.SelectedIndex = 0
        cmbType.SelectedIndex = 0
        dtpStart.Value = Date.Today
        dtpEnd.Value = Date.Today.AddDays(180)
        rdbICT.Checked = True
        rdbPending.Checked = True
        lblICTFormID.Visible = True
        lblICJFormID.Visible = False
        cmbTypeID.Visible = True
        cmbType.Visible = True
        lblReceiveID.Text = "Receiving County:"
        lblSendID.Text = "Sending County:"
        txbReceiveCo.BackColor = Color.White
        txbReceiveCo.ForeColor = Color.Black
        txbSendCo.BackColor = Color.White
        txbSendCo.ForeColor = Color.Black
        ckbProgRpt.Checked = False
        txbChildName.Focus()

    End Sub

    Private Sub FillData()

        If Not rdbPending.Checked Then
            dteStart = CDate(dtpStart.Value)
            dteProgress = CDate(dteStart.AddDays(90))
            dteEnd = CDate(dteStart.AddDays(180))
            dtpEnd.Value = dteEnd
            lblProgRptDate.Text = dteProgress.ToString("MM/dd/yyyy")
            lblTransThreshold.Text = dteEnd.ToString("MM/dd/yyyy")
            lblDaysRemainProg.Text = dteProgress.Subtract(Date.Now).Days.ToString
            lblDaysRemainTrns.Text = dteEnd.Subtract(Date.Now).Days.ToString
        Else
            dtpStart.Enabled = False
            dtpEnd.Enabled = False
            lblProgRptDate.Text = "Pending"
            lblTransThreshold.Text = "Pending"
            lblDaysRemainProg.Text = "N/A"
            lblDaysRemainTrns.Text = "N/A"
        End If

    End Sub

    Private Sub RefillCombo()

        cmbOfficer.Items.Add("[Select Officer]")
        cmbOfficer.Items.Add("Garrison")
        cmbOfficer.Items.Add("Anderson")
        cmbOfficer.Items.Add("Klipstein")
        cmbOfficer.Items.Add("Childress")
        cmbOfficer.SelectedIndex = 0

        cmbType.Items.Add("[Select Type]")
        cmbType.Items.Add("Int Probation")
        cmbType.Items.Add("Int Deferred")
        cmbType.Items.Add("Int Det Sent Prob")
        cmbType.Items.Add("Interim Inter Co Trans")
        cmbType.SelectedIndex = 0

    End Sub

    '------------------------------ Control Events -----------------------------------------------

    Private Sub ckbProgRpt_CheckedChanged(sender As Object, e As EventArgs) Handles ckbProgRpt.CheckedChanged

        If ckbProgRpt.Checked Then
            lblDaysRemainProg.Text = "Completed"
            lblProgRptDate.ForeColor = Color.Gray
            lblDaysRemainProg.ForeColor = Color.Gray
        Else
            lblProgRptDate.ForeColor = Color.Black
            lblDaysRemainProg.ForeColor = Color.Black
            If rdbSupervision.Checked Then
                FillData()
            ElseIf rdbPending.Checked Then
                lblDaysRemainProg.Text = "N/A"
            End If
        End If

    End Sub

    Private Sub dtpStart_TextChanged(sender As Object, e As EventArgs) Handles dtpStart.TextChanged

        FillData()

    End Sub

    Private Sub txbReceiveCo_TextChanged(sender As Object, e As EventArgs) Handles txbReceiveCo.TextChanged

        If rdbICT.Checked AndAlso txbReceiveCo.Text.Trim().Equals("Orange", StringComparison.OrdinalIgnoreCase) Then
            txbReceiveCo.BackColor = Color.Orange
            txbReceiveCo.ForeColor = Color.Black
        ElseIf rdbICJ.Checked AndAlso txbReceiveCo.Text.Trim().Equals("Texas", StringComparison.OrdinalIgnoreCase) Then
            txbReceiveCo.BackColor = Color.Maroon
            txbReceiveCo.ForeColor = Color.White
        Else
            txbReceiveCo.BackColor = Color.White
            txbReceiveCo.ForeColor = Color.Black
        End If

    End Sub

    Private Sub txbSendCo_TextChanged(sender As Object, e As EventArgs) Handles txbSendCo.TextChanged

        If rdbICT.Checked AndAlso txbSendCo.Text.Trim().Equals("Orange", StringComparison.OrdinalIgnoreCase) Then
            txbSendCo.BackColor = Color.Orange
            txbSendCo.ForeColor = Color.Black
        ElseIf rdbICJ.Checked AndAlso txbSendCo.Text.Trim().Equals("Texas", StringComparison.OrdinalIgnoreCase) Then
            txbSendCo.BackColor = Color.Maroon
            txbSendCo.ForeColor = Color.White
        Else
            txbSendCo.BackColor = Color.White
            txbSendCo.ForeColor = Color.Black
        End If

    End Sub

    Private Sub rdbICT_Click(sender As Object, e As EventArgs) Handles rdbICT.Click

        lblICTFormID.Visible = True
        lblICJFormID.Visible = False
        cmbTypeID.Visible = True
        cmbType.Visible = True
        lblReceiveID.Text = "Receiving County:"
        lblSendID.Text = "Sending County:"
        txbReceiveCo.BackColor = Color.White
        txbReceiveCo.ForeColor = Color.Black
        txbSendCo.BackColor = Color.White
        txbSendCo.ForeColor = Color.Black

    End Sub

    Private Sub rdbICJ_Click(sender As Object, e As EventArgs) Handles rdbICJ.Click

        lblICJFormID.Visible = True
        lblICTFormID.Visible = False
        cmbTypeID.Visible = False
        cmbType.Visible = False
        lblReceiveID.Text = "Receiving State:"
        lblSendID.Text = "Sending State:"
        txbReceiveCo.BackColor = Color.White
        txbReceiveCo.ForeColor = Color.Black
        txbSendCo.BackColor = Color.White
        txbSendCo.ForeColor = Color.Black

    End Sub

    Private Sub rdbPending_Click(sender As Object, e As EventArgs) Handles rdbPending.Click

        dtpStart.Enabled = False
        dtpEnd.Enabled = False
        lblProgRptDate.Text = "Pending"
        lblTransThreshold.Text = "Pending"
        lblDaysRemainProg.Text = "N/A"
        lblDaysRemainTrns.Text = "N/A"

    End Sub

    Private Sub rdbSupervision_Click(sender As Object, e As EventArgs) Handles rdbSupervision.Click

        dtpStart.Enabled = True
        dtpEnd.Enabled = True
        dteStart = CDate(dtpStart.Value)
        dteProgress = CDate(dteStart.AddDays(90))
        dteEnd = CDate(dteStart.AddDays(180))
        dtpEnd.Value = dteEnd
        lblProgRptDate.Text = dteProgress.ToString("MM/dd/yyyy")
        lblTransThreshold.Text = dteEnd.ToString("MM/dd/yyyy")
        lblDaysRemainProg.Text = dteProgress.Subtract(Date.Now).Days.ToString
        lblDaysRemainTrns.Text = dteEnd.Subtract(Date.Now).Days.ToString

    End Sub

End Class
