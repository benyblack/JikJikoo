<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrUploadFile
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
        Me.btnUpload = New System.Windows.Forms.Button
        Me.txtFile = New System.Windows.Forms.TextBox
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.txtOut = New System.Windows.Forms.TextBox
        Me.prgUpload = New System.Windows.Forms.ProgressBar
        Me.SuspendLayout()
        '
        'btnUpload
        '
        Me.btnUpload.Enabled = False
        Me.btnUpload.ForeColor = System.Drawing.Color.Black
        Me.btnUpload.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnUpload.Location = New System.Drawing.Point(314, 29)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(108, 23)
        Me.btnUpload.TabIndex = 8
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'txtFile
        '
        Me.txtFile.BackColor = System.Drawing.Color.White
        Me.txtFile.Location = New System.Drawing.Point(0, 3)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.ReadOnly = True
        Me.txtFile.Size = New System.Drawing.Size(308, 20)
        Me.txtFile.TabIndex = 7
        '
        'btnBrowse
        '
        Me.btnBrowse.ForeColor = System.Drawing.Color.Black
        Me.btnBrowse.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBrowse.Location = New System.Drawing.Point(314, 3)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(108, 23)
        Me.btnBrowse.TabIndex = 8
        Me.btnBrowse.Text = "&Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtOut
        '
        Me.txtOut.BackColor = System.Drawing.Color.White
        Me.txtOut.Location = New System.Drawing.Point(0, 29)
        Me.txtOut.Name = "txtOut"
        Me.txtOut.ReadOnly = True
        Me.txtOut.Size = New System.Drawing.Size(308, 20)
        Me.txtOut.TabIndex = 10
        '
        'prgUpload
        '
        Me.prgUpload.Location = New System.Drawing.Point(0, 55)
        Me.prgUpload.Name = "prgUpload"
        Me.prgUpload.Size = New System.Drawing.Size(422, 23)
        Me.prgUpload.TabIndex = 11
        '
        'ctrUploadFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.prgUpload)
        Me.Controls.Add(Me.txtOut)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.btnUpload)
        Me.Controls.Add(Me.txtFile)
        Me.Name = "ctrUploadFile"
        Me.Size = New System.Drawing.Size(425, 88)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents txtFile As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtOut As System.Windows.Forms.TextBox
    Friend WithEvents prgUpload As System.Windows.Forms.ProgressBar

End Class
