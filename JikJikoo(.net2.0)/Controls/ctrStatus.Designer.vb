﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        CType(Me.picUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.mnuUsername.SuspendLayout()
        Me.SuspendLayout()
        '
        'picUser
        '
        resources.ApplyResources(Me.picUser, "picUser")
        Me.picUser.Name = "picUser"
        Me.picUser.TabStop = False
        '
        'lblUserName
        '
        resources.ApplyResources(Me.lblUserName, "lblUserName")
        Me.lblUserName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblUserName.Name = "lblUserName"
        '
        'lblTime
        '
        resources.ApplyResources(Me.lblTime, "lblTime")
        Me.lblTime.Name = "lblTime"
        '
        'lnkSource
        '
        resources.ApplyResources(Me.lnkSource, "lnkSource")
        Me.lnkSource.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnkSource.Name = "lnkSource"
        Me.lnkSource.TabStop = True
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.Black
        Me.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtStatus.DetectUrls = True
        Me.txtStatus.ForeColor = System.Drawing.Color.White
        resources.ApplyResources(Me.txtStatus, "txtStatus")
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.lblUserName)
        Me.FlowLayoutPanel1.Controls.Add(Me.lnkSource)
        resources.ApplyResources(Me.FlowLayoutPanel1, "FlowLayoutPanel1")
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        '
        'mnuUsername
        '
        Me.mnuUsername.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UseToolStripMenuItem, Me.ReplyToolStripMenuItem, Me.RTToolStripMenuItem, Me.MentionsToolStripMenuItem})
        Me.mnuUsername.Name = "ContextMenuStrip1"
        resources.ApplyResources(Me.mnuUsername, "mnuUsername")
        '
        'UseToolStripMenuItem
        '
        Me.UseToolStripMenuItem.Name = "UseToolStripMenuItem"
        resources.ApplyResources(Me.UseToolStripMenuItem, "UseToolStripMenuItem")
        '
        'ReplyToolStripMenuItem
        '
        Me.ReplyToolStripMenuItem.Name = "ReplyToolStripMenuItem"
        resources.ApplyResources(Me.ReplyToolStripMenuItem, "ReplyToolStripMenuItem")
        '
        'RTToolStripMenuItem
        '
        Me.RTToolStripMenuItem.Name = "RTToolStripMenuItem"
        resources.ApplyResources(Me.RTToolStripMenuItem, "RTToolStripMenuItem")
        '
        'MentionsToolStripMenuItem
        '
        Me.MentionsToolStripMenuItem.Name = "MentionsToolStripMenuItem"
        resources.ApplyResources(Me.MentionsToolStripMenuItem, "MentionsToolStripMenuItem")
        '
        'ctrStatus
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.picUser)
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

End Class
