<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageGolferEventYearSponsors
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
        Me.btnAddSponsor = New System.Windows.Forms.Button()
        Me.cboGolfers = New System.Windows.Forms.ComboBox()
        Me.cboEventYears = New System.Windows.Forms.ComboBox()
        Me.lstGolferEventYearSponsors = New System.Windows.Forms.ListBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAddSponsor
        '
        Me.btnAddSponsor.Location = New System.Drawing.Point(36, 249)
        Me.btnAddSponsor.Name = "btnAddSponsor"
        Me.btnAddSponsor.Size = New System.Drawing.Size(149, 43)
        Me.btnAddSponsor.TabIndex = 0
        Me.btnAddSponsor.Text = "Add Sponsor"
        Me.btnAddSponsor.UseVisualStyleBackColor = True
        '
        'cboGolfers
        '
        Me.cboGolfers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGolfers.FormattingEnabled = True
        Me.cboGolfers.Location = New System.Drawing.Point(33, 23)
        Me.cboGolfers.Name = "cboGolfers"
        Me.cboGolfers.Size = New System.Drawing.Size(126, 24)
        Me.cboGolfers.TabIndex = 1
        '
        'cboEventYears
        '
        Me.cboEventYears.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEventYears.FormattingEnabled = True
        Me.cboEventYears.Location = New System.Drawing.Point(55, 23)
        Me.cboEventYears.Name = "cboEventYears"
        Me.cboEventYears.Size = New System.Drawing.Size(126, 24)
        Me.cboEventYears.TabIndex = 2
        '
        'lstGolferEventYearSponsors
        '
        Me.lstGolferEventYearSponsors.FormattingEnabled = True
        Me.lstGolferEventYearSponsors.ItemHeight = 16
        Me.lstGolferEventYearSponsors.Location = New System.Drawing.Point(57, 124)
        Me.lstGolferEventYearSponsors.Name = "lstGolferEventYearSponsors"
        Me.lstGolferEventYearSponsors.Size = New System.Drawing.Size(438, 100)
        Me.lstGolferEventYearSponsors.TabIndex = 3
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(373, 249)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(149, 43)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(203, 249)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(149, 43)
        Me.btnRefresh.TabIndex = 7
        Me.btnRefresh.Text = "Refresh List"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboGolfers)
        Me.GroupBox1.Location = New System.Drawing.Point(57, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(193, 73)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Golfers"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboEventYears)
        Me.GroupBox2.Location = New System.Drawing.Point(281, 36)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(214, 73)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "EventYears"
        '
        'frmManageGolferEventYearSponsors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(598, 352)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lstGolferEventYearSponsors)
        Me.Controls.Add(Me.btnAddSponsor)
        Me.Name = "frmManageGolferEventYearSponsors"
        Me.Text = "Manage Golfer EventYearSponsors"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAddSponsor As Button
    Friend WithEvents cboGolfers As ComboBox
    Friend WithEvents cboEventYears As ComboBox
    Friend WithEvents lstGolferEventYearSponsors As ListBox
    Friend WithEvents btnExit As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
End Class
