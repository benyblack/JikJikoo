Namespace DNE.Twitter
    Public Class DirectMessage

        Private _id As String = ""
        Private _sender_id As String = ""
        Private _text As String = ""
        Private _recipient_id As String = ""
        Private _created_at As String = ""
        Private _sender_screen_name As String = ""
        Private _recipient_screen_name As String = ""

        Private _sender As User = Nothing
        Private _recipient As User = Nothing

#Region "   Properties   "

        Public Property [id]() As String
            Get
                Return _id
            End Get
            Set(ByVal Value As String)
                _id = Value
            End Set
        End Property

        Public Property sender_id() As String
            Get
                Return _sender_id
            End Get
            Set(ByVal Value As String)
                _sender_id = Value
            End Set
        End Property

        Public Property text() As String
            Get
                Return _text
            End Get
            Set(ByVal Value As String)
                _text = Value
            End Set
        End Property

        Public Property recipient_id() As String
            Get
                Return _recipient_id
            End Get
            Set(ByVal Value As String)
                _recipient_id = Value
            End Set
        End Property

        Public Property created_at() As String
            Get
                Return _created_at
            End Get
            Set(ByVal Value As String)
                _created_at = Value
            End Set
        End Property

        Public Property sender_screen_name() As String
            Get
                Return _sender_screen_name
            End Get
            Set(ByVal Value As String)
                _sender_screen_name = Value
            End Set
        End Property

        Public Property recipient_screen_name() As String
            Get
                Return _recipient_screen_name
            End Get
            Set(ByVal Value As String)
                _recipient_screen_name = Value
            End Set
        End Property

        Public Property Sender() As User
            Get
                Return _sender
            End Get
            Set(ByVal value As User)
                _sender = value
            End Set
        End Property

        Public Property Recipient() As User
            Get
                Return _recipient
            End Get
            Set(ByVal value As User)
                _recipient = value
            End Set
        End Property

#End Region

    End Class
End Namespace
