Imports System.Threading
Imports System.Configuration.ConfigurationManager

Public Class ctrLogin

    Public Event Login As EventHandler
    Public Event Logout As EventHandler

    Private _loggedin As Boolean = False

    Private orgWidth As Int32 = 0
    Private orgLeft As Int32 = 0
    Private rm As New System.ComponentModel.ComponentResourceManager(Me.GetType)

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        'First Check Login
        If Not _loggedin Then
            orgWidth = Me.Width
            orgLeft = Me.Left
            Dim jc As New JikConfigManager()
            Dim tw As New DNE.JikJikoo.TwitterApi()
            tw.ConfigProxy(jc.proxytype, jc.proxyport, jc.proxyserver, jc.proxyuser, jc.proxypass)
            Dim u As DNE.Twitter.User = tw.UserShow(txtUid.Text) 'tw.VerifyCredentials()
            If u Is Nothing Then
                MsgBox(rm.GetString("LoginError"), MsgBoxStyle.Critical)
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
            password = txtPwd.Text
            txtPwd.Enabled = False
            txtUid.Enabled = False
            Dim ac As New AppConfig()
            ac.ConfigType = 1
            If chkSave.Checked Then
                ac.SetValue("user", username)
                ac.SetValue("password", password)

            Else
                ac.SetValue("user", "")
                ac.SetValue("password", "")

            End If
            btnLogin.Text = rm.GetString("logout")
            pnl1.Visible = False
            Me.Left = Me.Right - 80
            Me.Width = 80
            _loggedin = True
            RaiseEvent Login(Nothing, Nothing)

        Else
            txtUid.Enabled = True
            username = ""
            password = ""
            btnLogin.Text = rm.GetString("login")
            pnl1.Visible = True
            Me.Left = orgLeft
            Me.Width = orgWidth
            Dim jc As New JikConfigManager()
            jc.ClearAuthData()

            twa.UserName = ""
            twa.TokenSecret = ""
            twa.Token = ""

            _loggedin = False
            RaiseEvent Logout(Nothing, Nothing)

        End If


    End Sub

    Friend Sub SetSize()
        If orgWidth = 0 Then Exit Sub
        If txtUid.Enabled Then
            Me.Left = orgLeft
            Me.Width = orgWidth

        End If

    End Sub

    Private Sub ctrLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
    End Sub

    Friend Sub LoadLogin()
     
        If Me.Site IsNot Nothing AndAlso Me.Site.DesignMode Then Exit Sub
        Dim ace As New AppConfig()
        If ace.GetValue("user") <> "" Then
            txtUid.Text = ace.GetValue("user")
            txtPwd.Text = ace.GetValue("password")
            Dim jc As New JikConfigManager()
            Dim ouhash As String = Util.HashSHA1(txtUid.Text.ToLower(), jc.Token, jc.TokenSecret)
            If ouhash = jc.TokenHash Then
                btnLogin.Text = rm.GetString("logout") '"LogOut"
                pnl1.Visible = False
                Me.Left = Me.Right - 80
                Me.Width = 80
                'Me.BringToFront()
                RaiseEvent Login(Nothing, Nothing)
            End If
            chkSave.Checked = True

        Else
            txtUid.Text = ""
            txtPwd.Text = ""
            chkSave.Checked = False

        End If
     
    End Sub

    Private Function GetoAuth() As Boolean
        'get oAuth info from user
        Dim f As New frmOAuth()
        f.TempUser = txtUid.Text
        f.Temppass = txtPwd.Text
        If f.ShowDialog = DialogResult.Cancel Then
            MsgBox(rm.GetString("VeryfingError"), MsgBoxStyle.Critical)
            Return False

        Else
            Return True

        End If
    End Function

End Class

