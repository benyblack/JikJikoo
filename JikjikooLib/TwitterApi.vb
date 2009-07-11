Imports System
Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.Net.Sockets
Imports System.Web
Imports System.Xml
Imports System.Drawing

Imports Org.Mentalis.Network.ProxySocket

Namespace DNE.JikJikoo

    Public Class TwitterApi

        Public Event DownloadingDataStart As EventHandler
        Public Event DownloadingDataEnd As EventHandler


        Public Sub New()

        End Sub

        ''' <summary>
        ''' Use this cunstructor for Basic Authentication
        ''' </summary>
        ''' <param name="user">Username in Twitter</param>
        ''' <param name="pass">Password in Twitter</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal user As String, ByVal pass As String)
            Me._username = user
            Me._password = pass
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
            Me._username = user
            Me.Token = tok
            Me.TokenSecret = toksecret
            _authtype = AuthType.oAuth

        End Sub


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

        End Sub

        Private Function HttpRequest(ByVal method As String, ByVal url As String, ByVal query As String) As String
            If AuthenticationType = AuthType.oAuth Then
                Dim o As New oAuthExample.oAuthTwitter(Me)
                o.ConsumerKey = "Um0Z859qORQgTkN4ehyqdw"
                o.ConsumerSecret = "F1Ce6okvMspIYBbrJJ7Qh2LkvkJNhxruiI2Ln7CmA"
                o.Token = Me.Token
                o.TokenSecret = Me.TokenSecret

                Dim normurl As String = ""
                Dim normparam As String = ""

                Dim sign As String = o.GenerateSignature(New Uri("http://twitter.com" & url), o.ConsumerKey, o.ConsumerSecret, o.Token, o.TokenSecret, method, o.GenerateTimeStamp(), _
                                    o.GenerateNonce(), normurl, normparam)
                url = String.Format("{0}?{1}&oauth_signature={2}", normurl, normparam, sign)

            End If

            If Me.ProxyType = ProxyTypes.Socks4 Or Me.ProxyType = ProxyTypes.Socks5 Or Me.ProxyType = ProxyTypes.None Then
                Return HttpRequestSocket(method, url, query)

            Else
                Return HttpRequest(method, url, query)

            End If
            Return ""
        End Function



#Region " Urls "

        'timeline
        Private publictimelineurl As String = "/statuses/public_timeline.xml"

        ''' <summary>
        ''' 
        '''Parameters:
        '''since_id.  Optional.  Returns only statuses with an ID greater than (that is, more recent than) the specified ID.
        '''http://twitter.com/statuses/friends_timeline.xml?since_id=12345
        '''max_id. Optional.  Returns only statuses with an ID less than (that is, older than) or equal to the specified ID.
        '''Example: http://twitter.com/statuses/friends_timeline.xml?max_id=54321
        '''count.  Optional.  Specifies the number of statuses to retrieve. May not be greater than 200. 
        '''Example: http://twitter.com/statuses/friends_timeline.xml?count=5 
        '''page. Optional. Specifies the page of results to retrieve. Note: there are pagination limits.
        '''Example: http://twitter.com/statuses/friends_timeline.rss?page=3
        ''' </summary>
        ''' <remarks></remarks>
        Private friendtimelineurl As String = "/statuses/friends_timeline.xml"
        Private usertimelineurl As String = "/statuses/user_timeline.xml"
        Private mentionsurl As String = "/statuses/mentions.xml"


        'status
        Private showstatusurl As String = "/statuses/show/{0}.xml"
        Private updatestatusurl As String = "/statuses/update.xml"
        Private destrystatusurl As String = "/statuses/destroy/{0}.xml"

        'user
        Private showuserurl As String = "/users/show.xml"
        Private friendsurl As String = "/statuses/friends..xml"
        Private followersurl As String = "/statuses/followers.xml"


        'direct message
        Private directmessageurl As String = "/direct_messages.xml"
        Private sentmessageurl As String = "/direct_messages/sent.xml"
        Private newmessageurl As String = "/direct_messages/new.xml"
        Private destroymessageurl As String = "/direct_messages/destroy/{0}.xml"

        'friendship
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

            End Get
            Set(ByVal value As ProxyTypes)

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

