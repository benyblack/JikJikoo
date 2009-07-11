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

    Public Class IESettings

        <System.Runtime.InteropServices.DllImport("wininet.dll", SetLastError:=True)> _
Private Shared Function InternetSetOption(ByVal hInternet As IntPtr, ByVal dwOption As Integer, ByVal lpBuffer As IntPtr, ByVal lpdwBufferLength As Integer) As Boolean
        End Function

        Public Structure Struct_INTERNET_PROXY_INFO
            Public dwAccessType As Integer
            Public proxy As IntPtr
            Public proxyBypass As IntPtr
        End Structure

        Private Sub RefreshIESettings(ByVal strProxy As String)
            Const INTERNET_OPTION_PROXY As Integer = 38
            Const INTERNET_OPEN_TYPE_PROXY As Integer = 3

            Dim struct_IPI As Struct_INTERNET_PROXY_INFO

            ' Filling in structure
            struct_IPI.dwAccessType = INTERNET_OPEN_TYPE_PROXY
            struct_IPI.proxy = Marshal.StringToHGlobalAnsi(strProxy)
            struct_IPI.proxyBypass = Marshal.StringToHGlobalAnsi("local")

            ' Allocating memory
            Dim intptrStruct As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(struct_IPI))

            ' Converting structure to IntPtr
            Marshal.StructureToPtr(struct_IPI, intptrStruct, True)

            Dim iReturn As Boolean = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_PROXY, intptrStruct, System.Runtime.InteropServices.Marshal.SizeOf(struct_IPI))
        End Sub

    End Class
End Namespace
