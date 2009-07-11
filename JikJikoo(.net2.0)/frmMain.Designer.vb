<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.TimerRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.btnConfig = New System.Windows.Forms.Button
        Me.picUser = New System.Windows.Forms.PictureBox
        Me.lblUser = New System.Windows.Forms.Label
        Me.CtrLogin1 = New JikJikoo.ctrLogin
        Me.CtrStatusList1 = New JikJikoo.ctrStatusList
        Me.CtrlUpdateStatus1 = New JikJikoo.ctrlUpdateStatus
        CType(Me.picUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 3000
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Enabled = False
        Me.btnRefresh.ForeColor = System.Drawing.Color.Black
        Me.btnRefresh.Location = New System.Drawing.Point(505, 28)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 25)
        Me.btnRefresh.TabIndex = 3
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'TimerRefresh
        '
        '
        'btnConfig
        '
        Me.btnConfig.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConfig.ForeColor = System.Drawing.Color.Black
        Me.btnConfig.Location = New System.Drawing.Point(505, 1)
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(75, 25)
        Me.btnConfig.TabIndex = 4
        Me.btnConfig.Text = "Config"
        Me.btnConfig.UseVisualStyleBackColor = True
        '
        'picUser
        '
        Me.picUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picUser.BackColor = System.Drawing.Color.Black
        Me.picUser.Location = New System.Drawing.Point(733, 2)
        Me.picUser.Name = "picUser"
        Me.picUser.Size = New System.Drawing.Size(48, 48)
        Me.picUser.TabIndex = 14
        Me.picUser.TabStop = False
        '
        'lblUser
        '
        Me.lblUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUser.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblUser.Location = New System.Drawing.Point(586, 2)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(141, 23)
        Me.lblUser.TabIndex = 15
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'CtrLogin1
        '
        Me.CtrLogin1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrLogin1.BackColor = System.Drawing.Color.Transparent
        Me.CtrLogin1.Location = New System.Drawing.Point(2, -1)
        Me.CtrLogin1.Name = "CtrLogin1"
        Me.CtrLogin1.Size = New System.Drawing.Size(497, 26)
        Me.CtrLogin1.TabIndex = 0
        '
        'CtrStatusList1
        '
        Me.CtrStatusList1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrStatusList1.Enabled = False
        Me.CtrStatusList1.Location = New System.Drawing.Point(2, 99)
        Me.CtrStatusList1.Name = "CtrStatusList1"
        Me.CtrStatusList1.Size = New System.Drawing.Size(779, 430)
        Me.CtrStatusList1.Statuses = Nothing
        Me.CtrStatusList1.TabIndex = 1
        '
        'CtrlUpdateStatus1
        '
        Me.CtrlUpdateStatus1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CtrlUpdateStatus1.Enabled = False
        Me.CtrlUpdateStatus1.Location = New System.Drawing.Point(6, 2)
        Me.CtrlUpdateStatus1.Name = "CtrlUpdateStatus1"
        Me.CtrlUpdateStatus1.Size = New System.Drawing.Size(493, 80)
        Me.CtrlUpdateStatus1.TabIndex = 2
        Me.CtrlUpdateStatus1.Visible = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(784, 533)
        Me.Controls.Add(Me.CtrLogin1)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.picUser)
        Me.Controls.Add(Me.btnConfig)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.CtrStatusList1)
        Me.Controls.Add(Me.CtrlUpdateStatus1)
        Me.ForeColor = System.Drawing.Color.White
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JikJikoo"
        CType(Me.picUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CtrLogin1 As JikJikoo.ctrLogin
    Friend WithEvents CtrStatusList1 As JikJikoo.ctrStatusList
    Friend WithEvents CtrlUpdateStatus1 As JikJikoo.ctrlUpdateStatus
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents TimerRefresh As System.Windows.Forms.Timer
    Friend WithEvents btnConfig As System.Windows.Forms.Button
    Friend WithEvents picUser As System.Windows.Forms.PictureBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
End Class
