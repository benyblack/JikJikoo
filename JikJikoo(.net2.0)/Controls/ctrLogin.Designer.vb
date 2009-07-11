<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrLogin
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPwd = New System.Windows.Forms.TextBox
        Me.txtUid = New System.Windows.Forms.TextBox
        Me.btnLogin = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.chkSave = New System.Windows.Forms.CheckBox
        Me.pnl1 = New System.Windows.Forms.Panel
        Me.pnl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(151, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Password"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Username"
        '
        'txtPwd
        '
        Me.txtPwd.Location = New System.Drawing.Point(206, 2)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(100, 20)
        Me.txtPwd.TabIndex = 8
        Me.txtPwd.Visible = False
        '
        'txtUid
        '
        Me.txtUid.Location = New System.Drawing.Point(59, 2)
        Me.txtUid.Name = "txtUid"
        Me.txtUid.Size = New System.Drawing.Size(84, 20)
        Me.txtUid.TabIndex = 7
        '
        'btnLogin
        '
        Me.btnLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogin.ForeColor = System.Drawing.Color.Black
        Me.btnLogin.Location = New System.Drawing.Point(427, 2)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(75, 25)
        Me.btnLogin.TabIndex = 6
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(422, 27)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        Me.btnCancel.Visible = False
        '
        'chkSave
        '
        Me.chkSave.AutoSize = True
        Me.chkSave.Location = New System.Drawing.Point(315, 4)
        Me.chkSave.Name = "chkSave"
        Me.chkSave.Size = New System.Drawing.Size(101, 17)
        Me.chkSave.TabIndex = 12
        Me.chkSave.Text = "Save Login Info"
        Me.chkSave.UseVisualStyleBackColor = True
        Me.chkSave.Visible = False
        '
        'pnl1
        '
        Me.pnl1.Controls.Add(Me.chkSave)
        Me.pnl1.Controls.Add(Me.Label1)
        Me.pnl1.Controls.Add(Me.txtUid)
        Me.pnl1.Controls.Add(Me.Label2)
        Me.pnl1.Controls.Add(Me.txtPwd)
        Me.pnl1.Location = New System.Drawing.Point(0, 1)
        Me.pnl1.Name = "pnl1"
        Me.pnl1.Size = New System.Drawing.Size(416, 27)
        Me.pnl1.TabIndex = 13
        '
        'ctrLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.pnl1)
        Me.Name = "ctrLogin"
        Me.Size = New System.Drawing.Size(501, 28)
        Me.pnl1.ResumeLayout(False)
        Me.pnl1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPwd As System.Windows.Forms.TextBox
    Friend WithEvents txtUid As System.Windows.Forms.TextBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkSave As System.Windows.Forms.CheckBox
    Friend WithEvents pnl1 As System.Windows.Forms.Panel

End Class
