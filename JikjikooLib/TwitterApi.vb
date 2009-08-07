Imports System
Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.Net.Sockets
Imports System.Web
Imports System.Xml
Imports System.Drawing
Imports System.Collections.ObjectModel
Imports System.Text.RegularExpressions

Imports Org.Mentalis.Network.ProxySocket

Namespace DNE.Twitter

    Public Class Api

        Private Function HttpRequest(ByVal method As String, ByVal url As String, ByVal query As String, Optional ByVal host As String = "twitter.com") As String
            If AuthenticationType = AuthType.oAuth Then
                Dim o As New oAuthExample.oAuthTwitter(Me)
                o.ConsumerKey = "Um0Z859qORQgTkN4ehyqdw"
                o.ConsumerSecret = "F1Ce6okvMspIYBbrJJ7Qh2LkvkJNhxruiI2Ln7CmA"
                o.Token = Me.Token
                o.TokenSecret = Me.TokenSecret

                Dim normurl As String = ""
                Dim normparam As String = ""


                If query <> "" Then
                    If (url.IndexOf("?") > 0) Then
                        url = (url & "&")
                    Else
                        url = (url & "?")
                    End If

                End If
                Dim ts As String = o.GenerateTimeStamp()
                Dim nonce As String = o.GenerateNonce()
                Dim sign As String = o.GenerateSignature(New Uri("http://twitter.com" & url & query), _
                                    o.ConsumerKey, o.ConsumerSecret, o.Token, o.TokenSecret, method, ts, _
                                    nonce, normurl, normparam)
                'TODO:// must parse query & params
                'Completed
                'Not Tested
                If query <> "" And method.ToLower = "post" Then
                    Dim qnv As Collections.Specialized.NameValueCollection = HttpUtility.ParseQueryString(query)
                    Dim pnv As Collections.Specialized.NameValueCollection = HttpUtility.ParseQueryString(normparam)
                    For i As Int32 = 0 To qnv.Count - 1
                        pnv.Remove(qnv.AllKeys(i))


                    Next
                    normparam = ""
                    For i As Int32 = 0 To pnv.Count - 1
                        normparam += String.Format("{0}={1}&", pnv.Keys(i), UrlEncode(pnv(pnv.Keys(i))))

                    Next
                    'remove last "&"
                    normparam = normparam.Substring(0, normparam.Length - 1)
                    'normparam = normparam.Substring(0, normparam.Length - query.Length - 1)
                End If
                url = String.Format("{0}?{1}&oauth_signature={2}", normurl, normparam, UrlEncode(sign))
                DNE.JikJikoo.Util.LogIt(ts & " : " & nonce & " : " & sign & vbCrLf)
                If method.ToLower = "get" Then query = ""

            End If
            If method.ToUpper = "POST" Then
                Return Me.WebClient.DoPost(New Uri(url), query)

            ElseIf method.ToUpper = "GET" Then
                Return Me.WebClient.DoGet(New Uri(url))

            End If
            Return ""

        End Function

