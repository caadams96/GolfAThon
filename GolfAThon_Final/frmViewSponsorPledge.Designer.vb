<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewSponsorPledge
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
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboEvents = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboNames = New System.Windows.Forms.ComboBox()
        Me.btnPledgeSum = New System.Windows.Forms.Button()
        Me.txtPledge = New System.Windows.Forms.TextBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(321, 195)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(133, 36)
        Me.btnExit.TabIndex = 17
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboEvents)
        Me.GroupBox2.Location = New System.Drawing.Point(321, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(214, 73)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "EventYears"
        '
        'cboEvents
        '
        Me.cboEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEvents.FormattingEnabled = True
        Me.cboEvents.Location = New System.Drawing.Point(55, 23)
        Me.cboEvents.Name = "cboEvents"
        Me.cboEvents.Size = New System.Drawing.Size(126, 24)
        Me.cboEvents.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboNames)
        Me.GroupBox1.Location = New System.Drawing.Point(85, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(193, 73)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sponsors"
        '
        'cboNames
        '
        Me.cboNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNames.FormattingEnabled = True
        Me.cboNames.Location = New System.Drawing.Point(34, 23)
        Me.cboNames.Name = "cboNames"
        Me.cboNames.Size = New System.Drawing.Size(126, 24)
        Me.cboNames.TabIndex = 1
        '
        'btnPledgeSum
        '
        Me.btnPledgeSum.Location = New System.Drawing.Point(131, 195)
        Me.btnPledgeSum.Name = "btnPledgeSum"
        Me.btnPledgeSum.Size = New System.Drawing.Size(147, 36)
        Me.btnPledgeSum.TabIndex = 19
        Me.btnPledgeSum.Text = "Show Pledge Sum"
        Me.btnPledgeSum.UseVisualStyleBackColor = True
        '
        'txtPledge
        '
        Me.txtPledge.Location = New System.Drawing.Point(201, 151)
        Me.txtPledge.Name = "txtPledge"
        Me.txtPledge.Size = New System.Drawing.Size(164, 22)
        Me.txtPledge.TabIndex = 20
        '
        'frmViewSponsorPledge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(643, 309)
        Me.Controls.Add(Me.txtPledge)
        Me.Controls.Add(Me.btnPledgeSum)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmViewSponsorPledge"
        Me.Text = "View Sponsor Pledge"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cboEvents As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboNames As ComboBox
    Friend WithEvents btnPledgeSum As Button
    Friend WithEvents txtPledge As TextBox
End Class
