Imports System.Net
Imports System.Net.Sockets
Imports DNE.Twitter
Imports Org.Mentalis.Network.ProxySocket
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading

Namespace DNE.JikJikoo

    Public Class SocketWebClient
        Inherits DNE.JikJikoo.WebClient

        Public Event DownloadingDataStart As EventHandler
        Public Event DownloadingDataEnd As EventHandler
        Public Event HttpError As HttpEventHandler

#Region " Constructors "

        Public Sub New()
            MyBase.New()
        End Sub

        ''' <summary>
        ''' for basic authentication
        ''' </summary>
        ''' <param name="twitterUser"></param>
        ''' <param name="twitterPassword"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal twitterUser As String, ByVal twitterPassword As String)
            MyBase.New(twitterUser, twitterPassword)

        End Sub

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
            Dim hostEntry As IPHostEntry = Nothing 'Dns.GetHostEntry(host)
            Try
                hostEntry = Dns.GetHostEntry(host)

            Catch ex As SocketException
                RaiseEvent HttpError(Me, New HttpExEventArgs(ex, url, "Can not resolve host"))
                Throw New NoConnectionException()

            End Try
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

            ' for result
            Dim bytes As Integer = 0
            Dim strOut As String = ""
            Dim request As String = ""
            Try
                socket.Connect(ipe)

                If method.ToLower = "get" Then request = GenerateGetRequest(host, url, query, mustAuthenticate)
                If method.ToLower = "post" Then request = GeneratePostRequest(host, url, query, mustAuthenticate)

                Dim bytesSent As [Byte]() = Encoding.ASCII.GetBytes(request)
                Dim bytesReceived As [Byte]() = New [Byte](255) {}

                RaiseEvent DownloadingDataStart(Nothing, Nothing)

                ' send query
                socket.Send(bytesSent, bytesSent.Length, 0)

                ' get result
                Do
                    bytes = socket.Receive(bytesReceived, bytesReceived.Length, 0)
                    Thread.Sleep(25)
                    strOut += (Encoding.ASCII.GetString(bytesReceived, 0, bytes))
                Loop While bytes > 0

                socket.Close()
            Catch ex As SocketException
                If socket.Connected Then
                    socket.Disconnect(False)

                End If
                RaiseEvent HttpError(Me, New HttpExEventArgs(ex, url, "We got a error while downloading data"))

            End Try

            RaiseEvent DownloadingDataEnd(Nothing, Nothing)
            If strOut.Length > 4 Then
                'Check HTTP Headers
                Dim headers As New DNE.JikJikoo.HtmlHeaders(strOut.Substring(0, strOut.IndexOf(vbCrLf + vbCrLf)))
                strOut = strOut.Substring(strOut.IndexOf(vbCrLf + vbCrLf) + 4)
                If headers.StatusCode <> 200 Then
                    'TODO://
                    ' DNE.JikJikoo.Util.LogIt(request & headers.Text & vbCrLf & System.Text.RegularExpressions.Regex.Match(strOut, "<error>(.*?)</error>").Value)
                    DNE.JikJikoo.Util.LogIt(Regex.Match(strOut, "<error>(.*?)</error>").Groups(1).Value)
                    'DNE.JikJikoo.Util.LogIt(Regex.Match(strOut, "oauth_signature=(.*?)</request>").Groups(1).Value & vbCrLf)


                End If

            End If
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
        Private Function HttpDownloadSocket(ByVal method As String, ByVal url As String, ByVal query As String, ByVal mustAuth As Boolean) As Byte()
            ' specify host, url, port number and parameter
            Dim host As String = (New Uri(url)).Host
            Dim port As Integer = 80

            ' Retrieve IP from host name
            Dim hostEntry As IPHostEntry = Nothing 'Dns.GetHostEntry(host)
            Try
                hostEntry = Dns.GetHostEntry(host)

            Catch ex As SocketException
                RaiseEvent HttpError(Me, New HttpExEventArgs(ex, url, "Can not resolve host"))
                Return Nothing

            End Try

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

            ' for result
            Dim bytes As Integer = 0
            Dim strOut As String = ""
            Dim ba As New ArrayList
            Try
                socket.Connect(ipe)

                Dim request As String = ""
                If method.ToLower = "get" Then request = GenerateGetRequest(host, url, query, mustAuth)
                If method.ToLower = "post" Then request = GeneratePostRequest(host, url, query, mustAuth)


                Dim bytesSent As [Byte]() = Encoding.ASCII.GetBytes(request)
                Dim bytesReceived As [Byte]() = New [Byte](255) {}

                ' send query
                socket.Send(bytesSent, bytesSent.Length, 0)
                Dim ns As New NetworkStream(socket, True)
                ns.ReadTimeout = 5000


                Do
                    Dim ssize As Int32 = socket.Available
                    If ssize > bytesReceived.Length Then
                        ssize = bytesReceived.Length
                    End If
                    bytes = socket.Receive(bytesReceived, ssize, 0)
                    'bytes = ns.Read(bytesReceived, 0, bytesReceived.Length)
                    Thread.Sleep(25)
                    AddBytes(ba, bytesReceived, bytes)

                    'bytes = socket.Receive(bytesReceived, bytesReceived.Length, 0)
                    'Thread.Sleep(25)
                    'AddBytes(ba, bytesReceived, bytes)
                Loop While ns.DataAvailable 'bytes > 0
                socket.Close()

            Catch ex As SocketException
                If socket.Connected Then
                    socket.Disconnect(False)

                End If
                RaiseEvent HttpError(Me, New HttpExEventArgs(ex, url, "We got a error while downloading data"))

            End Try

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
            If query <> "" Then
                If (url.IndexOf("?") > 0) Then
                    url = (url & "&")
                Else
                    url = (url & "?")
                End If

            End If

            If query <> "" Then url += query 'HttpUtility.UrlEncode(query)
            Dim request As String = "GET " & url & " HTTP/1.1" & vbCrLf
            request += "Host: " & host & vbCrLf
            request += "User-Agent: JikJikoo" & vbCrLf
            'If _cookie <> "" Then
            '    request += "Cookie: " & _cookie & vbCrLf

            'End If
            If AuthenticationType = AuthType.Basic Then
                If mustAuth Then request += "Authorization:Basic " & Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(UserName & ":" & Password)) & vbCrLf

            End If
            request += vbCrLf
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
            Dim request As String = "POST " & url & " HTTP/1.1" & vbCrLf
            request += "Host: " & host & vbCrLf
            request += "User-Agent: JikJikoo" & vbCrLf
            request += "Content-Type: application/x-www-form-urlencoded" & vbCrLf
            If AuthenticationType = AuthType.Basic Then
                If mustAuth Then request += "Authorization:Basic " & Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(UserName & ":" & Password)) & vbCrLf

            End If
            request += "Content-Length:" & data.Length & vbCrLf & vbCrLf
            request += data
            Return request

        End Function

#End Region

        Public Overrides Function DoGet(ByVal url As System.Uri) As String
            Return HttpRequestSocket("GET", url.AbsolutePath, url.Query.Substring(1))

        End Function

        Public Overrides Function DoPost(ByVal url As System.Uri, ByVal data As String) As String
            Return HttpRequestSocket("POST", url.AbsolutePath, data)

        End Function

        Public Overrides Function DownloadData(ByVal url As System.Uri) As Byte()
            Return HttpDownloadSocket("GET", url.ToString(), "", True)

        End Function

        Public Overrides Function DoGetNoAuth(ByVal url As System.Uri) As String
            Return HttpRequestSocket("GET", url.AbsolutePath, url.Query.Substring(1), url.Host, False)

        End Function

        Public Overrides Function DownloadDataNoAuth(ByVal url As System.Uri) As Byte()
            Return HttpDownloadSocket("GET", url.ToString(), "", False)

        End Function

    End Class

End Namespace

