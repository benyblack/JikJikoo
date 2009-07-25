'from: http://shorturlcreator.codeplex.com/

Imports System.Net
Imports System.IO
Imports System.Web

Namespace DNE.JikJikoo.ShortenUrl

    Public Class TinyArrowsProvider
        Inherits ProviderBase

        Public Sub New()
            mProviderURL = "http://tinyarro.ws/api-create.php?url={0}"
        End Sub

        Public Overrides Function GetShortURL(ByVal longURL As String) As String
            Dim request As HttpWebRequest
            Dim reader As StreamReader
            Dim response As HttpWebResponse
            Dim result As String = ""

            request = WebRequest.Create(String.Format(mProviderURL, longURL))
            response = request.GetResponse()
            reader = New StreamReader(response.GetResponseStream())
            result = reader.ReadToEnd()
            result = HttpUtility.HtmlDecode(result)
            Return result
        End Function

    End Class

End Namespace
