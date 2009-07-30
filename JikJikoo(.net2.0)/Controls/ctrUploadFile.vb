Public Class ctrUploadFile

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim ofd As New OpenFileDialog()
        If ofd.ShowDialog = DialogResult.OK Then
            txtFile.Text = ofd.FileName

        End If

    End Sub

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Dim d As New Dropio.Core.ProductionService()

    End Sub
End Class
