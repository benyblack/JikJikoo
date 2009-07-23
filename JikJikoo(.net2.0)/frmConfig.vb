Imports System.Configuration
Public Class frmConfig

    Private Sub frmConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Util.SetButtonsStyle(Me)
        Dim ac As New AppConfig()
        ac.ConfigType = 1
        txtIP.Text = ac.GetValue("proxyserver")
        txtPort.Text = ac.GetValue("proxyport")
        txtUser.Text = ac.GetValue("proxyuser")
        txtPass.Text = ac.GetValue("proxypass")
        txtRefresh.Text = ac.GetValue("refresh")
        cboProxyType.SelectedIndex = CInt(ac.GetValue("proxytype"))
        If ac.GetValue("lang").ToLower() = "fa" Then
            cboLang.SelectedIndex = 0

        ElseIf ac.GetValue("lang").ToLower() = "en" Then
            cboLang.SelectedIndex = 1

        End If

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim ac As New AppConfig()
        ac.ConfigType = 1
        ac.SetValue("proxyserver", txtIP.Text)
        ac.SetValue("proxyport", txtPort.Text)
        ac.SetValue("proxytype", cboProxyType.SelectedIndex)
        ac.SetValue("proxyuser", txtUser.Text)
        ac.SetValue("proxypass", txtPass.Text)
        ac.SetValue("refresh", txtRefresh.Text.Trim())
        ac.SetValue("lang", IIf(cboLang.SelectedIndex = 0, "FA", "EN"))
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

End Class
