Public Class ctrlUpdateStatus

    Public Event UpdateStarted As EventHandler
    Public Event UpdateCompleted As EventHandler

    Private _in_reply_to_status_id As String = ""
    Public Property in_reply_to_status_id() As String
        Get
            Return _in_reply_to_status_id
        End Get
        Set(ByVal value As String)
            _in_reply_to_status_id = value
            SetButtonText()
        End Set
    End Property

    Private _in_reply_to_screen_name As String = ""
    Public Property in_reply_to_screen_name() As String
        Get
            Return _in_reply_to_screen_name
        End Get
        Set(ByVal value As String)
            _in_reply_to_screen_name = value
        End Set
    End Property

    Private Sub SetButtonText()
        Dim rm As New System.ComponentModel.ComponentResourceManager(Me.GetType)
        If _in_reply_to_status_id <> "" Then
            btnUpdate.Text = My.Resources.JikJikoo.ReplyButton  'rm.GetString("ReplyButton")
        Else
            btnUpdate.Text = rm.GetString("btnUpdate.Text")
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        RaiseEvent UpdateStarted(Nothing, Nothing)
        twa.UpdateStatus(txtStatus.Text.Trim(), _in_reply_to_status_id)
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
        Util.SetButtonsStyle(Me)
        cboShorten.SelectedIndex = 0

    End Sub

    Private Sub txtStatus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStatus.TextChanged
        If in_reply_to_status_id = "" Then Exit Sub
        If Not txtStatus.Text.Contains("@" & in_reply_to_screen_name) Then
            in_reply_to_status_id = ""
            in_reply_to_screen_name = ""
            SetButtonText()

        End If
    End Sub
End Class
