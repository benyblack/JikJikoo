﻿Imports System.Threading
Imports System.Configuration.ConfigurationManager
Imports System.Xml
Imports System.ComponentModel
Imports System.Collections.ObjectModel

Public Class frmMain

    Private t As Thread = Nothing
    Private curSttsType As DNE.JikJikoo.StatusListType = DNE.JikJikoo.StatusListType.FriendsTimeLine
    Private curSttsParams As New DictionaryEntry("", "")
    Private IsBinding As Boolean = False
    Private NewUpdate As Int32 = 0
    Private WaitingForCleanRefresh As Boolean = False
    Private _page As Int32 = 1

    Friend Property Page() As Int32
        Get
            Return _page
        End Get
        Set(ByVal value As Int32)
            If value <> _page Then
                _page = value

            End If
        End Set
    End Property

    Private Sub Bind()
        IsBinding = True
        Try
            Thread.Sleep(50)
            ' check current user
            ' if currentuser is nothing this means app not connected yet
            If CurrentUser Is Nothing Then
                SetCurrentUser()
            End If
            If Not CurrentUser Is Nothing Then
              

                Dim sts As Collections.ObjectModel.Collection(Of DNE.Twitter.Status) = Nothing
                If curSttsParams.Key.ToString().Length = 0 OrElse curSttsParams.Key.ToString() = "" Then stlMain.Clear()
                'need to store last stored id
                Dim lid As Int64 = 0
                If stlMain.LastId <> "" Then lid = CLng(stlMain.LastId)

                'friends timeline
                If curSttsType = DNE.JikJikoo.StatusListType.FriendsTimeLine Then
                    sts = twa.GetFriendsTimeLine(stlMain.LastId, Page)
                    If sts IsNot Nothing Then NewUpdate = sts.Count

                    'mentions
                ElseIf curSttsType = DNE.JikJikoo.StatusListType.Mentions Then
                    sts = twa.GetMentions(stlMain.LastId, Page)

                    'favorites
                ElseIf curSttsType = DNE.JikJikoo.StatusListType.Favorites Then
                    sts = twa.Favorites(CurrentUser.Screen_Name, Page)

                    'myupdates
                ElseIf curSttsType = DNE.JikJikoo.StatusListType.MyUpdates Then
                    sts = twa.GetUserTimeLine(CurrentUser.Screen_Name, stlMain.LastId, Page)

                    'userupdates
                ElseIf curSttsType = DNE.JikJikoo.StatusListType.UserUpdates Then
                    sts = twa.GetUserTimeLine(curSttsParams.Value, stlMain.LastId, Page)

                    'direct messages (inbox)
                ElseIf curSttsType = DNE.JikJikoo.StatusListType.DirectMessages Then
                    sts = Util.DirectMessage2Status(twa.DirectMessages(stlMain.LastId, Page))

                    'search results
                ElseIf curSttsType = DNE.JikJikoo.StatusListType.SearchResults Then
                    sts = Util.SearchResults2Status(twa.Search(curSttsParams.Value, Page, stlMain.LastId))

                ElseIf curSttsType = DNE.JikJikoo.StatusListType.Friends Then
                    Dim uc As Collection(Of DNE.Twitter.User) = twa.Friends(CurrentUser.Screen_Name, Page)
                    If uc IsNot Nothing AndAlso uc.Count > 0 Then
                        sts = New Collection(Of DNE.Twitter.Status)
                        For i As Int32 = 0 To uc.Count - 1
                            Dim tempst As New DNE.Twitter.Status()
                            If uc(i).Status IsNot Nothing Then
                                tempst = New DNE.Twitter.Status(uc(i).Status)

                            End If
                            tempst.User = uc(i)
                            sts.Add(tempst)

                        Next

                    End If

                End If
                stlMain.AddStatuses(sts)
                curSttsParams.Key = stlMain.LastStatusId

                'Update prev controls datetime
                stlMain.DateTimesUpdate()
                stlMain.FormatStatusText(lid)


            End If


        Catch ex As DNE.JikJikoo.NoConnectionException
            TimerRefresh.Enabled = True
            ShowMessage("Error in connection", "Not Connected. check your internet connection", True)
            'MsgBox("Not Connected. check your internet connection")

        End Try
        TimerRefresh.Enabled = True
        IsBinding = False

        If NewUpdate = 0 Then Exit Sub
        ShowMessage("Alert", String.Format(My.Resources.JikJikoo.NewUpdate, NewUpdate), False)
        NewUpdate = 0


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

#Region " UI "

    Private Sub TwitterApiHttpError(ByVal sender As Object, ByVal hea As DNE.JikJikoo.HttpExEventArgs)
        Dim host As String = ""
        If hea.Url <> "" Then host = New Uri(hea.Url).Host
        ShowMessage("Error in connection", hea.Message & vbCrLf & host, True)

    End Sub

    Private Sub SetUiEnable(ByVal b As Boolean)
        jikUpdate.Enabled = b
        jikUpdate.Visible = b
        stlMain.Enabled = b
        pnlMenu.Visible = b

    End Sub

    Private Sub ShowMessage(ByVal title As String, ByVal msg As String, ByVal err As Boolean)
        NotifyIcon1.ShowBalloonTip(30, title, msg, IIf(err, ToolTipIcon.Error, ToolTipIcon.Info))

    End Sub

