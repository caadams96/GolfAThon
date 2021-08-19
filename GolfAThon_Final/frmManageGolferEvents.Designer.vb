<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageGolferEvents
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCurrentEvent = New System.Windows.Forms.ComboBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstAvailableGolfers = New System.Windows.Forms.ListBox()
        Me.lstEventGolfers = New System.Windows.Forms.ListBox()
        Me.btnDropGolfer = New System.Windows.Forms.Button()
        Me.btnAddGolfer = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(537, 90)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 17)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Available Golfers"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(81, 90)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 17)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Current Event Golfers"
        '
        'cboCurrentEvent
        '
        Me.cboCurrentEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCurrentEvent.FormattingEnabled = True
        Me.cboCurrentEvent.Location = New System.Drawing.Point(296, 25)
        Me.cboCurrentEvent.Margin = New System.Windows.Forms.Padding(4)
        Me.cboCurrentEvent.Name = "cboCurrentEvent"
        Me.cboCurrentEvent.Size = New System.Drawing.Size(200, 24)
        Me.cboCurrentEvent.TabIndex = 16
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(281, 286)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(215, 28)
        Me.btnExit.TabIndex = 15
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(178, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 17)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Current Event"
        '
        'lstAvailableGolfers
        '
        Me.lstAvailableGolfers.FormattingEnabled = True
        Me.lstAvailableGolfers.ItemHeight = 16
        Me.lstAvailableGolfers.Location = New System.Drawing.Point(540, 129)
        Me.lstAvailableGolfers.Margin = New System.Windows.Forms.Padding(4)
        Me.lstAvailableGolfers.Name = "lstAvailableGolfers"
        Me.lstAvailableGolfers.Size = New System.Drawing.Size(159, 180)
        Me.lstAvailableGolfers.TabIndex = 13
        '
        'lstEventGolfers
        '
        Me.lstEventGolfers.FormattingEnabled = True
        Me.lstEventGolfers.ItemHeight = 16
        Me.lstEventGolfers.Location = New System.Drawing.Point(84, 129)
        Me.lstEventGolfers.Margin = New System.Windows.Forms.Padding(4)
        Me.lstEventGolfers.Name = "lstEventGolfers"
        Me.lstEventGolfers.Size = New System.Drawing.Size(159, 180)
        Me.lstEventGolfers.TabIndex = 12
        '
        'btnDropGolfer
        '
        Me.btnDropGolfer.Location = New System.Drawing.Point(281, 215)
        Me.btnDropGolfer.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDropGolfer.Name = "btnDropGolfer"
        Me.btnDropGolfer.Size = New System.Drawing.Size(215, 28)
        Me.btnDropGolfer.TabIndex = 11
        Me.btnDropGolfer.Text = "Drop Golfer From Event →"
        Me.btnDropGolfer.UseVisualStyleBackColor = True
        '
        'btnAddGolfer
        '
        Me.btnAddGolfer.Location = New System.Drawing.Point(281, 129)
        Me.btnAddGolfer.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddGolfer.Name = "btnAddGolfer"
        Me.btnAddGolfer.Size = New System.Drawing.Size(215, 28)
        Me.btnAddGolfer.TabIndex = 10
        Me.btnAddGolfer.Text = "‎← Add Golfer To Event"
        Me.btnAddGolfer.UseVisualStyleBackColor = True
        '
        'frmManageGolferEvents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 357)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCurrentEvent)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstAvailableGolfers)
        Me.Controls.Add(Me.lstEventGolfers)
        Me.Controls.Add(Me.btnDropGolfer)
        Me.Controls.Add(Me.btnAddGolfer)
        Me.Name = "frmManageGolferEvents"
        Me.Text = "Manage GolferEvents"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboCurrentEvent As ComboBox
    Friend WithEvents btnExit As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lstAvailableGolfers As ListBox
    Friend WithEvents lstEventGolfers As ListBox
    Friend WithEvents btnDropGolfer As Button
    Friend WithEvents btnAddGolfer As Button
End Class
