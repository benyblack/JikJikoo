<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrStatusList
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.pnlMain = New System.Windows.Forms.FlowLayoutPanel
        Me.lnkPrev = New System.Windows.Forms.LinkLabel
        Me.lnkNext = New System.Windows.Forms.LinkLabel
        Me.lblPager = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.Location = New System.Drawing.Point(0, 19)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(320, 331)
        Me.pnlMain.TabIndex = 0
        '
        'lnkPrev
        '
        Me.lnkPrev.AutoSize = True
        Me.lnkPrev.Location = New System.Drawing.Point(3, 3)
        Me.lnkPrev.Name = "lnkPrev"
        Me.lnkPrev.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lnkPrev.Size = New System.Drawing.Size(13, 13)
        Me.lnkPrev.TabIndex = 1
        Me.lnkPrev.TabStop = True
        Me.lnkPrev.Text = "<"
        '
        'lnkNext
        '
        Me.lnkNext.AutoSize = True
        Me.lnkNext.Location = New System.Drawing.Point(41, 3)
        Me.lnkNext.Name = "lnkNext"
        Me.lnkNext.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lnkNext.Size = New System.Drawing.Size(13, 13)
        Me.lnkNext.TabIndex = 2
        Me.lnkNext.TabStop = True
        Me.lnkNext.Text = ">"
        '
        'lblPager
        '
        Me.lblPager.AutoSize = True
        Me.lblPager.Location = New System.Drawing.Point(22, 3)
        Me.lblPager.Name = "lblPager"
        Me.lblPager.Size = New System.Drawing.Size(13, 13)
        Me.lblPager.TabIndex = 3
        Me.lblPager.Text = "1"
        '
        'ctrStatusList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblPager)
        Me.Controls.Add(Me.lnkNext)
        Me.Controls.Add(Me.lnkPrev)
        Me.Controls.Add(Me.pnlMain)
        Me.Name = "ctrStatusList"
        Me.Size = New System.Drawing.Size(320, 350)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlMain As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lnkPrev As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkNext As System.Windows.Forms.LinkLabel
    Friend WithEvents lblPager As System.Windows.Forms.Label

End Class
