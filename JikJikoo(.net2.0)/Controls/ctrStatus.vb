﻿Imports System.Text.RegularExpressions

Public Class ctrStatus

    Public Event TwitEvent As TwitEventHandler

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
    Private _formated As Boolean = False
    Public Property Formated() As Boolean
        Get
            Return _formated
        End Get
        Set(ByVal value As Boolean)
            _formated = value
        End Set
    End Property

    Private mousexyOntxtstatus As Point = Nothing

    Public Sub DateTimeUpdate()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf DateTimeUpdate))
        Else
            If Me.Status Is Nothing Then Exit Sub
            lblTime.Text = Util.GetPrettyDate(Status.CreatedAt, IIf(jc.lang.ToLower = "fa", Language.Farsi, Language.English))
        End If

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
        'DetectAtSign()

    End Sub

    Friend Sub FormatAtSigns()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf FormatAtSigns))
        Else

            Dim pat As String = "@[a-z0-9A-Z]*"
            Dim t As String = txtStatus.Text
            Dim mc As MatchCollection = Regex.Matches(t, pat)
            If mc Is Nothing Then Exit Sub
            Dim offset As Int32 = 0
            For i As Int32 = 0 To mc.Count - 1
                txtStatus.Select(mc(i).Index + 1 + offset, mc(i).Length - 1)
                txtStatus.InsertLink(mc(i).Value.Substring(1), "user")
                offset += 1 + 4 '"#view".Lenght

            Next

        End If


    End Sub

    Friend Sub FormatUrls()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf FormatUrls))
        Else
            'from : http://regexlib.com/REDetails.aspx?regexp_id=96
            Dim urlpat As String = "(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?"
            Dim t As String = txtStatus.Text
            Dim mc As MatchCollection = Regex.Matches(t, urlpat)
            If mc Is Nothing Then Exit Sub
            Dim offset As Int32 = 0
            For i As Int32 = 0 To mc.Count - 1
                txtStatus.Select(mc(i).Index + offset, mc(i).Length)
                txtStatus.InsertLink(mc(i).Value, "url")
                offset += 4 '"#url".Lenght

            Next

        End If

    End Sub


    Private whatisClickedInTxtStatus As String = ""
    Private Sub txtStatus_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtStatus.LinkClicked
        If e.LinkText = "" Then Exit Sub
        Dim txt As String = e.LinkText
        Dim verb As String = txt.Split("#")(txt.Split("#").Length - 1)
        If verb.ToLower = "user" Then
            whatisClickedInTxtStatus = txt.Substring(0, txt.Length - 5)
            mnuUsername.Show(txtStatus, New Point(mousexyOntxtstatus.X - 2, mousexyOntxtstatus.Y - 2))

        ElseIf verb.ToLower = "url" Then
            Process.Start(e.LinkText.Substring(0, e.LinkText.Length - 4)) ' 4= "#url".lenght

        End If


    End Sub

    Private Sub lnkSource_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSource.LinkClicked
        Process.Start(lnkSourceHref)

    End Sub

    Private Sub ReplyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplyToolStripMenuItem.Click
        RaiseEvent TwitEvent(Me, New TwitEventArgs(Status.Id, TwitEvents.Reply))

    End Sub

    Private Sub RTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RTToolStripMenuItem.Click
        RaiseEvent TwitEvent(Me, New TwitEventArgs(Status.Text, TwitEvents.RT))

    End Sub

    Private Sub txtStatus_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtStatus.MouseMove
        mousexyOntxtstatus = e.Location

    End Sub

    Private Sub UseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UseToolStripMenuItem.Click
        RaiseEvent TwitEvent(Me, New TwitEventArgs(whatisClickedInTxtStatus, TwitEvents.Use_ScreenName))

    End Sub

    Private Sub lblUserName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblUserName.Click
        whatisClickedInTxtStatus = lblUserName.Text
        mnuUsername.Show(lblUserName, 5, 5)

    End Sub
End Class
