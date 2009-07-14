Imports System.Runtime.InteropServices

Namespace DNE.JikJikoo

    Public Class Util
        'http://is.gd/api.php?longurl=http://www.example.com
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
        'http://tinyurl.com/api-create.php?url=
        Public Shared Function ShortenUrl(ByVal whoShorten As ShortenServers, ByVal longUrl As String) As String
            Dim twa As New TwitterApi()
            'Return twa.GetSimpleHttpGet(String.Format("http://is.gd/api.php?longurl={0}", longUrl))
            'Return twa.GetSimpleHttpGet(String.Format("http://api.bit.ly/shorten?version=2.0.1&longUrl={0}&login=jikjikoo&apiKey=R_737c18d68503f3ff2696387f43ceabde&format=xml", longUrl))
            Return twa.GetSimpleHttpGet(String.Format("http://tinyurl.com/api-create.php?url={0}", longUrl))
        End Function

    End Class

    Public Enum ShortenServers
        bit_ly
        is_gd
        tinyurl_com


    End Enum

    Public Enum StatusListType
        FriendsTimeLine
        UserUpdates
        DirectMessages
        Favorites
        Mentions
        MyUpdates

    End Enum

End Namespace
