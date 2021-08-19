<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewPledgeTotals
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
        Me.btnGolferPledge = New System.Windows.Forms.Button()
        Me.btnSponsorPledge = New System.Windows.Forms.Button()
        Me.tnEventPledge = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnGolferPledge
        '
        Me.btnGolferPledge.Location = New System.Drawing.Point(155, 46)
        Me.btnGolferPledge.Name = "btnGolferPledge"
        Me.btnGolferPledge.Size = New System.Drawing.Size(202, 63)
        Me.btnGolferPledge.TabIndex = 0
        Me.btnGolferPledge.Text = "Golfer Pledge Total"
        Me.btnGolferPledge.UseVisualStyleBackColor = True
        '
        'btnSponsorPledge
        '
        Me.btnSponsorPledge.Location = New System.Drawing.Point(155, 145)
        Me.btnSponsorPledge.Name = "btnSponsorPledge"
        Me.btnSponsorPledge.Size = New System.Drawing.Size(202, 63)
        Me.btnSponsorPledge.TabIndex = 1
        Me.btnSponsorPledge.Text = "Sponsor Pledge Total"
        Me.btnSponsorPledge.UseVisualStyleBackColor = True
        '
        'tnEventPledge
        '
        Me.tnEventPledge.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tnEventPledge.Location = New System.Drawing.Point(155, 244)
        Me.tnEventPledge.Name = "tnEventPledge"
        Me.tnEventPledge.Size = New System.Drawing.Size(202, 63)
        Me.tnEventPledge.TabIndex = 2
        Me.tnEventPledge.Text = "Event Pledge Total"
        Me.tnEventPledge.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(155, 348)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(202, 63)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmViewPledgeTotals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 466)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.tnEventPledge)
        Me.Controls.Add(Me.btnSponsorPledge)
        Me.Controls.Add(Me.btnGolferPledge)
        Me.Name = "frmViewPledgeTotals"
        Me.Text = "frmViewPledgeTotals"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnGolferPledge As Button
    Friend WithEvents btnSponsorPledge As Button
    Friend WithEvents tnEventPledge As Button
    Friend WithEvents btnExit As Button
End Class
