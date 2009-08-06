Imports System.Collections.ObjectModel
Imports DNE.Twitter
Imports System.Threading

Public Class ctrStatusList

    Friend Event StartCachingImages As EventHandler
    Friend Event EndCachingImages As EventHandler
    Friend Event StartAddStatuses As EventHandler
    Friend Event EndAddStatuses As EventHandler
    Friend Event TwitCommand As TwitEventHandler
    Friend Event PagerNext As EventHandler
    Friend Event PagerPrev As EventHandler

#Region " Properties "

    Private _statuses As Collection(Of Status)
    Private _users As Collection(Of User)
    'Private _images As New Dictionary(Of String, Image)
    Private _laststatusId As Int64 = 0
    Private _page As Int32 = 1

    Friend Property Page() As Int32
        Get
            Return _page
        End Get
        Set(ByVal value As Int32)
            If _page <> value Then
                _page = value
                lblPager.Text = _page.ToString()

            End If

        End Set
    End Property

    'Friend ReadOnly Property Images() As Dictionary(Of String, Image)
    '    Get
    '        Return _images
    '    End Get
    'End Property

    Friend ReadOnly Property LastStatusId() As Int64
        Get
            Return _laststatusId
        End Get
    End Property

    Friend ReadOnly Property LastId() As String
        Get
            Return IIf(_laststatusId = 0, "", _laststatusId.ToString())
        End Get
    End Property

#End Region

#Region " Status Management "

    ''' <summary>
    ''' Add Statuses on top of prev statuses
    ''' </summary>
    ''' <param name="sts">Collection of statuses</param>
    ''' <remarks></remarks>
    Friend Sub AddStatuses(ByVal sts As Collection(Of Status))
        If sts Is Nothing OrElse sts.Count = 0 Then
            RaiseEvent EndAddStatuses(Me, Nothing)
            Exit Sub

        End If
        CashImage(sts)
        RaiseEvent StartAddStatuses(Me, Nothing)

        Thread.Sleep(50)
        Me.SuspendLayout()
        For i As Int32 = sts.Count - 1 To 0 Step -1
            AddStatusControl(sts(i))

        Next
        Me.ResumeLayout()

        If _statuses Is Nothing Then _statuses = New Collection(Of Status)
        For i As Int32 = sts.Count - 1 To 0 Step -1
            _statuses.Insert(0, sts(i))

        Next
        RaiseEvent EndAddStatuses(Me, Nothing)

    End Sub

    Private _tempstatus As Status
    Private Sub AddStatusControl(ByVal st As Status)
        If Me.InvokeRequired Then
            _tempstatus = st
            Me.Invoke(New MethodInvoker(AddressOf AddStatusControl))
        Else
            Dim c As New ctrStatus()
            c.Status = st
            Dim img As Image = Nothing
            img = CacheManager.LoadImage(st.User.Profile_image_url)
            If img Is Nothing Then twa.GetImage(st.User.Profile_image_url)
            c.picUser.Image = img
            AddHandler c.TwitEvent, AddressOf TwitEvent
            Me.pnlMain.Controls.Add(c)
            If c.ObjectId > _laststatusId Then
                _laststatusId = c.ObjectId
                pnlMain.Controls.SetChildIndex(pnlMain.Controls(pnlMain.Controls.Count - 1), 0)

            End If

        End If

    End Sub

    Private Sub AddStatusControl()
        Dim st As Status = _tempstatus
        Dim c As New ctrStatus()
        c.Status = st


        Dim img As Image = Nothing
        img = CacheManager.LoadImage(st.User.Profile_image_url)
        If img Is Nothing Then twa.GetImage(st.User.Profile_image_url)
        c.picUser.Image = img
 
        AddHandler c.TwitEvent, AddressOf TwitEvent
        Me.pnlMain.Controls.Add(c)
        If c.ObjectId > _laststatusId Then
            _laststatusId = c.ObjectId
            pnlMain.Controls.SetChildIndex(pnlMain.Controls(pnlMain.Controls.Count - 1), 0)

        End If

    End Sub

#End Region

#Region " User Management "

    ''' <summary>
    ''' Add Users on top of prev statuses
    ''' </summary>
    ''' <param name="uc">Collection of users</param>
    ''' <remarks></remarks>
    Friend Sub AddUsers(ByVal uc As Collection(Of User))
        If uc Is Nothing OrElse uc.Count = 0 Then
            RaiseEvent EndAddStatuses(Me, Nothing)
            Exit Sub

        End If
        CashImage(uc)
        RaiseEvent StartAddStatuses(Me, Nothing)

        Thread.Sleep(50)
        Me.SuspendLayout()
        For i As Int32 = uc.Count - 1 To 0 Step -1
            AddStatusControl(uc(i))

        Next
        Me.ResumeLayout()

        If _users Is Nothing Then _users = New Collection(Of User)
        For i As Int32 = uc.Count - 1 To 0 Step -1
            _users.Insert(0, uc(i))

        Next
        RaiseEvent EndAddStatuses(Me, Nothing)

    End Sub

    Private Function UsersContains(ByVal screenname As String) As Boolean
        For Each c As ctrStatus In pnlMain.Controls
            If c.User IsNot Nothing AndAlso c.User.Screen_Name = screenname Then
                Return True

            End If
        Next
        Return False

    End Function

    Private _tempuser As User
    Private Sub AddStatusControl(ByVal u As User)
        If Me.InvokeRequired Then
            _tempuser = u
            Me.Invoke(New MethodInvoker(AddressOf AddStatusControlforUser))
        Else
            If UsersContains(u.Screen_Name) Then Exit Sub
            Dim c As New ctrStatus()
            c.User = u
            Dim img As Image = Nothing
            img = CacheManager.LoadImage(u.Profile_image_url)
            If img Is Nothing Then twa.GetImage(u.Profile_image_url)
            c.picUser.Image = img

            AddHandler c.TwitEvent, AddressOf TwitEvent
            Me.pnlMain.Controls.Add(c)
            If c.ObjectId > _laststatusId Then
                _laststatusId = c.ObjectId
                pnlMain.Controls.SetChildIndex(pnlMain.Controls(pnlMain.Controls.Count - 1), 0)

            End If

        End If

    End Sub

    Private Sub AddStatusControlforUser()
        Dim u As User = _tempuser
        If UsersContains(u.Screen_Name) Then Exit Sub

        Dim c As New ctrStatus()
        c.User = u
       
        Dim img As Image = Nothing
        img = CacheManager.LoadImage(u.Profile_image_url)
        If img Is Nothing Then twa.GetImage(u.Profile_image_url)
        c.picUser.Image = img
        c.picUser.ImageLocation = u.Profile_image_url

        AddHandler c.TwitEvent, AddressOf TwitEvent
        Me.pnlMain.Controls.Add(c)
        If c.ObjectId > _laststatusId Then
            _laststatusId = c.ObjectId
            pnlMain.Controls.SetChildIndex(pnlMain.Controls(pnlMain.Controls.Count - 1), 0)

        End If

    End Sub

