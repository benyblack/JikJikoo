Imports System.Runtime.InteropServices
Imports DNE.Twitter
Imports DNE.JikJikoo.ShortenUrl

Namespace DNE.JikJikoo

    Public Class Util
    
        Public Shared Function ShortenUrl(ByVal whoShorten As ShortenServers, ByVal longUrl As String) As String
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

        Public Shared Sub LogIt(ByVal s As String)
            Dim startpath As String = My.Application.Info.DirectoryPath
            startpath += "\log.txt"
            IO.File.AppendAllText(startpath, s)


        End Sub

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

        Private _text As String = ""
        Public Property Text() As String
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                _text = value
            End Set
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
            _text = s
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
