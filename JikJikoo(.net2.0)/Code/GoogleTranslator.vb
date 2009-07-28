Imports System
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Net.Sockets
Imports System.Threading
Imports System.Web

Public Class GoogleTranslator
    Public Sub New()
    End Sub

    ''' <summary>
    ''' Translate Using Google Translator
    ''' </summary>
    ''' <param name="input">Test To Translate</param>
    ''' <param name="SourceLanguage">Translate From Language. Two letter (fa,en,fr ...)</param>
    ''' <param name="ToLanguage">Translate To Language. Two letter (fa,en,fr ...)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function TranslateText(ByVal input As String, ByVal SourceLanguage As String, ByVal ToLanguage As String) As String
        Dim url As String = [String].Format("http://www.google.com/translate_a/t?client=t&text={0}&sl={1}&tl={2}", HttpUtility.UrlEncode(input), SourceLanguage, ToLanguage)

        Dim result As String = [String].Empty
        Dim b() As Byte = Nothing
        result = HttpGetRequestSocket(url, "translate.google.com")
        Dim m As Match = Regex.Match(result, "(\n)(.*?)(\n)")
        Dim pm As String = "\[\""(.*?)\"""
        Dim ps As String = "\[\""{0}\"",\""(.*?)\]"
        Dim outstr As String = ""
        If m.Success Then
            Dim ires As String = ""
            result = m.Groups(2).Value
            ires = result
            Dim mm As MatchCollection = Regex.Matches(ires, pm)
            If mm.Count > 0 Then
                outstr = mm(0).Groups(1).Value & vbCrLf
            Else
                Return result.Replace("""", "")
            End If
            For i As Int32 = 1 To mm.Count - 1
                Dim p As String = String.Format(ps, mm(i).Groups(1).Value)
                outstr += mm(i).Groups(1).Value & ": " & Regex.Match(result, p).Groups(1).Value & vbCrLf

            Next

        Else
            Return result.Replace("""", "")


        End If
        Return outstr.Replace("""", "")

    End Function

#Region " Http Function "

    ''' <summary>
    ''' Send Http Get Request from socket and recieve responsed data
    ''' </summary>
    ''' <param name="url"></param>
    ''' <param name="host"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function HttpGetRequestSocket(ByVal url As String, ByVal host As String) As String
        Dim port As Integer = 80
        ' Retrieve IP from host name
        Dim hostEntry As IPHostEntry = Nothing 'Dns.GetHostEntry(host)
        Try
            hostEntry = Dns.GetHostEntry(host)

        Catch ex As SocketException
            'RaiseEvent HttpError(Me, New HttpExEventArgs(ex, url, "Can not resolve host"))
            'Throw New NoConnectionException()

        End Try
        Dim address As IPAddress = hostEntry.AddressList(0)
        Dim ipe As New IPEndPoint(address, port)

        ' Make connection
        Dim socket As New Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp)

        ' for result
        Dim bytes As Integer = 0
        Dim strOut As String = ""
        Try
            socket.Connect(ipe)

            Dim request As String = ""
            request = GenerateGetRequest(host, url)


            Dim bytesSent As [Byte]() = Encoding.ASCII.GetBytes(request)

            'RaiseEvent DownloadingDataStart(Nothing, Nothing)

            ' send query
            socket.Send(bytesSent, bytesSent.Length, 0)
            While socket.Available = 0

            End While
            Dim bytesReceived As [Byte]() = New [Byte](socket.Available - 1) {}

            ' get result
            Do
                Dim ssize As Int32 = socket.Available
                If ssize > bytesReceived.Length Then
                    ssize = bytesReceived.Length
                End If
                bytes = socket.Receive(bytesReceived, ssize, 0)
                'Thread.Sleep(20)
                strOut += (Encoding.UTF8.GetString(bytesReceived, 0, bytes))

            Loop While socket.Available > 0

            socket.Close()
        Catch ex As SocketException
            If socket.Connected Then
                socket.Disconnect(False)

            End If
            MsgBox(ex.Message)
            'RaiseEvent HttpError(Me, New HttpExEventArgs(ex, url, "We got a error while downloading data"))

        End Try

        ' RaiseEvent DownloadingDataEnd(Nothing, Nothing)
        If strOut.Length > 4 Then strOut = strOut.Substring(strOut.IndexOf(vbCrLf + vbCrLf) + 4)
        Return strOut

    End Function

    Private Shared Function GenerateGetRequest(ByVal host As String, ByVal url As String) As String
        Dim request As String = "GET " & url & " HTTP/1.1" & vbLf
        request += "Host: www.google.com" & vbLf & _
        "User-Agent: Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.1.1) Gecko/20090715 Firefox/3.5.1 GTB5 (.NET CLR 3.5.30729)" & vbLf & _
        "Accept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8" & vbLf & _
        "Accept-Language: en-us,en;q=0.5" & vbLf & _
        "Accept-Charset: ISO-8859-1,utf-8;q=0.7,*;q=0.7" & vbLf & _
        "Keep-Alive: 300" & vbLf & _
        "Connection: keep-alive" & vbLf & _
        "Referer: http://www.google.com/translate_t?hl=en&ie=UTF8&text=test&langpair=en|fa" & vbLf
        '"Accept-Encoding : gzip, deflate" & vbLf & _

        request += vbLf
        Return request

    End Function

    Private Shared Sub AddBytes(ByRef al As ArrayList, ByVal b As Byte(), ByVal count As Int32)
        For i As Int32 = 0 To count - 1
            al.Add(b(i))
        Next
    End Sub

#End Region

End Class
