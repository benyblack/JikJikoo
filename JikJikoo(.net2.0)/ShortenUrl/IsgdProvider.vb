'from: http://shorturlcreator.codeplex.com/

Imports System.Net
Imports System.IO

Namespace ShortenUrl

    Public Class IsgdProvider
        Inherits ProviderBase

        Public Sub New()
            mProviderURL = "http://is.gd/api.php?longurl={0}"
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
            Return result
        End Function

    End Class

End Namespace