#Region " Cunstructors "

        Public Sub New()

        End Sub

        ''' <summary>
        ''' Use this cunstructor for Basic Authentication
        ''' </summary>
        ''' <param name="user">Username in Twitter</param>
        ''' <param name="pass">Password in Twitter</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal user As String, ByVal pass As String)
            Me.UserName = user
            Me.Password = pass
            _authtype = AuthType.Basic

        End Sub

        ''' <summary>
        ''' Use this cunstructor for oAthu
        ''' </summary>
        ''' <param name="user">Username in Twitter</param>
        ''' <param name="tok">Token for oAuth</param>
        ''' <param name="toksecret">TokenSecret for oAuth</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal user As String, ByVal tok As String, ByVal toksecret As String)
            Me.UserName = user
            Me.Token = tok
            Me.TokenSecret = toksecret
            _authtype = AuthType.oAuth

        End Sub

#End Region

#Region " Proxy "

        ''' <summary>
        ''' Config Proxy.
        ''' Default Settings is : SOCKS4A,127.0.0.1,1080,"","" 
        ''' if you want to use default settign dont call this method
        ''' </summary>
        ''' <param name="ptype">Type of Proxy Server</param>
        ''' <param name="pport">Port of Proxy Server</param>
        ''' <param name="ip">IP of Proxy Server</param>
        ''' <param name="_user">User Name of Proxy Server</param>
        ''' <param name="_pass">Password of Proxy Server</param>
        ''' <remarks></remarks>
        Public Sub ConfigProxy(ByVal ptype As ProxyType, ByVal pport As Int32, ByVal ip As String, ByVal _user As String, ByVal _pass As String)
            Me.ProxyType = ptype
            Me.ProxyPort = pport
            Me.ProxyIP = ip
            Me.ProxyUserName = _user
            Me.ProxyPassword = _pass
            ConfigWebClientProxy()

        End Sub

        Private Sub ConfigWebClientProxy()
            If Me.ProxyType = ProxyTypes.Http Then
                If Me.AuthenticationType = AuthType.Basic Then
                    _hwc = New DNE.JikJikoo.HttpWebClient(Me.UserName, Me.Password)

                Else
                    _hwc = New DNE.JikJikoo.HttpWebClient()

                End If

            Else
                If Me.AuthenticationType = AuthType.Basic Then
                    _swc = New DNE.JikJikoo.SocketWebClient(Me.UserName, Me.Password)

                Else
                    _swc = New DNE.JikJikoo.SocketWebClient()

                End If

            End If
            Me.WebClient.ConfigProxy(Me.ProxyType, Me.ProxyPort, Me.ProxyIP, Me.ProxyUserName, Me.ProxyPassword)
            AddHandler _swc.DownloadingDataStart, AddressOf DownloadingData_Start
            AddHandler _swc.DownloadingDataEnd, AddressOf DownloadingData_End
            AddHandler _swc.HttpError, AddressOf Http_Error

        End Sub

#End Region

#Region " Events "

        Public Event DownloadingDataStart As EventHandler
        Public Event DownloadingDataEnd As EventHandler
        Public Event HttpError As HttpEventHandler

        Private Sub DownloadingData_Start(ByVal sender As Object, ByVal e As EventArgs)
            RaiseEvent DownloadingDataStart(sender, e)
        End Sub

        Private Sub DownloadingData_End(ByVal sender As Object, ByVal e As EventArgs)
            RaiseEvent DownloadingDataEnd(sender, e)

        End Sub

        Private Sub Http_Error(ByVal sender As Object, ByVal e As Twitter.HttpExEventArgs)
            RaiseEvent HttpError(sender, e)

        End Sub

#End Region

#Region " Urls "

        'timeline
        Private publictimelineurl As String = "/statuses/public_timeline.xml"
        Private friendtimelineurl As String = "/statuses/friends_timeline.xml"
        Private usertimelineurl As String = "/statuses/user_timeline.xml"
        Private usertimelineurl2 As String = "/statuses/user_timeline/{0}.xml"
        Private mentionsurl As String = "/statuses/mentions.xml"


        'status
        Private showstatusurl As String = "/statuses/show/{0}.xml"
        Private updatestatusurl As String = "/statuses/update.xml"
        Private destrystatusurl As String = "/statuses/destroy/{0}.xml"

        'user
        Private showuserurl As String = "/users/show.xml"
        Private friendsurl As String = "/statuses/friends.xml"
        Private followersurl As String = "/statuses/followers.xml"


        'direct message
        Private directmessageurl As String = "/direct_messages.xml"
        Private sentmessageurl As String = "/direct_messages/sent.xml"
        Private newmessageurl As String = "/direct_messages/new.xml"
        Private destroymessageurl As String = "/direct_messages/destroy/{0}.xml"

        'friendship   *
        Private friendshipscreateurl As String = "/friendships/create/{0}.xml"
        Private friendshipsdestroyurl As String = "/friendships/destroy/{0}.xml"
        Private friendshipsexistsurl As String = "/friendships/exists.xml"
        Private friendshipsshowurl As String = "/friendships/show.xml"

        'social graph
        Private friendsidsurl As String = "/friends/ids.xml"
        Private folowersidsurl As String = "/followers/ids.xml"

        'account
        Private accountverifycredentialsurl As String = "/account/verify_credentials.xml"

        'OAuth 
        Private oauthrequesttokenurl As String = "/oauth/request_token"
        Private oauthauthorizeurl As String = "/oauth/authorize"
        Private oauthauthenticateurl As String = "/oauth/authenticate"  'optional:force_login
        Private oauthaccesstokenurl As String = "/oauth/access_token"

        'favorite
        Private favoritesurl As String = "/favorites/{0}.xml"
        Private favoritescreateurl As String = "/favorites/create/{0}.xml"
        Private favoritesdestroyurl As String = "/favorites/destroy/{0}.xml"

        'search
        Private SearchHost As String = "search.twitter.com"
        Private searchurl As String = "/search.json"
        Private trendsurl As String = "/trends.json"
        Private trendscurrenturl As String = "/trends/current.json"
        Private trendsdailyurl As String = "/trends/daily.json"
        Private trendsweeklyurl As String = "/trends/weekly.json"

