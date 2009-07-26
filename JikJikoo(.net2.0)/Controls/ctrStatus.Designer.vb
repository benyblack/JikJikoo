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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrStatus))
        Me.picUser = New System.Windows.Forms.PictureBox
        Me.lblUserName = New System.Windows.Forms.Label
        Me.lblTime = New System.Windows.Forms.Label
        Me.lnkSource = New System.Windows.Forms.LinkLabel
        Me.txtStatus = New RichTextBoxLinks.RichTextBoxEx
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.mnuUsername = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReplyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MentionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SendDirectMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.picUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.mnuUsername.SuspendLayout()
        Me.SuspendLayout()
        '
        'picUser
        '
        Me.picUser.AccessibleDescription = Nothing
        Me.picUser.AccessibleName = Nothing
        resources.ApplyResources(Me.picUser, "picUser")
        Me.picUser.BackgroundImage = Nothing
        Me.picUser.Font = Nothing
        Me.picUser.ImageLocation = Nothing
        Me.picUser.Name = "picUser"
        Me.picUser.TabStop = False
        '
        'lblUserName
        '
        Me.lblUserName.AccessibleDescription = Nothing
        Me.lblUserName.AccessibleName = Nothing
        resources.ApplyResources(Me.lblUserName, "lblUserName")
        Me.lblUserName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblUserName.Name = "lblUserName"
        '
        'lblTime
        '
        Me.lblTime.AccessibleDescription = Nothing
        Me.lblTime.AccessibleName = Nothing
        resources.ApplyResources(Me.lblTime, "lblTime")
        Me.lblTime.Name = "lblTime"
        '
        'lnkSource
        '
        Me.lnkSource.AccessibleDescription = Nothing
        Me.lnkSource.AccessibleName = Nothing
        resources.ApplyResources(Me.lnkSource, "lnkSource")
        Me.lnkSource.Font = Nothing
        Me.lnkSource.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkSource.Name = "lnkSource"
        Me.lnkSource.TabStop = True
        '
        'txtStatus
        '
        Me.txtStatus.AccessibleDescription = Nothing
        Me.txtStatus.AccessibleName = Nothing
        resources.ApplyResources(Me.txtStatus, "txtStatus")
        Me.txtStatus.BackColor = System.Drawing.Color.Black
        Me.txtStatus.BackgroundImage = Nothing
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtStatus.DetectUrls = True
        Me.txtStatus.Font = Nothing
        Me.txtStatus.ForeColor = System.Drawing.Color.White
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AccessibleDescription = Nothing
        Me.FlowLayoutPanel1.AccessibleName = Nothing
        resources.ApplyResources(Me.FlowLayoutPanel1, "FlowLayoutPanel1")
        Me.FlowLayoutPanel1.BackgroundImage = Nothing
        Me.FlowLayoutPanel1.Controls.Add(Me.lblUserName)
        Me.FlowLayoutPanel1.Controls.Add(Me.lnkSource)
        Me.FlowLayoutPanel1.Font = Nothing
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        '
        'mnuUsername
        '
        Me.mnuUsername.AccessibleDescription = Nothing
        Me.mnuUsername.AccessibleName = Nothing
        resources.ApplyResources(Me.mnuUsername, "mnuUsername")
        Me.mnuUsername.BackColor = System.Drawing.Color.Black
        Me.mnuUsername.BackgroundImage = Nothing
        Me.mnuUsername.Font = Nothing
        Me.mnuUsername.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UseToolStripMenuItem, Me.ReplyToolStripMenuItem, Me.RTToolStripMenuItem, Me.MentionsToolStripMenuItem, Me.SendDirectMessageToolStripMenuItem})
        Me.mnuUsername.Name = "ContextMenuStrip1"
        Me.mnuUsername.ShowImageMargin = False
        '
        'UseToolStripMenuItem
        '
        Me.UseToolStripMenuItem.AccessibleDescription = Nothing
        Me.UseToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.UseToolStripMenuItem, "UseToolStripMenuItem")
        Me.UseToolStripMenuItem.BackgroundImage = Nothing
        Me.UseToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.UseToolStripMenuItem.Name = "UseToolStripMenuItem"
        Me.UseToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'ReplyToolStripMenuItem
        '
        Me.ReplyToolStripMenuItem.AccessibleDescription = Nothing
        Me.ReplyToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.ReplyToolStripMenuItem, "ReplyToolStripMenuItem")
        Me.ReplyToolStripMenuItem.BackgroundImage = Nothing
        Me.ReplyToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ReplyToolStripMenuItem.Name = "ReplyToolStripMenuItem"
        Me.ReplyToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'RTToolStripMenuItem
        '
        Me.RTToolStripMenuItem.AccessibleDescription = Nothing
        Me.RTToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.RTToolStripMenuItem, "RTToolStripMenuItem")
        Me.RTToolStripMenuItem.BackgroundImage = Nothing
        Me.RTToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.RTToolStripMenuItem.Name = "RTToolStripMenuItem"
        Me.RTToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'MentionsToolStripMenuItem
        '
        Me.MentionsToolStripMenuItem.AccessibleDescription = Nothing
        Me.MentionsToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.MentionsToolStripMenuItem, "MentionsToolStripMenuItem")
        Me.MentionsToolStripMenuItem.BackgroundImage = Nothing
        Me.MentionsToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.MentionsToolStripMenuItem.Name = "MentionsToolStripMenuItem"
        Me.MentionsToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'SendDirectMessageToolStripMenuItem
        '
        Me.SendDirectMessageToolStripMenuItem.AccessibleDescription = Nothing
        Me.SendDirectMessageToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.SendDirectMessageToolStripMenuItem, "SendDirectMessageToolStripMenuItem")
        Me.SendDirectMessageToolStripMenuItem.BackgroundImage = Nothing
        Me.SendDirectMessageToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.SendDirectMessageToolStripMenuItem.Name = "SendDirectMessageToolStripMenuItem"
        Me.SendDirectMessageToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'ctrStatus
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.picUser)
        Me.Font = Nothing
        Me.Name = "ctrStatus"
        CType(Me.picUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.mnuUsername.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picUser As System.Windows.Forms.PictureBox
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents txtStatus As RichTextBoxLinks.RichTextBoxEx
    Friend WithEvents lnkSource As System.Windows.Forms.LinkLabel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents mnuUsername As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ReplyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MentionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SendDirectMessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
