Public Delegate Sub ReplyEventHandler(ByVal sender As Object, ByVal rea As ReplyEventArgs)


Public Class ReplyEventArgs
    Inherits EventArgs

    Dim _replyto As String = ""
    Public Property ReplyTo() As String
        Get
            Return _replyto
        End Get
        Set(ByVal value As String)
            _replyto = value
        End Set
    End Property

    Public Sub New(ByVal UserToReply As String)
        _replyto = UserToReply
    End Sub
End Class
