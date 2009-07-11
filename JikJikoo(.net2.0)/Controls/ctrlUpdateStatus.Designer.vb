<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlUpdateStatus
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
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.txtShorten = New System.Windows.Forms.TextBox
        Me.cboShorten = New System.Windows.Forms.ComboBox
        Me.btnShorten = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtStatus
        '
        Me.txtStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStatus.Location = New System.Drawing.Point(0, 3)
        Me.txtStatus.MaxLength = 140
        Me.txtStatus.Multiline = True
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(308, 107)
        Me.txtStatus.TabIndex = 3
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.ForeColor = System.Drawing.Color.Black
        Me.btnUpdate.Location = New System.Drawing.Point(314, 87)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(108, 25)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update Status"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'txtShorten
        '
        Me.txtShorten.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtShorten.Location = New System.Drawing.Point(0, 116)
        Me.txtShorten.Name = "txtShorten"
        Me.txtShorten.Size = New System.Drawing.Size(237, 20)
        Me.txtShorten.TabIndex = 4
        '
        'cboShorten
        '
        Me.cboShorten.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboShorten.FormattingEnabled = True
        Me.cboShorten.Items.AddRange(New Object() {"bit.ly"})
        Me.cboShorten.Location = New System.Drawing.Point(243, 115)
        Me.cboShorten.Name = "cboShorten"
        Me.cboShorten.Size = New System.Drawing.Size(65, 21)
        Me.cboShorten.TabIndex = 5
        '
        'btnShorten
        '
        Me.btnShorten.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShorten.ForeColor = System.Drawing.Color.Black
        Me.btnShorten.Location = New System.Drawing.Point(314, 114)
        Me.btnShorten.Name = "btnShorten"
        Me.btnShorten.Size = New System.Drawing.Size(108, 23)
        Me.btnShorten.TabIndex = 6
        Me.btnShorten.Text = "Shorten Url"
        Me.btnShorten.UseVisualStyleBackColor = True
        '
        'ctrlUpdateStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnShorten)
        Me.Controls.Add(Me.cboShorten)
        Me.Controls.Add(Me.txtShorten)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.btnUpdate)
        Me.Name = "ctrlUpdateStatus"
        Me.Size = New System.Drawing.Size(421, 141)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents txtShorten As System.Windows.Forms.TextBox
    Friend WithEvents cboShorten As System.Windows.Forms.ComboBox
    Friend WithEvents btnShorten As System.Windows.Forms.Button

End Class
