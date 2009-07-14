﻿Imports System.Threading
Imports System.Configuration.ConfigurationManager
Imports System.Xml
Imports System.ComponentModel

Public Class frmMain

    Private t As Thread = Nothing
    Private rm As New System.ComponentModel.ComponentResourceManager(Me.GetType)
    Private curSttsType As DNE.JikJikoo.StatusListType = DNE.JikJikoo.StatusListType.FriendsTimeLine
    Private curSttsParams() As String = {""}
    Private IsBinding As Boolean = False
    Private NewUpdate As Int32 = 0
    Private WaitingForCleanRefresh As Boolean = False

    Private Sub Bind()
        IsBinding = True
        Thread.Sleep(50)
        TimerRefresh.Enabled = False
        Dim sts As Collections.ObjectModel.Collection(Of DNE.Twitter.Status) = Nothing
        If curSttsParams Is Nothing OrElse curSttsParams.Length = 0 OrElse curSttsParams(0) = "" Then stlMain.Clear()

        If curSttsType = DNE.JikJikoo.StatusListType.FriendsTimeLine Then
            sts = twa.GetFriendsTimeLine(stlMain.LastId)
            NewUpdate = sts.Count

        ElseIf curSttsType = DNE.JikJikoo.StatusListType.Mentions Then
            sts = twa.GetMentions(stlMain.LastId)


        ElseIf curSttsType = DNE.JikJikoo.StatusListType.Favorites Then
            sts = twa.Favorites(stlMain.LastId)


        ElseIf curSttsType = DNE.JikJikoo.StatusListType.MyUpdates Then
            sts = twa.GetUserTimeLine(stlMain.LastId)

        ElseIf curSttsType = DNE.JikJikoo.StatusListType.UserUpdates Then
            sts = twa.GetUserTimeLine(curSttsParams(1), stlMain.LastId)

        ElseIf curSttsType = DNE.JikJikoo.StatusListType.DirectMessages Then
            sts = Util.DirectMessage2Status(twa.DirectMessages(stlMain.LastId))


        End If
        stlMain.AddStatuses(sts)
        curSttsParams = New String() {stlMain.LastStatusId}
        'Update prev controls datetime
        stlMain.DateTimesUpdate()

        TimerRefresh.Enabled = True
        IsBinding = False

        If NewUpdate = 0 Then Exit Sub
        NotifyIcon1.BalloonTipText = NewUpdate.ToString & " " & rm.GetString("NewUpdate", (New JikConfigManager()).CultureInfo)
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon1.ShowBalloonTip(1000)

    End Sub

    Private Sub ReloadConfig()
        Try
            Dim jcm As New JikConfigManager()
            twa = New DNE.JikJikoo.TwitterApi(jcm.user, jcm.Token, jcm.TokenSecret)
            twa.ConfigProxy(CInt(jcm.proxytype), CInt(jcm.proxyport), jcm.proxyserver, jcm.proxyuser, jcm.proxypass)
            TimerRefresh.Interval = CInt(jcm.refresh) * 1000
            AddHandler twa.DownloadingDataStart, AddressOf DownloadStart
            AddHandler twa.DownloadingDataEnd, AddressOf DownloadEnd
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub SetUiEnable(ByVal b As Boolean)
        jikUpdate.Enabled = b
        jikUpdate.Visible = b
        stlMain.Enabled = b
        pnlMenu.Visible = b

    End Sub

#Region " Form Events "

    Private Sub btnConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfig.Click
        Dim f As New frmConfig()
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ReloadConfig()
        End If


    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()

        End If

    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReloadConfig()
        jikLogin.LoadLogin()

    End Sub

    Private Sub jikUpdate_UpdateCompleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles jikUpdate.UpdateCompleted
        Me.Text = "JikJikoo - Update Status Completed!"
        Timer1.Start()
        TimerRefresh_Tick(jikUpdate, Nothing)

    End Sub

    Private Sub CtrlUpdateStatus1_UpdateStarted(ByVal sender As Object, ByVal e As System.EventArgs) Handles jikUpdate.UpdateStarted
        TimerRefresh.Enabled = False

    End Sub

    Private Sub TimerRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerRefresh.Tick
        If IsBinding Then
            TimerRefresh.Interval = 1000
            Exit Sub
        End If
        Dim jc As New JikConfigManager()
        TimerRefresh.Interval = jc.refresh * 1000
        If WaitingForCleanRefresh Then
            curSttsParams = New String() {""}
            WaitingForCleanRefresh = False
        End If
        t = New Thread(AddressOf Bind)
        t.Start()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Text = "JikJikoo"
        Timer1.Stop()

    End Sub

#End Region

#Region " Login Events "

    Private Sub CtrLogin1_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles jikLogin.Login
        Dim ace As New AppConfig()
        SetUiEnable(True)
        ReloadConfig()
        Dim u As DNE.Twitter.User = twa.UserShow(jikLogin.txtUid.Text)
        CurrentUser = u
        picUser.Image = twa.GetImage(CurrentUser.Profile_image_url)
        lblUser.Text = CurrentUser.Screen_Name
        SetLastUpdateText(CurrentUser.Status.Text)

        Application.DoEvents()

        TimerRefresh_Tick(Me, Nothing)

        TimerRefresh.Interval = CInt(ace.GetValue("refresh")) * 1000
        TimerRefresh.Enabled = False

    End Sub

    Private Sub CtrLogin1_Logout(ByVal sender As Object, ByVal e As System.EventArgs) Handles jikLogin.Logout
        TimerRefresh.Enabled = False
        SetUiEnable(False)
        stlMain.Clear()
        picUser.Image = Nothing
        lblUser.Text = ""

    End Sub

