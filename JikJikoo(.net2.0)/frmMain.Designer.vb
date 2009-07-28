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
        Me.lnkSent = New System.Windows.Forms.LinkLabel
        Me.lnkSearchLinks = New System.Windows.Forms.LinkLabel
        Me.lnkFriends = New System.Windows.Forms.LinkLabel
        Me.lnkFollowers = New System.Windows.Forms.LinkLabel
        Me.lnkSearch = New System.Windows.Forms.LinkLabel
        Me.pnlSearch = New System.Windows.Forms.Panel
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.lnkBrowsLinks = New System.Windows.Forms.LinkLabel
        Me.picStatus = New System.Windows.Forms.PictureBox
        Me.picSetting = New System.Windows.Forms.PictureBox
        Me.picUser = New System.Windows.Forms.PictureBox
        Me.tip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.jikUpdate = New JikJikoo.ctrlUpdateStatus
        Me.jikLogin = New JikJikoo.ctrLoginOAuth
        Me.stlMain = New JikJikoo.ctrStatusList
        Me.ContextMenuStrip1.SuspendLayout()
        Me.pnlMenu.SuspendLayout()
        Me.pnlSearch.SuspendLayout()
        CType(Me.picStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSetting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 3000
        '
        'TimerRefresh
        '
        '
        'lnkFriendsTimeLine
        '
        Me.lnkFriendsTimeLine.AccessibleDescription = Nothing
        Me.lnkFriendsTimeLine.AccessibleName = Nothing
        resources.ApplyResources(Me.lnkFriendsTimeLine, "lnkFriendsTimeLine")
        Me.lnkFriendsTimeLine.Font = Nothing
        Me.lnkFriendsTimeLine.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkFriendsTimeLine.LinkColor = System.Drawing.Color.Chartreuse
        Me.lnkFriendsTimeLine.Name = "lnkFriendsTimeLine"
        Me.lnkFriendsTimeLine.TabStop = True
        Me.tip1.SetToolTip(Me.lnkFriendsTimeLine, resources.GetString("lnkFriendsTimeLine.ToolTip"))
        '
        'lnkMentions
        '
        Me.lnkMentions.AccessibleDescription = Nothing
        Me.lnkMentions.AccessibleName = Nothing
        resources.ApplyResources(Me.lnkMentions, "lnkMentions")
        Me.lnkMentions.Font = Nothing
        Me.lnkMentions.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkMentions.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkMentions.Name = "lnkMentions"
        Me.lnkMentions.TabStop = True
        Me.tip1.SetToolTip(Me.lnkMentions, resources.GetString("lnkMentions.ToolTip"))
        '
        'lnkMessages
        '
        Me.lnkMessages.AccessibleDescription = Nothing
        Me.lnkMessages.AccessibleName = Nothing
        resources.ApplyResources(Me.lnkMessages, "lnkMessages")
        Me.lnkMessages.Font = Nothing
        Me.lnkMessages.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkMessages.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkMessages.Name = "lnkMessages"
        Me.lnkMessages.TabStop = True
        Me.tip1.SetToolTip(Me.lnkMessages, resources.GetString("lnkMessages.ToolTip"))
        '
        'lnkFavorites
        '
        Me.lnkFavorites.AccessibleDescription = Nothing
        Me.lnkFavorites.AccessibleName = Nothing
        resources.ApplyResources(Me.lnkFavorites, "lnkFavorites")
        Me.lnkFavorites.Font = Nothing
        Me.lnkFavorites.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkFavorites.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkFavorites.Name = "lnkFavorites"
        Me.lnkFavorites.TabStop = True
        Me.tip1.SetToolTip(Me.lnkFavorites, resources.GetString("lnkFavorites.ToolTip"))
        '
        'lnkMyUpdates
        '
        Me.lnkMyUpdates.AccessibleDescription = Nothing
        Me.lnkMyUpdates.AccessibleName = Nothing
        resources.ApplyResources(Me.lnkMyUpdates, "lnkMyUpdates")
        Me.lnkMyUpdates.AutoEllipsis = True
        Me.lnkMyUpdates.Font = Nothing
        Me.lnkMyUpdates.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkMyUpdates.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkMyUpdates.Name = "lnkMyUpdates"
        Me.lnkMyUpdates.TabStop = True
        Me.tip1.SetToolTip(Me.lnkMyUpdates, resources.GetString("lnkMyUpdates.ToolTip"))
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
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HideToolStripMenuItem, Me.ShowToolStripMenuItem, Me.ToolStripSeparator1, Me.AboutToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.tip1.SetToolTip(Me.ContextMenuStrip1, resources.GetString("ContextMenuStrip1.ToolTip"))
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
        Me.pnlMenu.Controls.Add(Me.lnkSent)
        Me.pnlMenu.Controls.Add(Me.lnkSearchLinks)
        Me.pnlMenu.Controls.Add(Me.lnkFriendsTimeLine)
        Me.pnlMenu.Controls.Add(Me.lnkMentions)
        Me.pnlMenu.Controls.Add(Me.lnkMessages)
        Me.pnlMenu.Controls.Add(Me.lnkFavorites)
        Me.pnlMenu.Controls.Add(Me.lnkMyUpdates)
        Me.pnlMenu.Font = Nothing
        Me.pnlMenu.Name = "pnlMenu"
        Me.tip1.SetToolTip(Me.pnlMenu, resources.GetString("pnlMenu.ToolTip"))
        '
        'lnkSent
        '
        Me.lnkSent.AccessibleDescription = Nothing
        Me.lnkSent.AccessibleName = Nothing
        resources.ApplyResources(Me.lnkSent, "lnkSent")
        Me.lnkSent.Font = Nothing
        Me.lnkSent.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkSent.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkSent.Name = "lnkSent"
        Me.lnkSent.TabStop = True
        Me.tip1.SetToolTip(Me.lnkSent, resources.GetString("lnkSent.ToolTip"))
        '
        'lnkSearchLinks
        '
        Me.lnkSearchLinks.AccessibleDescription = Nothing
        Me.lnkSearchLinks.AccessibleName = Nothing
        resources.ApplyResources(Me.lnkSearchLinks, "lnkSearchLinks")
        Me.lnkSearchLinks.AutoEllipsis = True
        Me.lnkSearchLinks.Font = Nothing
        Me.lnkSearchLinks.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkSearchLinks.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkSearchLinks.Name = "lnkSearchLinks"
        Me.lnkSearchLinks.TabStop = True
        Me.tip1.SetToolTip(Me.lnkSearchLinks, resources.GetString("lnkSearchLinks.ToolTip"))
        '
        'lnkFriends
        '
        Me.lnkFriends.AccessibleDescription = Nothing
        Me.lnkFriends.AccessibleName = Nothing
        resources.ApplyResources(Me.lnkFriends, "lnkFriends")
        Me.lnkFriends.AutoEllipsis = True
        Me.lnkFriends.Font = Nothing
        Me.lnkFriends.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkFriends.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkFriends.Name = "lnkFriends"
        Me.lnkFriends.TabStop = True
        Me.tip1.SetToolTip(Me.lnkFriends, resources.GetString("lnkFriends.ToolTip"))
        '
        'lnkFollowers
        '
        Me.lnkFollowers.AccessibleDescription = Nothing
        Me.lnkFollowers.AccessibleName = Nothing
        resources.ApplyResources(Me.lnkFollowers, "lnkFollowers")
        Me.lnkFollowers.AutoEllipsis = True
        Me.lnkFollowers.Font = Nothing
        Me.lnkFollowers.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkFollowers.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkFollowers.Name = "lnkFollowers"
        Me.lnkFollowers.TabStop = True
        Me.tip1.SetToolTip(Me.lnkFollowers, resources.GetString("lnkFollowers.ToolTip"))
        '
        'lnkSearch
        '
        Me.lnkSearch.AccessibleDescription = Nothing
        Me.lnkSearch.AccessibleName = Nothing
        resources.ApplyResources(Me.lnkSearch, "lnkSearch")
        Me.lnkSearch.AutoEllipsis = True
        Me.lnkSearch.Font = Nothing
        Me.lnkSearch.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkSearch.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkSearch.Name = "lnkSearch"
        Me.lnkSearch.TabStop = True
        Me.tip1.SetToolTip(Me.lnkSearch, resources.GetString("lnkSearch.ToolTip"))
        '
        'pnlSearch
        '
        Me.pnlSearch.AccessibleDescription = Nothing
        Me.pnlSearch.AccessibleName = Nothing
        resources.ApplyResources(Me.pnlSearch, "pnlSearch")
        Me.pnlSearch.BackgroundImage = Nothing
        Me.pnlSearch.Controls.Add(Me.lnkFollowers)
        Me.pnlSearch.Controls.Add(Me.lnkFriends)
        Me.pnlSearch.Controls.Add(Me.txtSearch)
        Me.pnlSearch.Controls.Add(Me.lnkBrowsLinks)
        Me.pnlSearch.Controls.Add(Me.lnkSearch)
        Me.pnlSearch.Font = Nothing
        Me.pnlSearch.Name = "pnlSearch"
        Me.tip1.SetToolTip(Me.pnlSearch, resources.GetString("pnlSearch.ToolTip"))
        '
        'txtSearch
        '
        Me.txtSearch.AccessibleDescription = Nothing
        Me.txtSearch.AccessibleName = Nothing
        resources.ApplyResources(Me.txtSearch, "txtSearch")
        Me.txtSearch.BackgroundImage = Nothing
        Me.txtSearch.Font = Nothing
        Me.txtSearch.Name = "txtSearch"
        Me.tip1.SetToolTip(Me.txtSearch, resources.GetString("txtSearch.ToolTip"))
        '
        'lnkBrowsLinks
        '
        Me.lnkBrowsLinks.AccessibleDescription = Nothing
        Me.lnkBrowsLinks.AccessibleName = Nothing
        resources.ApplyResources(Me.lnkBrowsLinks, "lnkBrowsLinks")
        Me.lnkBrowsLinks.AutoEllipsis = True
        Me.lnkBrowsLinks.Font = Nothing
        Me.lnkBrowsLinks.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkBrowsLinks.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkBrowsLinks.Name = "lnkBrowsLinks"
        Me.lnkBrowsLinks.TabStop = True
        Me.tip1.SetToolTip(Me.lnkBrowsLinks, resources.GetString("lnkBrowsLinks.ToolTip"))
        '
        'picStatus
        '
        Me.picStatus.AccessibleDescription = Nothing
        Me.picStatus.AccessibleName = Nothing
        resources.ApplyResources(Me.picStatus, "picStatus")
        Me.picStatus.BackgroundImage = Nothing
        Me.picStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picStatus.Font = Nothing
        Me.picStatus.Image = Global.JikJikoo.My.Resources.Resources.status
        Me.picStatus.ImageLocation = Nothing
        Me.picStatus.Name = "picStatus"
        Me.picStatus.TabStop = False
        Me.tip1.SetToolTip(Me.picStatus, resources.GetString("picStatus.ToolTip"))
        '
        'picSetting
        '
        Me.picSetting.AccessibleDescription = Nothing
        Me.picSetting.AccessibleName = Nothing
        resources.ApplyResources(Me.picSetting, "picSetting")
        Me.picSetting.BackgroundImage = Nothing
        Me.picSetting.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picSetting.Font = Nothing
        Me.picSetting.ImageLocation = Nothing
        Me.picSetting.Name = "picSetting"
        Me.picSetting.TabStop = False
        Me.tip1.SetToolTip(Me.picSetting, resources.GetString("picSetting.ToolTip"))
        '
        'picUser
        '
        Me.picUser.AccessibleDescription = Nothing
        Me.picUser.AccessibleName = Nothing
        resources.ApplyResources(Me.picUser, "picUser")
        Me.picUser.BackgroundImage = Nothing
        Me.picUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picUser.Font = Nothing
        Me.picUser.Image = Global.JikJikoo.My.Resources.Resources.user
        Me.picUser.ImageLocation = Nothing
        Me.picUser.Name = "picUser"
        Me.picUser.TabStop = False
        Me.tip1.SetToolTip(Me.picUser, resources.GetString("picUser.ToolTip"))
        '
        'jikUpdate
        '
        Me.jikUpdate.AccessibleDescription = Nothing
        Me.jikUpdate.AccessibleName = Nothing
        resources.ApplyResources(Me.jikUpdate, "jikUpdate")
        Me.jikUpdate.BackgroundImage = Nothing
        Me.jikUpdate.DirectMessage = False
        Me.jikUpdate.Font = Nothing
        Me.jikUpdate.in_reply_to_screen_name = ""
        Me.jikUpdate.in_reply_to_status_id = ""
        Me.jikUpdate.Name = "jikUpdate"
        Me.jikUpdate.SendMessageTo = ""
        Me.tip1.SetToolTip(Me.jikUpdate, resources.GetString("jikUpdate.ToolTip"))
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
        Me.tip1.SetToolTip(Me.jikLogin, resources.GetString("jikLogin.ToolTip"))
        '
        'stlMain
        '
        Me.stlMain.AccessibleDescription = Nothing
        Me.stlMain.AccessibleName = Nothing
        resources.ApplyResources(Me.stlMain, "stlMain")
        Me.stlMain.BackgroundImage = Nothing
        Me.stlMain.Font = Nothing
        Me.stlMain.Name = "stlMain"
        Me.tip1.SetToolTip(Me.stlMain, resources.GetString("stlMain.ToolTip"))
        '
        'frmMain
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.jikUpdate)
        Me.Controls.Add(Me.jikLogin)
        Me.Controls.Add(Me.pnlSearch)
        Me.Controls.Add(Me.picUser)
        Me.Controls.Add(Me.picSetting)
        Me.Controls.Add(Me.picStatus)
        Me.Controls.Add(Me.stlMain)
        Me.Controls.Add(Me.pnlMenu)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "frmMain"
        Me.tip1.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.pnlMenu.ResumeLayout(False)
        Me.pnlMenu.PerformLayout()
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        CType(Me.picStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSetting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents stlMain As JikJikoo.ctrStatusList
    Friend WithEvents jikUpdate As JikJikoo.ctrlUpdateStatus
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TimerRefresh As System.Windows.Forms.Timer
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
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
    Friend WithEvents jikLogin As JikJikoo.ctrLoginOAuth
    Friend WithEvents lnkSearch As System.Windows.Forms.LinkLabel
    Friend WithEvents pnlSearch As System.Windows.Forms.Panel
    Friend WithEvents lnkBrowsLinks As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkSearchLinks As System.Windows.Forms.LinkLabel
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lnkFollowers As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkFriends As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkSent As System.Windows.Forms.LinkLabel
    Friend WithEvents picStatus As System.Windows.Forms.PictureBox
    Friend WithEvents picSetting As System.Windows.Forms.PictureBox
    Friend WithEvents picUser As System.Windows.Forms.PictureBox
    Friend WithEvents tip1 As System.Windows.Forms.ToolTip
End Class
