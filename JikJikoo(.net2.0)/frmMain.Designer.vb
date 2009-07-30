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
        resources.ApplyResources(Me.lnkFriendsTimeLine, "lnkFriendsTimeLine")
        Me.lnkFriendsTimeLine.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkFriendsTimeLine.LinkColor = System.Drawing.Color.Chartreuse
        Me.lnkFriendsTimeLine.Name = "lnkFriendsTimeLine"
        Me.lnkFriendsTimeLine.TabStop = True
        '
        'lnkMentions
        '
        resources.ApplyResources(Me.lnkMentions, "lnkMentions")
        Me.lnkMentions.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkMentions.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkMentions.Name = "lnkMentions"
        Me.lnkMentions.TabStop = True
        '
        'lnkMessages
        '
        resources.ApplyResources(Me.lnkMessages, "lnkMessages")
        Me.lnkMessages.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkMessages.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkMessages.Name = "lnkMessages"
        Me.lnkMessages.TabStop = True
        '
        'lnkFavorites
        '
        resources.ApplyResources(Me.lnkFavorites, "lnkFavorites")
        Me.lnkFavorites.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkFavorites.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkFavorites.Name = "lnkFavorites"
        Me.lnkFavorites.TabStop = True
        '
        'lnkMyUpdates
        '
        Me.lnkMyUpdates.AutoEllipsis = True
        resources.ApplyResources(Me.lnkMyUpdates, "lnkMyUpdates")
        Me.lnkMyUpdates.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkMyUpdates.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkMyUpdates.Name = "lnkMyUpdates"
        Me.lnkMyUpdates.TabStop = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        resources.ApplyResources(Me.NotifyIcon1, "NotifyIcon1")
        '
        'ContextMenuStrip1
        '
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HideToolStripMenuItem, Me.ShowToolStripMenuItem, Me.ToolStripSeparator1, Me.AboutToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        '
        'HideToolStripMenuItem
        '
        Me.HideToolStripMenuItem.Name = "HideToolStripMenuItem"
        resources.ApplyResources(Me.HideToolStripMenuItem, "HideToolStripMenuItem")
        '
        'ShowToolStripMenuItem
        '
        Me.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem"
        resources.ApplyResources(Me.ShowToolStripMenuItem, "ShowToolStripMenuItem")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        resources.ApplyResources(Me.AboutToolStripMenuItem, "AboutToolStripMenuItem")
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        resources.ApplyResources(Me.ExitToolStripMenuItem, "ExitToolStripMenuItem")
        '
        'pnlMenu
        '
        Me.pnlMenu.Controls.Add(Me.lnkSent)
        Me.pnlMenu.Controls.Add(Me.lnkSearchLinks)
        Me.pnlMenu.Controls.Add(Me.lnkFriendsTimeLine)
        Me.pnlMenu.Controls.Add(Me.lnkMentions)
        Me.pnlMenu.Controls.Add(Me.lnkMessages)
        Me.pnlMenu.Controls.Add(Me.lnkFavorites)
        Me.pnlMenu.Controls.Add(Me.lnkMyUpdates)
        resources.ApplyResources(Me.pnlMenu, "pnlMenu")
        Me.pnlMenu.Name = "pnlMenu"
        '
        'lnkSent
        '
        resources.ApplyResources(Me.lnkSent, "lnkSent")
        Me.lnkSent.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkSent.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkSent.Name = "lnkSent"
        Me.lnkSent.TabStop = True
        '
        'lnkSearchLinks
        '
        Me.lnkSearchLinks.AutoEllipsis = True
        resources.ApplyResources(Me.lnkSearchLinks, "lnkSearchLinks")
        Me.lnkSearchLinks.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkSearchLinks.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkSearchLinks.Name = "lnkSearchLinks"
        Me.lnkSearchLinks.TabStop = True
        '
        'lnkFriends
        '
        Me.lnkFriends.AutoEllipsis = True
        resources.ApplyResources(Me.lnkFriends, "lnkFriends")
        Me.lnkFriends.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkFriends.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkFriends.Name = "lnkFriends"
        Me.lnkFriends.TabStop = True
        '
        'lnkFollowers
        '
        Me.lnkFollowers.AutoEllipsis = True
        resources.ApplyResources(Me.lnkFollowers, "lnkFollowers")
        Me.lnkFollowers.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkFollowers.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkFollowers.Name = "lnkFollowers"
        Me.lnkFollowers.TabStop = True
        '
        'lnkSearch
        '
        Me.lnkSearch.AutoEllipsis = True
        resources.ApplyResources(Me.lnkSearch, "lnkSearch")
        Me.lnkSearch.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkSearch.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkSearch.Name = "lnkSearch"
        Me.lnkSearch.TabStop = True
        '
        'pnlSearch
        '
        Me.pnlSearch.Controls.Add(Me.lnkFollowers)
        Me.pnlSearch.Controls.Add(Me.lnkFriends)
        Me.pnlSearch.Controls.Add(Me.txtSearch)
        Me.pnlSearch.Controls.Add(Me.lnkBrowsLinks)
        Me.pnlSearch.Controls.Add(Me.lnkSearch)
        resources.ApplyResources(Me.pnlSearch, "pnlSearch")
        Me.pnlSearch.Name = "pnlSearch"
        '
        'txtSearch
        '
        resources.ApplyResources(Me.txtSearch, "txtSearch")
        Me.txtSearch.Name = "txtSearch"
        '
        'lnkBrowsLinks
        '
        Me.lnkBrowsLinks.AutoEllipsis = True
        resources.ApplyResources(Me.lnkBrowsLinks, "lnkBrowsLinks")
        Me.lnkBrowsLinks.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.lnkBrowsLinks.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkBrowsLinks.Name = "lnkBrowsLinks"
        Me.lnkBrowsLinks.TabStop = True
        '
        'picStatus
        '
        resources.ApplyResources(Me.picStatus, "picStatus")
        Me.picStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picStatus.Image = Global.JikJikoo.My.Resources.Resources.status
        Me.picStatus.Name = "picStatus"
        Me.picStatus.TabStop = False
        Me.tip1.SetToolTip(Me.picStatus, resources.GetString("picStatus.ToolTip"))
        '
        'picSetting
        '
        resources.ApplyResources(Me.picSetting, "picSetting")
        Me.picSetting.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picSetting.Name = "picSetting"
        Me.picSetting.TabStop = False
        Me.tip1.SetToolTip(Me.picSetting, resources.GetString("picSetting.ToolTip"))
        '
        'picUser
        '
        resources.ApplyResources(Me.picUser, "picUser")
        Me.picUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picUser.Image = Global.JikJikoo.My.Resources.Resources.user
        Me.picUser.Name = "picUser"
        Me.picUser.TabStop = False
        Me.tip1.SetToolTip(Me.picUser, resources.GetString("picUser.ToolTip"))
        '
        'jikUpdate
        '
        resources.ApplyResources(Me.jikUpdate, "jikUpdate")
        Me.jikUpdate.DirectMessage = False
        Me.jikUpdate.in_reply_to_screen_name = ""
        Me.jikUpdate.in_reply_to_status_id = ""
        Me.jikUpdate.Name = "jikUpdate"
        Me.jikUpdate.SendMessageTo = ""
        '
        'jikLogin
        '
        Me.jikLogin.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.jikLogin, "jikLogin")
        Me.jikLogin.Name = "jikLogin"
        '
        'stlMain
        '
        resources.ApplyResources(Me.stlMain, "stlMain")
        Me.stlMain.Name = "stlMain"
        '
        'frmMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.jikUpdate)
        Me.Controls.Add(Me.jikLogin)
        Me.Controls.Add(Me.pnlSearch)
        Me.Controls.Add(Me.picSetting)
        Me.Controls.Add(Me.picUser)
        Me.Controls.Add(Me.stlMain)
        Me.Controls.Add(Me.picStatus)
        Me.Controls.Add(Me.pnlMenu)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "frmMain"
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
