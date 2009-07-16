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

    Private _twitevent As TwitEvents
    Public Property TwitEvent() As TwitEvents
        Get
            Return _twitevent
        End Get
        Set(ByVal value As TwitEvents)
            _twitevent = value
        End Set
    End Property

    Public Sub New(ByVal Message As String, ByVal WhatHappend As TwitEvents)
        _twitevent = WhatHappend
        _text = Message

    End Sub

End Class

Public Enum TwitEvents
    Use_ScreenName = 0
    RT = 1
    Reply = 2

End Enum

