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
        lblICTListingID = New Label()
        lblICTListing = New Label()
        btnAdd = New Button()
        btnDelete = New Button()
        lblDateID = New Label()
        lblTotICTChildren = New Label()
        lblTotICTReceived = New Label()
        lblTotICTSent = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        brnClose = New Button()
        btnSearch = New Button()
        btnRefresh = New Button()
        lblICJListing = New Label()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        lblTotICJSent = New Label()
        lblTotICJReceived = New Label()
        lblTotICJChildren = New Label()
        lblICJListingID = New Label()
        lblNinety = New Label()
        lblOneEighty = New Label()
        lblToday = New Label()
        SuspendLayout()
        ' 
        ' lblICTListingID
        ' 
        lblICTListingID.AutoSize = True
        lblICTListingID.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblICTListingID.ForeColor = Color.Blue
        lblICTListingID.Location = New Point(12, -1)
        lblICTListingID.Name = "lblICTListingID"
        lblICTListingID.Size = New Size(521, 32)
        lblICTListingID.TabIndex = 0
        lblICTListingID.Text = "Listing of Inter County Transfer Supervision:" & vbCrLf
        ' 
        ' lblICTListing
        ' 
        lblICTListing.BackColor = SystemColors.ActiveCaptionText
        lblICTListing.Font = New Font("Cascadia Mono", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblICTListing.ForeColor = SystemColors.Control
        lblICTListing.Location = New Point(12, 36)
        lblICTListing.Name = "lblICTListing"
        lblICTListing.Size = New Size(1110, 213)
        lblICTListing.TabIndex = 1
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.Green
        btnAdd.Location = New Point(826, 498)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(75, 39)
        btnAdd.TabIndex = 1
        btnAdd.Text = "Add New"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.Red
        btnDelete.Location = New Point(1047, 498)
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
        lblDateID.Location = New Point(18, 592)
        lblDateID.Name = "lblDateID"
        lblDateID.Size = New Size(80, 15)
        lblDateID.TabIndex = 5
        lblDateID.Text = "Today's Date:"
        ' 
        ' lblTotICTChildren
        ' 
        lblTotICTChildren.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotICTChildren.Location = New Point(17, 282)
        lblTotICTChildren.Name = "lblTotICTChildren"
        lblTotICTChildren.Size = New Size(102, 23)
        lblTotICTChildren.TabIndex = 7
        lblTotICTChildren.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTotICTReceived
        ' 
        lblTotICTReceived.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotICTReceived.Location = New Point(137, 282)
        lblTotICTReceived.Name = "lblTotICTReceived"
        lblTotICTReceived.Size = New Size(102, 23)
        lblTotICTReceived.TabIndex = 8
        lblTotICTReceived.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTotICTSent
        ' 
        lblTotICTSent.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotICTSent.Location = New Point(264, 282)
        lblTotICTSent.Name = "lblTotICTSent"
        lblTotICTSent.Size = New Size(102, 23)
        lblTotICTSent.TabIndex = 9
        lblTotICTSent.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label5.Location = New Point(12, 263)
        Label5.Name = "Label5"
        Label5.Size = New Size(107, 15)
        Label5.TabIndex = 12
        Label5.Text = "Total ICT Children:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label6.Location = New Point(137, 263)
        Label6.Name = "Label6"
        Label6.Size = New Size(106, 15)
        Label6.TabIndex = 13
        Label6.Text = "Total ICT Recived:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label7.Location = New Point(264, 263)
        Label7.Name = "Label7"
        Label7.Size = New Size(87, 15)
        Label7.TabIndex = 14
        Label7.Text = "Total ICT Sent:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label8.Location = New Point(193, 592)
        Label8.Name = "Label8"
        Label8.Size = New Size(119, 15)
        Label8.TabIndex = 15
        Label8.Text = "90 Days from Today:" & vbCrLf
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label9.Location = New Point(373, 592)
        Label9.Name = "Label9"
        Label9.Size = New Size(126, 15)
        Label9.TabIndex = 16
        Label9.Text = "180 Days from Today:"
        ' 
        ' brnClose
        ' 
        brnClose.BackColor = Color.SkyBlue
        brnClose.Location = New Point(1047, 592)
        brnClose.Name = "brnClose"
        brnClose.Size = New Size(75, 39)
        brnClose.TabIndex = 4
        brnClose.Text = "Close"
        brnClose.UseVisualStyleBackColor = False
        ' 
        ' btnSearch
        ' 
        btnSearch.BackColor = Color.Gold
        btnSearch.Location = New Point(935, 498)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(75, 39)
        btnSearch.TabIndex = 2
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = False
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BackColor = Color.DodgerBlue
        btnRefresh.Location = New Point(935, 592)
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
        lblICJListing.Location = New Point(12, 358)
        lblICJListing.Name = "lblICJListing"
        lblICJListing.Size = New Size(1110, 127)
        lblICJListing.TabIndex = 20
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label1.Location = New Point(264, 498)
        Label1.Name = "Label1"
        Label1.Size = New Size(85, 15)
        Label1.TabIndex = 29
        Label1.Text = "Total ICJ Sent:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label2.Location = New Point(137, 498)
        Label2.Name = "Label2"
        Label2.Size = New Size(104, 15)
        Label2.TabIndex = 28
        Label2.Text = "Total ICJ Recived:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label3.Location = New Point(12, 498)
        Label3.Name = "Label3"
        Label3.Size = New Size(105, 15)
        Label3.TabIndex = 27
        Label3.Text = "Total ICJ Children:"
        ' 
        ' lblTotICJSent
        ' 
        lblTotICJSent.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotICJSent.Location = New Point(264, 517)
        lblTotICJSent.Name = "lblTotICJSent"
        lblTotICJSent.Size = New Size(102, 23)
        lblTotICJSent.TabIndex = 26
        lblTotICJSent.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTotICJReceived
        ' 
        lblTotICJReceived.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotICJReceived.Location = New Point(137, 517)
        lblTotICJReceived.Name = "lblTotICJReceived"
        lblTotICJReceived.Size = New Size(102, 23)
        lblTotICJReceived.TabIndex = 25
        lblTotICJReceived.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTotICJChildren
        ' 
        lblTotICJChildren.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotICJChildren.Location = New Point(17, 517)
        lblTotICJChildren.Name = "lblTotICJChildren"
        lblTotICJChildren.Size = New Size(102, 23)
        lblTotICJChildren.TabIndex = 24
        lblTotICJChildren.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblICJListingID
        ' 
        lblICJListingID.AutoSize = True
        lblICJListingID.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblICJListingID.ForeColor = Color.Blue
        lblICJListingID.Location = New Point(12, 322)
        lblICJListingID.Name = "lblICJListingID"
        lblICJListingID.Size = New Size(503, 32)
        lblICJListingID.TabIndex = 30
        lblICJListingID.Text = "Listing of Inter State Compact Supervision:"
        ' 
        ' lblNinety
        ' 
        lblNinety.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblNinety.Location = New Point(198, 608)
        lblNinety.Name = "lblNinety"
        lblNinety.Size = New Size(87, 23)
        lblNinety.TabIndex = 31
        ' 
        ' lblOneEighty
        ' 
        lblOneEighty.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblOneEighty.Location = New Point(379, 608)
        lblOneEighty.Name = "lblOneEighty"
        lblOneEighty.Size = New Size(87, 23)
        lblOneEighty.TabIndex = 32
        ' 
        ' lblToday
        ' 
        lblToday.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblToday.Location = New Point(18, 609)
        lblToday.Name = "lblToday"
        lblToday.Size = New Size(87, 23)
        lblToday.TabIndex = 33
        ' 
        ' frmMain
        ' 
        AcceptButton = btnAdd
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = brnClose
        ClientSize = New Size(1135, 649)
        Controls.Add(lblToday)
        Controls.Add(lblOneEighty)
        Controls.Add(lblNinety)
        Controls.Add(lblICJListingID)
        Controls.Add(Label1)
        Controls.Add(Label2)
        Controls.Add(Label3)
        Controls.Add(lblTotICJSent)
        Controls.Add(lblTotICJReceived)
        Controls.Add(lblTotICJChildren)
        Controls.Add(lblICJListing)
        Controls.Add(btnRefresh)
        Controls.Add(btnSearch)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(lblTotICTSent)
        Controls.Add(lblTotICTReceived)
        Controls.Add(lblTotICTChildren)
        Controls.Add(lblDateID)
        Controls.Add(brnClose)
        Controls.Add(btnDelete)
        Controls.Add(btnAdd)
        Controls.Add(lblICTListing)
        Controls.Add(lblICTListingID)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "frmMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Inter County Transfer Thresholds"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblICTListingID As Label
    Friend WithEvents lblICTListing As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents lblDateID As Label
    Friend WithEvents lblTotICTChildren As Label
    Friend WithEvents lblTotICTReceived As Label
    Friend WithEvents lblTotICTSent As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents brnClose As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents lblICJListing As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTotICJSent As Label
    Friend WithEvents lblTotICJReceived As Label
    Friend WithEvents lblTotICJChildren As Label
    Friend WithEvents lblICJListingID As Label
    Friend WithEvents lblNinety As Label
    Friend WithEvents lblOneEighty As Label
    Friend WithEvents lblToday As Label

End Class
