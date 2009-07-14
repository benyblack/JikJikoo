Namespace DNE.Twitter
    Public Class User

        Private _id As String = ""
        Private _name As String = ""
        Private _screen_name As String = ""
        Private _location As String = ""
        Private _description As String = ""
        Private _profile_image_url As String = ""
        Private _url As String = ""
        Private _protected As String = ""
        Private _followers_count As String = ""
        Private _profile_background_color As String = ""
        Private _profile_text_color As String = ""
        Private _profile_link_color As String = ""
        Private _profile_sidebar_fill_color As String = ""
        Private _profile_sidebar_border_color As String = ""
        Private _friends_count As String = ""
        Private _created_at As String = ""
        Private _favourites_count As String = ""
        Private _utc_offset As String = ""
        Private _time_zone As String = ""
        Private _profile_background_image_url As String = ""
        Private _profile_background_tile As String = ""
        Private _statuses_count As String = ""
        Private _notifications As String = ""
        Private _following As String = ""
        Private _verified As String = ""
        Private _status As StatusBase = Nothing

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

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal Value As String)
                _name = Value
            End Set
        End Property

        Public Property Screen_Name() As String
            Get
                Return _screen_name
            End Get
            Set(ByVal Value As String)
                _screen_name = Value
            End Set
        End Property

        Public Property Location() As String
            Get
                Return _location
            End Get
            Set(ByVal Value As String)
                _location = Value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return _description
            End Get
            Set(ByVal Value As String)
                _description = Value
            End Set
        End Property

        Public Property Profile_image_url() As String
            Get
                Return _profile_image_url
            End Get
            Set(ByVal Value As String)
                _profile_image_url = Value
            End Set
        End Property

        Public Property Url() As String
            Get
                Return _url
            End Get
            Set(ByVal Value As String)
                _url = Value
            End Set
        End Property

        Public Property [Protected]() As String
            Get
                Return _protected
            End Get
            Set(ByVal Value As String)
                _protected = Value
            End Set
        End Property

        Public Property Followers_count() As String
            Get
                Return _followers_count
            End Get
            Set(ByVal Value As String)
                _followers_count = Value
            End Set
        End Property

        Public Property Profile_background_color() As String
            Get
                Return _profile_background_color
            End Get
            Set(ByVal Value As String)
                _profile_background_color = Value
            End Set
        End Property

        Public Property Profile_text_color() As String
            Get
                Return _profile_text_color
            End Get
            Set(ByVal Value As String)
                _profile_text_color = Value
            End Set
        End Property

        Public Property Profile_link_color() As String
            Get
                Return _profile_link_color
            End Get
            Set(ByVal Value As String)
                _profile_link_color = Value
            End Set
        End Property

        Public Property Profile_sidebar_fill_color() As String
            Get
                Return _profile_sidebar_fill_color
            End Get
            Set(ByVal Value As String)
                _profile_sidebar_fill_color = Value
            End Set
        End Property

        Public Property Profile_sidebar_border_color() As String
            Get
                Return _profile_sidebar_border_color
            End Get
            Set(ByVal Value As String)
                _profile_sidebar_border_color = Value
            End Set
        End Property

        Public Property Friends_count() As String
            Get
                Return _friends_count
            End Get
            Set(ByVal Value As String)
                _friends_count = Value
            End Set
        End Property

        Public Property Created_at() As String
            Get
                Return _created_at
            End Get
            Set(ByVal Value As String)
                _created_at = Value
            End Set
        End Property

        Public Property Favourites_count() As String
            Get
                Return _favourites_count
            End Get
            Set(ByVal Value As String)
                _favourites_count = Value
            End Set
        End Property

        Public Property Utc_offset() As String
            Get
                Return _utc_offset
            End Get
            Set(ByVal Value As String)
                _utc_offset = Value
            End Set
        End Property

        Public Property Time_zone() As String
            Get
                Return _time_zone
            End Get
            Set(ByVal Value As String)
                _time_zone = Value
            End Set
        End Property

        Public Property Profile_background_image_url() As String
            Get
                Return _profile_background_image_url
            End Get
            Set(ByVal Value As String)
                _profile_background_image_url = Value
            End Set
        End Property

        Public Property Profile_background_tile() As String
            Get
                Return _profile_background_tile
            End Get
            Set(ByVal Value As String)
                _profile_background_tile = Value
            End Set
        End Property

        Public Property Statuses_count() As String
            Get
                Return _statuses_count
            End Get
            Set(ByVal Value As String)
                _statuses_count = Value
            End Set
        End Property

        Public Property Notifications() As String
            Get
                Return _notifications
            End Get
            Set(ByVal Value As String)
                _notifications = Value
            End Set
        End Property

        Public Property Following() As String
            Get
                Return _following
            End Get
            Set(ByVal Value As String)
                _following = Value
            End Set
        End Property

        Public Property Verified() As String
            Get
                Return _verified
            End Get
            Set(ByVal Value As String)
                _verified = Value
            End Set
        End Property

        Public Property Status() As StatusBase
            Get
                Return _status
            End Get
            Set(ByVal value As StatusBase)
                _status = value
            End Set
        End Property

#End Region

    End Class

End Namespace
