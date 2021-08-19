Option Strict On
Option Explicit On

Public Class frmAddGolferEventYearSponsor
#Region "Button Functionality"
    ''**************************************************************************************
    ''OPEN ADD SPONSOR BUTTON
    ''**************************************************************************************
    Private Sub btnAddSponsor_Click(sender As Object, e As EventArgs) Handles btnAddSponsor.Click
        Dim Pledge As Double

        If ValidateEventYear() = True Then
            MessageBox.Show("Golfer Had No Available Events To Add Sponsor To", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        Else
            If Validation(Pledge) = True Then
                AddSponsor(Pledge)
            End If
        End If



    End Sub
    ''**************************************************************************************
    ''EXIT BUTTON
    ''**************************************************************************************

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
#End Region

#Region "OpenDB SUBROUTINE"
    ''**************************************************************************************
    ''SUBROUTINE OpenDB: Opens Connection to Database
    ''**************************************************************************************
    Private Sub OpenDB()
        ''Validates that The function does not return False
        ''If True DB Connection Succeeded
        ''Function OpenDatabaseConnectionSQLServer() can be found in modDatebaseUtilities
        If OpenDatabaseConnectionSQLServer() = False Then
            ''If failed warn user
            MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' Close 
            Me.Close()

        End If


    End Sub
#End Region

#Region "Load Data"
    ''**************************************************************************************
    ''SUBROUTINE frmAddGolferEventYearSponsor_Load: Loads All Data
    ''**************************************************************************************
    Private Sub frmAddGolferEventYearSponsor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Golfers()
        Load_Events()
        Load_Sponsors()
        Load_SponsorType()
        Load_PaymentType()
    End Sub
    ''**************************************************************************************
    ''SUBROUTINE cboGolfers_SelectedIndexChanged: Refreshes Event Combo Box if cboGolfers index is changed
    ''**************************************************************************************
    Private Sub cboGolfers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGolfers.SelectedIndexChanged
        Load_Events()
    End Sub
    ''**************************************************************************************
    ''SUBROUTINE Load_Sponsors(): Load Sponsors
    ''**************************************************************************************
    Private Sub Load_Sponsors()
        Try
            ''Declare Variables
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            ''Looks for TextBox and clears them of any data
            For Each cntrl As Control In Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = String.Empty
                End If
            Next

            cboSponsors.BeginUpdate()
            OpenDB()


            strSelect = "SELECT intSponsorID, strLastName FROM TSponsors"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)


            ''Put data into cboNames
            cboSponsors.ValueMember = "intSponsorID"
            cboSponsors.DisplayMember = "strLastName"
            cboSponsors.DataSource = dt

            cboSponsors.EndUpdate()
            ''Close Connection to data
            drSourceTable.Close()
            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub
    ''**************************************************************************************
    ''SUBROUTINE Load_Golfers(): Load Golfer
    ''**************************************************************************************
    Private Sub Load_Golfers()
        Try
            ''Declare Variables
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            ''Looks for TextBox and clears them of any data
            For Each cntrl As Control In Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = String.Empty
                End If
            Next

            cboGolfers.BeginUpdate()

            OpenDB() ''Open DB

            ''Set Up SQL Command Statement
            strSelect = "SELECT intGolferID, strLastName FROM TGolfers"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)


            ''Put data into cboNames
            cboGolfers.ValueMember = "intGolferID"
            cboGolfers.DisplayMember = "strLastName"
            cboGolfers.DataSource = dt

            cboGolfers.EndUpdate()
            ''Close Connection to data
            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub

    ''**************************************************************************************
    ''SUBROUTINE Load_Events: Loads Event Data
    ''**************************************************************************************
    Private Sub Load_Events()
        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            Dim GolferID As String = cboGolfers.SelectedValue.ToString

            OpenDB()

            strSelect = "SELECT * FROM vGolferEvents WHERE GolferID = " & GolferID

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            dt.Load(drSourceTable)

            cboEventYears.ValueMember = "intEventYearID"
            cboEventYears.DisplayMember = "intEventYear"
            cboEventYears.DataSource = dt



            If cboEventYears.Items.Count > 0 Then cboEventYears.SelectedIndex = 0

            drSourceTable.Close()

            CloseDatabaseConnection()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub
    ''**************************************************************************************
    ''SUBROUTINE Load_SponsorType: Loads Data
    ''**************************************************************************************
    Private Sub Load_SponsorType()
        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            OpenDB()

            strSelect = "SELECT intSponsorTypeID, strSponsorTypeDesc From TSponsorTypes"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)
            cboSponsorType.ValueMember = "intSponsorType"
            cboSponsorType.DisplayMember = "strSponsorTypeDesc"
            cboSponsorType.DataSource = dt


            If cboSponsorType.Items.Count > 0 Then cboSponsorType.SelectedIndex = 0

            drSourceTable.Close()

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub
    ''**************************************************************************************
    ''SUBROUTINE Payment_Events: Loads Data
    ''**************************************************************************************
    Private Sub Load_PaymentType()
        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            OpenDB()
            strSelect = "SELECT intPaymentTypeID, strPaymentTypeDesc From TPaymentTypes"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)
            cboPaymentType.ValueMember = "intPaymentTypeID"
            cboPaymentType.DisplayMember = "strPaymentTypeDesc"
            cboPaymentType.DataSource = dt

            If cboPaymentType.Items.Count > 0 Then cboPaymentType.SelectedIndex = 0

            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try

    End Sub


