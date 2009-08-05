Public Class frmUpload

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub frmUpload_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Util.SetButtonsStyle(Me)

    End Sub

    Private Sub CtrUploadFile1_DownloadCompleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrUploadFile1.DownloadCompleted
        btnOk.Enabled = True

    End Sub

End Class
