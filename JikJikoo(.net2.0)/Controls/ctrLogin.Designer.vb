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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrLogin))
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
        Me.Label2.AccessibleDescription = Nothing
        Me.Label2.AccessibleName = Nothing
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Font = Nothing
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = Nothing
        Me.Label1.AccessibleName = Nothing
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Font = Nothing
        Me.Label1.Name = "Label1"
        '
        'txtPwd
        '
        Me.txtPwd.AccessibleDescription = Nothing
        Me.txtPwd.AccessibleName = Nothing
        resources.ApplyResources(Me.txtPwd, "txtPwd")
        Me.txtPwd.BackgroundImage = Nothing
        Me.txtPwd.Font = Nothing
        Me.txtPwd.Name = "txtPwd"
        '
        'txtUid
        '
        Me.txtUid.AccessibleDescription = Nothing
        Me.txtUid.AccessibleName = Nothing
        resources.ApplyResources(Me.txtUid, "txtUid")
        Me.txtUid.BackgroundImage = Nothing
        Me.txtUid.Font = Nothing
        Me.txtUid.Name = "txtUid"
        '
        'btnLogin
        '
        Me.btnLogin.AccessibleDescription = Nothing
        Me.btnLogin.AccessibleName = Nothing
        resources.ApplyResources(Me.btnLogin, "btnLogin")
        Me.btnLogin.BackgroundImage = Nothing
        Me.btnLogin.Font = Nothing
        Me.btnLogin.ForeColor = System.Drawing.Color.Black
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleDescription = Nothing
        Me.btnCancel.AccessibleName = Nothing
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.BackgroundImage = Nothing
        Me.btnCancel.Font = Nothing
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'chkSave
        '
        Me.chkSave.AccessibleDescription = Nothing
        Me.chkSave.AccessibleName = Nothing
        resources.ApplyResources(Me.chkSave, "chkSave")
        Me.chkSave.BackgroundImage = Nothing
        Me.chkSave.Font = Nothing
        Me.chkSave.Name = "chkSave"
        Me.chkSave.UseVisualStyleBackColor = True
        '
        'pnl1
        '
        Me.pnl1.AccessibleDescription = Nothing
        Me.pnl1.AccessibleName = Nothing
        resources.ApplyResources(Me.pnl1, "pnl1")
        Me.pnl1.BackgroundImage = Nothing
        Me.pnl1.Controls.Add(Me.chkSave)
        Me.pnl1.Controls.Add(Me.Label1)
        Me.pnl1.Controls.Add(Me.txtUid)
        Me.pnl1.Controls.Add(Me.Label2)
        Me.pnl1.Controls.Add(Me.txtPwd)
        Me.pnl1.Font = Nothing
        Me.pnl1.Name = "pnl1"
        '
        'ctrLogin
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.pnl1)
        Me.Font = Nothing
        Me.Name = "ctrLogin"
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
