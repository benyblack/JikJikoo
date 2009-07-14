Imports System.Collections.ObjectModel
Imports DNE.Twitter
Imports System.Threading

Public Class ctrStatusList

    Public Event StartCachingImages As EventHandler
    Public Event EndCachingImages As EventHandler
    Public Event StartAddStatuses As EventHandler
    Public Event EndAddStatuses As EventHandler
    Public Event ReplyCommand As ReplyEventHandler


    Private _statuses As Collection(Of Status)
    Private _images As New Dictionary(Of String, Image)
    Private _laststatusId As Int64 = 0

    ''' <summary>
    ''' Collection of status objects.
    ''' when you set this property
    ''' status controls will be added to panel
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Statuses() As Collection(Of Status)
        Get
            Return _statuses
        End Get
        Set(ByVal value As Collection(Of Status))
            _statuses = value
            If _statuses Is Nothing OrElse _statuses.Count = 0 Then
                RaiseEvent EndAddStatuses(Me, Nothing)
                Exit Property
            End If
            Me.pnlMain.Controls.Clear()

        End Set
    End Property

    Public ReadOnly Property Images() As Dictionary(Of String, Image)
        Get
            Return _images
        End Get
    End Property

    Public ReadOnly Property LastStatusId() As Int64
        Get
            Return _laststatusId
        End Get
    End Property

    Public ReadOnly Property LastId() As String
        Get
            Return IIf(_laststatusId = 0, "", _laststatusId.ToString())
        End Get
    End Property

    ''' <summary>
    ''' Clear status list
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf Clear))
        Else
            pnlMain.Controls.Clear()
            _laststatusId = 0
            If _statuses Is Nothing Then Exit Sub
            _statuses.Clear()

        End If


    End Sub

    ''' <summary>
    ''' Add Statuses on top of prev statuses
    ''' </summary>
    ''' <param name="sts">Collection of statuses</param>
    ''' <remarks></remarks>
    Public Sub AddStatuses(ByVal sts As Collection(Of Status))
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
        For i As Int32 = sts.Count - 1 To 0
            _statuses.Insert(0, sts(i))

        Next
        RaiseEvent EndAddStatuses(Me, Nothing)

    End Sub

    Private Sub SetLastFirst()
        pnlMain.Controls.SetChildIndex(pnlMain.Controls(pnlMain.Controls.Count - 1), 0)

    End Sub

    Private _tempstatus As Status
    Private Sub AddStatusControl(ByVal st As Status)
        If Me.InvokeRequired Then
            _tempstatus = st
            Me.Invoke(New MethodInvoker(AddressOf AddStatusControl))
        Else
            'Dim st As Status = _tempstatus
            Dim c As New ctrStatus()
            c.Status = st
            'If st.numId > _laststatusId Then _laststatusId = st.numId
            If Images.Count > 0 AndAlso Images.ContainsKey(st.User.Profile_image_url) Then
                c.picUser.Image = Images(st.User.Profile_image_url)

            Else
                Dim img As Image = twa.GetImage(st.User.Profile_image_url)
                Me.Images.Add(st.User.Profile_image_url, img)
                c.picUser.Image = img

            End If
            AddHandler c.ReplyCommand, AddressOf Reply
            Me.pnlMain.Controls.Add(c)
            If c.Status.numId > _laststatusId Then
                _laststatusId = c.Status.numId
                pnlMain.Controls.SetChildIndex(pnlMain.Controls(pnlMain.Controls.Count - 1), 0)

            End If

            'Dim c As New ctrStatus()
            'c.Status = st
            'If st.numId > _laststatusId Then _laststatusId = CLng(st.Id)
            'If Images.ContainsKey(st.User.Profile_image_url) Then
            '    c.picUser.Image = Images(st.User.Profile_image_url)
            'Else
            '    Dim img As Image = twa.GetImage(st.User.Profile_image_url)
            '    Me.Images.Add(st.User.Profile_image_url, img)
            '    c.picUser.Image = img

            'End If
            'AddHandler c.ReplyCommand, AddressOf Reply
            'Me.pnlMain.Controls.Add(c)
            'If c.Status.numId > CType(pnlMain.Controls(0), ctrStatus).Status.numId Then
            '    pnlMain.Controls.SetChildIndex(pnlMain.Controls(pnlMain.Controls.Count - 1), 0)

            'End If
        End If

    End Sub


    Private Sub AddStatusControl()
        Dim st As Status = _tempstatus
        Dim c As New ctrStatus()
        c.Status = st
        'If st.numId > _laststatusId Then _laststatusId = st.numId
        If Images.ContainsKey(st.User.Profile_image_url) Then
            c.picUser.Image = Images(st.User.Profile_image_url)
        Else
            'Dim img As Image = twa.GetImage(st.User.Profile_image_url)
            'Me.Images.Add(st.User.Profile_image_url, img)
            'c.picUser.Image = img
            c.picUser.ImageLocation = st.User.Profile_image_url

        End If
        AddHandler c.ReplyCommand, AddressOf Reply
        Me.pnlMain.Controls.Add(c)
        If c.Status.numId > _laststatusId Then
            _laststatusId = c.Status.numId
            pnlMain.Controls.SetChildIndex(pnlMain.Controls(pnlMain.Controls.Count - 1), 0)

        End If

    End Sub

    Private Sub CashImage(ByRef stti As Collection(Of Status))
        RaiseEvent StartCachingImages(Me, Nothing)
        Thread.Sleep(50)
        For i As Int32 = 0 To stti.Count - 1
            If Images.Count = 0 OrElse Not Images.ContainsKey(stti(i).User.Profile_image_url) Then
                Dim img As Image = twa.GetImage(stti(i).User.Profile_image_url)
                Me.Images.Add(stti(i).User.Profile_image_url, img)

            End If

        Next
        RaiseEvent EndCachingImages(Me, Nothing)

    End Sub

    Private Sub Reply(ByVal sender As Object, ByVal e As ReplyEventArgs)
        RaiseEvent ReplyCommand(sender, e)

    End Sub

    Public Sub DateTimesUpdate()
        For Each c As ctrStatus In Me.pnlMain.Controls
            c.DateTimeUpdate()

        Next
    End Sub
End Class

