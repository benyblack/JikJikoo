''' <summary>
''' Fire when a @screen_name clicked on ctrStatus
''' </summary>
''' <param name="sender"></param>
''' <param name="Tea">Contain an enum for what to do and a text property for message</param>
''' <remarks></remarks>
Public Delegate Sub TwitEventHandler(ByVal sender As Object, ByVal Tea As TwitEventArgs)


Public Class TwitEventArgs
    Inherits EventArgs

    Private _text As String = ""
    Public Property Text() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property

    Private _status As DNE.Twitter.Status = Nothing
    Public Property [Status]() As DNE.Twitter.Status
        Get
            Return _status
        End Get
        Set(ByVal value As DNE.Twitter.Status)
            _status = value
        End Set
    End Property

    Private _twitevent As TwitEvents
    Public Property TwitEvent() As TwitEvents
        Get
            Return _twitevent
        End Get
        Set(ByVal value As TwitEvents)
            _twitevent = value
        End Set
    End Property

    Public Sub New(ByVal stts As DNE.Twitter.Status, ByVal txt As String, ByVal WhatHappend As TwitEvents)
        _twitevent = WhatHappend
        _text = txt
        _status = stts

    End Sub

End Class

Public Enum TwitEvents
    Use_ScreenName = 0
    RT = 1
    Reply = 2
    UserStatuses = 3

End Enum

