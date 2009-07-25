'from: http://shorturlcreator.codeplex.com/

Imports System.Net
Imports System.IO

Namespace DNE.JikJikoo.ShortenUrl

    Public Class CortasProvider
        Inherits ProviderBase

        Public Sub New()
            mProviderURL = "http://www.soitu.es/cortas/encode.pl?u={0}&r=xml"
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
            ' The result is a XML
            '<cortas>
            '	<status>ok</status>
            '	<urlCortas>http://cort.as/1</urlCortas>
            '	<uriOriginal>http://www.yahoo.com/</uriOriginal>
            '	<tracking>0</tracking>
            '</cortas>
            '
            '--- Original Code (works in .net 3.5) ----
            'Dim xmlResult As XElement = XElement.Parse(result)
            'Dim shortUrlValue = From node In xmlResult.Descendants("urlCortas") _
            '                       Select CStr(node.Value)

            'result = shortUrlValue(0)
            '      Return result
            '------------------------------------------

            'for .net 2.0
            Dim xdoc As New Xml.XmlDocument()
            xdoc.LoadXml(result)
            'first check ErrorCode
            Return xdoc.SelectSingleNode("cortas/urlCortas").InnerText

        End Function

    End Class

End Namespace
