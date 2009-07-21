Public Class ctrLoginOAuth

    Public Event Login As EventHandler
    Public Event Logout As EventHandler

    Private _loggedin As Boolean = False

    Friend Sub SetLastUpdateText(ByVal s As String)
        If Util.ContainRtlChars(s) Then
            txtStatus.RightToLeft = Windows.Forms.RightToLeft.Yes

        Else
            txtStatus.RightToLeft = Windows.Forms.RightToLeft.No

        End If
        txtStatus.Text = s

    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        'First Check Login
        If Not _loggedin Then
            Dim jc As New JikConfigManager()
            Dim tw As New DNE.Twitter.Api()
            tw.ConfigProxy(jc.proxytype, jc.proxyport, jc.proxyserver, jc.proxyuser, jc.proxypass)
            Dim u As DNE.Twitter.User = Nothing
            Try
                u = tw.UserShow(txtUid.Text)

            Catch ex As Exception
                Exit Sub

            End Try
            If u Is Nothing Then
                MsgBox(My.Resources.JikJikoo.LoginError, MsgBoxStyle.Critical)
                Exit Sub

            Else
                CurrentUser = u

            End If

            'Chec oAuth Configuration
            If jc.Token = "" Then
                'get oAuth info from user
                If Not GetoAuth() Then
                    Exit Sub

                End If

            Else
                Dim ouhash As String = Util.HashSHA1(txtUid.Text.ToLower(), jc.Token, jc.TokenSecret)
                If ouhash <> jc.TokenHash Then
                    'get oAuth info from user
                    If Not GetoAuth() Then
                        Exit Sub

                    End If

                End If

            End If

            username = txtUid.Text.Trim()
            txtUid.ReadOnly = True
            txtUid.BackColor = Color.Black
            txtUid.ForeColor = Color.White
            txtUid.BorderStyle = Windows.Forms.BorderStyle.None

            Dim ac As New AppConfig()
            ac.ConfigType = 1
            ac.SetValue("user", username)
            ac.SetValue("password", "")

            btnLogin.Text = My.Resources.JikJikoo.logout
            _loggedin = True
            RaiseEvent Login(Nothing, Nothing)

        Else

            txtUid.ReadOnly = False
            txtUid.BackColor = Color.White
            txtUid.ForeColor = Color.Black
            username = ""
            password = ""
            btnLogin.Text = My.Resources.JikJikoo.login
            Dim jc As New JikConfigManager()
            jc.ClearAuthData()

            twa.UserName = ""
            twa.TokenSecret = ""
            twa.Token = ""

            _loggedin = False
            picUser.Image = Nothing
            RaiseEvent Logout(Nothing, Nothing)

        End If


    End Sub

    Friend Sub LoadLogin()
        If Me.Site IsNot Nothing AndAlso Me.Site.DesignMode Then Exit Sub
        Dim ace As New AppConfig()
        If ace.GetValue("user") <> "" Then
            txtUid.Text = ace.GetValue("user")
            Dim jc As New JikConfigManager()
            Dim ouhash As String = Util.HashSHA1(txtUid.Text.ToLower(), jc.Token, jc.TokenSecret)
            If ouhash = jc.TokenHash Then
                btnLogin.Text = My.Resources.JikJikoo.logout
                txtUid.ReadOnly = True
                txtUid.BackColor = Color.Black
                txtUid.ForeColor = Color.White
                txtUid.BorderStyle = Windows.Forms.BorderStyle.None
                RaiseEvent Login(Nothing, Nothing)
            End If

        Else
            txtUid.Text = ""
            txtUid.BackColor = Color.White
            txtUid.ForeColor = Color.Black
            txtUid.BorderStyle = Windows.Forms.BorderStyle.Fixed3D

        End If

    End Sub

    Private Function GetoAuth() As Boolean
        'get oAuth info from user
        Dim f As New frmOAuth()
        f.TempUser = txtUid.Text
        f.Temppass = ""
        If f.ShowDialog = DialogResult.Cancel Then
            MsgBox(My.Resources.JikJikoo.VeryfingError)
            Return False

        Else
            Return True

        End If
    End Function

End Class
