Imports System.Globalization

Namespace DNE.Twitter

    Public Class StatusBase

        Private _id As String = ""
        Private _created_at As String = ""
        Private _text As String = ""
        Private _source As String = ""
        Private _truncated As String = ""
        Private _in_reply_to_status_id As String = ""
        Private _in_reply_to_user_id As String = ""
        Private _favorited As String = ""
        Private _in_reply_to_screen_name As String = ""


        Public Sub New()

        End Sub

#Region "   Properties   "

        Public Property [Id]() As String
            Get
                Return _id
            End Get
            Set(ByVal Value As String)
                _id = Value
            End Set
        End Property

        Public Property Created_At() As String
            Get
                Return _created_at
            End Get
            Set(ByVal Value As String)
                _created_at = Value
            End Set
        End Property

        Public Const TimeFormat As String = "ddd MMM dd HH:mm:ss zzzz yyyy"
        Public ReadOnly Property CreatedAt() As DateTime
            Get
                'This is from TwitterN: Amplify.Twitter.Status
                Return DateTime.ParseExact(_created_at, TimeFormat, New CultureInfo("en-US"), DateTimeStyles.AllowWhiteSpaces)
            End Get
        End Property

        Public Property Text() As String
            Get
                Return _text
            End Get
            Set(ByVal Value As String)
                _text = Value
            End Set
        End Property

        Public Property Source() As String
            Get
                Return _source
            End Get
            Set(ByVal Value As String)
                _source = Value
            End Set
        End Property

        Public Property Truncated() As String
            Get
                Return _truncated
            End Get
            Set(ByVal Value As String)
                _truncated = Value
            End Set
        End Property

        Public Property In_reply_to_status_id() As String
            Get
                Return _in_reply_to_status_id
            End Get
            Set(ByVal Value As String)
                _in_reply_to_status_id = Value
            End Set
        End Property

        Public Property In_reply_to_user_id() As String
            Get
                Return _in_reply_to_user_id
            End Get
            Set(ByVal Value As String)
                _in_reply_to_user_id = Value
            End Set
        End Property

        Public Property Favorited() As String
            Get
                Return _favorited
            End Get
            Set(ByVal Value As String)
                _favorited = Value
            End Set
        End Property

        Public Property In_reply_to_screen_name() As String
            Get
                Return _in_reply_to_screen_name
            End Get
            Set(ByVal Value As String)
                _in_reply_to_screen_name = Value
            End Set
        End Property

#End Region

    End Class

    Public Class Status
        Inherits StatusBase
        Private _user As User = Nothing

        Public Property [User]() As User
            Get
                Return _user
            End Get
            Set(ByVal value As User)
                _user = value
            End Set
        End Property

        Public ReadOnly Property numId() As Int64
            Get
                Return CLng(Me.Id)
            End Get
        End Property


    End Class

End Namespace