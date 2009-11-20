Imports Org.Mentalis.Network.ProxySocket
Imports DNE.Twitter

Namespace DNE.JikJikoo

    Public MustInherit Class WebClient

        Public Sub New()
            _authtype = AuthType.oAuth

        End Sub

        ''' <summary>
        ''' for basic authentication
        ''' </summary>
        ''' <param name="twitterUser"></param>
        ''' <param name="twitterPassword"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal twitterUser As String, ByVal twitterPassword As String)
            Me.UserName = twitterUser
            Me.Password = twitterPassword
            _authtype = AuthType.Basic

        End Sub

        Public Sub ConfigProxy(ByVal ptype As ProxyTypes, ByVal pport As Int32, ByVal ip As String, ByVal puser As String, ByVal ppass As String)
            Me.ProxyType = ptype
            Me.ProxyPort = pport
            Me.ProxyIP = ip
            Me.ProxyUserName = puser
            Me.ProxyPassword = ppass

        End Sub

        Protected Sub AddBytes(ByRef al As ArrayList, ByVal b As Byte(), ByVal count As Int32)
            For i As Int32 = 0 To count - 1
                al.Add(b(i))

            Next

        End Sub

#Region " Properties "

        '-------- Authentication -------
        Private _username As String = ""
        Private _password As String = ""
        Private _authtype As AuthType = AuthType.oAuth

        '------------ Proxy ------------
        Private _proxytype As ProxyTypes = ProxyTypes.Socks4
        Private _proxyPort As Int32 = 1080
        Private _proxyIP As String = "127.0.0.1"
        Private _proxyuser As String = ""
        Private _proxypassword As String = ""


        Public Property UserName() As String
            Get
                Return _username
            End Get
            Set(ByVal value As String)
                _username = value
            End Set
        End Property

        Public Property Password() As String
            Get
                Return _password
            End Get
            Set(ByVal value As String)
                _password = value
            End Set
        End Property

        Public ReadOnly Property AuthenticationType() As AuthType
            Get
                Return _authtype
            End Get
        End Property

        Public Property ProxyType() As ProxyTypes
            Get
                Return _proxytype
            End Get
            Set(ByVal value As ProxyTypes)
                _proxytype = value
            End Set
        End Property

        Public Property ProxyPort() As Int32
            Get
                Return _proxyPort
            End Get
            Set(ByVal value As Int32)
                _proxyPort = value
            End Set
        End Property

        Public Property ProxyIP() As String
            Get
                Return _proxyIP
            End Get
            Set(ByVal value As String)
                _proxyIP = value
            End Set
        End Property

        Public Property ProxyUserName() As String
            Get
                Return _proxyuser
            End Get
            Set(ByVal value As String)
                _proxyuser = value
            End Set
        End Property

        Public Property ProxyPassword() As String
            Get
                Return _proxypassword
            End Get
            Set(ByVal value As String)
                _proxypassword = value
            End Set
        End Property

#End Region

#Region " Overridables "

        Public MustOverride Function DoPost(ByVal url As Uri, ByVal data As String) As String

        Public MustOverride Function DoGet(ByVal url As Uri) As String

        Public MustOverride Function DownloadData(ByVal url As Uri) As Byte()

        Public MustOverride Function DoGetNoAuth(ByVal url As Uri) As String

        Public MustOverride Function DownloadDataNoAuth(ByVal url As Uri) As Byte()

#End Region

    End Class

End Namespace
