Imports System.Runtime.InteropServices
Imports DNE.Twitter
Imports DNE.JikJikoo.ShortenUrl

Namespace DNE.JikJikoo

    Public Class Util
        ''http://is.gd/api.php?longurl=http://www.example.com
        ''login=login&apiKey=apiKey
        ''<bitly>
        ''      <errorCode>0</errorCode>
        ''      <errorMessage></errorMessage>
        ''      <results>
        ''          <nodeKeyVal>
        ''              <userHash>Zkmf7</userHash>
        ''              <shortKeywordUrl></shortKeywordUrl>
        ''              <hash>3j4ir4</hash>
        ''              <nodeKey><![CDATA[http://google.com]]></nodeKey>
        ''              <shortUrl>http://bit.ly/Zkmf7</shortUrl>
        ''          </nodeKeyVal>
        ''      </results>
        ''      <statusCode>OK</statusCode>
        ''</bitly>
        ''http://tinyurl.com/api-create.php?url=
        'Public Shared Function ShortenUrl(ByVal whoShorten As JikJikoo.ShortenUrl.ShortenServers, ByVal longUrl As String) As String
        '    Dim twa As New Api()
        '    'Return twa.GetSimpleHttpGet(String.Format("http://is.gd/api.php?longurl={0}", longUrl))
        '    'Return twa.GetSimpleHttpGet(String.Format("http://api.bit.ly/shorten?version=2.0.1&longUrl={0}&login=jikjikoo&apiKey=R_737c18d68503f3ff2696387f43ceabde&format=xml", longUrl))
        '    Return twa.GetSimpleHttpGet(String.Format("http://tinyurl.com/api-create.php?url={0}", longUrl))
        'End Function

        Public Shared Function ShortenUrl(ByVal whoShorten As ShortenServers, ByVal longUrl As String) As String
            'Dim sxml As String = twa.GetSimpleHttpGet(String.Format("http://api.bit.ly/shorten?version=2.0.1&longUrl={0}&login=jikjikoo&apiKey=R_737c18d68503f3ff2696387f43ceabde&format=xml", longUrl))
            'Dim xdoc As New Xml.XmlDocument()
            'xdoc.LoadXml(sxml)
            ''first check ErrorCode
            'Return xdoc.SelectSingleNode("bitly/results/nodeKeyVal/shortUrl").InnerText
            ''Return twa.GetSimpleHttpGet(String.Format("http://is.gd/api.php?longurl={0}", longUrl))
            ''Return twa.GetSimpleHttpGet(String.Format("http://tinyurl.com/api-create.php?url={0}", longUrl))


            Dim sp As ShortenUrl.ProviderBase = Nothing
            If whoShorten = ShortenServers.bit_ly Then
                sp = New ShortenUrl.BitlyProvider()

            ElseIf whoShorten = ShortenServers.cort_as Then
                sp = New ShortenUrl.CortasProvider()

            ElseIf whoShorten = ShortenServers.is_gd Then
                sp = New ShortenUrl.IsgdProvider()

            ElseIf whoShorten = ShortenServers.kissa_be Then
                sp = New ShortenUrl.KissabeProvider()

            ElseIf whoShorten = ShortenServers.tinyarro_ws Then
                sp = New ShortenUrl.TinyArrowsProvider()

            ElseIf whoShorten = ShortenServers.tinyurl Then
                sp = New ShortenUrl.TinyURLProvider()

            ElseIf whoShorten = ShortenServers.tr_im Then
                sp = New ShortenUrl.TrimProvider()

            End If
            If sp IsNot Nothing Then Return sp.GetShortURL(longUrl)
            Return ""

        End Function

    End Class

End Namespace
