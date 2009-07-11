Imports System.Collections.ObjectModel
Imports DNE.Twitter


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
            If _statuses Is Nothing OrElse _statuses.Count = 0 Then Exit Property
            Me.pnlMain.Controls.Clear()
            FillList()

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

    ''' <summary>
    ''' Clear status list
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()
        pnlMain.Controls.Clear()
        _statuses.Clear()
        _laststatusId = 0

    End Sub

    ''' <summary>
    ''' Add Statuses on top of prev statuses
    ''' </summary>
    ''' <param name="sts">Collection of statuses</param>
    ''' <remarks></remarks>
    Public Sub AddStatuses(ByVal sts As Collection(Of Status))
        If sts Is Nothing OrElse sts.Count = 0 Then
            RaiseEvent EndAddStatuses(Nothing, Nothing)
            Exit Sub
        End If
        RaiseEvent StartAddStatuses(Nothing, Nothing)
        Threading.Thread.Sleep(50)
        'pnlMain.Controls.Clear()
        Me.SuspendLayout()
        For i As Int32 = 0 To sts.Count - 1
            AddStatusControl(sts(i))
            pnlMain.Controls.SetChildIndex(pnlMain.Controls(pnlMain.Controls.Count - 1), 0)
        Next
        Me.ResumeLayout()

        'For i As Int32 = 0 To _statuses.Count - 1
        '    AddStatusControl(_statuses(i))

        'Next
        For i As Int32 = sts.Count - 1 To 0
            _statuses.Insert(0, sts(i))

        Next
        RaiseEvent EndAddStatuses(Nothing, Nothing)

    End Sub

    Private _tempstatus As Status
    Private Sub AddStatusControl(ByVal st As Status)
        If Me.InvokeRequired Then
            _tempstatus = st
            Me.Invoke(New MethodInvoker(AddressOf AddStatusControl))
        Else
            Dim c As New ctrStatus()
            c.Status = st
            If CLng(st.Id) > _laststatusId Then _laststatusId = CLng(st.Id)
            If Images.ContainsKey(st.User.Profile_image_url) Then
                c.picUser.Image = Images(st.User.Profile_image_url)
            Else
                Dim img As Image = twa.GetImage(st.User.Profile_image_url)
                Me.Images.Add(st.User.Profile_image_url, img)
                c.picUser.Image = img

            End If
            AddHandler c.ReplyCommand, AddressOf Reply
            Me.pnlMain.Controls.Add(c)
        End If

    End Sub

    Private Sub AddStatusControl()
        Dim st As Status = _tempstatus
        Dim c As New ctrStatus()
        c.Status = st
        If CLng(st.Id) > _laststatusId Then _laststatusId = CLng(st.Id)
        If Images.ContainsKey(st.User.Profile_image_url) Then
            c.picUser.Image = Images(st.User.Profile_image_url)
        Else
            Dim img As Image = twa.GetImage(st.User.Profile_image_url)
            Me.Images.Add(st.User.Profile_image_url, img)
            c.picUser.Image = img

        End If
        AddHandler c.ReplyCommand, AddressOf Reply
        Me.pnlMain.Controls.Add(c)
    End Sub

    Private Sub FillList()
        RaiseEvent StartCachingImages(Nothing, Nothing)
        Threading.Thread.Sleep(50)
        For i As Int32 = 0 To _statuses.Count - 1
            If Not Images.ContainsKey(_statuses(i).User.Profile_image_url) Then
                Dim img As Image = twa.GetImage(_statuses(i).User.Profile_image_url)
                Me.Images.Add(_statuses(i).User.Profile_image_url, img)

            End If
        Next
        RaiseEvent EndCachingImages(Nothing, Nothing)
        RaiseEvent StartAddStatuses(Nothing, Nothing)

        For i As Int32 = 0 To _statuses.Count - 1
            AddStatusControl(_statuses(i))

        Next
        RaiseEvent EndAddStatuses(Nothing, Nothing)

    End Sub

    Private Sub Reply(ByVal sender As Object, ByVal e As ReplyEventArgs)
        RaiseEvent ReplyCommand(sender, e)

    End Sub

End Class

