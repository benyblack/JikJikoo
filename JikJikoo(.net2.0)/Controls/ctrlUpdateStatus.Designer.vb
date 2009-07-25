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
        resources.ApplyResources(Me.txtStatus, "txtStatus")
        Me.txtStatus.Name = "txtStatus"
        '
        'btnUpdate
        '
        resources.ApplyResources(Me.btnUpdate, "btnUpdate")
        Me.btnUpdate.ForeColor = System.Drawing.Color.Black
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'txtShorten
        '
        resources.ApplyResources(Me.txtShorten, "txtShorten")
        Me.txtShorten.Name = "txtShorten"
        '
        'cboShorten
        '
        resources.ApplyResources(Me.cboShorten, "cboShorten")
        Me.cboShorten.FormattingEnabled = True
        Me.cboShorten.Items.AddRange(New Object() {resources.GetString("cboShorten.Items"), resources.GetString("cboShorten.Items1"), resources.GetString("cboShorten.Items2"), resources.GetString("cboShorten.Items3"), resources.GetString("cboShorten.Items4"), resources.GetString("cboShorten.Items5")})
        Me.cboShorten.Name = "cboShorten"
        '
        'btnShorten
        '
        resources.ApplyResources(Me.btnShorten, "btnShorten")
        Me.btnShorten.ForeColor = System.Drawing.Color.Black
        Me.btnShorten.Name = "btnShorten"
        Me.btnShorten.UseVisualStyleBackColor = True
        '
        'ctrlUpdateStatus
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
