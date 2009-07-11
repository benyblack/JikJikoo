Imports System.Text.RegularExpressions

Public Class ctrStatus

    Public Event ReplyCommand As ReplyEventHandler

    Private _status As DNE.Twitter.Status
    Public Property Status() As DNE.Twitter.Status
        Get
            Return _status
        End Get
        Set(ByVal value As DNE.Twitter.Status)
            _status = value
            BindFields()

        End Set
    End Property

    Private Sub ctrStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BindFields()
        lblUserName.Text = Status.User.Screen_Name
        lblTime.Text = ""
        txtStatus.Text = Status.Text
        picUser.ImageLocation = Status.User.Profile_image_url
        lblTime.Text = Status.CreatedAt.ToShortTimeString()
        DetectAtSign()

    End Sub

    Private Sub DetectAtSign()
        Dim pat As String = "@[a-z0-9A-Z]*"
        Dim t As String = txtStatus.Text
        Dim mc As MatchCollection = Regex.Matches(t, pat)
        If mc Is Nothing Then Exit Sub
        Dim offset As Int32 = 0
        For i As Int32 = 0 To mc.Count - 1
            txtStatus.Select(mc(i).Index + 1 + offset, mc(i).Length - 1)
            txtStatus.InsertLink(mc(i).Value.Substring(1), "view")
            offset += 1 + 4 '"#view".Lenght

        Next

    End Sub

    Private Sub txtStatus_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtStatus.LinkClicked
        If Not e.LinkText.StartsWith("http://") Then
            RaiseEvent ReplyCommand(Me, New ReplyEventArgs(e.LinkText.Substring(0, e.LinkText.IndexOf("#"))))

        Else
            Process.Start(e.LinkText)

        End If


    End Sub



End Class
