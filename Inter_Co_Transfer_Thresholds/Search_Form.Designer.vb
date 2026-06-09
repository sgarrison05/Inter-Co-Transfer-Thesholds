<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearch
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
        btnEnter = New Button()
        lblDisplay = New Label()
        btnClear = New Button()
        rdbICJ = New RadioButton()
        rdbICT = New RadioButton()
        gpbType = New GroupBox()
        btnUpdate = New Button()
        gpbType.SuspendLayout()
        SuspendLayout()
        ' 
        ' txbLastName
        ' 
        txbLastName.Font = New Font("Segoe UI", 12F)
        txbLastName.Location = New Point(12, 27)
        txbLastName.Name = "txbLastName"
        txbLastName.Size = New Size(335, 29)
        txbLastName.TabIndex = 0
        ' 
        ' lblChildNameID
        ' 
        lblChildNameID.AutoSize = True
        lblChildNameID.Location = New Point(12, 9)
        lblChildNameID.Name = "lblChildNameID"
        lblChildNameID.Size = New Size(143, 15)
        lblChildNameID.TabIndex = 19
        lblChildNameID.Text = "Child Name: (Last Name):"
        ' 
        ' btnReturn
        ' 
        btnReturn.BackColor = Color.Gold
        btnReturn.Location = New Point(292, 232)
        btnReturn.Name = "btnReturn"
        btnReturn.Size = New Size(75, 40)
        btnReturn.TabIndex = 3
        btnReturn.Text = "Rtn Main"
        btnReturn.UseVisualStyleBackColor = False
        ' 
        ' btnEnter
        ' 
        btnEnter.BackColor = Color.GreenYellow
        btnEnter.Location = New Point(12, 232)
        btnEnter.Name = "btnEnter"
        btnEnter.Size = New Size(75, 40)
        btnEnter.TabIndex = 1
        btnEnter.Text = "Enter"
        btnEnter.UseVisualStyleBackColor = False
        ' 
        ' lblDisplay
        ' 
        lblDisplay.BackColor = Color.Black
        lblDisplay.Font = New Font("Cascadia Mono", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDisplay.ForeColor = Color.White
        lblDisplay.Location = New Point(12, 140)
        lblDisplay.Name = "lblDisplay"
        lblDisplay.Size = New Size(598, 75)
        lblDisplay.TabIndex = 47
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = SystemColors.ControlDark
        btnClear.Location = New Point(200, 232)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(75, 40)
        btnClear.TabIndex = 2
        btnClear.Text = "Clear"
        btnClear.UseVisualStyleBackColor = False
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
        gpbType.Location = New Point(463, 9)
        gpbType.Name = "gpbType"
        gpbType.Size = New Size(147, 114)
        gpbType.TabIndex = 48
        gpbType.TabStop = False
        gpbType.Text = "Record to Enter"
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.Orange
        btnUpdate.Location = New Point(107, 232)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(75, 40)
        btnUpdate.TabIndex = 49
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' frmSearch
        ' 
        AcceptButton = btnEnter
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = btnReturn
        ClientSize = New Size(625, 287)
        Controls.Add(btnUpdate)
        Controls.Add(gpbType)
        Controls.Add(btnClear)
        Controls.Add(lblDisplay)
        Controls.Add(btnEnter)
        Controls.Add(btnReturn)
        Controls.Add(txbLastName)
        Controls.Add(lblChildNameID)
        Name = "frmSearch"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Search for Child"
        gpbType.ResumeLayout(False)
        gpbType.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txbLastName As TextBox
    Friend WithEvents lblChildNameID As Label
    Friend WithEvents btnReturn As Button
    Friend WithEvents btnEnter As Button
    Friend WithEvents lblDisplay As Label
    Friend WithEvents btnClear As Button
    Friend WithEvents rdbICJ As RadioButton
    Friend WithEvents rdbICT As RadioButton
    Friend WithEvents gpbType As GroupBox
    Friend WithEvents btnUpdate As Button
End Class
