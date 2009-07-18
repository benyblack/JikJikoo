Imports Newtonsoft.Json

Namespace DNE.Twitter
    Public Class Result

        Private _text As String = ""
        Private _to_user_id As String = ""
        Private _to_user As String = ""
        Private _from_user_id As String = ""
        Private _id As String = ""
        Private _from_user As String = ""
        Private _iso_language_code As String = ""
        Private _source As String = ""
        Private _profile_image_url As String = ""
        Private _created_at As String = ""


#Region "   Properties   "

        <JsonProperty("text")> _
        Public Property text() As String
            Get
                Return _text
            End Get
            Set(ByVal Value As String)
                _text = Value
            End Set
        End Property

        <JsonProperty("to_user_id")> _
        Public Property to_user_id() As String
            Get
                Return _to_user_id
            End Get
            Set(ByVal Value As String)
                _to_user_id = Value
            End Set
        End Property

        <JsonProperty("to_user")> _
        Public Property to_user() As String
            Get
                Return _to_user
            End Get
            Set(ByVal Value As String)
                _to_user = Value
            End Set
        End Property

        <JsonProperty("from_user_id")> _
        Public Property from_user_id() As String
            Get
                Return _from_user_id
            End Get
            Set(ByVal Value As String)
                _from_user_id = Value
            End Set
        End Property

        <JsonProperty("id")> _
        Public Property [id]() As String
            Get
                Return _id
            End Get
            Set(ByVal Value As String)
                _id = Value
            End Set
        End Property

        <JsonProperty("from_user")> _
        Public Property from_user() As String
            Get
                Return _from_user
            End Get
            Set(ByVal Value As String)
                _from_user = Value
            End Set
        End Property

        <JsonProperty("iso_language_code")> _
        Public Property iso_language_code() As String
            Get
                Return _iso_language_code
            End Get
            Set(ByVal Value As String)
                _iso_language_code = Value
            End Set
        End Property

        <JsonProperty("source")> _
        Public Property source() As String
            Get
                Return _source
            End Get
            Set(ByVal Value As String)
                _source = Value
            End Set
        End Property

        <JsonProperty("profile_image_url")> _
        Public Property profile_image_url() As String
            Get
                Return _profile_image_url
            End Get
            Set(ByVal Value As String)
                _profile_image_url = Value
            End Set
        End Property

        <JsonProperty("created_at")> _
        Public Property created_at() As String
            Get
                Return _created_at
            End Get
            Set(ByVal Value As String)
                _created_at = Value
            End Set
        End Property


#End Region

    End Class


    Public Class SearchResults

        Private _result As Result() = Nothing
        Public Property results() As Result()
            Get
                Return _result
            End Get
            Set(ByVal value As Result())
                _result = value
            End Set
        End Property

        Private _since_id As String = ""
        Private _max_id As String = ""
        Private _refresh_url As String = ""
        Private _results_per_page As String = ""
        Private _next_page As String = ""
        Private _completed_in As String = ""
        Private _page As String = ""
        Private _query As String = ""

        <JsonProperty("since_id")> _
        Public Property since_id() As String
            Get
                Return _since_id
            End Get
            Set(ByVal Value As String)
                _since_id = Value
            End Set
        End Property

        <JsonProperty("max_id")> _
        Public Property max_id() As String
            Get
                Return _max_id
            End Get
            Set(ByVal Value As String)
                _max_id = Value
            End Set
        End Property

        <JsonProperty("refresh_url")> _
        Public Property refresh_url() As String
            Get
                Return _refresh_url
            End Get
            Set(ByVal Value As String)
                _refresh_url = Value
            End Set
        End Property

        <JsonProperty("results_per_page")> _
        Public Property results_per_page() As String
            Get
                Return _results_per_page
            End Get
            Set(ByVal Value As String)
                _results_per_page = Value
            End Set
        End Property

        <JsonProperty("next_page")> _
        Public Property next_page() As String
            Get
                Return _next_page
            End Get
            Set(ByVal Value As String)
                _next_page = Value
            End Set
        End Property

        <JsonProperty("completed_in")> _
        Public Property completed_in() As String
            Get
                Return _completed_in
            End Get
            Set(ByVal Value As String)
                _completed_in = Value
            End Set
        End Property

        <JsonProperty("page")> _
        Public Property page() As String
            Get
                Return _page
            End Get
            Set(ByVal Value As String)
                _page = Value
            End Set
        End Property

        <JsonProperty("query")> _
        Public Property query() As String
            Get
                Return _query
            End Get
            Set(ByVal Value As String)
                _query = Value
            End Set
        End Property

    End Class
End Namespace
