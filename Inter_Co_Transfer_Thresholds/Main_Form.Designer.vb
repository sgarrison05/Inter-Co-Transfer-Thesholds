<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblListingID = New Label()
        lblICTListing = New Label()
        btnAdd = New Button()
        btnDelete = New Button()
        lblDateID = New Label()
        lblTotalChildren = New Label()
        lblTotReceived = New Label()
        lblTotSent = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        dtpNinety = New DateTimePicker()
        dtpOneEighty = New DateTimePicker()
        dtpToday = New DateTimePicker()
        brnClose = New Button()
        btnSearch = New Button()
        btnRefresh = New Button()
        lblICJListing = New Label()
        btnICJSearch = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        btnICJDelete = New Button()
        brnICJAdd = New Button()
        SuspendLayout()
        ' 
        ' lblListingID
        ' 
        lblListingID.AutoSize = True
        lblListingID.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblListingID.ForeColor = Color.Blue
        lblListingID.Location = New Point(12, 15)
        lblListingID.Name = "lblListingID"
        lblListingID.Size = New Size(333, 32)
        lblListingID.TabIndex = 0
        lblListingID.Text = "Listing of Current Transfers:" & vbCrLf
        ' 
        ' lblICTListing
        ' 
        lblICTListing.BackColor = SystemColors.ActiveCaptionText
        lblICTListing.Font = New Font("Cascadia Mono", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblICTListing.ForeColor = SystemColors.Control
        lblICTListing.Location = New Point(12, 59)
        lblICTListing.Name = "lblICTListing"
        lblICTListing.Size = New Size(1110, 213)
        lblICTListing.TabIndex = 1
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.Green
        btnAdd.Location = New Point(826, 286)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(75, 39)
        btnAdd.TabIndex = 1
        btnAdd.Text = "Add New"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.Red
        btnDelete.Location = New Point(1047, 286)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(75, 39)
        btnDelete.TabIndex = 3
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' lblDateID
        ' 
        lblDateID.AutoSize = True
        lblDateID.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDateID.Location = New Point(18, 571)
        lblDateID.Name = "lblDateID"
        lblDateID.Size = New Size(80, 15)
        lblDateID.TabIndex = 5
        lblDateID.Text = "Today's Date:"
        ' 
        ' lblTotalChildren
        ' 
        lblTotalChildren.BorderStyle = BorderStyle.FixedSingle
        lblTotalChildren.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalChildren.Location = New Point(17, 305)
        lblTotalChildren.Name = "lblTotalChildren"
        lblTotalChildren.Size = New Size(102, 23)
        lblTotalChildren.TabIndex = 7
        lblTotalChildren.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTotReceived
        ' 
        lblTotReceived.BorderStyle = BorderStyle.FixedSingle
        lblTotReceived.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotReceived.Location = New Point(137, 305)
        lblTotReceived.Name = "lblTotReceived"
        lblTotReceived.Size = New Size(102, 23)
        lblTotReceived.TabIndex = 8
        lblTotReceived.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTotSent
        ' 
        lblTotSent.BorderStyle = BorderStyle.FixedSingle
        lblTotSent.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotSent.Location = New Point(264, 305)
        lblTotSent.Name = "lblTotSent"
        lblTotSent.Size = New Size(102, 23)
        lblTotSent.TabIndex = 9
        lblTotSent.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label5.Location = New Point(12, 286)
        Label5.Name = "Label5"
        Label5.Size = New Size(107, 15)
        Label5.TabIndex = 12
        Label5.Text = "Total ICT Children:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label6.Location = New Point(137, 286)
        Label6.Name = "Label6"
        Label6.Size = New Size(106, 15)
        Label6.TabIndex = 13
        Label6.Text = "Total ICT Recived:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label7.Location = New Point(264, 286)
        Label7.Name = "Label7"
        Label7.Size = New Size(87, 15)
        Label7.TabIndex = 14
        Label7.Text = "Total ICT Sent:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label8.Location = New Point(193, 571)
        Label8.Name = "Label8"
        Label8.Size = New Size(119, 15)
        Label8.TabIndex = 15
        Label8.Text = "90 Days from Today:" & vbCrLf
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label9.Location = New Point(373, 571)
        Label9.Name = "Label9"
        Label9.Size = New Size(126, 15)
        Label9.TabIndex = 16
        Label9.Text = "180 Days from Today:"
        ' 
        ' dtpNinety
        ' 
        dtpNinety.Enabled = False
        dtpNinety.Font = New Font("Segoe UI", 11.25F)
        dtpNinety.Format = DateTimePickerFormat.Short
        dtpNinety.Location = New Point(193, 589)
        dtpNinety.Name = "dtpNinety"
        dtpNinety.Size = New Size(131, 27)
        dtpNinety.TabIndex = 17
        ' 
        ' dtpOneEighty
        ' 
        dtpOneEighty.Enabled = False
        dtpOneEighty.Font = New Font("Segoe UI", 11.25F)
        dtpOneEighty.Format = DateTimePickerFormat.Short
        dtpOneEighty.Location = New Point(373, 589)
        dtpOneEighty.Name = "dtpOneEighty"
        dtpOneEighty.Size = New Size(131, 27)
        dtpOneEighty.TabIndex = 18
        ' 
        ' dtpToday
        ' 
        dtpToday.Enabled = False
        dtpToday.Font = New Font("Segoe UI", 11.25F)
        dtpToday.Format = DateTimePickerFormat.Short
        dtpToday.Location = New Point(17, 589)
        dtpToday.Name = "dtpToday"
        dtpToday.Size = New Size(131, 27)
        dtpToday.TabIndex = 19
        ' 
        ' brnClose
        ' 
        brnClose.BackColor = Color.SkyBlue
        brnClose.Location = New Point(1047, 571)
        brnClose.Name = "brnClose"
        brnClose.Size = New Size(75, 39)
        brnClose.TabIndex = 4
        brnClose.Text = "Close"
        brnClose.UseVisualStyleBackColor = False
        ' 
        ' btnSearch
        ' 
        btnSearch.BackColor = Color.Gold
        btnSearch.Location = New Point(935, 286)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(75, 39)
        btnSearch.TabIndex = 2
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = False
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.DodgerBlue
        btnRefresh.Location = New Point(935, 571)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(75, 39)
        btnRefresh.TabIndex = 0
        btnRefresh.Text = "Refresh"
        btnRefresh.UseVisualStyleBackColor = False
        ' 
        ' lblICJListing
        ' 
        lblICJListing.BackColor = SystemColors.ActiveCaptionText
        lblICJListing.Font = New Font("Cascadia Mono", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblICJListing.ForeColor = SystemColors.Control
        lblICJListing.Location = New Point(12, 355)
        lblICJListing.Name = "lblICJListing"
        lblICJListing.Size = New Size(1110, 127)
        lblICJListing.TabIndex = 20
        ' 
        ' btnICJSearch
        ' 
        btnICJSearch.BackColor = Color.Gold
        btnICJSearch.Location = New Point(935, 495)
        btnICJSearch.Name = "btnICJSearch"
        btnICJSearch.Size = New Size(75, 39)
        btnICJSearch.TabIndex = 22
        btnICJSearch.Text = "Search"
        btnICJSearch.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label1.Location = New Point(264, 495)
        Label1.Name = "Label1"
        Label1.Size = New Size(85, 15)
        Label1.TabIndex = 29
        Label1.Text = "Total ICJ Sent:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label2.Location = New Point(137, 495)
        Label2.Name = "Label2"
        Label2.Size = New Size(104, 15)
        Label2.TabIndex = 28
        Label2.Text = "Total ICJ Recived:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label3.Location = New Point(12, 495)
        Label3.Name = "Label3"
        Label3.Size = New Size(105, 15)
        Label3.TabIndex = 27
        Label3.Text = "Total ICJ Children:"
        ' 
        ' Label4
        ' 
        Label4.BorderStyle = BorderStyle.FixedSingle
        Label4.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(264, 514)
        Label4.Name = "Label4"
        Label4.Size = New Size(102, 23)
        Label4.TabIndex = 26
        Label4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label10
        ' 
        Label10.BorderStyle = BorderStyle.FixedSingle
        Label10.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(137, 514)
        Label10.Name = "Label10"
        Label10.Size = New Size(102, 23)
        Label10.TabIndex = 25
        Label10.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label11
        ' 
        Label11.BorderStyle = BorderStyle.FixedSingle
        Label11.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(17, 514)
        Label11.Name = "Label11"
        Label11.Size = New Size(102, 23)
        Label11.TabIndex = 24
        Label11.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnICJDelete
        ' 
        btnICJDelete.BackColor = Color.Red
        btnICJDelete.Location = New Point(1047, 495)
        btnICJDelete.Name = "btnICJDelete"
        btnICJDelete.Size = New Size(75, 39)
        btnICJDelete.TabIndex = 23
        btnICJDelete.Text = "Delete"
        btnICJDelete.UseVisualStyleBackColor = False
        ' 
        ' brnICJAdd
        ' 
        brnICJAdd.BackColor = Color.Green
        brnICJAdd.Location = New Point(826, 495)
        brnICJAdd.Name = "brnICJAdd"
        brnICJAdd.Size = New Size(75, 39)
        brnICJAdd.TabIndex = 21
        brnICJAdd.Text = "Add New"
        brnICJAdd.UseVisualStyleBackColor = False
        ' 
        ' frmMain
        ' 
        AcceptButton = btnAdd
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = brnClose
        ClientSize = New Size(1135, 625)
        Controls.Add(btnICJSearch)
        Controls.Add(Label1)
        Controls.Add(Label2)
        Controls.Add(Label3)
        Controls.Add(Label4)
        Controls.Add(Label10)
        Controls.Add(Label11)
        Controls.Add(btnICJDelete)
        Controls.Add(brnICJAdd)
        Controls.Add(lblICJListing)
        Controls.Add(btnRefresh)
        Controls.Add(btnSearch)
        Controls.Add(dtpToday)
        Controls.Add(dtpOneEighty)
        Controls.Add(dtpNinety)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(lblTotSent)
        Controls.Add(lblTotReceived)
        Controls.Add(lblTotalChildren)
        Controls.Add(lblDateID)
        Controls.Add(brnClose)
        Controls.Add(btnDelete)
        Controls.Add(btnAdd)
        Controls.Add(lblICTListing)
        Controls.Add(lblListingID)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "frmMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Inter County Transfer Thresholds"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblListingID As Label
    Friend WithEvents lblICTListing As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents lblDateID As Label
    Friend WithEvents lblTotalChildren As Label
    Friend WithEvents lblTotReceived As Label
    Friend WithEvents lblTotSent As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents dtpNinety As DateTimePicker
    Friend WithEvents dtpOneEighty As DateTimePicker
    Friend WithEvents dtpToday As DateTimePicker
    Friend WithEvents brnClose As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents lblICJListing As Label
    Friend WithEvents btnICJSearch As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents btnICJDelete As Button
    Friend WithEvents brnICJAdd As Button

End Class
