Public Class frmTranslate

    Private Sub frmTranslate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Util.SetButtonsStyle(Me)
        InitLang()

    End Sub

    Public Sub Translate(ByVal s As String)
        InitLang()
        txtFrom.Text = s
        txtTo.Text = GoogleTranslator.TranslateText(txtFrom.Text.Trim(), cboFrom.SelectedItem, cboTo.SelectedItem)

    End Sub

    Private Sub btnTranslate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTranslate.Click
        txtTo.Text = GoogleTranslator.TranslateText(txtFrom.Text.Trim(), cboFrom.SelectedItem, cboTo.SelectedItem)

    End Sub

    Private Sub InitLang()
        If cboFrom.SelectedIndex = -1 Then cboFrom.SelectedItem = "en"
        If cboTo.SelectedIndex = -1 Then cboTo.SelectedItem = "fa"

    End Sub

    Private Sub btnSwap_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnSwap.LinkClicked
        If cboFrom.SelectedIndex = -1 Or cboTo.SelectedIndex = -1 Then Exit Sub
        Dim s As String = cboFrom.SelectedItem
        cboFrom.SelectedItem = cboTo.SelectedItem
        cboTo.SelectedItem = s

    End Sub
End Class