#End Region

#Region " Properties "

        '-------- Authentication -------
        Private _username As String = ""
        Private _password As String = ""
        Private _token As String = ""
        Private _tokensecret As String = ""
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

        Public Property Token() As String
            Get
                Return _token
            End Get
            Set(ByVal value As String)
                _token = value
            End Set
        End Property

        Public Property TokenSecret() As String
            Get
                Return _tokensecret
            End Get
            Set(ByVal value As String)
                _tokensecret = value
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

        '----------------------------------
        Private _swc As DNE.JikJikoo.SocketWebClient = Nothing
        Private _hwc As DNE.JikJikoo.HttpWebClient = Nothing
        Protected ReadOnly Property WebClient() As DNE.JikJikoo.WebClient
            Get
                If Me.ProxyType = ProxyTypes.Http Then
                    If _hwc Is Nothing Then ConfigWebClientProxy()
                    Return _hwc
                Else
                    If _swc Is Nothing Then ConfigWebClientProxy()
                    Return _swc
                End If
                
            End Get
        End Property

#End Region

#Region " Api Functions "

#Region " TimeLine "

        ''' <summary>
        ''' statuses/public_timeline
        ''' Returns the 20 most recent statuses from non-protected users who have set a custom user icon. The public timeline is cached for 60 seconds so requesting it more often than that is a waste of resources.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPublicTimeLine() As Collection(Of DNE.Twitter.Status)
            Dim s As String = HttpRequest("GET", publictimelineurl, "")
            'ParsStatusXML(s)
            Return ParsTwitterXML(Of Collection(Of DNE.Twitter.Status))(s, TwitterXmlTypes.Status)

        End Function

        ''' <summary>
        ''' statuses/public_timeline
        ''' Returns the 20 most recent statuses from non-protected users who have set a custom user icon. The public timeline is cached for 60 seconds so requesting it more often than that is a waste of resources.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPublicTimeLineXML() As String
            Return HttpRequest("GET", usertimelineurl, "")

        End Function

        ''' <summary>
        ''' statuses/friends_timeline
        ''' Returns the 20 most recent statuses posted by the authenticating user and that user's friends. This is the equivalent of /timeline/home on the Web.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFriendsTimeLine() As ObjectModel.Collection(Of DNE.Twitter.Status)
            Return GetFriendsTimeLine("")

        End Function

        ''' <summary>
        ''' statuses/friends_timeline
        ''' Returns the 20 most recent statuses posted by the authenticating user and that user's friends. This is the equivalent of /timeline/home on the Web.
        ''' </summary>
        ''' <param name="since_id">if have value methid return statuses after this id.leave blank for default</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFriendsTimeLine(ByVal since_id As String) As ObjectModel.Collection(Of DNE.Twitter.Status)
            'Dim query As String = ""
            'If since_id <> "" Then query = "since_id=" & since_id
            'Dim s As String = HttpRequest("GET", friendtimelineurl, query)
            'Return ParsTwitterXML(Of Collection(Of DNE.Twitter.Status))(s, TwitterXmlTypes.Status)
            Return GetFriendsTimeLine(since_id, 0)

        End Function

        Public Function GetFriendsTimeLine(ByVal since_id As String, ByVal page As Int32) As ObjectModel.Collection(Of DNE.Twitter.Status)
            Dim query As String = ""
            If since_id <> "" Then query = "since_id=" & since_id
            If page > 1 Then
                If query <> "" Then query += "&"
                query += "page=" & page.ToString()

            End If
            Dim s As String = HttpRequest("GET", friendtimelineurl, query)
            Return ParsTwitterXML(Of Collection(Of DNE.Twitter.Status))(s, TwitterXmlTypes.Status)
            'Return ParsStatusXML(s)

        End Function

        ''' <summary>
        ''' statuses/user_timeline
        ''' Returns the 20 most recent statuses posted from the authenticating user. It's also possible to request another user's timeline via the id parameter. This is the equivalent of the Web /user page for your own user, or the profile page for a third party.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUserTimeLine() As ObjectModel.Collection(Of DNE.Twitter.Status)
            Dim s As String = HttpRequest("GET", usertimelineurl, "")
            Return ParsTwitterXML(Of Collection(Of DNE.Twitter.Status))(s, TwitterXmlTypes.Status)
            'Return ParsStatusXML(s)

        End Function

        ''' <summary>
        ''' statuses/user_timeline
        ''' Returns the 20 most recent statuses posted from the authenticating user. It's also possible to request another user's timeline via the id parameter. This is the equivalent of the Web /user page for your own user, or the profile page for a third party.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUserTimeLine(ByVal since_id As String) As ObjectModel.Collection(Of DNE.Twitter.Status)
            'Dim query As String = ""
            'If since_id <> "" Then query = "since_id=" & since_id
            'Dim s As String = HttpRequest("GET", usertimelineurl, query)
            'Return ParsTwitterXML(Of Collection(Of DNE.Twitter.Status))(s, TwitterXmlTypes.Status)
            Return GetUserTimeLine("", since_id, 0)

        End Function


        ''' <summary>
        ''' statuses/user_timeline
        ''' Returns the 20 most recent statuses posted from the authenticating user. It's also possible to request another user's timeline via the id parameter. This is the equivalent of the Web /user page for your own user, or the profile page for a third party.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUserTimeLine(ByVal screenname As String, ByVal since_id As String) As ObjectModel.Collection(Of DNE.Twitter.Status)
            'If screenname = "" Then Return GetUserTimeLine(since_id)
            'Dim query As String = ""
            'If since_id <> "" Then query = "since_id=" & since_id
            'Dim s As String = HttpRequest("GET", String.Format(usertimelineurl2, screenname), query)
            'Return ParsTwitterXML(Of Collection(Of DNE.Twitter.Status))(s, TwitterXmlTypes.Status)
            Return GetUserTimeLine(screenname, since_id, 0)


        End Function

        Public Function GetUserTimeLine(ByVal screenname As String, ByVal since_id As String, ByVal page As Int32) As ObjectModel.Collection(Of DNE.Twitter.Status)
            Dim query As String = ""
            If since_id <> "" Then query = "since_id=" & since_id
            If page > 1 Then
                If query <> "" Then query += "&"
                query += "page=" & page.ToString()

            End If
            Dim xurl As String = usertimelineurl
            If screenname <> "" Then xurl = String.Format(usertimelineurl2, screenname)
            Dim s As String = HttpRequest("GET", xurl, query)
            Return ParsTwitterXML(Of Collection(Of DNE.Twitter.Status))(s, TwitterXmlTypes.Status)
            'Return ParsStatusXML(s)

        End Function

        ''' <summary>
        ''' statuses/mentions
        ''' Returns the 20 most recent mentions (status containing @username) for the authenticating user.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetMentions() As ObjectModel.Collection(Of DNE.Twitter.Status)
            Dim s As String = HttpRequest("GET", mentionsurl, "")
            Return ParsTwitterXML(Of Collection(Of DNE.Twitter.Status))(s, TwitterXmlTypes.Status)
            'Return ParsStatusXML(s)

        End Function

        ''' <summary>
        ''' statuses/mentions
        ''' Returns the 20 most recent mentions (status containing @username) for the authenticating user.
        ''' </summary>
        ''' <param name="since_id">if have value methid return statuses after this id.leave blank for default</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetMentions(ByVal since_id As String) As ObjectModel.Collection(Of DNE.Twitter.Status)
            Dim query As String = ""
            If since_id <> "" Then query = "since_id=" & since_id
            Dim s As String = HttpRequest("GET", mentionsurl, query)
            Return ParsTwitterXML(Of Collection(Of DNE.Twitter.Status))(s, TwitterXmlTypes.Status)
            'Return ParsStatusXML(s)

        End Function

        ''' <summary>
        ''' statuses/mentions
        ''' Returns the 20 most recent mentions (status containing @username) for the authenticating user.
        ''' </summary>
        ''' <param name="since_id">if have value methid return statuses after this id.leave blank for default</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetMentions(ByVal since_id As String, ByVal page As Int32) As ObjectModel.Collection(Of DNE.Twitter.Status)
            Dim query As String = ""
            If since_id <> "" Then query = "since_id=" & since_id
            If page > 1 Then
                If query <> "" Then query += "&"
                query += "page=" & page.ToString()

            End If
            Dim s As String = HttpRequest("GET", mentionsurl, query)
            Return ParsTwitterXML(Of Collection(Of DNE.Twitter.Status))(s, TwitterXmlTypes.Status)
            'Return ParsStatusXML(s)

        End Function

