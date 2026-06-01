Public Class frmEntry

    Public childName As String
    Public sendingCounty As String
    Public receivingCounty As String
    Public typeOfTransfer As String
    Public officer As String
    Private dteStart As Date
    Private dteEnd As Date
    Private dteProgress As Date

    Private Sub frmEntry_Load(sender As Object, e As EventArgs) Handles Me.Load

        RefillCombo()
        FillData()
        rdbICT.Checked = True
        lblICTFormID.Visible = True

    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click

        ' Warn user if fields have data before closing
        If Not String.IsNullOrWhiteSpace(txbChildName.Text) Then
            Dim confirm As DialogResult = MessageBox.Show(
                "You have unsaved data. Are you sure you want to return?",
                "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.No Then Return
        End If

        ClearForm()
        cmbType.Items.Clear()
        cmbOfficer.Items.Clear()
        frmMain.lblICTListing.Text = String.Empty
        frmMain.Show()
        frmMain.lblICTListing.Text = "Please Press Refresh to Update Data."
        Me.Close()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        CreateEntry()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        ClearForm()
        txbChildName.Focus()

    End Sub

    Private Sub CreateEntry()

        If String.IsNullOrWhiteSpace(txbChildName.Text) Then
            MessageBox.Show("Please enter a child name.",
                    "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txbChildName.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txbReceiveCo.Text) OrElse
       String.IsNullOrWhiteSpace(txbSendCo.Text) Then
            MessageBox.Show("Please enter both sending and receiving counties.",
                        "Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cmbType.SelectedIndex = 0 Then
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

        ' Assign field values to variables
        childName = txbChildName.Text
        receivingCounty = txbReceiveCo.Text
        sendingCounty = txbSendCo.Text
        typeOfTransfer = cmbType.Text
        officer = cmbOfficer.Text

        Try

            If My.Computer.FileSystem.FileExists(frmMain.ictfile) Then

                WriteDataLine()

            Else

                'Creates the Directory/File and writes the header and first line of data
                My.Computer.FileSystem.CreateDirectory(frmMain.tdirectory)
                WriteHeader()
                WriteDataLine()

            End If

            ' Confirm successful save to user
            MessageBox.Show("Record for " & childName & " has been saved.",
                            "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ClearForm()

        Catch ex As Exception
            MessageBox.Show("Error Saving Record: " & ex.Message,
                            "Entry", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub WriteDataLine()

        My.Computer.FileSystem.WriteAllText(frmMain.ictfile,
                                               childName.PadRight(20) & vbTab &
                                               receivingCounty.PadRight(17) & vbTab &
                                               sendingCounty.PadRight(17) & vbTab &
                                               typeOfTransfer.PadRight(22) & vbTab &
                                               officer.PadRight(10) & vbTab &
                                               dteStart.ToString("MM/dd/yyyy") & vbTab &
                                               dteEnd.ToString("MM/dd/yyyy") & vbTab &
                                               dteProgress.ToString("MM/dd/yyyy") & vbTab &
                                               lblDaysRemainProg.Text.PadLeft(3) & " days" & Space(4) & vbTab &
                                               lblDaysRemainTrns.Text.PadLeft(3) & " days" & vbCrLf,
                                               True)

    End Sub

    Private Sub WriteHeader()

        My.Computer.FileSystem.WriteAllText(frmMain.ictfile,
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
        txbChildName.Focus()

    End Sub

    Private Sub FillData()

        dteStart = CDate(dtpStart.Value)
        dteProgress = CDate(dteStart.AddDays(90))
        dteEnd = CDate(dteStart.AddDays(180))

        dtpEnd.Value = dteEnd

        lblProgRptDate.Text = dteProgress.ToString("MM/dd/yyyy")
        lblTransThreshold.Text = dteEnd.ToString("MM/dd/yyyy")
        lblDaysRemainProg.Text = dteProgress.Subtract(Date.Now).Days.ToString
        lblDaysRemainTrns.Text = dteEnd.Subtract(Date.Now).Days.ToString

    End Sub

    Private Sub RefillCombo()

        'Add officers to combo box
        cmbOfficer.Items.Add("[Select Officer]")
        cmbOfficer.Items.Add("Garrison")
        cmbOfficer.Items.Add("Anderson")
        cmbOfficer.Items.Add("Klipstein")
        cmbOfficer.Items.Add("Childress")
        cmbOfficer.SelectedIndex = 0

        'Add transfer types to combo box
        cmbType.Items.Add("[Select Type]")
        cmbType.Items.Add("Int Probation")
        cmbType.Items.Add("Int Deferred")
        cmbType.Items.Add("Int Det Sent Prob")
        cmbType.Items.Add("Interim Inter Co Trans")
        cmbType.SelectedIndex = 0


    End Sub

    Private Sub dtpStart_TextChanged(sender As Object, e As EventArgs) Handles dtpStart.TextChanged

        FillData()

    End Sub

    Private Sub txbReceiveCo_TextChanged(sender As Object, e As EventArgs) Handles txbReceiveCo.TextChanged

        If rdbICT.Checked And txbReceiveCo.Text.Trim().Equals("Orange", StringComparison.OrdinalIgnoreCase) Then
            txbReceiveCo.BackColor = Color.Orange
            txbReceiveCo.ForeColor = Color.Black

        ElseIf rdbICJ.Checked And txbReceiveCo.Text.Trim().Equals("Texas", StringComparison.OrdinalIgnoreCase) Then
            txbReceiveCo.BackColor = Color.Maroon
            txbReceiveCo.ForeColor = Color.White

        Else
            txbReceiveCo.BackColor = Color.White
            txbReceiveCo.ForeColor = Color.Black

        End If

    End Sub

    Private Sub txbSendCo_TextChanged(sender As Object, e As EventArgs) Handles txbSendCo.TextChanged

        If rdbICT.Checked And txbSendCo.Text.Trim().Equals("Orange", StringComparison.OrdinalIgnoreCase) Then
            txbSendCo.BackColor = Color.Orange
            txbSendCo.ForeColor = Color.Black

        ElseIf rdbICJ.Checked And txbSendCo.Text.Trim().Equals("Texas", StringComparison.OrdinalIgnoreCase) Then
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

    End Sub

    Private Sub rdbICJ_Click(sender As Object, e As EventArgs) Handles rdbICJ.Click
        lblICJFormID.Visible = True
        lblICTFormID.Visible = False
        cmbTypeID.Visible = False
        cmbType.Visible = False

        lblReceiveID.Text = "Receiving State:"
        lblSendID.Text = "Sending State:"

    End Sub
End Class