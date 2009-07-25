'from: http://shorturlcreator.codeplex.com/

Namespace DNE.JikJikoo.ShortenUrl

    Public Class ProviderBase

        Protected mProviderURL As String

        Public Property ProviderURL() As String
            Get
                Return mProviderURL
            End Get
            Set(ByVal value As String)
                mProviderURL = value
            End Set
        End Property

        Public Overridable Function GetShortURL(ByVal longURL As String) As String
            Throw New Exception("No Provider")

        End Function


    End Class

    Public Enum ShortenServers
        bit_ly
        is_gd
        cort_as
        kissa_be
        tinyarro_ws
        tinyurl
        tr_im

    End Enum

End Namespace
