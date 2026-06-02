<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDelete
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
        txbLastName = New TextBox()
        lblChildNameID = New Label()
        btnReturn = New Button()
        btnClear = New Button()
        btnDelete = New Button()
        rdbICJ = New RadioButton()
        rdbICT = New RadioButton()
        gpbType = New GroupBox()
        gpbType.SuspendLayout()
        SuspendLayout()
        ' 
        ' txbLastName
        ' 
        txbLastName.Font = New Font("Segoe UI", 12F)
        txbLastName.Location = New Point(12, 38)
        txbLastName.Name = "txbLastName"
        txbLastName.Size = New Size(316, 29)
        txbLastName.TabIndex = 0
        ' 
        ' lblChildNameID
        ' 
        lblChildNameID.AutoSize = True
        lblChildNameID.Location = New Point(12, 20)
        lblChildNameID.Name = "lblChildNameID"
        lblChildNameID.Size = New Size(226, 15)
        lblChildNameID.TabIndex = 21
        lblChildNameID.Text = "Child Name to be Removed: (Last Name):"
        ' 
        ' btnReturn
        ' 
        btnReturn.BackColor = Color.Gold
        btnReturn.Location = New Point(214, 128)
        btnReturn.Name = "btnReturn"
        btnReturn.Size = New Size(75, 40)
        btnReturn.TabIndex = 3
        btnReturn.Text = "Rtn Main"
        btnReturn.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = SystemColors.ControlDark
        btnClear.Location = New Point(113, 128)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(75, 40)
        btnClear.TabIndex = 2
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.IndianRed
        btnDelete.Location = New Point(12, 128)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(75, 40)
        btnDelete.TabIndex = 1
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = False
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
        ' gpbType
        ' 
        gpbType.BackColor = Color.DodgerBlue
        gpbType.Controls.Add(rdbICJ)
        gpbType.Controls.Add(rdbICT)
        gpbType.ForeColor = SystemColors.Window
        gpbType.Location = New Point(360, 12)
        gpbType.Name = "gpbType"
        gpbType.Size = New Size(147, 114)
        gpbType.TabIndex = 47
        gpbType.TabStop = False
        gpbType.Text = "Record to Enter"
        ' 
        ' frmDelete
        ' 
        AcceptButton = btnDelete
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnReturn
        ClientSize = New Size(519, 180)
        Controls.Add(gpbType)
        Controls.Add(btnDelete)
        Controls.Add(btnClear)
        Controls.Add(btnReturn)
        Controls.Add(txbLastName)
        Controls.Add(lblChildNameID)
        Name = "frmDelete"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Delete Child"
        gpbType.ResumeLayout(False)
        gpbType.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txbLastName As TextBox
    Friend WithEvents lblChildNameID As Label
    Friend WithEvents btnReturn As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents rdbICJ As RadioButton
    Friend WithEvents rdbICT As RadioButton
    Friend WithEvents gpbType As GroupBox
End Class
