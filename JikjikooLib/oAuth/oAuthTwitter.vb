Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Net
Imports System.IO
Imports System.Collections.Specialized

Namespace oAuthExample
    Public Class oAuthTwitter
        Inherits OAuthBase
        Public Enum Method
            [GET]
            POST
        End Enum
        Public Const REQUEST_TOKEN As String = "http://twitter.com/oauth/request_token"
        Public Const AUTHORIZE As String = "http://twitter.com/oauth/authorize"
        Public Const ACCESS_TOKEN As String = "http://twitter.com/oauth/access_token"

        Private _consumerKey As String = ""
        Private _consumerSecret As String = ""
        Private _token As String = ""
        Private _tokenSecret As String = ""

        'an instance of twitterapi for using its http methods
        Private twa As DNE.JikJikoo.TwitterApi
        Public Sub New(ByVal twapi As DNE.JikJikoo.TwitterApi)
            twa = twapi

        End Sub

        Public Sub New()

        End Sub

#Region "Properties"
        Public Property ConsumerKey() As String
            Get
                If _consumerKey.Length = 0 Then
                    _consumerKey = ConfigurationManager.AppSettings("consumerKey")
                End If
                Return _consumerKey
            End Get
            Set(ByVal value As String)
                _consumerKey = value
            End Set
        End Property

        Public Property ConsumerSecret() As String
            Get
                If _consumerSecret.Length = 0 Then
                    _consumerSecret = ConfigurationManager.AppSettings("consumerSecret")
                End If
                Return _consumerSecret
            End Get
            Set(ByVal value As String)
                _consumerSecret = value
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
                Return _tokenSecret
            End Get
            Set(ByVal value As String)
                _tokenSecret = value
            End Set
        End Property
#End Region

        ''' <summary>
        ''' Get the link to Twitter's authorization page for this application.
        ''' </summary>
        ''' <returns>The url with a valid request token, or a null string.</returns>
        Public Function AuthorizationLinkGet() As String
            Dim ret As String = Nothing

            Dim response As String = oAuthWebRequest(Method.[GET], REQUEST_TOKEN, [String].Empty)
           
            If response.Length > 0 Then
                'response contains token and token secret.  We only need the token.
                Dim qs As NameValueCollection = HttpUtility.ParseQueryString(response)
                If qs("oauth_token") IsNot Nothing Then
                    ret = (AUTHORIZE & "?oauth_token=") + qs("oauth_token")
                End If
            End If
            Return ret
        End Function

        ''' <summary>
        ''' Exchange the request token for an access token.
        ''' </summary>
        ''' <param name="authToken">The oauth_token is supplied by Twitter's authorization page following the callback.</param>
        Public Sub AccessTokenGet(ByVal authToken As String)
            'For Verifying PIN code
            authToken = "&oauth_verifier=" & authToken

            Me.Token += authToken

            Dim response As String = oAuthWebRequest(Method.[GET], ACCESS_TOKEN, [String].Empty)

            If response.Length > 0 Then
                'Store the Token and Token Secret
                Dim qs As NameValueCollection = HttpUtility.ParseQueryString(response)
                If qs("oauth_token") IsNot Nothing Then
                    Me.Token = qs("oauth_token")
                End If
                If qs("oauth_token_secret") IsNot Nothing Then
                    Me.TokenSecret = qs("oauth_token_secret")
                End If
            End If
        End Sub

        ''' <summary>
        ''' Submit a web request using oAuth.
        ''' </summary>
        ''' <param name="method__1">GET or POST</param>
        ''' <param name="url">The full url, including the querystring.</param>
        ''' <param name="postData">Data to post (querystring format)</param>
        ''' <returns>The web server response.</returns>
        Public Function oAuthWebRequest(ByVal method__1 As Method, ByVal url As String, ByVal postData As String) As String
            Dim outUrl As String = ""
            Dim querystring As String = ""
            Dim ret As String = ""


            'Setup postData for signing.
            'Add the postData to the querystring.
            If method__1 = Method.POST Then
                If postData.Length > 0 Then
                    'Decode the parameters and re-encode using the oAuth UrlEncode method.
                    Dim qs As NameValueCollection = HttpUtility.ParseQueryString(postData)
                    postData = ""
                    For Each key As String In qs.AllKeys
                        If postData.Length > 0 Then
                            postData += "&"
                        End If
                        qs(key) = HttpUtility.UrlDecode(qs(key))
                        qs(key) = Me.UrlEncode(qs(key))

                        postData += (key & "=") + qs(key)
                    Next
                    If url.IndexOf("?") > 0 Then
                        url += "&"
                    Else
                        url += "?"
                    End If
                    url += postData
                End If
            End If

            Dim uri As New Uri(url)

            Dim nonce As String = Me.GenerateNonce()
            Dim timeStamp As String = Me.GenerateTimeStamp()

            'Generate Signature
            Dim sig As String = Me.GenerateSignature(uri, Me.ConsumerKey, Me.ConsumerSecret, Me.Token, Me.TokenSecret, method__1.ToString(), _
             timeStamp, nonce, outUrl, querystring)

            querystring += "&oauth_signature=" & HttpUtility.UrlEncode(sig)

            'Convert the querystring to postData
            If method__1 = Method.POST Then
                postData = querystring
                querystring = ""
            End If

            If querystring.Length > 0 Then
                outUrl += "?"
            End If

            ret = twa.GetSimpleHttpGet(outUrl + querystring)
            'ret = WebRequest(method__1, outUrl + querystring, postData)

            Return ret
        End Function


        ''' <summary>
        ''' Web Request Wrapper
        ''' </summary>
        ''' <param name="method__1">Http Method</param>
        ''' <param name="url">Full url to the web resource</param>
        ''' <param name="postData">Data to post in querystring format</param>
        ''' <returns>The web server response.</returns>
        Public Function WebRequest(ByVal method__1 As Method, ByVal url As String, ByVal postData As String) As String
            Dim _webRequest As HttpWebRequest = Nothing
            Dim requestWriter As StreamWriter = Nothing
            Dim responseData As String = ""

            _webRequest = TryCast(System.Net.WebRequest.Create(url), HttpWebRequest)
            _webRequest.Method = method__1.ToString()
            _webRequest.ServicePoint.Expect100Continue = False
            'webRequest.UserAgent  = "Identify your application please.";
            'webRequest.Timeout = 20000;

            If method__1 = Method.POST Then
                _webRequest.ContentType = "application/x-www-form-urlencoded"

                'POST the data.
                requestWriter = New StreamWriter(_webRequest.GetRequestStream())
                Try
                    requestWriter.Write(postData)
                Catch
                    Throw
                Finally
                    requestWriter.Close()
                    requestWriter = Nothing
                End Try
            End If

            responseData = WebResponseGet(_webRequest)

            _webRequest = Nothing


            Return responseData
        End Function

        ''' <summary>
        ''' Process the web response.
        ''' </summary>
        ''' <param name="webRequest">The request object.</param>
        ''' <returns>The response data.</returns>
        Public Function WebResponseGet(ByVal webRequest As HttpWebRequest) As String
            Dim responseReader As StreamReader = Nothing
            Dim responseData As String = ""

            Try
                responseReader = New StreamReader(webRequest.GetResponse().GetResponseStream())
                responseData = responseReader.ReadToEnd()
            Catch
                Throw
            Finally
                webRequest.GetResponse().GetResponseStream().Close()
                responseReader.Close()
                responseReader = Nothing
            End Try

            Return responseData
        End Function
    End Class
End Namespace
