﻿Imports System.Text.RegularExpressions

Public Class ctrStatus

    Public Event TwitEvent As TwitEventHandler

    Public Sub DateTimeUpdate()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf DateTimeUpdate))
        Else
            If _status IsNot Nothing Then
                lblTime.Text = Util.GetPrettyDate(Status.CreatedAt, IIf(jc.lang.ToLower = "fa", Language.Farsi, Language.English))

            ElseIf _user IsNot Nothing Then
                If User.Status IsNot Nothing AndAlso User.Status.Created_At <> "" Then
                    lblTime.Text = Util.GetPrettyDate(User.Status.CreatedAt, IIf(jc.lang.ToLower = "fa", Language.Farsi, Language.English))

                Else
                    lblTime.Text = ""

                End If

            End If

        End If

    End Sub

    Private Sub BindFields()
        DeleteThisStatusToolStripMenuItem.Enabled = False
        If _status IsNot Nothing Then
            lblUserName.Text = Status.User.Screen_Name
            If CurrentUser.Screen_Name.ToLower = Status.User.Screen_Name.ToLower() Then
                DeleteThisStatusToolStripMenuItem.Enabled = True

            End If

            _originalText = Status.Text
            If Util.ContainRtlChars(_originalText) Then
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

        ElseIf _user IsNot Nothing Then
            lblUserName.Text = User.Screen_Name
            If User.Status IsNot Nothing Then
                _originalText = User.Status.Text
                If Util.ContainRtlChars(User.Status.Text) Then
                    txtStatus.RightToLeft = Windows.Forms.RightToLeft.Yes
                Else
                    txtStatus.RightToLeft = Windows.Forms.RightToLeft.No
                End If
                txtStatus.Text = User.Status.Text
                Dim m As Match = Regex.Match(User.Status.Source, "<a href=\""(.*?)\"">(.*?)</a>")
                If m IsNot Nothing AndAlso m.Groups.Count > 0 Then
                    lnkSource.Text = m.Groups(2).Value  'Status.Source
                    lnkSourceHref = m.Groups(1).Value

                End If

                'picUser.ImageLocation = Status.User.Profile_image_url
                If User.Status IsNot Nothing AndAlso User.Status.Created_At <> "" Then
                    lblTime.Text = Util.GetPrettyDate(_user.Status.CreatedAt, IIf(jc.lang.ToLower = "fa", Language.Farsi, Language.English))

                Else
                    lblTime.Text = ""

                End If

            End If

        End If


    End Sub


#Region " Properties "

    Private lnkSourceHref As String = ""
    Private jc As New JikConfigManager()
    Private mousexyOntxtstatus As Point = Nothing
    Private whatisClickedInTxtStatus As String = ""

    Private _status As DNE.Twitter.Status
    Friend Property Status() As DNE.Twitter.Status
        Get
            Return _status
        End Get
        Set(ByVal value As DNE.Twitter.Status)
            _status = value
            BindFields()

        End Set
    End Property

    Private _user As DNE.Twitter.User
    Friend Property User() As DNE.Twitter.User
        Get
            Return _user
        End Get
        Set(ByVal value As DNE.Twitter.User)
            _user = value
            BindFields()

        End Set
    End Property

    Private _formated As Boolean = False
    Friend Property Formated() As Boolean
        Get
            Return _formated
        End Get
        Set(ByVal value As Boolean)
            _formated = value
        End Set
    End Property

    Private _originalText As String = ""
    Friend Property OriginalText() As String
        Get
            Return _originalText
        End Get
        Set(ByVal value As String)
            _originalText = value
        End Set
    End Property

    ''' <summary>
    ''' Return Id of Current object
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property ObjectId() As Int64
        Get
            If _status IsNot Nothing Then
                Return _status.numId

            ElseIf _user IsNot Nothing Then
                Return _user.Id
            End If

        End Get
    End Property


#End Region

#Region " Formating "

    Friend Sub FormatText()
        'must be first
        FormatNumberSigns()

        FormatAtSigns()
        FormatUrls()
        Formated = True

    End Sub

    ''' <summary>
    ''' plz use it befor FormatAtSign and FormatUrl, richtextbox use # for link
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FormatNumberSigns()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf FormatNumberSigns))
        Else

            Dim pat As String = "#[a-z0-9A-Z]*"
            Dim t As String = txtStatus.Text
            Dim mc As MatchCollection = Regex.Matches(t, pat)
            If mc Is Nothing Then Exit Sub
            Dim offset As Int32 = 0
            For i As Int32 = 0 To mc.Count - 1
                txtStatus.Select(mc(i).Index + 1 + offset, mc(i).Length - 1)
                txtStatus.InsertLink(mc(i).Value.Substring(1), "tag")
                offset += 1 + 3 '"#tag".Lenght

            Next

        End If


    End Sub

    Private Sub FormatAtSigns()
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
                offset += 1 + 4 '"#user".Lenght

            Next

        End If


    End Sub

    Private Sub FormatUrls()
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

