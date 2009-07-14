<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
    '<System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TimerRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.btnConfig = New System.Windows.Forms.Button
        Me.picUser = New System.Windows.Forms.PictureBox
        Me.lblUser = New System.Windows.Forms.Label
        Me.lnkFriendsTimeLine = New System.Windows.Forms.LinkLabel
        Me.lnkMentions = New System.Windows.Forms.LinkLabel
        Me.lnkMessages = New System.Windows.Forms.LinkLabel
        Me.lnkFavorites = New System.Windows.Forms.LinkLabel
        Me.lnkMyUpdates = New System.Windows.Forms.LinkLabel
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.pnlMenu = New System.Windows.Forms.Panel
        Me.txtStatus = New RichTextBoxLinks.RichTextBoxEx
        Me.jikLogin = New JikJikoo.ctrLogin
        Me.stlMain = New JikJikoo.ctrStatusList
        Me.jikUpdate = New JikJikoo.ctrlUpdateStatus
        CType(Me.picUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.pnlMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 3000
        '
        'TimerRefresh
        '
        '
        'btnConfig
        '
        Me.btnConfig.AccessibleDescription = Nothing
        Me.btnConfig.AccessibleName = Nothing
        resources.ApplyResources(Me.btnConfig, "btnConfig")
        Me.btnConfig.BackgroundImage = Nothing
        Me.btnConfig.Font = Nothing
        Me.btnConfig.ForeColor = System.Drawing.Color.Black
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.UseVisualStyleBackColor = True
        '
        'picUser
        '
        Me.picUser.AccessibleDescription = Nothing
        Me.picUser.AccessibleName = Nothing
        resources.ApplyResources(Me.picUser, "picUser")
        Me.picUser.BackColor = System.Drawing.Color.Black
        Me.picUser.BackgroundImage = Nothing
        Me.picUser.Font = Nothing
        Me.picUser.ImageLocation = Nothing
        Me.picUser.Name = "picUser"
        Me.picUser.TabStop = False
        '
        'lblUser
        '
        Me.lblUser.AccessibleDescription = Nothing
        Me.lblUser.AccessibleName = Nothing
        resources.ApplyResources(Me.lblUser, "lblUser")
        Me.lblUser.Name = "lblUser"
        '
        'lnkFriendsTimeLine
        '
        Me.lnkFriendsTimeLine.AccessibleDescription = Nothing
        Me.lnkFriendsTimeLine.AccessibleName = Nothing
        resources.ApplyResources(Me.lnkFriendsTimeLine, "lnkFriendsTimeLine")
        Me.lnkFriendsTimeLine.Font = Nothing
        Me.lnkFriendsTimeLine.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkFriendsTimeLine.Name = "lnkFriendsTimeLine"
        Me.lnkFriendsTimeLine.TabStop = True
        '
        'lnkMentions
        '
        Me.lnkMentions.AccessibleDescription = Nothing
        Me.lnkMentions.AccessibleName = Nothing
        resources.ApplyResources(Me.lnkMentions, "lnkMentions")
        Me.lnkMentions.Font = Nothing
        Me.lnkMentions.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkMentions.Name = "lnkMentions"
        Me.lnkMentions.TabStop = True
        '
        'lnkMessages
        '
        Me.lnkMessages.AccessibleDescription = Nothing
        Me.lnkMessages.AccessibleName = Nothing
        resources.ApplyResources(Me.lnkMessages, "lnkMessages")
        Me.lnkMessages.Font = Nothing
        Me.lnkMessages.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkMessages.Name = "lnkMessages"
        Me.lnkMessages.TabStop = True
        '
        'lnkFavorites
        '
        Me.lnkFavorites.AccessibleDescription = Nothing
        Me.lnkFavorites.AccessibleName = Nothing
        resources.ApplyResources(Me.lnkFavorites, "lnkFavorites")
        Me.lnkFavorites.Font = Nothing
        Me.lnkFavorites.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkFavorites.Name = "lnkFavorites"
        Me.lnkFavorites.TabStop = True
        '
        'lnkMyUpdates
        '
        Me.lnkMyUpdates.AccessibleDescription = Nothing
        Me.lnkMyUpdates.AccessibleName = Nothing
        resources.ApplyResources(Me.lnkMyUpdates, "lnkMyUpdates")
        Me.lnkMyUpdates.Font = Nothing
        Me.lnkMyUpdates.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkMyUpdates.Name = "lnkMyUpdates"
        Me.lnkMyUpdates.TabStop = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        resources.ApplyResources(Me.NotifyIcon1, "NotifyIcon1")
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.AccessibleDescription = Nothing
        Me.ContextMenuStrip1.AccessibleName = Nothing
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        Me.ContextMenuStrip1.BackgroundImage = Nothing
        Me.ContextMenuStrip1.Font = Nothing
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HideToolStripMenuItem, Me.ShowToolStripMenuItem, Me.ToolStripSeparator1, Me.AboutToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        '
        'HideToolStripMenuItem
        '
        Me.HideToolStripMenuItem.AccessibleDescription = Nothing
        Me.HideToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.HideToolStripMenuItem, "HideToolStripMenuItem")
        Me.HideToolStripMenuItem.BackgroundImage = Nothing
        Me.HideToolStripMenuItem.Name = "HideToolStripMenuItem"
        Me.HideToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'ShowToolStripMenuItem
        '
        Me.ShowToolStripMenuItem.AccessibleDescription = Nothing
        Me.ShowToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.ShowToolStripMenuItem, "ShowToolStripMenuItem")
        Me.ShowToolStripMenuItem.BackgroundImage = Nothing
        Me.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem"
        Me.ShowToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.AccessibleDescription = Nothing
        Me.ToolStripSeparator1.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.AccessibleDescription = Nothing
        Me.AboutToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.AboutToolStripMenuItem, "AboutToolStripMenuItem")
        Me.AboutToolStripMenuItem.BackgroundImage = Nothing
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.AccessibleDescription = Nothing
        Me.ExitToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.ExitToolStripMenuItem, "ExitToolStripMenuItem")
        Me.ExitToolStripMenuItem.BackgroundImage = Nothing
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'pnlMenu
        '
        Me.pnlMenu.AccessibleDescription = Nothing
        Me.pnlMenu.AccessibleName = Nothing
        resources.ApplyResources(Me.pnlMenu, "pnlMenu")
        Me.pnlMenu.BackgroundImage = Nothing
        Me.pnlMenu.Controls.Add(Me.lnkFriendsTimeLine)
        Me.pnlMenu.Controls.Add(Me.lnkMentions)
        Me.pnlMenu.Controls.Add(Me.lnkMessages)
        Me.pnlMenu.Controls.Add(Me.lnkFavorites)
        Me.pnlMenu.Controls.Add(Me.lnkMyUpdates)
        Me.pnlMenu.Font = Nothing
        Me.pnlMenu.Name = "pnlMenu"
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
        '
        'jikLogin
        '
        Me.jikLogin.AccessibleDescription = Nothing
        Me.jikLogin.AccessibleName = Nothing
        resources.ApplyResources(Me.jikLogin, "jikLogin")
        Me.jikLogin.BackColor = System.Drawing.Color.Transparent
        Me.jikLogin.BackgroundImage = Nothing
        Me.jikLogin.Font = Nothing
        Me.jikLogin.Name = "jikLogin"
        '
        'stlMain
        '
        Me.stlMain.AccessibleDescription = Nothing
        Me.stlMain.AccessibleName = Nothing
        resources.ApplyResources(Me.stlMain, "stlMain")
        Me.stlMain.BackgroundImage = Nothing
        Me.stlMain.Font = Nothing
        Me.stlMain.Name = "stlMain"
        Me.stlMain.Statuses = Nothing
        '
        'jikUpdate
        '
        Me.jikUpdate.AccessibleDescription = Nothing
        Me.jikUpdate.AccessibleName = Nothing
        resources.ApplyResources(Me.jikUpdate, "jikUpdate")
        Me.jikUpdate.BackgroundImage = Nothing
        Me.jikUpdate.Font = Nothing
        Me.jikUpdate.Name = "jikUpdate"
        '
        'frmMain
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.pnlMenu)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.btnConfig)
        Me.Controls.Add(Me.jikLogin)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.picUser)
        Me.Controls.Add(Me.stlMain)
        Me.Controls.Add(Me.jikUpdate)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "frmMain"
        CType(Me.picUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.pnlMenu.ResumeLayout(False)
        Me.pnlMenu.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents jikLogin As JikJikoo.ctrLogin
    Friend WithEvents stlMain As JikJikoo.ctrStatusList
    Friend WithEvents jikUpdate As JikJikoo.ctrlUpdateStatus
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TimerRefresh As System.Windows.Forms.Timer
    Friend WithEvents btnConfig As System.Windows.Forms.Button
    Friend WithEvents picUser As System.Windows.Forms.PictureBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lnkFriendsTimeLine As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkMentions As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkMessages As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkFavorites As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkMyUpdates As System.Windows.Forms.LinkLabel
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents HideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtStatus As RichTextBoxLinks.RichTextBoxEx
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
End Class
