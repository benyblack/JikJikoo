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
        Me.btnFinish.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFinish.ForeColor = System.Drawing.Color.Black
        Me.btnFinish.Location = New System.Drawing.Point(226, 118)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.Size = New System.Drawing.Size(113, 23)
        Me.btnFinish.TabIndex = 0
        Me.btnFinish.Text = "Paste && &Finish"
        Me.btnFinish.UseVisualStyleBackColor = True
        '
        'txtUrl
        '
        Me.txtUrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUrl.Location = New System.Drawing.Point(12, 73)
        Me.txtUrl.Name = "txtUrl"
        Me.txtUrl.Size = New System.Drawing.Size(526, 21)
        Me.txtUrl.TabIndex = 1
        '
        'txtPIN
        '
        Me.txtPIN.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPIN.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtPIN.Location = New System.Drawing.Point(111, 162)
        Me.txtPIN.Name = "txtPIN"
        Me.txtPIN.Size = New System.Drawing.Size(329, 63)
        Me.txtPIN.TabIndex = 2
        Me.txtPIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(529, 48)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Please paste this url in browser and complete steps then paste PIN code in second" & _
            " textbox"
        '
        'btnIE
        '
        Me.btnIE.ForeColor = System.Drawing.Color.Black
        Me.btnIE.Location = New System.Drawing.Point(102, 44)
        Me.btnIE.Name = "btnIE"
        Me.btnIE.Size = New System.Drawing.Size(75, 23)
        Me.btnIE.TabIndex = 4
        Me.btnIE.Text = "IE"
        Me.btnIE.UseVisualStyleBackColor = True
        '
        'btnFF
        '
        Me.btnFF.ForeColor = System.Drawing.Color.Black
        Me.btnFF.Location = New System.Drawing.Point(183, 44)
        Me.btnFF.Name = "btnFF"
        Me.btnFF.Size = New System.Drawing.Size(75, 23)
        Me.btnFF.TabIndex = 5
        Me.btnFF.Text = "FireFox"
        Me.btnFF.UseVisualStyleBackColor = True
        '
        'btnChrome
        '
        Me.btnChrome.ForeColor = System.Drawing.Color.Black
        Me.btnChrome.Location = New System.Drawing.Point(264, 44)
        Me.btnChrome.Name = "btnChrome"
        Me.btnChrome.Size = New System.Drawing.Size(75, 23)
        Me.btnChrome.TabIndex = 6
        Me.btnChrome.Text = "Chrome"
        Me.btnChrome.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Open url with:"
        '
        'btnsafari
        '
        Me.btnsafari.ForeColor = System.Drawing.Color.Black
        Me.btnsafari.Location = New System.Drawing.Point(345, 44)
        Me.btnsafari.Name = "btnsafari"
        Me.btnsafari.Size = New System.Drawing.Size(75, 23)
        Me.btnsafari.TabIndex = 8
        Me.btnsafari.Text = "Safari"
        Me.btnsafari.UseVisualStyleBackColor = True
        '
        'frmOAuth
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(550, 248)
        Me.Controls.Add(Me.btnsafari)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnChrome)
        Me.Controls.Add(Me.btnFF)
        Me.Controls.Add(Me.btnIE)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPIN)
        Me.Controls.Add(Me.txtUrl)
        Me.Controls.Add(Me.btnFinish)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOAuth"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "oAuth on Twitter"
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