#End Region

#Region " Utils "

    ''' <summary>
    ''' Clear status list
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub Clear()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf Clear))
        Else
            pnlMain.Controls.Clear()
            _laststatusId = 0
            If _statuses Is Nothing Then Exit Sub
            _statuses.Clear()

        End If


    End Sub

    Friend Sub FormatStatusText(ByVal lastFormatedId As Int64)
        For i As Int32 = 0 To pnlMain.Controls.Count - 1
            Dim c As ctrStatus = pnlMain.Controls(i)
            If Not c.Formated Then
                c.FormatText()

            End If

        Next

    End Sub

    Friend Sub DateTimesUpdate()
        For Each c As ctrStatus In Me.pnlMain.Controls
            c.DateTimeUpdate()

        Next
    End Sub

    Private Sub CashImage(ByRef stti As Collection(Of Status))
        RaiseEvent StartCachingImages(Me, Nothing)
        Thread.Sleep(50)
        For i As Int32 = 0 To stti.Count - 1
            Dim img As Image = CacheManager.LoadImage(stti(i).User.Profile_image_url)
            If img Is Nothing Then
                img = twa.GetImage(stti(i).User.Profile_image_url)
                CacheManager.SaveImage(img, stti(i).User.Profile_image_url)

            End If

        Next
        RaiseEvent EndCachingImages(Me, Nothing)

    End Sub

    Private Sub CashImage(ByRef uc As Collection(Of User))
        RaiseEvent StartCachingImages(Me, Nothing)
        Thread.Sleep(50)
        For i As Int32 = 0 To uc.Count - 1
            Dim img As Image = CacheManager.LoadImage(uc(i).Profile_image_url)
            If img Is Nothing Then
                img = twa.GetImage(uc(i).Profile_image_url)
                CacheManager.SaveImage(img, uc(i).Profile_image_url)

            End If

        Next
        RaiseEvent EndCachingImages(Me, Nothing)

    End Sub

    Private Sub SetLastFirst()
        pnlMain.Controls.SetChildIndex(pnlMain.Controls(pnlMain.Controls.Count - 1), 0)

    End Sub

