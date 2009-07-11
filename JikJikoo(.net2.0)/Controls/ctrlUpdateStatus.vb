Public Class ctrlUpdateStatus

    Public Event UpdateStarted As EventHandler
    Public Event UpdateCompleted As EventHandler

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        RaiseEvent UpdateStarted(Nothing, Nothing)
        twa.UpdateStatus(txtStatus.Text.Trim())
        RaiseEvent UpdateCompleted(Nothing, Nothing)
        txtStatus.Text = ""

    End Sub

    Private Sub btnShorten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShorten.Click
        If txtStatus.Text <> "" AndAlso Not txtStatus.Text.EndsWith(" ") Then txtStatus.Text += " "
        txtStatus.Text += Util.ShortenUrl(ShortenServers.bit_ly, txtShorten.Text)

    End Sub

    Friend Sub Clear()
        txtShorten.Text = ""
        txtStatus.Text = ""

    End Sub

    Private Sub ctrlUpdateStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboShorten.SelectedIndex = 0

    End Sub
End Class
