Namespace DNE.Twitter

    Public Delegate Sub HttpEventHandler(ByVal sender As Object, ByVal hea As HttpExEventArgs)


    Public Class HttpExEventArgs
        Inherits EventArgs

        Private _ex As Exception = Nothing
        Public Property [Exception]() As Exception
            Get
                Return _ex
            End Get
            Set(ByVal value As Exception)
                _ex = value
            End Set
        End Property

        Private _url As String = ""
        Public Property Url() As String
            Get
                Return _url
            End Get
            Set(ByVal value As String)
                _url = value
            End Set
        End Property

        Private _message As String = ""
        Public Property Message() As String
            Get
                Return _message
            End Get
            Set(ByVal value As String)
                _message = value
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ex">Exception Object</param>
        ''' <param name="urlex">Url that exception happend for it</param>
        ''' <param name="msg">Message about this exception</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal ex As Exception, ByVal urlex As String, ByVal msg As String)
            _url = urlex
            _ex = ex
            _message = msg

        End Sub
    End Class

    Public Class NoConnectionException
        Inherits Exception

    End Class

End Namespace
