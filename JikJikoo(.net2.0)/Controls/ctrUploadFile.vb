Public Class ctrUploadFile

    Public Event DownloadCompleted As EventHandler

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Util.SetButtonsStyle(Me)
        Dim ofd As New OpenFileDialog()
        If ofd.ShowDialog = DialogResult.OK Then
            txtFile.Text = ofd.FileName
            btnUpload.Enabled = True

        End If

    End Sub

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        prgUpload.Minimum = 0
        prgUpload.Maximum = 100
        prgUpload.Value = 0
        Dim f As String = txtFile.Text
        Dropio.Core.ServiceProxy.Instance.ServiceAdapter.ApiKey = "b440ce3c6b53e48f10c052d064a28cdef2cd11ea"
        Dim d As Dropio.Core.Drop = Dropio.Core.Drop.Create(CurrentUser.Screen_Name, "")
        Dim x As New Dropio.Core.ProductionService()
        Dim a As Dropio.Core.Asset = Nothing

        a = d.AddFile(f, AddressOf eh)
        a.Save()
        txtOut.Text = vbCrLf & String.Format("http://drop.io/{0}/asset/{1}", d.Name, a.Name)

    End Sub

    Public Sub eh(ByVal sender As Object, ByVal e As Dropio.Core.TransferProgressEventArgs)
        prgUpload.Value = CInt((e.Bytes / e.Total) * 100)
        If e.Bytes = e.Total Then RaiseEvent DownloadCompleted(Nothing, Nothing)

    End Sub

End Class
