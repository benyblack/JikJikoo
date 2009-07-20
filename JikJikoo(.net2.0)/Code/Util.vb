Imports DNE.Twitter
Imports System.Collections.ObjectModel

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

    ''' <summary>
    ''' temporary method. must be removed.
    ''' </summary>
    ''' <param name="dmc"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Function DirectMessage2Status(ByVal dmc As Collection(Of DirectMessage)) As Collection(Of Status)
        If dmc Is Nothing Then Return Nothing
        Dim sc As New Collection(Of Status)
        For i As Int32 = 0 To dmc.Count - 1
            Dim st As New Status()
            st.Id = dmc(i).id
            st.Created_At = dmc(i).created_at
            st.Text = dmc(i).text
            st.User = dmc(i).Sender

            sc.Add(st)

        Next
        Return sc

    End Function

    ''' <summary>
    ''' temporary method. must be removed.
    ''' </summary>
    ''' <param name="sr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Function SearchResults2Status(ByVal sr As SearchResults) As Collection(Of Status)
        If sr Is Nothing Then Return Nothing
        Dim sc As New Collection(Of Status)
        For i As Int32 = 0 To sr.results.Length - 1
            Dim st As New Status()
            st.Id = sr.results(i).id
            st.Created_At = sr.results(i).created_at
            st.Text = sr.results(i).text
            st.User = New DNE.Twitter.User()
            st.User.Screen_Name = sr.results(i).from_user
            st.User.Profile_image_url = sr.results(i).profile_image_url

            sc.Add(st)

        Next
        Return sc

    End Function

    ''' <summary>
    ''' temporary method. must be removed.
    ''' </summary>
    ''' <param name="r"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Function Relations2Status(ByVal r As Collection(Of Relationship)) As Collection(Of Status)
        If r Is Nothing Then Return Nothing
        Dim sc As New Collection(Of Status)
        For i As Int32 = 0 To r.Count - 1
            Dim st As New Status()
            st.Id = ""
            st.Created_At = ""
            st.Text = "@" & r(i).target.screen_name
            Dim u As New User()
            st.User = u
            st.User.Screen_Name = r(i).target.screen_name

            sc.Add(st)

        Next
        Return sc
    End Function
    Public Shared Function ContainRtlChars(ByVal s As String) As Boolean
      For i As Int32 = 0 To s.Length - 1
            Dim ii As Int32 = AscW(s.ToCharArray()(i))
            If ii > 1535 And ii < 1792 Then
                Return True
            End If

        Next
        Return False

    End Function


    ''' <summary>
    ''' from:http://dotnetperls.com/pretty-date
    ''' </summary>
    ''' <param name="d"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPrettyDate(ByVal d As DateTime, ByVal lang As Language) As String
        Dim ago As String = "Ago"
        Dim sec As String = "Second"
        Dim min As String = "Minute"
        Dim hour As String = "Hour"
        Dim day As String = "Day"
        Dim lessthan As String = "Less Than"
        If lang = Language.Farsi Then
            ago = "قبل"
            sec = "ثانیه"
            min = "دقیقه"
            hour = "ساعت"
            day = "روز"
            lessthan = "کمتر از"
        End If

        Dim pat As String = "{0} {1} {2}"

        ' 1.
        ' Get time span elapsed since the date.
        Dim s As TimeSpan = DateTime.Now.Subtract(d)

        ' 2.
        ' Get total number of days elapsed.
        Dim dayDiff As Integer = CInt(s.TotalDays)

        ' 3.
        ' Get total number of seconds elapsed.
        Dim secDiff As Integer = CInt(s.TotalSeconds)

        ' 4.
        ' Don't allow out of range values.
        If dayDiff < 0 OrElse dayDiff >= 31 Then
            Return d.ToString("hh:mm MMM YYYY dd")

            'Return Nothing
        End If

        ' 5.
        ' Handle same-day times.
        If dayDiff = 0 Then
            ' A.
            ' Less than one minute ago.
            If secDiff < 60 Then
                Return String.Format(pat, secDiff.ToString, sec, ago)
            End If
            ' B.
            ' Less than 2 minutes ago.
            If secDiff < 120 Then
                Return "1 minute ago"
            End If
            ' C.
            ' Less than one hour ago.
            If secDiff < 3600 Then
                Return String.Format(pat, Math.Floor(CDbl(secDiff) / 60), min, ago)

            End If
            ' D.
            ' Less than 2 hours ago.
            If secDiff < 7200 Then
                Dim mins As Int32 = Math.Floor(CDbl(secDiff - 3600) / 60)
                Return String.Format(pat, "1", hour & " " & mins.ToString & ", " & min, ago)

            End If
            ' E.
            ' Less than one day ago.
            If secDiff < 86400 Then
                Return String.Format(pat, Math.Floor(CDbl(secDiff) / 3600), hour, ago)
            End If
        End If
        ' 6.
        If dayDiff >= 1 Then
            If lang = Language.Farsi Then Return GetPersianDate(d)
            Return d.ToString("hh:mm MMM dd")
        End If
        '' Handle previous days.
        'If dayDiff = 1 Then
        '    Return "yesterday"
        'End If
        'If dayDiff < 7 Then
        '    Return String.Format("{0} days ago", dayDiff)
        'End If
        'If dayDiff < 31 Then
        '    Return String.Format("{0} weeks ago", Math.Ceiling(CDbl(dayDiff) / 7))
        'End If
        Return Nothing

    End Function

    Private Shared PersianMonths() As String = {"فروردين", "ارديبهشت", "خرداد", "تير", "مرداد", "شهريور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"}

    ''' <summary>
    ''' </summary>
    ''' <param name="d"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPersianDate(ByVal d As DateTime) As String
        Dim pcal As New System.Globalization.PersianCalendar
        Dim YY As String = pcal.GetYear(d)
        Dim MM As Int32 = pcal.GetMonth(d)
        Dim DD As String = pcal.GetDayOfMonth(d)
        'If MM.Length = 1 Then MM = "0" & MM
        If DD.Length = 1 Then DD = "0" & DD
        Return YY & "/" & PersianMonths(MM - 1) & "/" & DD


    End Function

End Class

Public Enum Language
    Farsi = 0
    English = 1

End Enum

Public Enum ShortenServers
    bit_ly
    'is_gd
    'tinyurl_com

End Enum
