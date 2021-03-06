﻿Imports System.Globalization

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
        Public Const TimeFormatSearch As String = "ddd, dd MMM yyyy HH:mm:ss zzzz"
        '"Sat, 18 Jul 2009 07:26:18 +0000"
        'Sun Jul 19 17:53:31 +0000 2009
        '"ddd, dd MMM yyyy HH:mm:ss zzzz"
        Public ReadOnly Property CreatedAt() As DateTime
            Get
                If _created_at = "" Then Return DateTime.MinValue
                Try
                    'This is from TwitterN: Amplify.Twitter.Status
                    Return DateTime.ParseExact(_created_at, TimeFormat, New CultureInfo("en-US"), DateTimeStyles.AllowWhiteSpaces)

                Catch ex As Exception
                    Return DateTime.ParseExact(_created_at, TimeFormatSearch, New CultureInfo("en-US"), DateTimeStyles.AllowWhiteSpaces)

                End Try
                Return Nothing
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

        Public Sub New()

        End Sub

        Public Sub New(ByVal stb As StatusBase)
            Me.Created_At = stb.Created_At
            Me.Favorited = stb.Favorited
            Me.Id = stb.Id
            Me.In_reply_to_screen_name = stb.In_reply_to_screen_name
            Me.In_reply_to_status_id = stb.In_reply_to_status_id
            Me.In_reply_to_user_id = stb.In_reply_to_user_id
            Me.Source = stb.Source
            Me.Text = stb.Text
            Me.Truncated = stb.Truncated
            
        End Sub

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
                If Me.Id = "" Then Return 0
                Return CLng(Me.Id)
            End Get
        End Property


    End Class

End Namespace