#Region " Api Functions "

        'TimeLine
        '-----------------------------------------------------------

        ''' <summary>
        ''' statuses/public_timeline
        ''' Returns the 20 most recent statuses from non-protected users who have set a custom user icon. The public timeline is cached for 60 seconds so requesting it more often than that is a waste of resources.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPublicTimeLine() As ObjectModel.Collection(Of DNE.Twitter.Status)
            Dim s As String = HttpRequest("GET", publictimelineurl, "")
            Return ParsStatusXML(s)

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
            Dim s As String = HttpRequest("GET", friendtimelineurl, "")
            Return ParsStatusXML(s)

        End Function

        ''' <summary>
        ''' statuses/friends_timeline
        ''' Returns the 20 most recent statuses posted by the authenticating user and that user's friends. This is the equivalent of /timeline/home on the Web.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFriendsTimeLinesinceid(ByVal since_id As String) As ObjectModel.Collection(Of DNE.Twitter.Status)
            Dim s As String = HttpRequest("GET", friendtimelineurl, "since_id=" & since_id)
            Return ParsStatusXML(s)

        End Function

        ''' <summary>
        ''' statuses/user_timeline
        ''' Returns the 20 most recent statuses posted from the authenticating user. It's also possible to request another user's timeline via the id parameter. This is the equivalent of the Web /user page for your own user, or the profile page for a third party.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUserTimeLine() As ObjectModel.Collection(Of DNE.Twitter.Status)
            Dim s As String = HttpRequest("GET", usertimelineurl, "")
            Return ParsStatusXML(s)

        End Function

        ''' <summary>
        ''' statuses/mentions
        ''' Returns the 20 most recent mentions (status containing @username) for the authenticating user.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetMentions() As ObjectModel.Collection(Of DNE.Twitter.Status)
            Dim s As String = HttpRequest("GET", mentionsurl, "")
            Return ParsStatusXML(s)

        End Function

        'status
        '-----------------------------------------------------------

        ''' <summary>
        ''' Twitter REST API Method: statuses/show
        ''' Returns a single status, specified by the id parameter below.  The status's author will be returned inline.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ShowStatus(ByVal statusid As String) As DNE.Twitter.Status
            Dim s As String = HttpRequest("GET", showstatusurl, "")
            Return ParsStatusXML(s)(0)

        End Function

        ''' <summary>
        ''' statuses/update
        ''' Updates the authenticating user's status.  Requires the status parameter specified below.  Request must be a POST.  A status update with text identical to the authenticating user's current status will be ignored to prevent duplicates.
        ''' </summary>
        ''' <param name="status">Text of new status</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateStatus(ByVal status As String) As String
            Return HttpRequest("POST", updatestatusurl, "status=" & HttpUtility.UrlEncode(status))

        End Function

        ''' <summary>
        ''' statuses/destroy
        ''' Destroys the status specified by the required ID parameter.  The authenticating user must be the author of the specified status.
        ''' </summary>
        ''' <param name="statusid"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DestroyStatus(ByVal statusid As String) As String
            Return HttpRequest("POST", destrystatusurl, "id=" & statusid)

        End Function

        ''' <summary>
        ''' Send Direct Message To Another User
        ''' </summary>
        ''' <param name="ToUser">User Id of who that message will send to him</param>
        ''' <param name="message">Text of message</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SendMessage(ByVal ToUser As String, ByVal message As String) As String
            Return HttpRequest("POST", newmessageurl, String.Format("user={0}&text={1}", ToUser, HttpUtility.UrlEncode(message)))

        End Function

        'account
        '-----------------------------------------------------------

        ''' <summary>
        ''' Veryfy Credentials
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function VerifyCredentials() As DNE.Twitter.User
            Dim s As String = HttpRequest("GET", accountverifycredentialsurl, "")
            Return ParsUserXML(s)

        End Function

        'user 

        ''' <summary>
        ''' users/show
        ''' Returns extended information of a given user, specified by ID or screen name as per the required id parameter.  The author's most recent status will be returned inline.
        ''' </summary>
        ''' <param name="screenname">Username in Twitter</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UserShow(ByVal screenname As String) As DNE.Twitter.User
            Dim s As String = HttpRequest("GET", showuserurl, "screen_name=" & screenname)
            Return ParsUserXML(s)
        End Function

#End Region

#Region " Http Functions "

        ''' <summary>
        ''' Executes an HTTP GET command and retrives the information.(from Yedda Project)
        ''' </summary>
        ''' <param name="url">The URL to perform the GET operation</param>
        ''' <param name="userName">The username to use with the request</param>
        ''' <param name="password">The password to use with the request</param>
        ''' <returns>The response of the request, or null if we got 404 or nothing.</returns>
        Protected Function ExecuteGetCommand(ByVal url As String, ByVal userName As String, ByVal password As String) As String
            'TODO: must replace with socket get
            Using client As New WebClient()

                Dim wp As New WebProxy(Me.ProxyIP, ProxyPort)
                wp.Credentials = New NetworkCredential(userName, password)
                client.Proxy = wp

                If AuthenticationType = AuthType.Basic Then
                    If Not String.IsNullOrEmpty(userName) AndAlso Not String.IsNullOrEmpty(password) Then
                        client.Credentials = New NetworkCredential(userName, password)
                    End If

                End If

                Try
                    Using stream As IO.Stream = client.OpenRead(url)
                        Using reader As New IO.StreamReader(stream)
                            Return reader.ReadToEnd()
                        End Using
                    End Using
                Catch ex As WebException
                    '
                    ' Handle HTTP 404 errors gracefully and return a null string to indicate there is no content.
                    '
                    If TypeOf ex.Response Is HttpWebResponse Then
                        If TryCast(ex.Response, HttpWebResponse).StatusCode = HttpStatusCode.NotFound Then
                            Return Nothing
                        End If
                    End If

                    Throw ex
                End Try
            End Using

            Return Nothing
        End Function

        ''' <summary>
        ''' Executes an HTTP POST command and retrives the information. (from Yedda Project)
        ''' This function will automatically include a "source" parameter if the "Source" property is set.
        ''' </summary>
        ''' <param name="url">The URL to perform the POST operation</param>
        ''' <param name="userName">The username to use with the request</param>
        ''' <param name="password">The password to use with the request</param>
        ''' <param name="data">The data to post</param>
        ''' <returns>The response of the request, or null if we got 404 or nothing.</returns>
        Protected Function ExecutePostCommand(ByVal url As String, ByVal userName As String, ByVal password As String, ByVal data As String) As String
            Dim request As WebRequest = WebRequest.Create(url)
            Dim wp As New WebProxy(Me.ProxyIP, ProxyPort)
            wp.Credentials = New NetworkCredential(userName, password)
            request.Proxy = wp

            If Not String.IsNullOrEmpty(userName) AndAlso Not String.IsNullOrEmpty(password) Then
                If AuthenticationType = AuthType.Basic Then
                    request.Credentials = New NetworkCredential(userName, password)

                End If

                request.ContentType = "application/x-www-form-urlencoded"
                request.Method = "POST"

                'request.Headers.Add("X-Twitter-Client", "JikJikoo")
                'request.Headers.Add("X-Twitter-Version", "0.1 beta")
                'request.Headers.Add("X-Twitter-URL", "http://code.google.com/p/jikjikoo")

                Dim bytes As Byte() = Encoding.UTF8.GetBytes(data)

                request.ContentLength = bytes.Length
                Using requestStream As IO.Stream = request.GetRequestStream()
                    requestStream.Write(bytes, 0, bytes.Length)

                    Using response As WebResponse = request.GetResponse()
                        Using reader As New IO.StreamReader(response.GetResponseStream())
                            Return reader.ReadToEnd()
                        End Using
                    End Using
                End Using
            End If
            Return Nothing

        End Function

        Protected Function DownloadFromHttp(ByVal url As String) As Byte()
            Dim wc As New WebClient()
            Dim wp As New WebProxy(Me.ProxyIP, ProxyPort)
            wp.Credentials = New NetworkCredential(UserName, Password)
            wc.Proxy = wp
            Return wc.DownloadData(url)

        End Function

        Private Function HttpRequestHTTP(ByVal method As String, ByVal url As String, ByVal query As String) As String
            If method.ToLower = "post" Then
                Return ExecutePostCommand(url, UserName, Password, query)
            ElseIf method.ToLower = "get" Then
                Return ExecuteGetCommand(url, UserName, Password)
            End If
            Return ""

        End Function

#End Region

#Region " Socket Function "

        ''' <summary>
        ''' Send Http Request from socket and recieve responsed data
        ''' </summary>
        ''' <param name="method">Get or Post</param>
        ''' <param name="url"></param>
        ''' <param name="query"></param>
        ''' <param name="host"></param>
        ''' <param name="mustAuthenticate">Optional, used by basic authentication</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function HttpRequestSocket(ByVal method As String, ByVal url As String, ByVal query As String, Optional ByVal host As String = "twitter.com", Optional ByVal mustAuthenticate As Boolean = True) As String
            Dim port As Integer = 80
          
            ' Retrieve IP from host name
            Dim hostEntry As IPHostEntry = Dns.GetHostEntry(host)
            Dim address As IPAddress = hostEntry.AddressList(0)
            Dim ipe As New IPEndPoint(address, port)

            ' Make connection
            Dim socket As New ProxySocket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
            socket.ProxyType = Me.ProxyType  'ProxyTypes.Socks4
            If Me.ProxyType <> ProxyTypes.None Then
                socket.ProxyEndPoint = New IPEndPoint(IPAddress.Parse(Me.ProxyIP), Me.ProxyPort)

            End If
            If Me.ProxyUserName <> "" Then
                socket.ProxyUser = Me.ProxyUserName
                socket.ProxyPass = Me.ProxyPassword
            Else
                socket.ProxyUser = ""
                socket.ProxyPass = ""
            End If
            socket.Connect(ipe)

            Dim request As String = ""
            If method.ToLower = "get" Then request = GenerateGetRequest(host, url, query, mustAuthenticate)
            If method.ToLower = "post" Then request = GeneratePostRequest(host, url, query, mustAuthenticate)


            Dim bytesSent As [Byte]() = Encoding.ASCII.GetBytes(request)
            Dim bytesReceived As [Byte]() = New [Byte](255) {}

            RaiseEvent DownloadingDataStart(Nothing, Nothing)

            ' send query
            socket.Send(bytesSent, bytesSent.Length, 0)

            ' get result
            Dim bytes As Integer = 0
            Dim strOut As String = ""
            Do
                bytes = socket.Receive(bytesReceived, bytesReceived.Length, 0)
                Thread.Sleep(25)
                strOut += (Encoding.ASCII.GetString(bytesReceived, 0, bytes))
            Loop While bytes > 0

            socket.Close()
            RaiseEvent DownloadingDataEnd(Nothing, Nothing)
            If strOut.Length > 4 Then strOut = strOut.Substring(strOut.IndexOf(vbCrLf + vbCrLf) + 4)
            Return strOut

        End Function

        ''' <summary>
        ''' A usefull method for downloading small files
        ''' this method does not require authentication
        ''' </summary>
        ''' <param name="method">Get or Post</param>
        ''' <param name="url"></param>
        ''' <param name="query"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function HttpDownloadSocket(ByVal method As String, ByVal url As String, ByVal query As String) As Byte()
            ' specify host, url, port number and parameter
            Dim host As String = (New Uri(url)).Host
            Dim port As Integer = 80

            ' Retrieve IP from host name
            Dim hostEntry As IPHostEntry = Dns.GetHostEntry(host)
            Dim address As IPAddress = hostEntry.AddressList(0)
            Dim ipe As New IPEndPoint(address, port)

            ' Make connection
            Dim socket As New ProxySocket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
            socket.ProxyType = Me.ProxyType
            If Me.ProxyType <> ProxyTypes.None Then
                socket.ProxyEndPoint = New IPEndPoint(IPAddress.Parse(Me.ProxyIP), Me.ProxyPort)

            End If
            If Me.ProxyUserName <> "" Then
                socket.ProxyUser = Me.ProxyUserName
                socket.ProxyPass = Me.ProxyPassword
            Else
                socket.ProxyUser = ""
                socket.ProxyPass = ""
            End If
            socket.Connect(ipe)

            Dim request As String = ""
            If method.ToLower = "get" Then request = GenerateGetRequest(host, url, query)
            If method.ToLower = "post" Then request = GeneratePostRequest(host, url, query)


            Dim bytesSent As [Byte]() = Encoding.ASCII.GetBytes(request)
            Dim bytesReceived As [Byte]() = New [Byte](255) {}

            ' send query
            socket.Send(bytesSent, bytesSent.Length, 0)
            Dim ns As New NetworkStream(socket, True)
            ns.ReadTimeout = 5000

            ' get result
            Dim bytes As Integer = 0
            Dim strOut As String = ""
            Dim ba As New ArrayList
            Do
                bytes = ns.Read(bytesReceived, 0, bytesReceived.Length)
                ' currently i have no idea for this line but 
                ' ns will not read completelly
                Thread.Sleep(25)
                AddBytes(ba, bytesReceived, bytes)
            Loop While ns.DataAvailable

            socket.Close()

            ' seeking end of header
            Dim b() As Byte = ba.ToArray(GetType(Byte))
            Dim b1310 As Int32 = 0
            For i As Int32 = 0 To b.Length - 1
                If b(i) = 13 Then
                    If (i < b.Length - 4) Then
                        If b(i + 1) = 10 And b(i + 2) = 13 And b(i + 3) = 10 Then
                            b1310 = i + 4
                        End If

                    End If
                End If
            Next
            Dim outb(b.Length - b1310 - 1) As Byte
            Array.Copy(b, b1310, outb, 0, b.Length - b1310)
            Return outb

        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="host"></param>
        ''' <param name="url"></param>
        ''' <param name="query"></param>
        ''' <param name="mustAuth">Optional,this will use for Basic Authentication</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GenerateGetRequest(ByVal host As String, ByVal url As String, _
                            ByVal query As String, Optional ByVal mustAuth As Boolean = False) As String
            If (url.IndexOf("?") > 0) Then
                url = (url & "&")
            Else
                url = (url & "?")
            End If

            If query <> "" Then url += query 'HttpUtility.UrlEncode(query)
            Dim request As String = "GET " & url & " HTTP/1.1" & vbLf
            request += "Host: " & host & vbLf
            request += "User-Agent: JikJikoo" & vbLf
            If AuthenticationType = AuthType.Basic Then
                If mustAuth Then request += "Authorization:Basic " & Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(UserName & ":" & Password)) & vbLf

            End If
            request += vbLf
            Return request

        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="host"></param>
        ''' <param name="url"></param>
        ''' <param name="data"></param>
        ''' <param name="mustAuth">Optional,this will use for Basic Authentication</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GeneratePostRequest(ByVal host As String, _
                ByVal url As String, ByVal data As String, Optional ByVal mustAuth As Boolean = False) As String
            Dim request As String = "POST " & url & " HTTP/1.1" & vbLf
            request += "Host: " & host & vbLf
            request += "User-Agent: JikJikoo" & vbLf
            request += "Content-Type: application/x-www-form-urlencoded" & vbLf
            If AuthenticationType = AuthType.Basic Then
                If mustAuth Then request += "Authorization:Basic " & Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(UserName & ":" & Password)) & vbLf

            End If
            request += "Content-Length:" & data.Length & vbLf & vbLf
            request += data
            Return request

        End Function

