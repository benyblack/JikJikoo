Imports System.Net
Imports Org.Mentalis.Network.ProxySocket
Imports DNE.Twitter
Imports System.Text

Namespace DNE.JikJikoo

    Public Class HttpWebClient
        Inherits DNE.JikJikoo.WebClient

        Public Event DownloadingDataStart As EventHandler
        Public Event DownloadingDataEnd As EventHandler
        Public Event HttpError As HttpEventHandler

#Region " Http Functions "

        ''' <summary>
        ''' Executes an HTTP GET command and retrives the information.(from Yedda Project)
        ''' </summary>
        ''' <param name="url">The URL to perform the GET operation</param>
        ''' <returns>The response of the request, or null if we got 404 or nothing.</returns>
        Protected Function ExecuteGetCommand(ByVal url As String) As String
            'TODO: must replace with socket get
            Using client As New System.Net.WebClient()

                Dim wp As New WebProxy(Me.ProxyIP, ProxyPort)
                wp.Credentials = New NetworkCredential(Me.ProxyUserName, Me.ProxyPassword)
                client.Proxy = wp

                If AuthenticationType = AuthType.Basic Then
                    If Not String.IsNullOrEmpty(UserName) AndAlso Not String.IsNullOrEmpty(Password) Then
                        client.Credentials = New NetworkCredential(Me.UserName, Me.Password)
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
        ''' <param name="data">The data to post</param>
        ''' <returns>The response of the request, or null if we got 404 or nothing.</returns>
        Protected Function ExecutePostCommand(ByVal url As String, ByVal data As String) As String
            Dim request As WebRequest = WebRequest.Create(url)
            Dim wp As New WebProxy(Me.ProxyIP, ProxyPort)
            wp.Credentials = New NetworkCredential(Me.ProxyUserName, Me.ProxyPassword)
            request.Proxy = wp

            If Not String.IsNullOrEmpty(UserName) AndAlso Not String.IsNullOrEmpty(Password) Then
                If AuthenticationType = AuthType.Basic Then
                    request.Credentials = New NetworkCredential(Me.UserName, Me.Password)

                End If

                request.ContentType = "application/x-www-form-urlencoded"
                request.Method = "POST"

                'request.Headers.Add("X-Twitter-Client", "JikJikoo")
                'request.Headers.Add("X-Twitter-Version", "0.1 beta")
                'request.Headers.Add("X-Twitter-URL", "http://jikjikoo.codeplex.com/")

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
            If url.Trim = "" Then Return Nothing
            Dim wc As New System.Net.WebClient()
            If Me.ProxyType = ProxyTypes.Http Then
                Dim wp As New WebProxy(Me.ProxyIP, ProxyPort)
                wp.Credentials = New NetworkCredential(Me.ProxyUserName, Me.ProxyPassword)
                wc.Proxy = wp

            End If
            Dim b() As Byte = Nothing
            Try
                b = wc.DownloadData(url)

            Catch ex As WebException
                '
                ' Handle HTTP 404 errors gracefully and return a null string to indicate there is no content.
                '
                RaiseEvent HttpError(Me, New HttpExEventArgs(ex, url, "Server Not Responsing or Url Not Found"))
                If TypeOf ex.Response Is HttpWebResponse Then
                    If TryCast(ex.Response, HttpWebResponse).StatusCode = HttpStatusCode.NotFound Then
                        Return Nothing
                    End If
                End If

            End Try
            Return b
        End Function

        Private Function HttpRequestHTTP(ByVal method As String, ByVal url As String, ByVal query As String) As String
            If method.ToLower = "post" Then
                Return ExecutePostCommand(url, query)
            ElseIf method.ToLower = "get" Then
                Return ExecuteGetCommand(url)
            End If
            Return ""

        End Function

#End Region

    End Class

End Namespace
