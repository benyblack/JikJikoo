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
    Private lnkSourceHref As String = ""
    Private jc As New JikConfigManager()

    Public Sub DateTimeUpdate()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf DateTimeUpdate))
        Else
            If Me.Status Is Nothing Then Exit Sub
            lblTime.Text = Util.GetPrettyDate(Status.CreatedAt, IIf(jc.lang.ToLower = "fa", Language.Farsi, Language.English))
        End If

    End Sub


    Private Sub ctrStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BindFields()
        lblUserName.Text = Status.User.Screen_Name
        If Util.ContainRtlChars(Status.Text) Then
            txtStatus.RightToLeft = Windows.Forms.RightToLeft.Yes
        Else
            txtStatus.RightToLeft = Windows.Forms.RightToLeft.No
        End If
        txtStatus.Text = Status.Text
        Dim m As Match = Regex.Match(Status.Source, "<a href=\""(.*?)\"">(.*?)</a>")
        If m IsNot Nothing AndAlso m.Groups.Count > 0 Then
            lnkSource.Text = m.Groups(2).Value  'Status.Source
            lnkSourceHref = m.Groups(1).Value

        End If

        'picUser.ImageLocation = Status.User.Profile_image_url
        lblTime.Text = Util.GetPrettyDate(Status.CreatedAt, IIf(jc.lang.ToLower = "fa", Language.Farsi, Language.English))
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

    Private Sub lnkSource_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSource.LinkClicked
        Process.Start(lnkSourceHref)

    End Sub
End Class
