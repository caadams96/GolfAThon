Option Strict On
Option Explicit On

Public Class frmAddGolfer

#Region "Button Functionality"
    ''**************************************************************************************
    ''ADD NEW GOLFER BUTTON
    ''**************************************************************************************
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        ''Declare Variables
        Dim strFirstName As String = ""
        Dim strLastNAme As String = ""
        Dim strAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZip As String = ""
        Dim strPhoneNumber As String = ""
        Dim strEmail As String = ""
        Dim intShirtSizeID As String = ""
        Dim intGenderID As String = ""
        ''Verify Data
        If Validation(strFirstName, strLastNAme, strAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID) = True Then
            ''Update Golfer Data
            AddGolfer(strFirstName, strLastNAme, strAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID)
        End If
    End Sub
    ''**************************************************************************************
    ''EXIT PROGRAM BUTTON
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
    ''SUBROUTINE frmAddGolfers_Load: Loads all the information inside the cboBoxes
    ''*************************************************************************************
    Private Sub frmAddGolfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Load_ShirtSize()
            Load_Gender()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    ''**************************************************************************************
    ''SUBROUTINE Load_Gender: Loads Genders into cboGender
    ''**************************************************************************************
    Private Sub Load_Gender()
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            OpenDB()


            strSelect = "SELECT intGenderID, strGenderDesc FROM TGenders"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            dt.Load(drSourceTable)

            cboGender.ValueMember = "intGenderID"
            cboGender.DisplayMember = "strGenderDesc"
            cboGender.DataSource = dt


            If cboGender.Items.Count > 0 Then cboGender.SelectedIndex = 0

            drSourceTable.Close()

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    ''**************************************************************************************
    ''SUBROUTINE Load_ShirtSize: Loads ShirtsSize into cboShirtSize
    ''**************************************************************************************
    Private Sub Load_ShirtSize()

        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dt As DataTable = New DataTable

        OpenDB()
        strSelect = "SELECT intShirtSizeID, strShirtSizeDesc FROM TShirtSizes"

        cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
        drSourceTable = cmdSelect.ExecuteReader

        dt.Load(drSourceTable)

        cboShirtSize.ValueMember = "intShirtSizeID"
        cboShirtSize.DisplayMember = "strShirtSizeDesc"
        cboShirtSize.DataSource = dt

        drSourceTable.Close()

        CloseDatabaseConnection()

    End Sub
#End Region

#Region "Stored Procedures"
    ''**************************************************************************************
    ''SUBROUTINE AddGolfer: Adds New Golfer inside DataBase
    ''**************************************************************************************

    Private Sub AddGolfer(ByVal FirstName As String, ByVal LastName As String, ByVal Address As String, ByVal City As String, ByVal State As String, ByVal Zip As String, ByVal PhoneNumber As String, ByVal Email As String, ByVal GenderID As String, ByVal ShirtSizeID As String)
        Try
            ''Declare Variables
            Dim cmdAddGolfer As New OleDb.OleDbCommand()
            Dim intRowsAffected As Integer
            Dim intPKID As Integer
            OpenDB() '' Open DataBase
            ''Set up SQL Command Statement
            cmdAddGolfer.CommandText = "EXECUTE uspAddGolfer '" & intPKID & "','" & FirstName & "','" & LastName & "','" & Address & "','" & City & "','" & State & "','" & Zip & "','" & PhoneNumber & "','" & Email & "','" & GenderID & "','" & ShirtSizeID & "'"
            cmdAddGolfer.CommandType = CommandType.StoredProcedure
            cmdAddGolfer = New OleDb.OleDbCommand(cmdAddGolfer.CommandText, m_conAdministrator)
            intRowsAffected = cmdAddGolfer.ExecuteNonQuery()
            CloseDatabaseConnection() ''Close DataBase

            ''If any Rows have been affected then a prompt will let user know
            ''If no rows have been affected prompt will let user notify user
            If intRowsAffected > 0 Then
                MessageBox.Show("Insert Successful Golfer " & LastName & " Has Been Added .")
            Else
                MessageBox.Show("Insert failed")
            End If
            Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub
#End Region

#Region "Validation"

    ''**************************************************************************************
    ''FUNCTION Validation: validates that all textboxes have information in them before an action takes place
    ''**************************************************************************************
    Function Validation(ByRef FirstName As String, ByRef LastName As String, ByRef Address As String, ByRef City As String, ByRef State As String, ByRef Zip As String, ByRef PhoneNumber As String, ByRef Email As String, ByRef ShirtSizeID As String, ByRef GenderID As String) As Boolean
        ''Turns all textBoxes BackColor to White
        For Each cntrl As Control In Controls
            If TypeOf cntrl Is TextBox Then
                cntrl.BackColor = Color.White
            End If
        Next

        '' Multiple If Statements to make no text box is empty
        '' If Text Boxes are not empty variables will get assigned the data from that textbox
        If txtFirstName.Text <> String.Empty Then
            FirstName = txtFirstName.Text
        Else
            MessageBox.Show("Please Enter Golfers First name")
            txtFirstName.BackColor = Color.Yellow
            txtFirstName.Focus()
            Return False
        End If

        If txtLastName.Text <> String.Empty Then
            LastName = txtLastName.Text
        Else
            MessageBox.Show("Please Enter Golfers Last Name")
            txtLastName.BackColor = Color.Yellow
            txtLastName.Focus()
            Return False
        End If

        If txtAddress.Text <> String.Empty Then
            Address = txtAddress.Text
        Else
            MessageBox.Show("Please Enter Golfers Address")
            txtAddress.BackColor = Color.Yellow
            txtAddress.Focus()
            Return False

        End If

        If txtCity.Text <> String.Empty Then
            City = txtCity.Text
        Else
            MessageBox.Show("Please Enter Golfers City")
            txtCity.BackColor = Color.Yellow
            txtCity.Focus()
            Return False
        End If

        If txtState.Text <> String.Empty Then
            State = txtState.Text
        Else
            MessageBox.Show("Please Enter Golfers State")
            txtState.BackColor = Color.Yellow
            txtState.Focus()
            Return False

        End If

        If txtZip.Text <> String.Empty Then
            Zip = txtZip.Text
        Else
            MessageBox.Show("Please Enter Golfers Zip")
            txtZip.BackColor = Color.Yellow
            txtZip.Focus()
            Return False
        End If

        If txtEmail.Text <> String.Empty Then
            Email = txtEmail.Text
        Else
            MessageBox.Show("Please Enter Golfers Email")
            txtEmail.BackColor = Color.Yellow
            txtEmail.Focus()
            Return False
        End If

        If txtPhoneNumber.Text <> String.Empty Then
            PhoneNumber = txtPhoneNumber.Text
        Else
            MessageBox.Show("Please Enter Golfers Phone Number")
            txtPhoneNumber.BackColor = Color.Yellow
            txtPhoneNumber.Focus()
            Return False
        End If

        ''Adds 1 to selected index to make the selected index align with the SQL Rows  
        GenderID = cboGender.SelectedValue.ToString

        ShirtSizeID = cboShirtSize.SelectedValue.ToString

        Return True


    End Function



#End Region

End Class