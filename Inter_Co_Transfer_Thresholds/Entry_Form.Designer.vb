<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntry
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label9 = New Label()
        Label8 = New Label()
        lblSendID = New Label()
        cmbTypeID = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        lblChildNameID = New Label()
        txbChildName = New TextBox()
        txbSendCo = New TextBox()
        dtpStart = New DateTimePicker()
        dtpEnd = New DateTimePicker()
        cmbType = New ComboBox()
        cmbOfficer = New ComboBox()
        lblProgRptDate = New Label()
        lblDaysRemainProg = New Label()
        lblTransThreshold = New Label()
        lblDaysRemainTrns = New Label()
        Label14 = New Label()
        Label15 = New Label()
        btnSave = New Button()
        btnReturn = New Button()
        Label16 = New Label()
        txbReceiveCo = New TextBox()
        lblReceiveID = New Label()
        btnClear = New Button()
        lblICTFormID = New Label()
        gpbType = New GroupBox()
        rdbICJ = New RadioButton()
        rdbICT = New RadioButton()
        lblICJFormID = New Label()
        gpbType.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(503, 305)
        Label9.Name = "Label9"
        Label9.Size = New Size(97, 15)
        Label9.TabIndex = 26
        Label9.Text = "Days Till Transfer:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(170, 305)
        Label8.Name = "Label8"
        Label8.Size = New Size(119, 15)
        Label8.TabIndex = 25
        Label8.Text = "Days Till Prog Report:" & vbCrLf
        ' 
        ' lblSendID
        ' 
        lblSendID.AutoSize = True
        lblSendID.Location = New Point(205, 123)
        lblSendID.Name = "lblSendID"
        lblSendID.Size = New Size(95, 15)
        lblSendID.TabIndex = 24
        lblSendID.Text = "Sending County:"
        ' 
        ' cmbTypeID
        ' 
        cmbTypeID.AutoSize = True
        cmbTypeID.Location = New Point(395, 123)
        cmbTypeID.Name = "cmbTypeID"
        cmbTypeID.Size = New Size(34, 15)
        cmbTypeID.TabIndex = 23
        cmbTypeID.Text = "Type:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(395, 54)
        Label5.Name = "Label5"
        Label5.Size = New Size(46, 15)
        Label5.TabIndex = 22
        Label5.Text = "Officer:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(203, 210)
        Label4.Name = "Label4"
        Label4.Size = New Size(57, 15)
        Label4.TabIndex = 21
        Label4.Text = "End Date:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(359, 305)
        Label3.Name = "Label3"
        Label3.Size = New Size(106, 15)
        Label3.TabIndex = 20
        Label3.Text = "Transfer Threshold:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(15, 305)
        Label2.Name = "Label2"
        Label2.Size = New Size(120, 15)
        Label2.TabIndex = 19
        Label2.Text = "Progress Report Date:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(16, 210)
        Label1.Name = "Label1"
        Label1.Size = New Size(61, 15)
        Label1.TabIndex = 18
        Label1.Text = "Start Date:"
        ' 
        ' lblChildNameID
        ' 
        lblChildNameID.AutoSize = True
        lblChildNameID.Location = New Point(16, 54)
        lblChildNameID.Name = "lblChildNameID"
        lblChildNameID.Size = New Size(133, 15)
        lblChildNameID.TabIndex = 17
        lblChildNameID.Text = "Child Name: (Last, First)"
        ' 
        ' txbChildName
        ' 
        txbChildName.Font = New Font("Segoe UI", 12F)
        txbChildName.Location = New Point(16, 72)
        txbChildName.Name = "txbChildName"
        txbChildName.Size = New Size(335, 29)
        txbChildName.TabIndex = 0
        ' 
        ' txbSendCo
        ' 
        txbSendCo.Font = New Font("Segoe UI", 12F)
        txbSendCo.Location = New Point(205, 150)
        txbSendCo.Name = "txbSendCo"
        txbSendCo.Size = New Size(178, 29)
        txbSendCo.TabIndex = 2
        ' 
        ' dtpStart
        ' 
        dtpStart.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        dtpStart.Format = DateTimePickerFormat.Short
        dtpStart.Location = New Point(16, 228)
        dtpStart.Name = "dtpStart"
        dtpStart.Size = New Size(137, 29)
        dtpStart.TabIndex = 5
        ' 
        ' dtpEnd
        ' 
        dtpEnd.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        dtpEnd.Format = DateTimePickerFormat.Short
        dtpEnd.Location = New Point(203, 228)
        dtpEnd.Name = "dtpEnd"
        dtpEnd.Size = New Size(137, 29)
        dtpEnd.TabIndex = 6
        ' 
        ' cmbType
        ' 
        cmbType.Font = New Font("Segoe UI", 12F)
        cmbType.FormattingEnabled = True
        cmbType.Location = New Point(395, 150)
        cmbType.Name = "cmbType"
        cmbType.Size = New Size(187, 29)
        cmbType.TabIndex = 3
        ' 
        ' cmbOfficer
        ' 
        cmbOfficer.Font = New Font("Segoe UI", 12F)
        cmbOfficer.FormattingEnabled = True
        cmbOfficer.Location = New Point(395, 72)
        cmbOfficer.Name = "cmbOfficer"
        cmbOfficer.Size = New Size(126, 29)
        cmbOfficer.TabIndex = 4
        ' 
        ' lblProgRptDate
        ' 
        lblProgRptDate.BorderStyle = BorderStyle.FixedSingle
        lblProgRptDate.Location = New Point(18, 329)
        lblProgRptDate.Name = "lblProgRptDate"
        lblProgRptDate.Size = New Size(103, 23)
        lblProgRptDate.TabIndex = 34
        lblProgRptDate.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblDaysRemainProg
        ' 
        lblDaysRemainProg.BorderStyle = BorderStyle.FixedSingle
        lblDaysRemainProg.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblDaysRemainProg.Location = New Point(173, 329)
        lblDaysRemainProg.Name = "lblDaysRemainProg"
        lblDaysRemainProg.Size = New Size(57, 23)
        lblDaysRemainProg.TabIndex = 35
        lblDaysRemainProg.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTransThreshold
        ' 
        lblTransThreshold.BorderStyle = BorderStyle.FixedSingle
        lblTransThreshold.Location = New Point(362, 329)
        lblTransThreshold.Name = "lblTransThreshold"
        lblTransThreshold.Size = New Size(103, 23)
        lblTransThreshold.TabIndex = 36
        lblTransThreshold.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblDaysRemainTrns
        ' 
        lblDaysRemainTrns.BorderStyle = BorderStyle.FixedSingle
        lblDaysRemainTrns.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblDaysRemainTrns.Location = New Point(506, 329)
        lblDaysRemainTrns.Name = "lblDaysRemainTrns"
        lblDaysRemainTrns.Size = New Size(57, 23)
        lblDaysRemainTrns.TabIndex = 37
        lblDaysRemainTrns.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label14
        ' 
        Label14.Location = New Point(231, 330)
        Label14.Name = "Label14"
        Label14.Size = New Size(47, 22)
        Label14.TabIndex = 38
        Label14.Text = "Days"
        Label14.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' Label15
        ' 
        Label15.Location = New Point(569, 323)
        Label15.Name = "Label15"
        Label15.Size = New Size(47, 22)
        Label15.TabIndex = 39
        Label15.Text = "Days"
        Label15.TextAlign = ContentAlignment.BottomLeft
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        btnSave.Location = New Point(685, 217)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(75, 40)
        btnSave.TabIndex = 7
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnReturn
        ' 
        btnReturn.BackColor = Color.Gold
        btnReturn.Location = New Point(685, 313)
        btnReturn.Name = "btnReturn"
        btnReturn.Size = New Size(75, 40)
        btnReturn.TabIndex = 9
        btnReturn.Text = "Rtn Main"
        btnReturn.UseVisualStyleBackColor = False
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label16.Location = New Point(164, 235)
        Label16.Name = "Label16"
        Label16.Size = New Size(30, 15)
        Label16.TabIndex = 42
        Label16.Text = "--->"
        ' 
        ' txbReceiveCo
        ' 
        txbReceiveCo.Font = New Font("Segoe UI", 12F)
        txbReceiveCo.Location = New Point(16, 149)
        txbReceiveCo.Name = "txbReceiveCo"
        txbReceiveCo.Size = New Size(178, 29)
        txbReceiveCo.TabIndex = 1
        ' 
        ' lblReceiveID
        ' 
        lblReceiveID.AutoSize = True
        lblReceiveID.Location = New Point(16, 122)
        lblReceiveID.Name = "lblReceiveID"
        lblReceiveID.Size = New Size(103, 15)
        lblReceiveID.TabIndex = 43
        lblReceiveID.Text = "Receiving County:"
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.Silver
        btnClear.Location = New Point(685, 263)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(75, 40)
        btnClear.TabIndex = 8
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' lblICTFormID
        ' 
        lblICTFormID.AutoSize = True
        lblICTFormID.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblICTFormID.ForeColor = Color.RoyalBlue
        lblICTFormID.Location = New Point(16, 9)
        lblICTFormID.Name = "lblICTFormID"
        lblICTFormID.Size = New Size(256, 25)
        lblICTFormID.TabIndex = 45
        lblICTFormID.Text = "Inter County Transfer Entry"
        lblICTFormID.Visible = False
        ' 
        ' gpbType
        ' 
        gpbType.BackColor = Color.DodgerBlue
        gpbType.Controls.Add(rdbICJ)
        gpbType.Controls.Add(rdbICT)
        gpbType.ForeColor = SystemColors.Window
        gpbType.Location = New Point(613, 12)
        gpbType.Name = "gpbType"
        gpbType.Size = New Size(147, 114)
        gpbType.TabIndex = 46
        gpbType.TabStop = False
        gpbType.Text = "Record to Enter"
        ' 
        ' rdbICJ
        ' 
        rdbICJ.AutoSize = True
        rdbICJ.Location = New Point(6, 67)
        rdbICJ.Name = "rdbICJ"
        rdbICJ.Size = New Size(126, 19)
        rdbICJ.TabIndex = 1
        rdbICJ.TabStop = True
        rdbICJ.Text = "Interstate Compact"
        rdbICJ.UseVisualStyleBackColor = True
        ' 
        ' rdbICT
        ' 
        rdbICT.AutoSize = True
        rdbICT.Location = New Point(6, 29)
        rdbICT.Name = "rdbICT"
        rdbICT.Size = New Size(135, 19)
        rdbICT.TabIndex = 0
        rdbICT.TabStop = True
        rdbICT.Text = "Inter County Transfer"
        rdbICT.UseVisualStyleBackColor = True
        ' 
        ' lblICJFormID
        ' 
        lblICJFormID.AutoSize = True
        lblICJFormID.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblICJFormID.ForeColor = Color.Maroon
        lblICJFormID.Location = New Point(16, 9)
        lblICJFormID.Name = "lblICJFormID"
        lblICJFormID.Size = New Size(348, 25)
        lblICJFormID.TabIndex = 47
        lblICJFormID.Text = "Interstate Compact on Juveniles Entry"
        lblICJFormID.Visible = False
        ' 
        ' frmEntry
        ' 
        AcceptButton = btnSave
        AccessibleRole = AccessibleRole.Caret
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnReturn
        ClientSize = New Size(772, 369)
        Controls.Add(lblICJFormID)
        Controls.Add(gpbType)
        Controls.Add(lblICTFormID)
        Controls.Add(btnClear)
        Controls.Add(txbReceiveCo)
        Controls.Add(lblReceiveID)
        Controls.Add(Label16)
        Controls.Add(btnReturn)
        Controls.Add(btnSave)
        Controls.Add(Label15)
        Controls.Add(Label14)
        Controls.Add(lblDaysRemainTrns)
        Controls.Add(lblTransThreshold)
        Controls.Add(lblDaysRemainProg)
        Controls.Add(lblProgRptDate)
        Controls.Add(cmbOfficer)
        Controls.Add(cmbType)
        Controls.Add(dtpEnd)
        Controls.Add(dtpStart)
        Controls.Add(txbSendCo)
        Controls.Add(txbChildName)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(lblSendID)
        Controls.Add(cmbTypeID)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(lblChildNameID)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "frmEntry"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ICT Entry Form"
        gpbType.ResumeLayout(False)
        gpbType.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblSendID As Label
    Friend WithEvents cmbTypeID As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblChildNameID As Label
    Friend WithEvents txbChildName As TextBox
    Friend WithEvents txbSendCo As TextBox
    Friend WithEvents dtpStart As DateTimePicker
    Friend WithEvents dtpEnd As DateTimePicker
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents cmbOfficer As ComboBox
    Friend WithEvents lblProgRptDate As Label
    Friend WithEvents lblDaysRemainProg As Label
    Friend WithEvents lblTransThreshold As Label
    Friend WithEvents lblDaysRemainTrns As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnReturn As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents txbReceiveCo As TextBox
    Friend WithEvents lblReceiveID As Label
    Friend WithEvents btnClear As Button
    Friend WithEvents lblICTFormID As Label
    Friend WithEvents gpbType As GroupBox
    Friend WithEvents rdbICT As RadioButton
    Friend WithEvents rdbICJ As RadioButton
    Friend WithEvents lblICJFormID As Label
End Class
