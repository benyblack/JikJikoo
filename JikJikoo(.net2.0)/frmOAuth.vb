Imports DNE.Twitter

Public Class frmOAuth

    Private _tempuser As String = ""
    Private _temppass As String = ""
    Friend WriteOnly Property TempUser() As String
        Set(ByVal value As String)
            _tempuser = value
        End Set
    End Property

    Friend WriteOnly Property Temppass() As String
        Set(ByVal value As String)
            _temppass = value
        End Set
    End Property

    Dim o As oAuthExample.oAuthTwitter
    Dim jc As New JikConfigManager()

    Private Sub frmOAuth_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Util.SetButtonsStyle(Me)
        Dim tw As New Api()
        tw.ConfigProxy(jc.proxytype, jc.proxyport, jc.proxyserver, jc.proxyuser, jc.proxypass)
        o = New oAuthExample.oAuthTwitter(tw)
        txtPIN.Enabled = False
        btnFinish.Enabled = True
        o.ConsumerKey = "Um0Z859qORQgTkN4ehyqdw"
        o.ConsumerSecret = "F1Ce6okvMspIYBbrJJ7Qh2LkvkJNhxruiI2Ln7CmA"
        txtUrl.Text = o.AuthorizationLinkGet()
        o.Token = txtUrl.Text.Split("=")(1)
        txtPIN.Enabled = True

    End Sub

    Private Sub txtPIN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPIN.TextChanged
        ValidatePINforClient()

    End Sub

    Private Function ValidatePINforClient()
        If Microsoft.VisualBasic.IsNumeric(txtPIN.Text) Then
            If txtPIN.Text.Length >= 6 Then
                Return True

            End If
        End If
        Return False
    End Function

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        txtPIN.Text = My.Computer.Clipboard.GetText()
        Application.DoEvents()
        Threading.Thread.Sleep(1000)
        o.AccessTokenGetPIN(txtPIN.Text)
        If o.TokenSecret = "" Then
            MsgBox("Entered PIN Is Not Valid", MsgBoxStyle.Critical)
            Exit Sub

        End If
        Dim ac As New AppConfig()

        ac.SetValue("Token", o.Token)
        ac.SetValue("TokenSecret", o.TokenSecret)
        ac.SetValue("TokenHash", Util.HashSHA1(_tempuser, o.Token, o.TokenSecret))
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub btnIE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIE.Click
        Process.Start("iexplore", txtUrl.Text)

    End Sub

    Private Sub btnFF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFF.Click
        Process.Start("firefox", txtUrl.Text)

    End Sub

    Private Sub btnChrome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChrome.Click
        Dim ix As Int32 = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData.IndexOf("AppData")
        Dim path As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData.Substring(0, ix + 7)
        path += "\Local\Google\Chrome\Application\chrome.exe"
        Process.Start(path, txtUrl.Text)

    End Sub

    Private Sub btnsafari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsafari.Click
        Process.Start("safari", txtUrl.Text)

    End Sub

End Class