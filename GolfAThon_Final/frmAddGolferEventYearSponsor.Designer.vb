<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddGolferEventYearSponsor
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
        Me.lblEventYear = New System.Windows.Forms.Label()
        Me.lblGolfer = New System.Windows.Forms.Label()
        Me.cboEventYears = New System.Windows.Forms.ComboBox()
        Me.cboGolfers = New System.Windows.Forms.ComboBox()
        Me.cboSponsors = New System.Windows.Forms.ComboBox()
        Me.cboSponsorType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPledge = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboPaymentType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkPaid = New System.Windows.Forms.CheckBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAddSponsor
        '
        Me.btnAddSponsor.Location = New System.Drawing.Point(29, 335)
        Me.btnAddSponsor.Name = "btnAddSponsor"
        Me.btnAddSponsor.Size = New System.Drawing.Size(150, 40)
        Me.btnAddSponsor.TabIndex = 0
        Me.btnAddSponsor.Text = "Add Golfer Sponsor"
        Me.btnAddSponsor.UseVisualStyleBackColor = True
        '
        'lblEventYear
        '
        Me.lblEventYear.AutoSize = True
        Me.lblEventYear.Location = New System.Drawing.Point(20, 48)
        Me.lblEventYear.Name = "lblEventYear"
        Me.lblEventYear.Size = New System.Drawing.Size(78, 17)
        Me.lblEventYear.TabIndex = 9
        Me.lblEventYear.Text = "Event Year"
        '
        'lblGolfer
        '
        Me.lblGolfer.AutoSize = True
        Me.lblGolfer.Location = New System.Drawing.Point(19, 43)
        Me.lblGolfer.Name = "lblGolfer"
        Me.lblGolfer.Size = New System.Drawing.Size(45, 17)
        Me.lblGolfer.TabIndex = 8
        Me.lblGolfer.Text = "Name"
        '
        'cboEventYears
        '
        Me.cboEventYears.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEventYears.FormattingEnabled = True
        Me.cboEventYears.Location = New System.Drawing.Point(126, 45)
        Me.cboEventYears.Name = "cboEventYears"
        Me.cboEventYears.Size = New System.Drawing.Size(158, 24)
        Me.cboEventYears.TabIndex = 7
        '
        'cboGolfers
        '
        Me.cboGolfers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGolfers.FormattingEnabled = True
        Me.cboGolfers.Location = New System.Drawing.Point(72, 40)
        Me.cboGolfers.Name = "cboGolfers"
        Me.cboGolfers.Size = New System.Drawing.Size(158, 24)
        Me.cboGolfers.TabIndex = 6
        '
        'cboSponsors
        '
        Me.cboSponsors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSponsors.FormattingEnabled = True
        Me.cboSponsors.Location = New System.Drawing.Point(126, 33)
        Me.cboSponsors.Name = "cboSponsors"
        Me.cboSponsors.Size = New System.Drawing.Size(158, 24)
        Me.cboSponsors.TabIndex = 10
        '
        'cboSponsorType
        '
        Me.cboSponsorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSponsorType.FormattingEnabled = True
        Me.cboSponsorType.Location = New System.Drawing.Point(126, 75)
        Me.cboSponsorType.Name = "cboSponsorType"
        Me.cboSponsorType.Size = New System.Drawing.Size(158, 24)
        Me.cboSponsorType.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 17)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Sponsor Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 17)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Name"
        '
        'txtPledge
        '
        Me.txtPledge.Location = New System.Drawing.Point(146, 31)
        Me.txtPledge.Name = "txtPledge"
        Me.txtPledge.Size = New System.Drawing.Size(100, 22)
        Me.txtPledge.TabIndex = 14
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboGolfers)
        Me.GroupBox1.Controls.Add(Me.lblGolfer)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(266, 91)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Golfer"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboEventYears)
        Me.GroupBox2.Controls.Add(Me.lblEventYear)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 180)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 104)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Event Year"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboSponsors)
        Me.GroupBox3.Controls.Add(Me.cboSponsorType)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(396, 31)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(336, 131)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Sponsor"
        '
        'cboPaymentType
        '
        Me.cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaymentType.FormattingEnabled = True
        Me.cboPaymentType.Location = New System.Drawing.Point(146, 74)
        Me.cboPaymentType.Name = "cboPaymentType"
        Me.cboPaymentType.Size = New System.Drawing.Size(158, 24)
        Me.cboPaymentType.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 17)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Payment Type"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.chkPaid)
        Me.GroupBox4.Controls.Add(Me.txtPledge)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.cboPaymentType)
        Me.GroupBox4.Location = New System.Drawing.Point(396, 197)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(336, 178)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Payment Information"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 17)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Pledge Amount"
        '
        'chkPaid
        '
        Me.chkPaid.AutoSize = True
        Me.chkPaid.Location = New System.Drawing.Point(19, 119)
        Me.chkPaid.Name = "chkPaid"
        Me.chkPaid.Size = New System.Drawing.Size(106, 21)
        Me.chkPaid.TabIndex = 17
        Me.chkPaid.Text = "Pledge Paid"
        Me.chkPaid.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(203, 335)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(150, 40)
        Me.btnExit.TabIndex = 19
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmAddGolferEventYearSponsor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnAddSponsor)
        Me.Name = "frmAddGolferEventYearSponsor"
        Me.Text = "frmAddGolferEventYearSponsor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAddSponsor As Button
    Friend WithEvents lblEventYear As Label
    Friend WithEvents lblGolfer As Label
    Friend WithEvents cboEventYears As ComboBox
    Friend WithEvents cboGolfers As ComboBox
    Friend WithEvents cboSponsors As ComboBox
    Friend WithEvents cboSponsorType As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPledge As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cboPaymentType As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chkPaid As CheckBox
    Friend WithEvents btnExit As Button
End Class
