<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOAuth
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOAuth))
        Me.btnFinish = New System.Windows.Forms.Button
        Me.txtUrl = New System.Windows.Forms.TextBox
        Me.txtPIN = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnIE = New System.Windows.Forms.Button
        Me.btnFF = New System.Windows.Forms.Button
        Me.btnChrome = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnsafari = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnFinish
        '
        Me.btnFinish.AccessibleDescription = Nothing
        Me.btnFinish.AccessibleName = Nothing
        resources.ApplyResources(Me.btnFinish, "btnFinish")
        Me.btnFinish.BackgroundImage = Nothing
        Me.btnFinish.Font = Nothing
        Me.btnFinish.ForeColor = System.Drawing.Color.Black
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.UseVisualStyleBackColor = True
        '
        'txtUrl
        '
        Me.txtUrl.AccessibleDescription = Nothing
        Me.txtUrl.AccessibleName = Nothing
        resources.ApplyResources(Me.txtUrl, "txtUrl")
        Me.txtUrl.BackgroundImage = Nothing
        Me.txtUrl.Font = Nothing
        Me.txtUrl.Name = "txtUrl"
        '
        'txtPIN
        '
        Me.txtPIN.AccessibleDescription = Nothing
        Me.txtPIN.AccessibleName = Nothing
        resources.ApplyResources(Me.txtPIN, "txtPIN")
        Me.txtPIN.BackgroundImage = Nothing
        Me.txtPIN.Name = "txtPIN"
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = Nothing
        Me.Label1.AccessibleName = Nothing
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Font = Nothing
        Me.Label1.Name = "Label1"
        '
        'btnIE
        '
        Me.btnIE.AccessibleDescription = Nothing
        Me.btnIE.AccessibleName = Nothing
        resources.ApplyResources(Me.btnIE, "btnIE")
        Me.btnIE.BackgroundImage = Nothing
        Me.btnIE.Font = Nothing
        Me.btnIE.ForeColor = System.Drawing.Color.Black
        Me.btnIE.Name = "btnIE"
        Me.btnIE.UseVisualStyleBackColor = True
        '
        'btnFF
        '
        Me.btnFF.AccessibleDescription = Nothing
        Me.btnFF.AccessibleName = Nothing
        resources.ApplyResources(Me.btnFF, "btnFF")
        Me.btnFF.BackgroundImage = Nothing
        Me.btnFF.Font = Nothing
        Me.btnFF.ForeColor = System.Drawing.Color.Black
        Me.btnFF.Name = "btnFF"
        Me.btnFF.UseVisualStyleBackColor = True
        '
        'btnChrome
        '
        Me.btnChrome.AccessibleDescription = Nothing
        Me.btnChrome.AccessibleName = Nothing
        resources.ApplyResources(Me.btnChrome, "btnChrome")
        Me.btnChrome.BackgroundImage = Nothing
        Me.btnChrome.Font = Nothing
        Me.btnChrome.ForeColor = System.Drawing.Color.Black
        Me.btnChrome.Name = "btnChrome"
        Me.btnChrome.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = Nothing
        Me.Label2.AccessibleName = Nothing
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Font = Nothing
        Me.Label2.Name = "Label2"
        '
        'btnsafari
        '
        Me.btnsafari.AccessibleDescription = Nothing
        Me.btnsafari.AccessibleName = Nothing
        resources.ApplyResources(Me.btnsafari, "btnsafari")
        Me.btnsafari.BackgroundImage = Nothing
        Me.btnsafari.Font = Nothing
        Me.btnsafari.ForeColor = System.Drawing.Color.Black
        Me.btnsafari.Name = "btnsafari"
        Me.btnsafari.UseVisualStyleBackColor = True
        '
        'frmOAuth
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.btnsafari)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnChrome)
        Me.Controls.Add(Me.btnFF)
        Me.Controls.Add(Me.btnIE)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPIN)
        Me.Controls.Add(Me.txtUrl)
        Me.Controls.Add(Me.btnFinish)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = Nothing
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOAuth"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnFinish As System.Windows.Forms.Button
    Friend WithEvents txtUrl As System.Windows.Forms.TextBox
    Friend WithEvents txtPIN As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnIE As System.Windows.Forms.Button
    Friend WithEvents btnFF As System.Windows.Forms.Button
    Friend WithEvents btnChrome As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnsafari As System.Windows.Forms.Button
End Class
