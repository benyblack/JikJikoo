Imports System.Text.Encoding
Imports System.IO

Public Class CacheManager


    Public Shared Sub SaveImage(ByVal img As Image, ByVal url As String)
        If img Is Nothing Then Exit Sub
        Dim newFileName As String = HashUrl(url) & ".jpg"
        Dim ms As New IO.MemoryStream()
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim b() As Byte = ms.ToArray()
        File.WriteAllBytes(Path.Combine(GetCachePath(), newFileName), b)

    End Sub

    Public Shared Function LoadImage(ByVal url As String) As Image
        Dim dp As String = GetCachePath()
        Dim hash As String = HashUrl(url)
        If File.Exists(Path.Combine(dp, hash & ".jpg")) Then
            Dim img As Image = Image.FromFile(Path.Combine(dp, hash & ".jpg"))
            Return img

        End If
        Return Nothing

    End Function

    Private Shared Function GetCachePath() As String
        Dim dirpath As String = Path.Combine(Application.StartupPath, "Cache")
        If Not Directory.Exists(dirpath) Then
            Directory.CreateDirectory(dirpath)

        End If
        Return dirpath

    End Function

    Private Shared Function HashUrl(ByVal url As String) As String
        Dim sh1 As New Security.Cryptography.SHA1CryptoServiceProvider()
        Dim bhash As Byte() = sh1.ComputeHash(ASCII.GetBytes(url))
        Return BitConverter.ToString(bhash).Replace("-", "")

    End Function

End Class
