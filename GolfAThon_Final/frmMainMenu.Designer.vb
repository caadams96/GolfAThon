<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainMenu
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
        Me.btnGolfers = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnEvents = New System.Windows.Forms.Button()
        Me.btnGolferEvents = New System.Windows.Forms.Button()
        Me.btnSponsors = New System.Windows.Forms.Button()
        Me.btnGolferEventYearSponsors = New System.Windows.Forms.Button()
        Me.btnViewPledge = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnGolfers
        '
        Me.btnGolfers.Location = New System.Drawing.Point(43, 98)
        Me.btnGolfers.Name = "btnGolfers"
        Me.btnGolfers.Size = New System.Drawing.Size(298, 47)
        Me.btnGolfers.TabIndex = 0
        Me.btnGolfers.Text = "Manage Golfers"
        Me.btnGolfers.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(239, 333)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(298, 47)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnEvents
        '
        Me.btnEvents.Location = New System.Drawing.Point(378, 168)
        Me.btnEvents.Name = "btnEvents"
        Me.btnEvents.Size = New System.Drawing.Size(298, 47)
        Me.btnEvents.TabIndex = 2
        Me.btnEvents.Text = "Manage Events"
        Me.btnEvents.UseVisualStyleBackColor = True
        '
        'btnGolferEvents
        '
        Me.btnGolferEvents.Location = New System.Drawing.Point(43, 168)
        Me.btnGolferEvents.Name = "btnGolferEvents"
        Me.btnGolferEvents.Size = New System.Drawing.Size(298, 47)
        Me.btnGolferEvents.TabIndex = 3
        Me.btnGolferEvents.Text = "Manage GolferEvents"
        Me.btnGolferEvents.UseVisualStyleBackColor = True
        '
        'btnSponsors
        '
        Me.btnSponsors.Location = New System.Drawing.Point(378, 98)
        Me.btnSponsors.Name = "btnSponsors"
        Me.btnSponsors.Size = New System.Drawing.Size(298, 47)
        Me.btnSponsors.TabIndex = 4
        Me.btnSponsors.Text = "Manage Sponsors"
        Me.btnSponsors.UseVisualStyleBackColor = True
        '
        'btnGolferEventYearSponsors
        '
        Me.btnGolferEventYearSponsors.Location = New System.Drawing.Point(43, 257)
        Me.btnGolferEventYearSponsors.Name = "btnGolferEventYearSponsors"
        Me.btnGolferEventYearSponsors.Size = New System.Drawing.Size(298, 47)
        Me.btnGolferEventYearSponsors.TabIndex = 5
        Me.btnGolferEventYearSponsors.Text = "Manage GolferEventYearSponsors"
        Me.btnGolferEventYearSponsors.UseVisualStyleBackColor = True
        '
        'btnViewPledge
        '
        Me.btnViewPledge.Location = New System.Drawing.Point(378, 257)
        Me.btnViewPledge.Name = "btnViewPledge"
        Me.btnViewPledge.Size = New System.Drawing.Size(298, 47)
        Me.btnViewPledge.TabIndex = 6
        Me.btnViewPledge.Text = "View Pledges"
        Me.btnViewPledge.UseVisualStyleBackColor = True
        '
        'frmMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(776, 498)
        Me.Controls.Add(Me.btnViewPledge)
        Me.Controls.Add(Me.btnGolferEventYearSponsors)
        Me.Controls.Add(Me.btnSponsors)
        Me.Controls.Add(Me.btnGolferEvents)
        Me.Controls.Add(Me.btnEvents)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnGolfers)
        Me.Name = "frmMainMenu"
        Me.Text = "Golf-A-Thon "
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnGolfers As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnEvents As Button
    Friend WithEvents btnGolferEvents As Button
    Friend WithEvents btnSponsors As Button
    Friend WithEvents btnGolferEventYearSponsors As Button
    Friend WithEvents btnViewPledge As Button
End Class