#End Region

#Region " Util "

        Private Function ParsStatusXML(ByVal s As String) As ObjectModel.Collection(Of DNE.Twitter.Status)
            Dim xdoc As New XmlDocument()
            xdoc.LoadXml(s)
            Dim xnl As XmlNodeList = xdoc.SelectNodes("/statuses/status")
            Dim sc As New ObjectModel.Collection(Of DNE.Twitter.Status)
            'Dim uc As New ObjectModel.Collection(Of DNE.Twitter.User)

            For i As Int32 = 0 To xnl.Count - 1
                Dim st As New DNE.Twitter.Status()
                st.Favorited = xdoc.SelectNodes("/statuses/status/favorited")(i).InnerText
                st.Created_At = xdoc.SelectNodes("/statuses/status/created_at")(i).InnerText
                st.Id = xdoc.SelectNodes("/statuses/status/id")(i).InnerText
                st.In_reply_to_screen_name = xdoc.SelectNodes("/statuses/status/in_reply_to_screen_name")(i).InnerText
                st.In_reply_to_status_id = xdoc.SelectNodes("/statuses/status/in_reply_to_status_id")(i).InnerText
                st.In_reply_to_user_id = xdoc.SelectNodes("/statuses/status/in_reply_to_user_id")(i).InnerText
                st.Source = xdoc.SelectNodes("/statuses/status/source")(i).InnerText
                st.Text = xdoc.SelectNodes("/statuses/status/text")(i).InnerText
                st.Truncated = xdoc.SelectNodes("/statuses/status/truncated")(i).InnerText

                Dim u As New DNE.Twitter.User()
                u.Created_at = xdoc.SelectNodes("/statuses/status/user/created_at")(i).InnerText
                u.Description = xdoc.SelectNodes("/statuses/status/user/description")(i).InnerText
                u.Favourites_count = xdoc.SelectNodes("/statuses/status/user/favourites_count")(i).InnerText
                u.Followers_count = xdoc.SelectNodes("/statuses/status/user/followers_count")(i).InnerText
                u.Following = xdoc.SelectNodes("/statuses/status/user/following")(i).InnerText
                u.Friends_count = xdoc.SelectNodes("/statuses/status/user/friends_count")(i).InnerText
                u.Id = xdoc.SelectNodes("/statuses/status/user/id")(i).InnerText
                u.Location = xdoc.SelectNodes("/statuses/status/user/location")(i).InnerText
                u.Name = xdoc.SelectNodes("/statuses/status/user/name")(i).InnerText
                u.Notifications = xdoc.SelectNodes("/statuses/status/user/notifications")(i).InnerText
                u.Profile_background_color = xdoc.SelectNodes("/statuses/status/user/profile_background_color")(i).InnerText
                u.Profile_background_image_url = xdoc.SelectNodes("/statuses/status/user/profile_background_image_url")(i).InnerText
                u.Profile_background_tile = xdoc.SelectNodes("/statuses/status/user/profile_background_tile")(i).InnerText
                u.Profile_image_url = xdoc.SelectNodes("/statuses/status/user/profile_image_url")(i).InnerText
                u.Profile_link_color = xdoc.SelectNodes("/statuses/status/user/profile_link_color")(i).InnerText
                u.Profile_sidebar_border_color = xdoc.SelectNodes("/statuses/status/user/profile_sidebar_border_color")(i).InnerText
                u.Profile_sidebar_fill_color = xdoc.SelectNodes("/statuses/status/user/profile_sidebar_fill_color")(i).InnerText
                u.Profile_text_color = xdoc.SelectNodes("/statuses/status/user/profile_text_color")(i).InnerText
                u.Protected = xdoc.SelectNodes("/statuses/status/user/protected")(i).InnerText
                u.Screen_Name = xdoc.SelectNodes("/statuses/status/user/screen_name")(i).InnerText
                u.Statuses_count = xdoc.SelectNodes("/statuses/status/user/statuses_count")(i).InnerText
                u.Time_zone = xdoc.SelectNodes("/statuses/status/user/time_zone")(i).InnerText
                u.Url = xdoc.SelectNodes("/statuses/status/user/url")(i).InnerText
                u.Utc_offset = xdoc.SelectNodes("/statuses/status/user/utc_offset")(i).InnerText
                u.Verified = xdoc.SelectNodes("/statuses/status/user/verified")(i).InnerText
                st.User = u

                'uc.Add(u)
                sc.Add(st)

            Next
            Return sc

        End Function

        Private Function ParsUserXML(ByVal s As String) As DNE.Twitter.User
            Dim xdoc As New XmlDocument()
            xdoc.LoadXml(s)
            Dim xnl As XmlNodeList = xdoc.SelectNodes("/user")
            If xnl Is Nothing OrElse xnl.Count = 0 Then Return Nothing

            Dim u As New DNE.Twitter.User()
            u.Created_at = xdoc.SelectSingleNode("/user/created_at").InnerText
            u.Description = xdoc.SelectSingleNode("/user/description").InnerText
            u.Favourites_count = xdoc.SelectSingleNode("/user/favourites_count").InnerText
            u.Followers_count = xdoc.SelectSingleNode("/user/followers_count").InnerText
            u.Following = xdoc.SelectSingleNode("/user/following").InnerText
            u.Friends_count = xdoc.SelectSingleNode("/user/friends_count").InnerText
            u.Id = xdoc.SelectSingleNode("/user/id").InnerText
            u.Location = xdoc.SelectSingleNode("/user/location").InnerText
            u.Name = xdoc.SelectSingleNode("/user/name").InnerText
            u.Notifications = xdoc.SelectSingleNode("/user/notifications").InnerText
            u.Profile_background_color = xdoc.SelectSingleNode("/user/profile_background_color").InnerText
            u.Profile_background_image_url = xdoc.SelectSingleNode("/user/profile_background_image_url").InnerText
            u.Profile_background_tile = xdoc.SelectSingleNode("/user/profile_background_tile").InnerText
            u.Profile_image_url = xdoc.SelectSingleNode("/user/profile_image_url").InnerText
            u.Profile_link_color = xdoc.SelectSingleNode("/user/profile_link_color").InnerText
            u.Profile_sidebar_border_color = xdoc.SelectSingleNode("/user/profile_sidebar_border_color").InnerText
            u.Profile_sidebar_fill_color = xdoc.SelectSingleNode("/user/profile_sidebar_fill_color").InnerText
            u.Profile_text_color = xdoc.SelectSingleNode("/user/profile_text_color").InnerText
            u.Protected = xdoc.SelectSingleNode("/user/protected").InnerText
            u.Screen_Name = xdoc.SelectSingleNode("/user/screen_name").InnerText
            u.Statuses_count = xdoc.SelectSingleNode("/user/statuses_count").InnerText
            u.Time_zone = xdoc.SelectSingleNode("/user/time_zone").InnerText
            u.Url = xdoc.SelectSingleNode("/user/url").InnerText
            u.Utc_offset = xdoc.SelectSingleNode("/user/utc_offset").InnerText
            u.Verified = xdoc.SelectSingleNode("/user/verified").InnerText

            Dim st As New DNE.Twitter.StatusBase()
            If Not CBool(u.Protected) Then
                st.Favorited = xdoc.SelectSingleNode("/user/status/favorited").InnerText
                st.Created_At = xdoc.SelectSingleNode("/user/status/created_at").InnerText
                st.Id = xdoc.SelectSingleNode("/user/status/id").InnerText
                st.In_reply_to_screen_name = xdoc.SelectSingleNode("/user/status/in_reply_to_screen_name").InnerText
                st.In_reply_to_status_id = xdoc.SelectSingleNode("/user/status/in_reply_to_status_id").InnerText
                st.In_reply_to_user_id = xdoc.SelectSingleNode("/user/status/in_reply_to_user_id").InnerText
                st.Source = xdoc.SelectSingleNode("/user/status/source").InnerText
                st.Text = xdoc.SelectSingleNode("/user/status/text").InnerText
                st.Truncated = xdoc.SelectSingleNode("/user/status/truncated").InnerText

                u.Status = st
            End If


            Return u

        End Function

        Public Function GetImage(ByVal url As String) As Drawing.Image
            If Me.ProxyType = ProxyTypes.Http Then
                Return Image.FromStream(New IO.MemoryStream(DownloadFromHttp(url)))

            Else

                Dim b() As Byte = HttpDownloadSocket("GET", url, "")
                Dim ms As New IO.MemoryStream(b)
                Try
                    Return Image.FromStream(ms)

                Catch ex As Exception
                    ex.ToString()

                End Try

            End If
            Return Nothing

        End Function

        Public Function GetSimpleHttpGet(ByVal url As String) As String
            If Me.ProxyType = ProxyTypes.Socks4 Or Me.ProxyType = ProxyTypes.Socks5 Or Me.ProxyType = ProxyTypes.None Then
                Return HttpRequestSocket("GET", url, "", (New Uri(url)).Host, False)

            Else
                Return HttpRequest("GET", url, "")

            End If
            Return ""

        End Function


        Private Sub AddBytes(ByRef al As ArrayList, ByVal b As Byte(), ByVal count As Int32)
            For i As Int32 = 0 To count - 1
                al.Add(b(i))
            Next
        End Sub

#End Region


    End Class

    Public Enum ProxyType As Int32
        None = 0
        HTTP = 1
        SOCKS4 = 2
        SOCKS5 = 3

    End Enum

    Public Enum AuthType
        Basic = 0
        oAuth = 1

    End Enum

End Namespace