#End Region

#Region " Events "

    Private Sub TwitEvent(ByVal sender As Object, ByVal t As TwitEventArgs)
        RaiseEvent TwitCommand(sender, t)

    End Sub

    Private Sub lnkPrev_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkPrev.LinkClicked
        RaiseEvent PagerPrev(Me, Nothing)
        'If Page > 1 Then Page -= 1

    End Sub

    Private Sub lnkNext_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNext.LinkClicked
        RaiseEvent PagerNext(Me, Nothing)
        'Page += 1

    End Sub

#End Region

#Region " Binding "

    ''' <summary>
    ''' Bind a collection to this control
    ''' </summary>
    ''' <param name="curSttsParams"></param>
    ''' <param name="curSttsType"></param>
    ''' <param name="NewUpdate"></param>
    ''' <remarks></remarks>
    Public Sub Bind(ByRef curSttsParams As DictionaryEntry, ByVal curSttsType As StatusListType, ByRef NewUpdate As Int32)
        Dim sts As Collections.ObjectModel.Collection(Of DNE.Twitter.Status) = Nothing
        If curSttsParams.Key.ToString().Length = 0 OrElse curSttsParams.Key.ToString() = "" Then Me.Clear()
        'need to store last stored id
        Dim lid As Int64 = 0
        If Me.LastId <> "" Then lid = CLng(Me.LastId)

        'friends timeline
        If curSttsType = StatusListType.FriendsTimeLine Then
            sts = twa.GetFriendsTimeLine(Me.LastId, Page)
            If sts IsNot Nothing Then NewUpdate = sts.Count
            Me.AddStatuses(sts)

            'mentions
        ElseIf curSttsType = StatusListType.Mentions Then
            sts = twa.GetMentions(Me.LastId, Page)
            Me.AddStatuses(sts)

            'favorites
        ElseIf curSttsType = StatusListType.Favorites Then
            sts = twa.Favorites(CurrentUser.Screen_Name, Page)
            Me.AddStatuses(sts)

            'myupdates
        ElseIf curSttsType = StatusListType.MyUpdates Then
            sts = twa.GetUserTimeLine(CurrentUser.Screen_Name, Me.LastId, Page)
            Me.AddStatuses(sts)

            'userupdates
        ElseIf curSttsType = StatusListType.UserUpdates Then
            sts = twa.GetUserTimeLine(curSttsParams.Value, Me.LastId, Page)
            Me.AddStatuses(sts)

            'direct messages (inbox)
        ElseIf curSttsType = StatusListType.DirectMessages Then
            sts = Util.DirectMessage2Status(twa.DirectMessages(Me.LastId, Page), True)
            Me.AddStatuses(sts)

            'sent Messages (sent)
        ElseIf curSttsType = StatusListType.SentMessages Then
            sts = Util.DirectMessage2Status(twa.SentMessages(Me.LastId, Page), False)
            Me.AddStatuses(sts)

            'search results
        ElseIf curSttsType = StatusListType.SearchResults Then
            ' SetActiveLinkButtonColor(lnkSearch)
            sts = Util.SearchResults2Status(twa.Search(curSttsParams.Value, Page, Me.LastId))
            Me.AddStatuses(sts)

            'Friends
        ElseIf curSttsType = StatusListType.Friends Then
            Dim uc As Collection(Of DNE.Twitter.User) = twa.Friends(CurrentUser.Screen_Name, Page)
            Me.AddUsers(uc)

            'Followers
        ElseIf curSttsType = StatusListType.Followers Then
            Dim uc As Collection(Of DNE.Twitter.User) = twa.Followers(CurrentUser.Screen_Name, Page)
            Me.AddUsers(uc)

        End If
        curSttsParams.Key = Me.LastStatusId

        'Update prev statuscontrols datetime
        Me.DateTimesUpdate()
        Me.FormatStatusText(lid)


    End Sub

#End Region

End Class