#End Region

#Region " Status "

        ''' <summary>
        ''' Twitter REST API Method: statuses/show
        ''' Returns a single status, specified by the id parameter below.  The status's author will be returned inline.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ShowStatus(ByVal statusid As String) As DNE.Twitter.Status
            Dim s As String = HttpRequest("GET", showstatusurl, "")
            Return ParsTwitterXML(Of Collection(Of DNE.Twitter.Status))(s, TwitterXmlTypes.Status)(0)
            'Return ParsStatusXML(s)(0)

        End Function

        ''' <summary>
        ''' statuses/update
        ''' Updates the authenticating user's status.  Requires the status parameter specified below.  Request must be a POST.  A status update with text identical to the authenticating user's current status will be ignored to prevent duplicates.
        ''' </summary>
        ''' <param name="status">Text of new status</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateStatus(ByVal status As String, ByVal in_reply_to_status_id As String) As String
            Dim query As String = String.Format("status={0}", UrlEncode(status))
            If in_reply_to_status_id <> "" Then query += String.Format("&in_reply_to_status_id={0}", in_reply_to_status_id)
            Return HttpRequest("POST", updatestatusurl, query)

        End Function

        ''' <summary>
        ''' statuses/destroy
        ''' Destroys the status specified by the required ID parameter.  The authenticating user must be the author of the specified status.
        ''' </summary>
        ''' <param name="statusid"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DestroyStatus(ByVal statusid As String) As String
            Return HttpRequest("POST", String.Format(destrystatusurl, statusid), "")

        End Function

#End Region

#Region " User "

        ''' <summary>
        ''' users/show
        ''' Returns extended information of a given user, specified by ID or screen name as per the required id parameter.  The author's most recent status will be returned inline.
        ''' </summary>
        ''' <param name="screenname">Specfies the screen name of the user to return. Helpful for disambiguating when a valid screen name is also a user ID.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UserShow(ByVal screenname As String) As DNE.Twitter.User
            Dim query As String = ""
            query = String.Format("screen_name={0}", screenname)
            Dim s As String = HttpRequest("GET", showuserurl, query)
            Return ParsTwitterXML(Of DNE.Twitter.User)(s, TwitterXmlTypes.User)

        End Function

        ''' <summary>
        ''' Returns a user's friends, each with current status inline. 
        ''' They are ordered by the order in which they were added as friends, 100 at a time. 
        ''' (Please note that the result set isn't guaranteed to be 100 every time as suspended users will be filtered out.) 
        ''' Use the page option to access older friends. 
        ''' With no user specified, request defaults to the authenticated user's friends. 
        ''' It's also possible to request another user's friends list via the id, screen_name or user_id parameter.
        ''' </summary>
        ''' <param name="screen_name">Optional.Specfies the screen name of the user for whom to return the list of friends. Helpful for disambiguating when a valid screen name is also a user ID</param>
        ''' <param name="page">Optional.Specifies the page of friends to receive.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Friends(ByVal screen_name As String, ByVal page As Int32) As Collection(Of DNE.Twitter.User)
            Dim query As String = ""
            If screen_name <> "" Then query = "screen_name=" & screen_name
            If page > 1 Then
                If query <> "" Then query += "&"
                query += String.Format("page=" & page.ToString())

            End If
            Dim s As String = HttpRequest("GET", friendsurl, query)
            Return ParsTwitterXML(Of Collection(Of DNE.Twitter.User))(s, TwitterXmlTypes.Users)

        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="screen_name"></param>
        ''' <param name="page"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Followers(ByVal screen_name As String, ByVal page As Int32) As Collection(Of DNE.Twitter.User)
            Dim query As String = ""
            If screen_name <> "" Then query = "screen_name=" & screen_name
            If page > 1 Then
                If query <> "" Then query += "&"
                query += String.Format("page=" & page.ToString())

            End If
            Dim s As String = HttpRequest("GET", followersurl, query)
            Return ParsTwitterXML(Of Collection(Of DNE.Twitter.User))(s, TwitterXmlTypes.Users)

        End Function

#End Region

#Region " Direct Messages "


        ''' <summary>
        ''' direct_messages
        ''' Returns a list of the 20 most recent direct messages sent to the authenticating user.  The XML and JSON versions include detailed information about the sending and recipient users.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DirectMessages() As ObjectModel.Collection(Of DNE.Twitter.DirectMessage)
            Return DirectMessages("")

        End Function

        ''' <summary>
        ''' direct_messages
        ''' Returns a list of the 20 most recent direct messages sent to the authenticating user.  The XML and JSON versions include detailed information about the sending and recipient users.
        ''' </summary>
        ''' <param name="since_id"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DirectMessages(ByVal since_id As String) As ObjectModel.Collection(Of DNE.Twitter.DirectMessage)
            'Dim query As String = ""
            'If since_id <> "" Then query = "since_id=" & since_id
            'Dim s As String = HttpRequest("GET", directmessageurl, query)
            'Return ParsTwitterXML(Of Collection(Of DNE.Twitter.DirectMessage))(s, TwitterXmlTypes.DirectMessage)
            Return DirectMessages(since_id, 1)

        End Function


        ''' <summary>
        ''' direct_messages
        ''' Returns a list of the 20 most recent direct messages sent to the authenticating user.  The XML and JSON versions include detailed information about the sending and recipient users.
        ''' </summary>
        ''' <param name="since_id">Returns only direct messages with an ID greater than (that is, more recent than) the specified ID</param>
        ''' <param name="page">Optional. Specifies the page of direct messages to retrieve</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DirectMessages(ByVal since_id As String, ByVal page As Int32) As ObjectModel.Collection(Of DNE.Twitter.DirectMessage)
            Dim query As String = ""
            If since_id <> "" Then query = "since_id=" & since_id
            If page > 1 Then
                If query <> "" Then query += "&"
                query += String.Format("page=" & page.ToString())

            End If
            Dim s As String = HttpRequest("GET", directmessageurl, query)
            Return ParsTwitterXML(Of Collection(Of DNE.Twitter.DirectMessage))(s, TwitterXmlTypes.DirectMessage)

        End Function

        ''' <summary>
        ''' Returns a list of the 20 most recent direct messages sent by the authenticating user.  The XML and JSON versions include detailed information about the sending and recipient users.
        ''' </summary>
        ''' <param name="since_id">Returns only direct messages with an ID greater than (that is, more recent than) the specified ID</param>
        ''' <param name="page">Optional. Specifies the page of direct messages to retrieve</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SentMessages(ByVal since_id As String, ByVal page As Int32) As ObjectModel.Collection(Of DNE.Twitter.DirectMessage)
            Dim query As String = ""
            If since_id <> "" Then query = "since_id=" & since_id
            If page > 1 Then
                If query <> "" Then query += "&"
                query += String.Format("page=" & page.ToString())

            End If
            Dim s As String = HttpRequest("GET", sentmessageurl, query)
            Return ParsTwitterXML(Of Collection(Of DNE.Twitter.DirectMessage))(s, TwitterXmlTypes.DirectMessage)

        End Function

        ''' <summary>
        ''' Sends a new direct message to the specified user from the authenticating user. Requires both the user and text parameters. Request must be a POST. Returns the sent message in the requested format when successful.
        ''' </summary>
        ''' <param name="ToUser">User Id of who that message will send to him</param>
        ''' <param name="message">Text of message</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SendMessage(ByVal ToUser As String, ByVal message As String) As String
            Return HttpRequest("POST", newmessageurl, String.Format("user={0}&text={1}", ToUser, HttpUtility.UrlEncode(message)))

        End Function

        ''' <summary>
        ''' TODO://
        ''' Not Tested
        ''' </summary>
        ''' <param name="MessageId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DestroyMessage(ByVal MessageId As String) As String
            Return HttpRequest("POST", String.Format(destroymessageurl, MessageId), "")

        End Function

#End Region

#Region " social graph "

        ''' <summary>
        ''' Returns an array of numeric IDs for every user the specified user is following.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FriendsIds() As String()
            Dim s As String = HttpRequest("GET", friendsidsurl, "")
            Dim xmlparser As New DNE.JikJikoo.Parser()
            Return xmlparser.ParsIdsXML(s)

        End Function

        ''' <summary>
        ''' Returns an array of numeric IDs for every user following the specified user.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function FollowersIds() As String()
            Dim s As String = HttpRequest("GET", folowersidsurl, "")
            Dim xmlparser As New DNE.JikJikoo.Parser()
            Return xmlparser.ParsIdsXML(s)

        End Function

#End Region

#Region " Account "

        ''' <summary>
        ''' Veryfy Credentials
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function VerifyCredentials() As DNE.Twitter.User
            Dim s As String = HttpRequest("GET", accountverifycredentialsurl, "")
            Return ParsTwitterXML(Of DNE.Twitter.User)(s, TwitterXmlTypes.User)
            'Return ParsUserXML(s)

        End Function

#End Region

#Region " Favorites "

        Public Function Favorites(ByVal screenname As String, ByVal page As Int32) As Collection(Of DNE.Twitter.Status)
            Dim query As String = ""
            If page > 1 Then query = String.Format("page={0}", page.ToString())
            Dim s As String = HttpRequest("GET", String.Format(favoritesurl, screenname), query)
            Return ParsTwitterXML(Of Collection(Of DNE.Twitter.Status))(s, TwitterXmlTypes.Status)

        End Function

        ''' <summary>
        ''' TODO://
        ''' Not Tested
        ''' Must Document
        ''' </summary>
        ''' <param name="StatusId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateFavorite(ByVal StatusId As String) As String
            Return HttpRequest("POST", String.Format(favoritescreateurl, StatusId), "")

        End Function

        ''' <summary>
        ''' TODO://
        ''' Not Tested
        ''' Must Document
        ''' </summary>
        ''' <param name="StatusId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DestroyFavorite(ByVal StatusId As String) As String
            Return HttpRequest("POST", String.Format(favoritesdestroyurl, StatusId), "")

        End Function

#End Region

#End Region

#Region " Search Api "

        ''' <summary>
        ''' Search
        ''' </summary>
        ''' <param name="q">Query</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Search(ByVal q As String) As DNE.Twitter.SearchResults
            Return Search(q, "", 0, 1, "", "", False)

        End Function

        ''' <summary>
        ''' Search
        ''' </summary>
        ''' <param name="q">Query</param>
        ''' <param name="since_id">Optional. Returns tweets with status ids greater than the given id.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Search(ByVal q As String, ByVal since_id As String) As DNE.Twitter.SearchResults
            Return Search(q, "", 0, 1, since_id, "", False)

        End Function

        ''' <summary>
        ''' Search
        ''' </summary>
        ''' <param name="q">Query</param>
        ''' <param name="page">Optional. The page number (starting at 1) to return, up to a max of roughly 1500 results (based on rpp * page). </param>
        ''' <param name="since_id">Optional. Returns tweets with status ids greater than the given id.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Search(ByVal q As String, ByVal page As Int32, ByVal since_id As String) As DNE.Twitter.SearchResults
            Return Search(q, "", 0, page, since_id, "", False)

        End Function

        ''' <summary>
        ''' Search
        ''' </summary>
        ''' <param name="q">Query</param>
        ''' <param name="lang">Optional: Restricts tweets to the given language, 
        ''' given by an <a href="http://en.wikipedia.org/wiki/List_of_ISO_639-1_codes">ISO 639-1 code</a>.</param>
        ''' <param name="rpp">Optional. The number of tweets to return per page, up to a max of 100.</param>
        ''' <param name="page">Optional. The page number (starting at 1) to return, up to a max of roughly 1500 results (based on rpp * page). </param>
        ''' <param name="since_id">Optional. Returns tweets with status ids greater than the given id.</param>
        ''' <param name="geocode">Optional. Returns tweets by users located within a given radius of the given latitude/longitude, 
        ''' where the user's location is taken from their Twitter profile. 
        ''' The parameter value is specified by "latitide,longitude,radius", 
        ''' where radius units must be specified as either "mi" (miles) or "km" (kilometers). 
        ''' Note that you cannot use the near operator via the API to geocode arbitrary locations; 
        ''' however you can use this geocode parameter to search near geocodes directly.
        ''' Example: <example>http://search.twitter.com/search.atom?geocode=40.757929%2C-73.985506%2C25km</example> </param>
        ''' <param name="show_user"> Optional. When true, prepends user tag to the beginning of the tweet. This is useful for readers that do not display Atom's author field. The default is false.
        ''' </param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Search(ByVal q As String, ByVal lang As String, ByVal rpp As Int32, _
                               ByVal page As Int32, ByVal since_id As String, ByVal geocode As String, ByVal show_user As Boolean) As DNE.Twitter.SearchResults
            Dim query As String = "q=" & HttpUtility.HtmlEncode(q)
            If lang <> "" Then query += "&lang=" & lang
            If rpp > 0 Then query += "&rpp=" & rpp.ToString()
            If page > 1 Then query += "&page=" & page.ToString()
            If since_id <> "" Then query += "&since_id=" & since_id
            If geocode <> "" Then query += "&geocode=" & geocode
            If show_user Then query += "&show_user=true"
            Dim s As String = HttpRequest("GET", searchurl, query, SearchHost)
            Dim jsonparser As New DNE.JikJikoo.Parser()
            Return jsonparser.ParsJsonSearchResults(s)

        End Function

        ''' <summary>
        ''' TODO://
        ''' Not Tested
        ''' Not Completed
        ''' Must Document
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Trends() As String
            Return HttpRequest("GET", trendsurl, "")

        End Function

        ''' <summary>
        ''' TODO://
        ''' Not Tested
        ''' Not Completed
        ''' Must Document
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function TrendsCurrent() As String
            Return HttpRequest("GET", trendscurrenturl, "")

        End Function

        ''' <summary>
        ''' TODO://
        ''' Not Tested
        ''' Not Completed
        ''' Must Document
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function TrendsDaily() As String
            Return HttpRequest("GET", trendsdailyurl, "")

        End Function

        ''' <summary>
        ''' TODO://
        ''' Not Tested
        ''' Not Completed
        ''' Must Document
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function TrendsWeekly() As String
            Return HttpRequest("GET", trendsweeklyurl, "")

        End Function

#End Region

#Region " Util "

        Private Function ParsTwitterXML(Of T)(ByVal sXml As String, ByVal xt As TwitterXmlTypes) As T
            If sXml = "" Then
                RaiseEvent HttpError(Me, New HttpExEventArgs(Nothing, "", "Server Return Nothing!"))
                Return Nothing

            End If
            Dim o As Object = Nothing
            Dim xmlparser As New DNE.JikJikoo.Parser()
            If xt = TwitterXmlTypes.User Then
                o = xmlparser.ParsUserXML(sXml)

            ElseIf xt = TwitterXmlTypes.Users Then
                o = xmlparser.ParsUsersXML(sXml)

            ElseIf xt = TwitterXmlTypes.Status Then
                o = xmlparser.ParsStatusXML(sXml)

            ElseIf xt = TwitterXmlTypes.DirectMessage Then
                o = xmlparser.ParsDirectmessageXML(sXml)
            End If
            Return CType(o, T)

        End Function

        Public Function GetImage(ByVal url As String) As Drawing.Image
            Dim b() As Byte = Me.WebClient.DownloadDataNoAuth(New Uri(url))
            If b Is Nothing Then Return Nothing
            Try
                Return Image.FromStream(New IO.MemoryStream(b))

            Catch ex As Exception
                Return Nothing

            End Try
            Return Nothing

        End Function

        Public Function GetSimpleHttpGet(ByVal url As String) As String
            Return Me.WebClient.DoGetNoAuth(New Uri(url))

        End Function

        Private Sub AddBytes(ByRef al As ArrayList, ByVal b As Byte(), ByVal count As Int32)
            For i As Int32 = 0 To count - 1
                al.Add(b(i))
            Next
        End Sub

        Private Function UrlEncode(ByVal s As String) As String
            Dim c() As Char = s.ToCharArray
            Dim ss As String = ""
            Dim unreservedChars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~"
            For i As Int32 = 0 To s.Length - 1
                If unreservedChars.IndexOf(c(i)) <> -1 Then
                    ss += c(i)

                ElseIf c(i) = " "c Then
                    ss += "%20"

                Else
                    ss += HttpUtility.UrlEncode(c(i)).ToUpper()

                End If


            Next
            Return ss

        End Function

#End Region

    End Class

End Namespace
