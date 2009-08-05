Public Class frmTranslate

    Private Sub frmTranslate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Util.SetButtonsStyle(Me)


    End Sub

    Public Sub Translate(ByVal s As String)
        txtFrom.Text = s
        txtTo.Text = GoogleTranslator.TranslateText(txtFrom.Text.Trim(), cboFrom.SelectedItem, cboTo.SelectedItem)

    End Sub

    Private Sub btnTranslate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTranslate.Click
        txtTo.Text = GoogleTranslator.TranslateText(txtFrom.Text.Trim(), cboFrom.SelectedItem, cboTo.SelectedItem)

    End Sub

End Class