#End Region

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
        AddHandler twa.HttpError, AddressOf TwitterApiHttpError

    End Sub

    Private Sub jikUpdate_UpdateCompleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles jikUpdate.UpdateCompleted
        Me.Text = "JikJikoo - Update Status Completed!"
        Timer1.Start()
        TimerRefresh_Tick(jikUpdate, Nothing)

    End Sub

    Private Sub TimerRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerRefresh.Tick
        If IsBinding Then
            TimerRefresh.Interval = 1000
            Exit Sub
        End If
        Dim jc As New JikConfigManager()
        TimerRefresh.Interval = jc.refresh * 1000
        If WaitingForCleanRefresh Then
            curSttsParams.Key = ""
            'curSttsParams.Value = ""
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

    Private Sub SetCurrentUser()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf SetCurrentUser))
        Else
            Dim u As DNE.Twitter.User = Nothing
            Try
                u = twa.UserShow(jikLogin.txtUid.Text)
                If u Is Nothing Then Exit Sub
                CurrentUser = u
                Dim img As Image = twa.GetImage(CurrentUser.Profile_image_url)
                If img IsNot Nothing Then jikLogin.picUser.Image = img
                'lblUser.Text = CurrentUser.Screen_Name
                lnkMentions.Text = "@" & CurrentUser.Screen_Name
                jikLogin.SetLastUpdateText(CurrentUser.Status.Text)

            Catch ex As DNE.JikJikoo.NoConnectionException
                ShowMessage("Error in connection", "Not Connected. Can not receive user information.", True)
                Exit Sub

            End Try

        End If

    End Sub

    Private Sub jikLogin_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles jikLogin.Login
        Dim ace As New AppConfig()
        SetUiEnable(True)
        ReloadConfig()
        SetCurrentUser()

        Application.DoEvents()
        TimerRefresh_Tick(Me, Nothing)
        TimerRefresh.Interval = CInt(ace.GetValue("refresh")) * 1000
        TimerRefresh.Enabled = True

    End Sub

    Private Sub jikLogin_Logout(ByVal sender As Object, ByVal e As System.EventArgs)
        TimerRefresh.Enabled = False
        SetUiEnable(False)
        stlMain.Clear()
        'lblUser.Text = ""

    End Sub

#End Region

#Region " Status List Events "

    Private Sub stlMain_EndAddStatuses(ByVal sender As Object, ByVal e As System.EventArgs) Handles stlMain.EndAddStatuses
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf EndAddStatuses))
        Else
            Me.Text = "JikJikoo"
        End If
    End Sub

    Private Sub stlMain_EndCachingImages(ByVal sender As Object, ByVal e As System.EventArgs) Handles stlMain.EndCachingImages
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf EndCachingImages))
        Else
            Me.Text = "JikJikoo - " & My.Resources.JikJikoo.CachingImageEnd
        End If
    End Sub

    Private Sub stlMain_TwitCommand(ByVal sender As Object, ByVal t As TwitEventArgs) Handles stlMain.TwitCommand
        jikUpdate.in_reply_to_status_id = ""
        If t.TwitEvent = TwitEvents.Use_ScreenName Then
            jikUpdate.txtStatus.Paste("@" & t.Text)

        ElseIf t.TwitEvent = TwitEvents.RT Then
            jikUpdate.txtStatus.Text = "RT @" & t.Status.User.Screen_Name & " " & t.Status.Text

        ElseIf t.TwitEvent = TwitEvents.Reply Then
            jikUpdate.in_reply_to_status_id = t.Status.Id
            jikUpdate.in_reply_to_screen_name = t.Status.User.Screen_Name
            jikUpdate.txtStatus.Text = "@" & t.Status.User.Screen_Name

        ElseIf t.TwitEvent = TwitEvents.UserStatuses Then
            curSttsParams.Value = t.Text
            curSttsParams.Key = ""
            WaitingForCleanRefresh = True

            curSttsType = DNE.JikJikoo.StatusListType.UserUpdates
            TimerRefresh_Tick(Me, Nothing)

        ElseIf t.TwitEvent = TwitEvents.SearchTags Then
            curSttsParams.Value = "%23" & t.Text
            curSttsParams.Key = ""
            WaitingForCleanRefresh = True
            txtSearch.Text = "#" & t.Text
            curSttsType = DNE.JikJikoo.StatusListType.SearchResults
            TimerRefresh_Tick(Me, Nothing)
            lnkSearchLinks_LinkClicked(Nothing, Nothing)

        End If
    End Sub

    Private Sub stlMain_PagerPrev(ByVal sender As Object, ByVal e As System.EventArgs) Handles stlMain.PagerPrev
        If Page > 1 Then Page -= 1
        SetBindingInfo(curSttsType, False, curSttsParams.Key, curSttsParams.Value)

    End Sub

    Private Sub stlMain_PagerNext(ByVal sender As Object, ByVal e As System.EventArgs) Handles stlMain.PagerNext
        Page += 1
        SetBindingInfo(curSttsType, False, curSttsParams.Key, curSttsParams.Value)

    End Sub

    Private Sub stlMain_StartAddStatuses(ByVal sender As Object, ByVal e As System.EventArgs) Handles stlMain.StartAddStatuses
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf StartAddStatuses))
        Else
            Me.Text = "JikJikoo - " & My.Resources.JikJikoo.AddStatusStart
        End If
    End Sub

    Private Sub stlMain_StartCachingImages(ByVal sender As Object, ByVal e As System.EventArgs) Handles stlMain.StartCachingImages
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf StartCachingImages))
        Else
            Me.Text = "JikJikoo - " & My.Resources.JikJikoo.CashingImageStart
        End If

    End Sub

    Private Sub DownloadStart(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf DownloadStart))
        Else
            Me.Text = "JikJikoo - " & My.Resources.JikJikoo.DownloadDataStart

        End If

    End Sub

    Private Sub DownloadEnd(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf DownloadEnd))
        Else
            Me.Text = "JikJikoo - " & My.Resources.JikJikoo.DownloadDataEnd
        End If
    End Sub

    Private Sub DownloadStart()
        Me.Text = "JikJikoo - " & My.Resources.JikJikoo.DownloadDataStart

    End Sub

    Private Sub EndCachingImages()
        Me.Text = "JikJikoo - " & My.Resources.JikJikoo.CachingImageEnd

    End Sub


    Private Sub StartAddStatuses()
        Me.Text = "JikJikoo - " & My.Resources.JikJikoo.AddStatusStart

    End Sub

    Private Sub EndAddStatuses()
        Me.Text = "JikJikoo"

    End Sub

    Private Sub StartCachingImages()
        Me.Text = "JikJikoo - " & My.Resources.JikJikoo.CashingImageStart
        Threading.Thread.Sleep(25)


    End Sub

    Private Sub DownloadEnd()
        Me.Text = "JikJikoo - " & My.Resources.JikJikoo.DownloadDataEnd

    End Sub

