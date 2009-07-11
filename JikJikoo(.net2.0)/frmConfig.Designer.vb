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
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Proxy Type:"
        '
        'cboProxyType
        '
        Me.cboProxyType.FormattingEnabled = True
        Me.cboProxyType.Items.AddRange(New Object() {"None", "SOCKS4A", "SOCKS5", "HTTP"})
        Me.cboProxyType.Location = New System.Drawing.Point(82, 9)
        Me.cboProxyType.Name = "cboProxyType"
        Me.cboProxyType.Size = New System.Drawing.Size(121, 21)
        Me.cboProxyType.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Proxy Port:"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(274, 9)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(62, 21)
        Me.txtPort.TabIndex = 3
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(82, 36)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(122, 21)
        Me.txtIP.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Proxy IP:"
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOk.Location = New System.Drawing.Point(263, 150)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 6
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(82, 62)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(122, 21)
        Me.txtUser.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Proxy User:"
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(82, 88)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(122, 21)
        Me.txtPass.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Proxy Pass:"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(182, 150)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'cboLang
        '
        Me.cboLang.FormattingEnabled = True
        Me.cboLang.Items.AddRange(New Object() {"فارسی", "English"})
        Me.cboLang.Location = New System.Drawing.Point(274, 36)
        Me.cboLang.Name = "cboLang"
        Me.cboLang.Size = New System.Drawing.Size(62, 21)
        Me.cboLang.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(210, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Language:"
        '
        'txtRefresh
        '
        Me.txtRefresh.Location = New System.Drawing.Point(82, 114)
        Me.txtRefresh.Name = "txtRefresh"
        Me.txtRefresh.Size = New System.Drawing.Size(122, 21)
        Me.txtRefresh.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 117)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Refresh Time"
        '
        'frmConfig
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(350, 185)
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
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
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
