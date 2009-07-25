'from: http://shorturlcreator.codeplex.com/
Imports System.Net
Imports System.IO

Namespace DNE.JikJikoo.ShortenUrl

    Public Class BitlyProvider
        Inherits ProviderBase

        Public Sub New()
            mProviderURL = "http://api.bit.ly/shorten?version=2.0.1&format=xml&longUrl={0}&login=jikjikoo&apiKey=R_737c18d68503f3ff2696387f43ceabde"
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
            '<bitly>
            '	<errorCode>0</errorCode>
            '	<errorMessage/>
            '	<results>
            '		<nodeKeyVal>
            '			<userHash>kYnhS</userHash>
            '			<shortKeywordUrl/>
            '			<hash>qGKcO</hash>
            '			<nodeKey>http://omarslvd.blogspot.com</nodeKey>
            '			<shortUrl>http://bit.ly/kYnhS</shortUrl>
            '		</nodeKeyVal>
            '	</results>
            '	<statusCode>OK</statusCode>
            '</bitly>

            '--- Original Code (works in .net 3.5) ----
            'Dim xmlResult As XElement = XElement.Parse(result)
            'Dim shortUrlValue = From node In xmlResult.Descendants("results").Descendants("nodeKeyVal") _
            '			        Select CStr(node.Element("shortUrl"))

            'result = shortUrlValue(0)
            'Return result
            '------------------------------------------

            'for .net 2.0
            Dim xdoc As New Xml.XmlDocument()
            xdoc.LoadXml(result)
            'first check ErrorCode
            Return xdoc.SelectSingleNode("bitly/results/nodeKeyVal/shortUrl").InnerText

        End Function

    End Class
End Namespace
