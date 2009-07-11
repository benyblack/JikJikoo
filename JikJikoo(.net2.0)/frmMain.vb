Imports System.Configuration.ConfigurationManager
Imports System.Xml
Imports System.ComponentModel

Public Class frmMain


    Private Sub Bind()
        Threading.Thread.Sleep(3000)
        Dim sts As Collections.ObjectModel.Collection(Of DNE.Twitter.Status)
        If CtrStatusList1.LastStatusId = 0 Then
            sts = twa.GetFriendsTimeLine()
            CtrStatusList1.Statuses = sts

        Else
            sts = twa.GetFriendsTimeLinesinceid(CtrStatusList1.LastStatusId)
            CtrStatusList1.AddStatuses(sts)

        End If

    End Sub

    Private Sub ReloadConfig()
        Try
            Dim jcm As New JikConfigManager()
            twa = New DNE.JikJikoo.TwitterApi(jcm.user, jcm.password, jcm.Token, jcm.TokenSecret)
            twa.ConfigProxy(CInt(jcm.proxytype), CInt(jcm.proxyport), jcm.proxyserver, jcm.proxyuser, jcm.proxypass)
            TimerRefresh.Interval = CInt(jcm.refresh) * 1000

            AddHandler twa.DownloadingDataStart, AddressOf DownloadStart
            AddHandler twa.DownloadingDataEnd, AddressOf DownloadEnd
        Catch ex As Exception
            ex.ToString()

        End Try


    End Sub

    Private Sub SetUiEnable(ByVal b As Boolean)
        CtrlUpdateStatus1.Enabled = b
        CtrlUpdateStatus1.Visible = b
        CtrStatusList1.Enabled = b
        btnRefresh.Enabled = b

    End Sub

#Region " Form Events "

    Private Sub btnConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfig.Click
        Dim f As New frmConfig()
        f.ShowDialog()

    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReloadConfig()

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        TimerRefresh.Enabled = False
        Bind()
        TimerRefresh.Enabled = True

    End Sub

    Private Sub CtrlUpdateStatus1_UpdateCompleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlUpdateStatus1.UpdateCompleted
        Me.Text = "JikJikoo - Update Status Completed!"
        Timer1.Start()
        Bind()
        TimerRefresh.Enabled = True

    End Sub

    Private Sub CtrlUpdateStatus1_UpdateStarted(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlUpdateStatus1.UpdateStarted
        TimerRefresh.Enabled = False

    End Sub

    Private Sub TimerRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerRefresh.Tick
        Bind()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Text = "JikJikoo"
        Timer1.Stop()

    End Sub

#End Region

#Region " Login Events "

    Private Sub CtrLogin1_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrLogin1.Login
        Dim ace As New AppConfig()
        SetUiEnable(True)
        ReloadConfig()
        picUser.Image = twa.GetImage(CurrentUser.Profile_image_url)
        lblUser.Text = CurrentUser.Screen_Name
        Application.DoEvents()
        
        Dim t As New Threading.Thread(AddressOf Bind)
        t.Start()

        'Bind()
        TimerRefresh.Interval = CInt(ace.GetValue("refresh")) * 1000
        TimerRefresh.Enabled = False

    End Sub

    Private Sub CtrLogin1_Logout(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrLogin1.Logout
        TimerRefresh.Enabled = False
        SetUiEnable(False)
        CtrStatusList1.Clear()
        picUser.Image = Nothing
        lblUser.Text = ""

    End Sub

#End Region

#Region " Status List Events "

    Private Sub CtrStatusList1_EndAddStatuses(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrStatusList1.EndAddStatuses
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf EndAddStatuses))
        Else
            Me.Text = "JikJikoo"
        End If
    End Sub

    Private Sub CtrStatusList1_EndCachingImages(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrStatusList1.EndCachingImages
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf EndCachingImages))
        Else
            Me.Text = "JikJikoo - Caching Images Completed"
        End If
    End Sub

    Private Sub CtrStatusList1_ReplyCommand(ByVal sender As Object, ByVal rea As ReplyEventArgs) Handles CtrStatusList1.ReplyCommand
        CtrlUpdateStatus1.txtStatus.Text = "@" & rea.ReplyTo
    End Sub

    Private Sub CtrStatusList1_StartAddStatuses(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrStatusList1.StartAddStatuses
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf StartAddStatuses))
        Else
            Me.Text = "JikJikoo - Adding Statuses ..."
        End If
    End Sub

    Private Sub CtrStatusList1_StartCachingImages(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrStatusList1.StartCachingImages
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf StartCachingImages))
        Else
            Me.Text = "JikJikoo - Caching Images ..."
        End If

    End Sub

    Private Sub DownloadStart(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf DownloadStart))
        Else
            Me.Text = "JikJikoo - Downloading Data Started ..."

        End If

    End Sub

    Private Sub DownloadEnd(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf DownloadEnd))
        Else
            Me.Text = "JikJikoo - Downloading Data Completed"
            Timer1.Start()
        End If
    End Sub

    Private Sub DownloadStart()
        Me.Text = "JikJikoo - Downloading Data Started ..."

    End Sub

    Private Sub EndCachingImages()
        Me.Text = "JikJikoo - Caching Images Completed"

    End Sub
 

    Private Sub StartAddStatuses()
        Me.Text = "JikJikoo - Adding Statuses ..."

    End Sub

    Private Sub EndAddStatuses()
        Me.Text = "JikJikoo"
        TimerRefresh.Enabled = True

    End Sub

    Private Sub StartCachingImages()
        Me.Text = "JikJikoo - Caching Images ..."
        Threading.Thread.Sleep(25)


    End Sub

    Private Sub DownloadEnd()
        Me.Text = "JikJikoo - Downloading Data Completed"
        'Timer1.Start()
    End Sub

#End Region

    Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        CtrLogin1.SetSize()

    End Sub

End Class
