<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrStatus
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
        Me.picUser = New System.Windows.Forms.PictureBox
        Me.lblUserName = New System.Windows.Forms.Label
        Me.lblTime = New System.Windows.Forms.Label
        Me.txtStatus = New RichTextBoxLinks.RichTextBoxEx
        CType(Me.picUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picUser
        '
        Me.picUser.Location = New System.Drawing.Point(3, 3)
        Me.picUser.Name = "picUser"
        Me.picUser.Size = New System.Drawing.Size(48, 48)
        Me.picUser.TabIndex = 0
        Me.picUser.TabStop = False
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblUserName.Location = New System.Drawing.Point(57, 3)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(45, 13)
        Me.lblUserName.TabIndex = 1
        Me.lblUserName.Text = "Label1"
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblTime.Location = New System.Drawing.Point(143, 3)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(39, 13)
        Me.lblTime.TabIndex = 3
        Me.lblTime.Text = "Label1"
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.Black
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtStatus.DetectUrls = True
        Me.txtStatus.ForeColor = System.Drawing.Color.White
        Me.txtStatus.Location = New System.Drawing.Point(60, 19)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(287, 48)
        Me.txtStatus.TabIndex = 4
        Me.txtStatus.Text = ""
        '
        'ctrStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.picUser)
        Me.Name = "ctrStatus"
        Me.Size = New System.Drawing.Size(350, 70)
        CType(Me.picUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picUser As System.Windows.Forms.PictureBox
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents txtStatus As RichTextBoxLinks.RichTextBoxEx

End Class
