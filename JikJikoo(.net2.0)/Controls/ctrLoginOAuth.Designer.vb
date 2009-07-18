<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrLoginOAuth
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrLoginOAuth))
        Me.btnLogin = New System.Windows.Forms.Button
        Me.txtUid = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btnLogin
        '
        Me.btnLogin.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.btnLogin, "btnLogin")
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'txtUid
        '
        resources.ApplyResources(Me.txtUid, "txtUid")
        Me.txtUid.Name = "txtUid"
        '
        'ctrLoginOAuth
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.txtUid)
        Me.Controls.Add(Me.btnLogin)
        Me.Name = "ctrLoginOAuth"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents txtUid As System.Windows.Forms.TextBox

End Class
