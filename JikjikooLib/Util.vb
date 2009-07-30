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

    Public Class HtmlHeaders
        Inherits Collections.Specialized.NameValueCollection

        Private _firstLine As String = ""
        Public Property FirstLine() As String
            Get
                Return _firstLine
            End Get
            Set(ByVal value As String)
                _firstLine = value
            End Set
        End Property

        Public ReadOnly Property Status() As String
            Get
                If Me("status") IsNot Nothing Then
                    Return Me("status")

                End If
                Return ""

            End Get
        End Property

        Public ReadOnly Property StatusCode() As Int32
            Get
                If Me("status") IsNot Nothing Then
                    Return CInt(Me("status").Split(" ")(0))
                End If
                Return 0

            End Get
        End Property

        Public Sub New(ByVal s As String)
            Dim Headers As String() = s.Split(vbCrLf)
            If Headers Is Nothing OrElse Headers.Length = 0 Then Exit Sub
            _firstLine = Headers(0)
            For i As Int32 = 1 To Headers.Length - 1
                Dim k As String = Headers(i).Split(":")(0).Trim()
                Dim v As String = Headers(i).Split(":")(1).Trim()
                Me.Add(k, v)

            Next

        End Sub

    End Class

End Namespace