#End Region

#Region "Stored Procedures"
    ''**************************************************************************************
    ''SUBROUTINE AddSponsor: Adds Sponsor 
    ''**************************************************************************************
    Private Sub AddSponsor(ByVal Pledge As Double)
        Try
            ''Declare Variables
            Dim cmdAddSponsor As New OleDb.OleDbCommand()
            Dim intRowsAffected As Integer
            Dim intPKID As Integer
            Dim Golfer As Integer = cboGolfers.SelectedIndex + 1
            Dim Sponsor As Integer = cboSponsors.SelectedIndex + 1
            Dim EventYear As Integer = CInt(cboEventYears.SelectedValue.ToString) ''View doesnt work with SelectedIndex + 1
            Dim SponsorType As Integer = cboSponsorType.SelectedIndex + 1
            Dim PaymentType As Integer = cboPaymentType.SelectedIndex + 1

            '' MessageBox.Show($" Golfer ID {Golfer} , SponsorID {Sponsor}, YearID {EventYear}, Pledge {Pledge} , SponsorType {SponsorType}, PaymentType{PaymentType}")
            Dim Paid As Integer
            If chkPaid.Checked Then
                Paid = 1
            Else
                Paid = 0
            End If


            OpenDB() '' Open DataBase
            ''Set up SQL Command Statement
            cmdAddSponsor.CommandText = "EXECUTE uspAddGolferEventYearSponsor'" & intPKID & "','" & Golfer & "','" & EventYear & "','" & Sponsor & "','" & Pledge & "','" & SponsorType & "','" & PaymentType & "','" & Paid & "'"
            cmdAddSponsor.CommandType = CommandType.StoredProcedure
            cmdAddSponsor = New OleDb.OleDbCommand(cmdAddSponsor.CommandText, m_conAdministrator)
            intRowsAffected = cmdAddSponsor.ExecuteNonQuery()
            CloseDatabaseConnection() ''Close DataBase

            If intRowsAffected > 0 Then
                MessageBox.Show("Sponsor Was Added")
            Else
                MessageBox.Show("Insert failed")
            End If
            Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
#End Region

#Region "Validation"
    ''**************************************************************************************
    ''FUNCTION Validation: Validates if the text box is empty
    ''**************************************************************************************
    Private Function Validation(ByRef Pledge As Double) As Boolean
        If txtPledge.Text <> String.Empty Then
            If IsNumeric(txtPledge.Text) Then
                Pledge = CDbl(txtPledge.Text)
            Else
                MessageBox.Show("Please Only Enter a Number")
                txtPledge.BackColor = Color.Yellow
                txtPledge.Focus()
                Return False
            End If
        Else
            MessageBox.Show("Please Enter Sponsors Pledge")
            txtPledge.BackColor = Color.Yellow
            txtPledge.Focus()
            Return False

        End If
        Return True

    End Function
    ''**************************************************************************************
    ''Function ValidateEventYear: validates if cboEventYears is Empty
    ''**************************************************************************************
    Private Function ValidateEventYear() As Boolean
        If (String.IsNullOrEmpty(cboEventYears.Text)) Then
            Return True
        End If
        Return False
    End Function




#End Region
End Class