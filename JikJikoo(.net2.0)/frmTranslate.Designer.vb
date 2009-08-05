<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTranslate
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
        Me.btnTranslate = New System.Windows.Forms.Button
        Me.btnSwap = New System.Windows.Forms.LinkLabel
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboTo = New System.Windows.Forms.ComboBox
        Me.cboFrom = New System.Windows.Forms.ComboBox
        Me.txtTo = New System.Windows.Forms.RichTextBox
        Me.txtFrom = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        'btnTranslate
        '
        Me.btnTranslate.ForeColor = System.Drawing.Color.Black
        Me.btnTranslate.Location = New System.Drawing.Point(10, 12)
        Me.btnTranslate.Name = "btnTranslate"
        Me.btnTranslate.Size = New System.Drawing.Size(75, 23)
        Me.btnTranslate.TabIndex = 2
        Me.btnTranslate.Text = "Translate"
        Me.btnTranslate.UseVisualStyleBackColor = True
        '
        'btnSwap
        '
        Me.btnSwap.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSwap.AutoSize = True
        Me.btnSwap.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.btnSwap.LinkColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.btnSwap.Location = New System.Drawing.Point(174, 19)
        Me.btnSwap.Name = "btnSwap"
        Me.btnSwap.Size = New System.Drawing.Size(34, 13)
        Me.btnSwap.TabIndex = 10
        Me.btnSwap.TabStop = True
        Me.btnSwap.Text = "Swap"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(262, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "To"
        '
        'cboTo
        '
        Me.cboTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTo.FormattingEnabled = True
        Me.cboTo.Items.AddRange(New Object() {"fa", "en", "fr", "es", "it", "ru", "cn", "gr", "ar"})
        Me.cboTo.Location = New System.Drawing.Point(288, 14)
        Me.cboTo.Name = "cboTo"
        Me.cboTo.Size = New System.Drawing.Size(42, 21)
        Me.cboTo.TabIndex = 8
        '
        'cboFrom
        '
        Me.cboFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFrom.FormattingEnabled = True
        Me.cboFrom.Items.AddRange(New Object() {"en", "fr", "es", "it", "ru", "cn", "gr", "fa", "ar"})
        Me.cboFrom.Location = New System.Drawing.Point(214, 14)
        Me.cboFrom.Name = "cboFrom"
        Me.cboFrom.Size = New System.Drawing.Size(42, 21)
        Me.cboFrom.TabIndex = 7
        '
        'txtTo
        '
        Me.txtTo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtTo.Location = New System.Drawing.Point(10, 171)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(318, 136)
        Me.txtTo.TabIndex = 12
        Me.txtTo.Text = ""
        '
        'txtFrom
        '
        Me.txtFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtFrom.Location = New System.Drawing.Point(10, 47)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(318, 118)
        Me.txtFrom.TabIndex = 11
        Me.txtFrom.Text = ""
        '
        'frmTranslate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(338, 319)
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.txtFrom)
        Me.Controls.Add(Me.btnSwap)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboTo)
        Me.Controls.Add(Me.cboFrom)
        Me.Controls.Add(Me.btnTranslate)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "frmTranslate"
        Me.Text = "Google Translator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnTranslate As System.Windows.Forms.Button
    Friend WithEvents btnSwap As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTo As System.Windows.Forms.ComboBox
    Friend WithEvents cboFrom As System.Windows.Forms.ComboBox
    Friend WithEvents txtTo As System.Windows.Forms.RichTextBox
    Friend WithEvents txtFrom As System.Windows.Forms.RichTextBox
End Class
