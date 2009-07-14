Imports System.Configuration.ConfigurationManager

Public Class JikConfigManager

    '<add key="proxytype" value="1"/> <!-- 0:None,1:SOCKS4,2:SOCKS5,3:HTTP -->
    '<add key="proxyserver" value="127.0.0.1"/>
    '<add key="proxyport" value="1080"/>
    '<add key="proxyuser" value=""/>
    '<add key="proxypass" value=""/>
    '<add key="user" value=""/>
    '<add key="password" value=""/>
    '<add key="refresh" value="60"/>
    '<add key="lang" value="FA"/> <!-- FA or EN -->

    '<add key="ConsumerKey" value="60"/>
    '<add key="ConsumerSecret" value="60"/>
    '<add key="Token" value="60"/>
    '<add key="TokenSecret" value="60"/>


    '<?xml version="1.0" encoding="utf-16"?>
    '<oAuthTwitter xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    '  <ConsumerKey>Um0Z859qORQgTkN4ehyqdw</ConsumerKey>
    '  <ConsumerSecret>F1Ce6okvMspIYBbrJJ7Qh2LkvkJNhxruiI2Ln7CmA</ConsumerSecret>
    '  <Token></Token>
    '  <TokenSecret></TokenSecret>
    '</oAuthTwitter>

    Private _proxytype As String = ""
    Private _proxyserver As String = ""
    Private _proxyport As String = ""
    Private _proxyuser As String = ""
    Private _proxypass As String = ""
    Private _user As String = ""
    Private _password As String = ""
    Private _refresh As String = ""
    Private _lang As String = ""

    'oAuth
    Private _consumerkey As String = "Um0Z859qORQgTkN4ehyqdw"
    Private _consumersecret As String = "F1Ce6okvMspIYBbrJJ7Qh2LkvkJNhxruiI2Ln7CmA"
    Private _token As String = ""
    Private _tokensecret As String = ""
    Private _tokenhash As String = ""



#Region "   Properties   "

    Public Property proxytype() As String
        Get
            Return _proxytype
        End Get
        Set(ByVal Value As String)
            _proxytype = Value
        End Set
    End Property

    Public Property proxyserver() As String
        Get
            Return _proxyserver
        End Get
        Set(ByVal Value As String)
            _proxyserver = Value
        End Set
    End Property

    Public Property proxyport() As String
        Get
            Return _proxyport
        End Get
        Set(ByVal Value As String)
            _proxyport = Value
        End Set
    End Property

    Public Property proxyuser() As String
        Get
            Return _proxyuser
        End Get
        Set(ByVal Value As String)
            _proxyuser = Value
        End Set
    End Property

    Public Property proxypass() As String
        Get
            Return _proxypass
        End Get
        Set(ByVal Value As String)
            _proxypass = Value
        End Set
    End Property

    Public Property user() As String
        Get
            Return _user
        End Get
        Set(ByVal Value As String)
            _user = Value
        End Set
    End Property

    Public Property password() As String
        Get
            Return _password
        End Get
        Set(ByVal Value As String)
            _password = Value
        End Set
    End Property

    Public Property refresh() As String
        Get
            Return _refresh
        End Get
        Set(ByVal Value As String)
            _refresh = Value
        End Set
    End Property

    Public Property lang() As String
        Get
            Return _lang
        End Get
        Set(ByVal Value As String)
            _lang = Value
        End Set
    End Property

    'oAuth
    Public ReadOnly Property ConsumerKey() As String
        Get
            Return _consumerkey
        End Get
    End Property

    Public ReadOnly Property ConsumerSecret() As String
        Get
            Return _consumersecret
        End Get
    End Property

    Public Property Token() As String
        Get
            Return _token
        End Get
        Set(ByVal Value As String)
            _token = Value
        End Set
    End Property

    Public Property TokenSecret() As String
        Get
            Return _tokensecret
        End Get
        Set(ByVal Value As String)
            _tokensecret = Value
        End Set
    End Property

    Public Property TokenHash() As String
        Get
            Return _TokenHash
        End Get
        Set(ByVal Value As String)
            _TokenHash = Value
        End Set
    End Property

#End Region

    Friend ReadOnly Property CultureInfo() As Globalization.CultureInfo
        Get
            If lang.ToLower = "fa" Then
                Return New Globalization.CultureInfo("fa-IR")

            End If
            Return New Globalization.CultureInfo("en-US")

        End Get
    End Property

    Public Sub New()
        
        Reload()
    End Sub

    Public Sub Reload()
        Dim ace As New AppConfig()
        _proxytype = ace.GetValue("proxytype")
        _proxyserver = ace.GetValue("proxyserver")
        _proxyport = ace.GetValue("proxyport")
        _proxyuser = ace.GetValue("proxyuser")
        _proxypass = ace.GetValue("proxypass")
        _user = ace.GetValue("user")
        _password = ace.GetValue("password")
        _refresh = ace.GetValue("refresh")
        _lang = ace.GetValue("lang")

        _token = ace.GetValue("Token")
        _tokensecret = ace.GetValue("TokenSecret")
        _tokenhash = ace.GetValue("TokenHash")

    End Sub

    Public Sub ClearAuthData()
        Dim ace As New AppConfig()
        ace.SetValue("Token", "")
        ace.SetValue("TokenSecret", "")
        ace.SetValue("TokenHash", "")
    End Sub


End Class
