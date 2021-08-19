Option Strict On
Option Explicit On

Public Class frmManageGolfers

#Region "Button Functionality"
    ''**************************************************************************************
    ''UPDATE BUTTON
    ''**************************************************************************************
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ''Declare Variables

        Dim strFirstName As String = ""
        Dim strLastNAme As String = ""
        Dim strAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZip As String = ""
        Dim strPhoneNumber As String = ""
        Dim strEmail As String = ""
        Dim intShirtSizeID As Integer
        Dim intGenderID As Integer

        ''Verify Data
        If Validation(strFirstName, strLastName, strAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID) = True Then
            ''Update Golfer Data
            Update_Golfer(strFirstName, strLastNAme, strAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID)
            ''Reload Form
            frmManageGolfers_Load(sender, e)
        End If
    End Sub
    ''**************************************************************************************
    ''NEW GOLFER BUTTON
    ''**************************************************************************************
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim AddGolfer As New frmAddGolfer  ''Make a new form Object
        AddGolfer.ShowDialog()  ''Open New Form
        frmManageGolfers_Load(sender, e)  ''Reload frmGolfers to show changes


    End Sub
    ''**************************************************************************************
    ''DELETE GOLFER BUTTON
    ''**************************************************************************************
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim strFirstName, strLastName, strAddress, strCity, strState, strZip, strPhoneNumber, strEmail As String

        ''declare variable
        'Dim strFirstName As String = ""
        'Dim strLastNAme As String = ""
        'Dim strAddress As String = ""
        'Dim strCity As String = ""
        'Dim strState As String = ""
        'Dim strZip As String = ""
        'Dim strPhoneNumber As String = ""
        'Dim strEmail As String = ""
        Dim intShirtSizeID As Integer
        Dim intGenderID As Integer

        ''Verify Data
        If Validation(strFirstName, strLastNAme, strAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeID, intGenderID) = True Then
            DeleteGolfer() ''Delete Golfer Data
            frmManageGolfers_Load(sender, e) ''Reload frmGolfers to show changes
        End If

    End Sub
    ''**************************************************************************************
    ''EXIT PROGRAM BUTTON
    ''**************************************************************************************
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close() ''Close Program
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
    ''SUBROUTINE frmGolfers_Load: Loads all the Data
    ''**************************************************************************************
    Private Sub frmManageGolfers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Gender()
        Load_ShirtSize()
        Load_Names()
    End Sub
    ''**************************************************************************************
    ''SUBROUTINE Load_Names: Loads Names into cboNames
    ''**************************************************************************************
    Private Sub Load_Names()
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

            cboNames.BeginUpdate()

            OpenDB() ''Open DB

            ''Set Up SQL Command Statement
            strSelect = "SELECT intGolferID, strLastName FROM TGolfers"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)


            ''Put data into cboNames
            cboNames.ValueMember = "intGolferID"
            cboNames.DisplayMember = "strLastName"
            cboNames.DataSource = dt

            cboNames.EndUpdate()
            ''Close Connection to data
            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub

    ''**************************************************************************************
    ''SUBROUTINE Load_Gender: Loads Genders into cboGender
    ''**************************************************************************************
    Private Sub Load_Gender()
        Try
            ''Declare Variables

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            OpenDB() ''Open DB

            ''Set Up SQL Command Statement
            strSelect = "SELECT intGenderID, strGenderDesc FROM TGenders"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)

            cboGender.BeginUpdate()
            ''Put data into cboGender
            cboGender.ValueMember = "intGenderID"
            cboGender.DisplayMember = "strGenderDesc"
            cboGender.DataSource = dt

            cboGender.EndUpdate()
            ''Close Connection to database
            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub
    ''**************************************************************************************
    ''SUBROUTINE Load_ShirtSize: Loads ShirtsSize into cboShirtSize
    ''**************************************************************************************
    Private Sub Load_ShirtSize()
        ''Declare Variables
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dt As DataTable = New DataTable

        OpenDB() ''Open DB

        ''Set Up SQL Command Statement
        strSelect = "SELECT intShirtSizeID, strShirtSizeDesc FROM TShirtSizes"
        cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
        drSourceTable = cmdSelect.ExecuteReader
        dt.Load(drSourceTable)
        cboShirtSize.BeginUpdate()
        ''Insert Date Into cboShirtSize
        cboShirtSize.ValueMember = "intShirtSizeID"
        cboShirtSize.DisplayMember = "strShirtSizeDesc"
        cboShirtSize.DataSource = dt

        cboShirtSize.EndUpdate()
        ''Close Connection to DB
        drSourceTable.Close()
        CloseDatabaseConnection()

    End Sub
    ''**************************************************************************************
    ''SUBROUTINE cboNames_SelectedIndexChanged: Inserts information from database into textboxes according to selected index of cboNames
    ''**************************************************************************************
    Private Sub cboNames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboNames.SelectedIndexChanged
        Try
            ''Declare Variables
            Dim strSelect As String = ""
            Dim strName As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable
            Dim intGender As Integer
            Dim intShirtSize As Integer

            OpenDB() ''Open DataBase

            ''Create SQL Command Statement
            strSelect = "SELECT strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intGenderID, intShirtSizeID FROM TGolfers Where intGolferID = " & cboNames.SelectedValue.ToString
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)

            ''Insert data into textboxes & comboBoxes

            txtFirstName.Text = dt.Rows(0).Item(0).ToString
            txtLastName.Text = dt.Rows(0).Item(1).ToString
            txtAddress.Text = dt.Rows(0).Item(2).ToString
            txtCity.Text = dt.Rows(0).Item(3).ToString
            txtState.Text = dt.Rows(0).Item(4).ToString
            txtZip.Text = dt.Rows(0).Item(5).ToString
            txtPhoneNumber.Text = dt.Rows(0).Item(6).ToString
            txtEmail.Text = dt.Rows(0).Item(7).ToString

            intGender = CInt(dt.Rows(0).Item(8).ToString)
            cboGender.SelectedValue = intGender

            intShirtSize = CInt(dt.Rows(0).Item(9).ToString)
            cboShirtSize.SelectedValue = intShirtSize

            ''Close Connection
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
    ''SUBROUTINE DeleteGolfer: Deletes Golfer Data inside DataBase
    ''**************************************************************************************
    Private Sub DeleteGolfer()
        Try
            ''Declare Variables
            Dim cmdDeleteGolfer As New OleDb.OleDbCommand()
            Dim intRowsAffected As Integer
            Dim intPKID As String
            Dim dt As DataTable = New DataTable
            Dim result As DialogResult
            ''Use Selected Value from cboNames for PrimaryKey ID
            intPKID = cboNames.SelectedValue.ToString

            ''Message Box Prompt Warning User of Delete Taken Place
            result = MessageBox.Show("Are you sure you want to Delete Golfer: Last Name- " & cboNames.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            cboNames.BeginUpdate()
            ''Select Case for buttons on message box
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes

                    OpenDB() ''Open DataBase

                    ''If Yes Button Clicked SQL Command Statement is built
                    cmdDeleteGolfer.CommandText = "Execute uspDeleteGolfer '" & intPKID & "'"
                    cmdDeleteGolfer.CommandType = CommandType.StoredProcedure
                    cmdDeleteGolfer = New OleDb.OleDbCommand(cmdDeleteGolfer.CommandText, m_conAdministrator)
                    intRowsAffected = cmdDeleteGolfer.ExecuteNonQuery()

                    ''If any Rows have been affected then a prompt will let user know
                    ''If no rows have been affected prompt will let user notify user
                    If intRowsAffected > 0 Then
                        MessageBox.Show("Delete Successful")
                    Else
                        MessageBox.Show("Delete Failed")
                    End If

                    ''Close DataBase
                    CloseDatabaseConnection()

            End Select

            cboNames.EndUpdate()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub

    ''**************************************************************************************
    ''SUBROUTINE Update_Golfer: Updates Golfer Data inside DataBase
    ''**************************************************************************************
    Private Sub Update_Golfer(ByVal FirstName As String, ByVal LastName As String, ByVal Address As String, ByVal City As String, ByVal State As String, ByVal Zip As String, ByVal PhoneNumber As String, ByVal Email As String, ByVal ShirtSizeID As Integer, ByVal GenderID As Integer)


        Try
            ''Declare Variables
            Dim cmdUpdateGolfer As New OleDb.OleDbCommand()
            Dim intRowsAffected As Integer
            Dim intPKID As String
            intPKID = cboNames.SelectedValue.ToString

            OpenDB() '' Open DataBase
            ''Set up SQL Command
            cmdUpdateGolfer.CommandText = "Execute uspUpdateGolfer '" & intPKID & "','" & FirstName & "','" & LastName & "','" & Address & "','" & City & "','" & State & "','" & Zip & "','" & PhoneNumber & "','" & Email & "','" & ShirtSizeID & "','" & GenderID & "'"
            cmdUpdateGolfer.CommandType = CommandType.StoredProcedure
            cmdUpdateGolfer = New OleDb.OleDbCommand(cmdUpdateGolfer.CommandText, m_conAdministrator)
            intRowsAffected = cmdUpdateGolfer.ExecuteNonQuery
            CloseDatabaseConnection() '' Close DataBase

            ''If any Rows have been affected then a prompt will let user know
            ''If no rows have been affected prompt will let user notify user
            If intRowsAffected > 0 Then
                MessageBox.Show("Update Was Successful")
            Else
                MessageBox.Show("Update Failed")
            End If

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
    Function Validation(ByRef FirstName As String, ByRef LastName As String, ByRef Address As String, ByRef City As String, ByRef State As String, ByRef Zip As String, ByRef PhoneNumber As String, ByRef Email As String, ByRef ShirtSizeID As Integer, ByRef GenderID As Integer) As Boolean
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
        GenderID = cboGender.SelectedIndex + 1

        ShirtSizeID = cboShirtSize.SelectedIndex + 1

        Return True


    End Function

#End Region

End Class