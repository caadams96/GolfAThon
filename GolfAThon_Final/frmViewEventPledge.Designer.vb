<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewEventPledge
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboEvents = New System.Windows.Forms.ComboBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnPledgeSum = New System.Windows.Forms.Button()
        Me.txtPledge = New System.Windows.Forms.TextBox()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboEvents)
        Me.GroupBox2.Location = New System.Drawing.Point(117, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(214, 73)
        Me.GroupBox2.TabIndex = 12
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
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(234, 198)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(146, 29)
        Me.btnExit.TabIndex = 14
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnPledgeSum
        '
        Me.btnPledgeSum.Location = New System.Drawing.Point(40, 191)
        Me.btnPledgeSum.Name = "btnPledgeSum"
        Me.btnPledgeSum.Size = New System.Drawing.Size(147, 36)
        Me.btnPledgeSum.TabIndex = 20
        Me.btnPledgeSum.Text = "Show Pledge Sum"
        Me.btnPledgeSum.UseVisualStyleBackColor = True
        '
        'txtPledge
        '
        Me.txtPledge.Location = New System.Drawing.Point(135, 126)
        Me.txtPledge.Name = "txtPledge"
        Me.txtPledge.Size = New System.Drawing.Size(148, 22)
        Me.txtPledge.TabIndex = 21
        '
        'frmViewEventPledge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(486, 280)
        Me.Controls.Add(Me.txtPledge)
        Me.Controls.Add(Me.btnPledgeSum)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmViewEventPledge"
        Me.Text = "View Event Pledge"
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cboEvents As ComboBox
    Friend WithEvents btnExit As Button
    Friend WithEvents btnPledgeSum As Button
    Friend WithEvents txtPledge As TextBox
End Class
