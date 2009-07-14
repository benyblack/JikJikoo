<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfig
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfig))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboProxyType = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.txtIP = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnOk = New System.Windows.Forms.Button
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPass = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.cboLang = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtRefresh = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = Nothing
        Me.Label1.AccessibleName = Nothing
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Font = Nothing
        Me.Label1.Name = "Label1"
        '
        'cboProxyType
        '
        Me.cboProxyType.AccessibleDescription = Nothing
        Me.cboProxyType.AccessibleName = Nothing
        resources.ApplyResources(Me.cboProxyType, "cboProxyType")
        Me.cboProxyType.BackgroundImage = Nothing
        Me.cboProxyType.Font = Nothing
        Me.cboProxyType.FormattingEnabled = True
        Me.cboProxyType.Items.AddRange(New Object() {resources.GetString("cboProxyType.Items"), resources.GetString("cboProxyType.Items1"), resources.GetString("cboProxyType.Items2"), resources.GetString("cboProxyType.Items3")})
        Me.cboProxyType.Name = "cboProxyType"
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = Nothing
        Me.Label2.AccessibleName = Nothing
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Font = Nothing
        Me.Label2.Name = "Label2"
        '
        'txtPort
        '
        Me.txtPort.AccessibleDescription = Nothing
        Me.txtPort.AccessibleName = Nothing
        resources.ApplyResources(Me.txtPort, "txtPort")
        Me.txtPort.BackgroundImage = Nothing
        Me.txtPort.Font = Nothing
        Me.txtPort.Name = "txtPort"
        '
        'txtIP
        '
        Me.txtIP.AccessibleDescription = Nothing
        Me.txtIP.AccessibleName = Nothing
        resources.ApplyResources(Me.txtIP, "txtIP")
        Me.txtIP.BackgroundImage = Nothing
        Me.txtIP.Font = Nothing
        Me.txtIP.Name = "txtIP"
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = Nothing
        Me.Label3.AccessibleName = Nothing
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Font = Nothing
        Me.Label3.Name = "Label3"
        '
        'btnOk
        '
        Me.btnOk.AccessibleDescription = Nothing
        Me.btnOk.AccessibleName = Nothing
        resources.ApplyResources(Me.btnOk, "btnOk")
        Me.btnOk.BackgroundImage = Nothing
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOk.Font = Nothing
        Me.btnOk.ForeColor = System.Drawing.Color.Black
        Me.btnOk.Name = "btnOk"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'txtUser
        '
        Me.txtUser.AccessibleDescription = Nothing
        Me.txtUser.AccessibleName = Nothing
        resources.ApplyResources(Me.txtUser, "txtUser")
        Me.txtUser.BackgroundImage = Nothing
        Me.txtUser.Font = Nothing
        Me.txtUser.Name = "txtUser"
        '
        'Label4
        '
        Me.Label4.AccessibleDescription = Nothing
        Me.Label4.AccessibleName = Nothing
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Font = Nothing
        Me.Label4.Name = "Label4"
        '
        'txtPass
        '
        Me.txtPass.AccessibleDescription = Nothing
        Me.txtPass.AccessibleName = Nothing
        resources.ApplyResources(Me.txtPass, "txtPass")
        Me.txtPass.BackgroundImage = Nothing
        Me.txtPass.Font = Nothing
        Me.txtPass.Name = "txtPass"
        '
        'Label5
        '
        Me.Label5.AccessibleDescription = Nothing
        Me.Label5.AccessibleName = Nothing
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Font = Nothing
        Me.Label5.Name = "Label5"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleDescription = Nothing
        Me.btnCancel.AccessibleName = Nothing
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.BackgroundImage = Nothing
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = Nothing
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'cboLang
        '
        Me.cboLang.AccessibleDescription = Nothing
        Me.cboLang.AccessibleName = Nothing
        resources.ApplyResources(Me.cboLang, "cboLang")
        Me.cboLang.BackgroundImage = Nothing
        Me.cboLang.Font = Nothing
        Me.cboLang.FormattingEnabled = True
        Me.cboLang.Items.AddRange(New Object() {resources.GetString("cboLang.Items"), resources.GetString("cboLang.Items1")})
        Me.cboLang.Name = "cboLang"
        '
        'Label6
        '
        Me.Label6.AccessibleDescription = Nothing
        Me.Label6.AccessibleName = Nothing
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Font = Nothing
        Me.Label6.Name = "Label6"
        '
        'txtRefresh
        '
        Me.txtRefresh.AccessibleDescription = Nothing
        Me.txtRefresh.AccessibleName = Nothing
        resources.ApplyResources(Me.txtRefresh, "txtRefresh")
        Me.txtRefresh.BackgroundImage = Nothing
        Me.txtRefresh.Font = Nothing
        Me.txtRefresh.Name = "txtRefresh"
        '
        'Label7
        '
        Me.Label7.AccessibleDescription = Nothing
        Me.Label7.AccessibleName = Nothing
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Font = Nothing
        Me.Label7.Name = "Label7"
        '
        'frmConfig
        '
        Me.AcceptButton = Me.btnOk
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Nothing
        Me.CancelButton = Me.btnCancel
        Me.Controls.Add(Me.txtRefresh)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboLang)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.txtIP)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboProxyType)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = Nothing
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfig"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboProxyType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents txtIP As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cboLang As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRefresh As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
