Public Class Util

    'bit.ly
    'login=login&apiKey=apiKey
    '<bitly>
    '      <errorCode>0</errorCode>
    '      <errorMessage></errorMessage>
    '      <results>
    '          <nodeKeyVal>
    '              <userHash>Zkmf7</userHash>
    '              <shortKeywordUrl></shortKeywordUrl>
    '              <hash>3j4ir4</hash>
    '              <nodeKey><![CDATA[http://google.com]]></nodeKey>
    '              <shortUrl>http://bit.ly/Zkmf7</shortUrl>
    '          </nodeKeyVal>
    '      </results>
    '      <statusCode>OK</statusCode>
    '</bitly>

    'is.gd
    'http://is.gd/api.php?longurl=http://www.example.com

    'tinyurl.com
    'http://tinyurl.com/api-create.php?url=

    Public Shared Function ShortenUrl(ByVal whoShorten As ShortenServers, ByVal longUrl As String) As String
        Dim sxml As String = twa.GetSimpleHttpGet(String.Format("http://api.bit.ly/shorten?version=2.0.1&longUrl={0}&login=jikjikoo&apiKey=R_737c18d68503f3ff2696387f43ceabde&format=xml", longUrl))
        Dim xdoc As New Xml.XmlDocument()
        xdoc.LoadXml(sxml)
        'first check ErrorCode
        Return xdoc.SelectSingleNode("bitly/results/nodeKeyVal/shortUrl").InnerText
        'Return twa.GetSimpleHttpGet(String.Format("http://is.gd/api.php?longurl={0}", longUrl))
        'Return twa.GetSimpleHttpGet(String.Format("http://tinyurl.com/api-create.php?url={0}", longUrl))
    End Function

    Public Shared Function HashSHA1(ByVal ParamArray p() As String) As String
        If p Is Nothing OrElse p.Length = 0 Then Return ""
        Dim src As String = ""
        For i As Int32 = 0 To p.Length - 1
            src += p(i)

        Next
        Dim sha As New System.Security.Cryptography.SHA1CryptoServiceProvider()
        Dim hashbytes() As Byte = sha.ComputeHash(System.Text.Encoding.ASCII.GetBytes(src))
        Dim strResult As String = ""
        For Each b As Byte In hashbytes
            strResult += b.ToString("x2")
        Next
        Return strResult

    End Function

End Class

Public Enum ShortenServers
    bit_ly
    'is_gd
    'tinyurl_com

End Enum