#End Region

#Region " Status List Events "

    Private Sub CtrStatusList1_EndAddStatuses(ByVal sender As Object, ByVal e As System.EventArgs) Handles stlMain.EndAddStatuses
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf EndAddStatuses))
        Else
            Me.Text = "JikJikoo"
        End If
    End Sub

    Private Sub CtrStatusList1_EndCachingImages(ByVal sender As Object, ByVal e As System.EventArgs) Handles stlMain.EndCachingImages
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf EndCachingImages))
        Else
            Me.Text = "JikJikoo - " & rm.GetString("CachingImageEnd")
        End If
    End Sub

    Private Sub CtrStatusList1_ReplyCommand(ByVal sender As Object, ByVal rea As ReplyEventArgs) Handles stlMain.ReplyCommand
        jikUpdate.txtStatus.Text = "@" & rea.ReplyTo
    End Sub

    Private Sub CtrStatusList1_StartAddStatuses(ByVal sender As Object, ByVal e As System.EventArgs) Handles stlMain.StartAddStatuses
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf StartAddStatuses))
        Else
            Me.Text = "JikJikoo - " & rm.GetString("AddStatusStart")
        End If
    End Sub

    Private Sub CtrStatusList1_StartCachingImages(ByVal sender As Object, ByVal e As System.EventArgs) Handles stlMain.StartCachingImages
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf StartCachingImages))
        Else
            Me.Text = "JikJikoo - " & rm.GetString("CashingImageStart")
        End If

    End Sub

    Private Sub DownloadStart(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf DownloadStart))
        Else
            Me.Text = "JikJikoo - " & rm.GetString("DownloadDataStart")

        End If

    End Sub

    Private Sub DownloadEnd(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf DownloadEnd))
        Else
            Me.Text = "JikJikoo - " & rm.GetString("DownloadDataEnd")
            Timer1.Start()
        End If
    End Sub

    Private Sub DownloadStart()
        Me.Text = "JikJikoo - " & rm.GetString("DownloadDataStart")

    End Sub

    Private Sub EndCachingImages()
        Me.Text = "JikJikoo - " & rm.GetString("CachingImageEnd")

    End Sub


    Private Sub StartAddStatuses()
        Me.Text = "JikJikoo - " & rm.GetString("AddStatusStart")

    End Sub

    Private Sub EndAddStatuses()
        Me.Text = "JikJikoo"
        TimerRefresh.Enabled = True

    End Sub

    Private Sub StartCachingImages()
        Me.Text = "JikJikoo - " & rm.GetString("CashingImageStart")
        Threading.Thread.Sleep(25)


    End Sub

    Private Sub DownloadEnd()
        Me.Text = "JikJikoo - " & rm.GetString("DownloadDataEnd")

    End Sub

#End Region

    Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        jikLogin.SetSize()

    End Sub

    Private Sub lnkFriendsTimeLine_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFriendsTimeLine.LinkClicked
        If curSttsType <> DNE.JikJikoo.StatusListType.FriendsTimeLine Then
            curSttsParams = New String() {""}
            WaitingForCleanRefresh = True

        End If
        curSttsType = DNE.JikJikoo.StatusListType.FriendsTimeLine
        TimerRefresh_Tick(Me, Nothing)

    End Sub

    Private Sub lnkMentions_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkMentions.LinkClicked
        If curSttsType <> DNE.JikJikoo.StatusListType.Mentions Then
            curSttsParams = New String() {""}
            WaitingForCleanRefresh = True

        End If
        curSttsType = DNE.JikJikoo.StatusListType.Mentions
        TimerRefresh_Tick(Me, Nothing)

    End Sub

    Private Sub lnkMessages_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkMessages.LinkClicked
        If curSttsType <> DNE.JikJikoo.StatusListType.DirectMessages Then
            curSttsParams = New String() {""}
            WaitingForCleanRefresh = True

        End If
        curSttsType = DNE.JikJikoo.StatusListType.DirectMessages
        TimerRefresh_Tick(Me, Nothing)

    End Sub

    Private Sub lnkFavorites_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFavorites.LinkClicked
        If curSttsType <> DNE.JikJikoo.StatusListType.Favorites Then
            curSttsParams = New String() {""}
            WaitingForCleanRefresh = True

        End If
        curSttsType = DNE.JikJikoo.StatusListType.Favorites
        TimerRefresh_Tick(Me, Nothing)

    End Sub

    Private Sub lnkMyUpdates_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkMyUpdates.LinkClicked
        If curSttsType <> DNE.JikJikoo.StatusListType.MyUpdates Then
            curSttsParams = New String() {""}
            WaitingForCleanRefresh = True

        End If
        curSttsType = DNE.JikJikoo.StatusListType.MyUpdates
        TimerRefresh_Tick(Me, Nothing)

    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        If Me.Visible Then
            Me.Hide()

        Else
            Me.Show()

        End If

    End Sub

    Private Sub SetLastUpdateText(ByVal s As String)
        If Util.ContainRtlChars(s) Then
            txtStatus.RightToLeft = Windows.Forms.RightToLeft.Yes

        Else
            txtStatus.RightToLeft = Windows.Forms.RightToLeft.No

        End If
        txtStatus.Text = s

    End Sub

    Private Sub HideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideToolStripMenuItem.Click
        Me.Hide()

    End Sub

    Private Sub ShowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowToolStripMenuItem.Click
        Me.Show()

    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim f As New AboutBox1()
        f.ShowDialog()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        If t IsNot Nothing Then
            t.Abort()

        End If
        NotifyIcon1.Visible = False
        Application.DoEvents()
        Application.Exit()

    End Sub

End Class
