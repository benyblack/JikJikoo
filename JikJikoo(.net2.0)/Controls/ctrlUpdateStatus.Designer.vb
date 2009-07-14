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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrlUpdateStatus))
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.txtShorten = New System.Windows.Forms.TextBox
        Me.cboShorten = New System.Windows.Forms.ComboBox
        Me.btnShorten = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtStatus
        '
        Me.txtStatus.AccessibleDescription = Nothing
        Me.txtStatus.AccessibleName = Nothing
        resources.ApplyResources(Me.txtStatus, "txtStatus")
        Me.txtStatus.BackgroundImage = Nothing
        Me.txtStatus.Font = Nothing
        Me.txtStatus.Name = "txtStatus"
        '
        'btnUpdate
        '
        Me.btnUpdate.AccessibleDescription = Nothing
        Me.btnUpdate.AccessibleName = Nothing
        resources.ApplyResources(Me.btnUpdate, "btnUpdate")
        Me.btnUpdate.BackgroundImage = Nothing
        Me.btnUpdate.Font = Nothing
        Me.btnUpdate.ForeColor = System.Drawing.Color.Black
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'txtShorten
        '
        Me.txtShorten.AccessibleDescription = Nothing
        Me.txtShorten.AccessibleName = Nothing
        resources.ApplyResources(Me.txtShorten, "txtShorten")
        Me.txtShorten.BackgroundImage = Nothing
        Me.txtShorten.Font = Nothing
        Me.txtShorten.Name = "txtShorten"
        '
        'cboShorten
        '
        Me.cboShorten.AccessibleDescription = Nothing
        Me.cboShorten.AccessibleName = Nothing
        resources.ApplyResources(Me.cboShorten, "cboShorten")
        Me.cboShorten.BackgroundImage = Nothing
        Me.cboShorten.Font = Nothing
        Me.cboShorten.FormattingEnabled = True
        Me.cboShorten.Items.AddRange(New Object() {resources.GetString("cboShorten.Items")})
        Me.cboShorten.Name = "cboShorten"
        '
        'btnShorten
        '
        Me.btnShorten.AccessibleDescription = Nothing
        Me.btnShorten.AccessibleName = Nothing
        resources.ApplyResources(Me.btnShorten, "btnShorten")
        Me.btnShorten.BackgroundImage = Nothing
        Me.btnShorten.Font = Nothing
        Me.btnShorten.ForeColor = System.Drawing.Color.Black
        Me.btnShorten.Name = "btnShorten"
        Me.btnShorten.UseVisualStyleBackColor = True
        '
        'ctrlUpdateStatus
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.btnShorten)
        Me.Controls.Add(Me.cboShorten)
        Me.Controls.Add(Me.txtShorten)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.btnUpdate)
        Me.Name = "ctrlUpdateStatus"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents txtShorten As System.Windows.Forms.TextBox
    Friend WithEvents cboShorten As System.Windows.Forms.ComboBox
    Friend WithEvents btnShorten As System.Windows.Forms.Button

End Class
