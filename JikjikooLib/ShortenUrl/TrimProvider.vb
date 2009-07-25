'from: http://shorturlcreator.codeplex.com/

Imports System.Net
Imports System.IO

Namespace DNE.JikJikoo.ShortenUrl

    Public Class TrimProvider
        Inherits ProviderBase

        Public Sub New()
            mProviderURL = "http://api.tr.im/api/trim_url.xml?url={0}"
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
            '<trim>
            '	<status result="OK" code="200" message="tr.im URL Added."/>
            '	<url>http://tr.im/lcjY</url>
            '	<reference>Hx5zjO66gKyKYv2baIlvjiyAM4zpK2</reference>
            '	<trimpath>lcjY</trimpath>
            '</trim>
            '--- Original Code (works in .net 3.5) ----
            'Dim xmlResult As XElement = XElement.Parse(result)
            'Dim shortUrlValue = From node In xmlResult.Descendants("url") _
            '				    Select CStr(node.Value)

            'result = shortUrlValue(0)
            'Return result
            '------------------------------------------

            'for .net 2.0
            Dim xdoc As New Xml.XmlDocument()
            xdoc.LoadXml(result)
            'first check ErrorCode
            Return xdoc.SelectSingleNode("trim/url").InnerText

        End Function

    End Class

End Namespace