#End Region

#Region " Events "


    Private Sub txtStatus_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtStatus.LinkClicked
        If e.LinkText = "" Then Exit Sub
        Dim txt As String = e.LinkText
        Dim verb As String = txt.Split("#")(txt.Split("#").Length - 1)
        If verb.ToLower = "user" Then
            whatisClickedInTxtStatus = txt.Substring(0, txt.Length - 5)
            RaiseEvent TwitEvent(Me, New TwitEventArgs(Status, whatisClickedInTxtStatus, TwitEvents.UserStatuses))

        ElseIf verb.ToLower = "tag" Then
            whatisClickedInTxtStatus = txt.Substring(0, txt.Length - 4)
            RaiseEvent TwitEvent(Me, New TwitEventArgs(Status, whatisClickedInTxtStatus, TwitEvents.HashTag))


        ElseIf verb.ToLower = "url" Then
            Process.Start(e.LinkText.Substring(0, e.LinkText.Length - 4)) ' 4= "#url".lenght

        End If


    End Sub

    Private Sub lnkSource_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSource.LinkClicked
        Process.Start(lnkSourceHref)

    End Sub

    Private Sub ReplyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplyToolStripMenuItem.Click
        RaiseEvent TwitEvent(Me, New TwitEventArgs(Status, whatisClickedInTxtStatus, TwitEvents.Reply))

    End Sub

    Private Sub RTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RTToolStripMenuItem.Click
        RaiseEvent TwitEvent(Me, New TwitEventArgs(Status, whatisClickedInTxtStatus, TwitEvents.RT))

    End Sub

    Private Sub txtStatus_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtStatus.MouseMove
        mousexyOntxtstatus = e.Location

    End Sub

    Private Sub UseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UseToolStripMenuItem.Click
        RaiseEvent TwitEvent(Me, New TwitEventArgs(Status, whatisClickedInTxtStatus, TwitEvents.Use_ScreenName))

    End Sub

    Private Sub lblUserName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblUserName.Click
        whatisClickedInTxtStatus = lblUserName.Text
        StatusesToolStripMenuItem.Text = String.Format("{0}'s statuses", lblUserName.Text)
        If FriendsIds Is Nothing Or FollowersId Is Nothing Then
            SendDirectMessageToolStripMenuItem.Enabled = False

        Else
            Dim curuserid As String = ""
            If Status Is Nothing Then
                curuserid = User.Id

            Else
                curuserid = Status.User.Id
            End If
            If Array.IndexOf(FriendsIds, curuserid) = -1 Then
                SendDirectMessageToolStripMenuItem.Enabled = False

            ElseIf Array.IndexOf(FollowersId, curuserid) = -1 Then
                SendDirectMessageToolStripMenuItem.Enabled = False

            Else
                SendDirectMessageToolStripMenuItem.Enabled = True

            End If

        End If

        mnuUsername.Show(lblUserName, 5, 5)

    End Sub

    Private Sub MentionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MentionsToolStripMenuItem.Click
        whatisClickedInTxtStatus = Status.User.Screen_Name
        RaiseEvent TwitEvent(Me, New TwitEventArgs(Status, whatisClickedInTxtStatus, TwitEvents.UserStatuses))

    End Sub

    Private Sub SendDirectMessageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendDirectMessageToolStripMenuItem.Click
        Dim sn As String = ""
        If User IsNot Nothing Then
            sn = User.Screen_Name

        ElseIf Status IsNot Nothing Then
            sn = Status.User.Screen_Name

        End If
        RaiseEvent TwitEvent(Me, New TwitEventArgs(Nothing, sn, TwitEvents.DirectMessage))

    End Sub

    Private Sub ctrStatus_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Util.SetButtonsStyle(Me)

    End Sub

    Private Sub DeleteThisStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteThisStatusToolStripMenuItem.Click
        If Me.Status Is Nothing Then Exit Sub
        twa.DestroyStatus(Me.Status.Id)

    End Sub

    Private Sub TranslateThisStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TranslateThisStatusToolStripMenuItem.Click
        Dim f As New frmTranslate()
        Dim sOrj As String = ""
        If Me.Status Is Nothing Then
            sOrj = Me.User.Status.Text

        Else
            sOrj = Me.Status.Text

        End If
        f.Translate(sOrj)
        f.ShowDialog()


    End Sub

#End Region


    Private Sub StatusesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusesToolStripMenuItem.Click
        whatisClickedInTxtStatus = lblUserName.Text
        RaiseEvent TwitEvent(Me, New TwitEventArgs(Status, whatisClickedInTxtStatus, TwitEvents.UserStatuses))

    End Sub

End Class