#End Region

#Region " LinkButtons "

    Friend Sub SetBindingInfo(ByVal sltype As DNE.JikJikoo.StatusListType, Optional ByVal CheckCurSLType As Boolean = True, Optional ByVal key As String = "", Optional ByVal value As String = "")
        If CheckCurSLType Then
            If curSttsType <> sltype Then
                curSttsParams = New DictionaryEntry(key, value)
                WaitingForCleanRefresh = True
                curSttsType = sltype
                Page = 1
                stlMain.Page = 1

            End If
        Else
            curSttsParams = New DictionaryEntry(key, value)
            WaitingForCleanRefresh = True
            curSttsType = sltype

        End If

        TimerRefresh_Tick(Me, Nothing)

    End Sub

    Private Sub lnkFriendsTimeLine_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFriendsTimeLine.LinkClicked
        stlMain.Page = 1
        SetBindingInfo(DNE.JikJikoo.StatusListType.FriendsTimeLine)

    End Sub

    Private Sub lnkMentions_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkMentions.LinkClicked
        stlMain.Page = 1
        SetBindingInfo(DNE.JikJikoo.StatusListType.Mentions)

    End Sub

    Private Sub lnkMessages_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkMessages.LinkClicked
        stlMain.Page = 1
        SetBindingInfo(DNE.JikJikoo.StatusListType.DirectMessages)

    End Sub

    Private Sub lnkFavorites_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFavorites.LinkClicked
        stlMain.Page = 1
        SetBindingInfo(DNE.JikJikoo.StatusListType.Favorites)

    End Sub

    Private Sub lnkMyUpdates_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkMyUpdates.LinkClicked
        stlMain.Page = 1
        SetBindingInfo(DNE.JikJikoo.StatusListType.MyUpdates)

    End Sub

    Private Sub lnkSearch_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSearch.LinkClicked
        stlMain.Page = 1
        SetBindingInfo(DNE.JikJikoo.StatusListType.SearchResults, False, "", txtSearch.Text.Trim().Replace("#", "%23"))

    End Sub

    Private Sub lnkSearchLinks_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSearchLinks.LinkClicked
        pnlSearch.Location = pnlMenu.Location
        pnlSearch.Visible = True
        pnlMenu.Visible = False

    End Sub

    Private Sub lnkBrowsLinks_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkBrowsLinks.LinkClicked
        pnlMenu.Location = pnlSearch.Location
        pnlSearch.Visible = False
        pnlMenu.Visible = True
    End Sub

    Private Sub lnkFriends_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkFriends.LinkClicked
        stlMain.Page = 1
        SetBindingInfo(DNE.JikJikoo.StatusListType.Friends)

    End Sub

#End Region

#Region " NotifyIcon & Context Menu"

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        If Me.Visible Then
            Me.Hide()

        Else
            Me.Show()

        End If

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

#End Region

   
End Class
