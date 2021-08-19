Option Strict On
Option Explicit On
Public Class frmManageSponsors

#Region "Button Functionality"
    ''**************************************************************************************
    ''Update BUTTON
    ''**************************************************************************************
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim strFirstName As String = ""
        Dim strLastNAme As String = ""
        Dim strAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZip As String = ""
        Dim strPhoneNumber As String = ""
        Dim strEmail As String = ""

        If Validation(strFirstName, strLastNAme, strAddress, strCity, strState, strZip, strPhoneNumber, strEmail) = True Then
            Update_Sponsor(strFirstName, strLastNAme, strAddress, strCity, strState, strZip, strPhoneNumber, strEmail)
            frmManageSponsors_Load(sender, e)

        End If
    End Sub
    ''**************************************************************************************
    ''OPEN Open frmAddSponsorBUTTON
    ''**************************************************************************************
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim NewSponsor As New frmAddSponsor
        NewSponsor.ShowDialog()
        frmManageSponsors_Load(sender, e)
    End Sub
    ''**************************************************************************************
    ''Delete BUTTON
    ''**************************************************************************************
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim strFirstName As String = ""
        Dim strLastNAme As String = ""
        Dim strAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZip As String = ""
        Dim strPhoneNumber As String = ""
        Dim strEmail As String = ""
        If Validation(strFirstName, strLastNAme, strAddress, strCity, strState, strZip, strPhoneNumber, strEmail) = True Then
            Delete_Sponsor()
            frmManageSponsors_Load(sender, e)
        End If
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
    Private Sub frmManageSponsors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Names()

    End Sub
    ''**************************************************************************************
    ''SUBROUTINE Load_Names: Loads Name Data
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
            OpenDB()


            strSelect = "SELECT intSponsorID, strLastName FROM TSponsors"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)


            ''Put data into cboNames
            cboNames.ValueMember = "intSponsorID"
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
    ''SUBROUTINE cboNames_SelectedIndexChanged: Loads when index is changed
    ''**************************************************************************************
    Private Sub cboNames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboNames.SelectedIndexChanged
        Try
            ''Declare Variables
            Dim strSelect As String = ""
            Dim strName As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable


            OpenDB() ''Open DataBase

            ''Create SQL Command Statement
            strSelect = "SELECT strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail FROM TSponsors Where intSponsorID = " & cboNames.SelectedValue.ToString
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
    ''SUBROUTINE Delete_Sponsor: Deletes Sponsor
    ''**************************************************************************************
    Private Sub Delete_Sponsor()
        Try
            ''Declare Variables
            Dim cmdDeleteSponsor As New OleDb.OleDbCommand()
            Dim intRowsAffected As Integer
            Dim intPKID As String
            Dim dt As DataTable = New DataTable
            Dim result As DialogResult

            intPKID = cboNames.SelectedValue.ToString

            ''Message Box Prompt Warning User of Delete Taken Place
            result = MessageBox.Show("Are you sure you want to Delete Sponsor: Last Name- " & cboNames.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            cboNames.BeginUpdate()
            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes

                    OpenDB() ''Open DataBase

                    ''If Yes Button Clicked SQL Command Statement is built
                    cmdDeleteSponsor.CommandText = "Execute uspDeleteSponsor '" & intPKID & "'"
                    cmdDeleteSponsor.CommandType = CommandType.StoredProcedure
                    cmdDeleteSponsor = New OleDb.OleDbCommand(cmdDeleteSponsor.CommandText, m_conAdministrator)
                    intRowsAffected = cmdDeleteSponsor.ExecuteNonQuery()

                    ''If any Rows have been affected then a prompt will let user know
                    ''If no rows have been affected prompt will let user notify user
                    If intRowsAffected > 0 Then
                        MessageBox.Show("Delete Successful")
                    Else
                        MessageBox.Show("Delete Failed")
                    End If
                    cboNames.EndUpdate()
                    ''Close DataBase
                    CloseDatabaseConnection()
            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub

    ''**************************************************************************************
    ''SUBROUTINE Update_Sponsor: Updates Sponsor
    ''**************************************************************************************
    Private Sub Update_Sponsor(ByVal FirstName As String, ByVal LastName As String, ByVal Address As String, ByVal City As String, ByVal State As String, ByVal Zip As String, ByVal PhoneNumber As String, ByVal Email As String)
        Try
            ''Declare Variables
            Dim cmdUpdateSponsor As New OleDb.OleDbCommand()
            Dim intRowsAffected As Integer
            Dim intPKID As String
            intPKID = cboNames.SelectedValue.ToString

            OpenDB() '' Open DataBase
            ''Set up SQL Command
            cmdUpdateSponsor.CommandText = "Execute uspUpdateSponsor '" & intPKID & "','" & FirstName & "','" & LastName & "','" & Address & "','" & City & "','" & State & "','" & Zip & "','" & PhoneNumber & "','" & Email & "'"
            cmdUpdateSponsor.CommandType = CommandType.StoredProcedure
            cmdUpdateSponsor = New OleDb.OleDbCommand(cmdUpdateSponsor.CommandText, m_conAdministrator)
            intRowsAffected = cmdUpdateSponsor.ExecuteNonQuery
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
    Function Validation(ByRef FirstName As String, ByRef LastName As String, ByRef Address As String, ByRef City As String, ByRef State As String, ByRef Zip As String, ByRef PhoneNumber As String, ByRef Email As String) As Boolean
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
            MessageBox.Show("Please Enter Sponsors First name")
            txtFirstName.BackColor = Color.Yellow
            txtFirstName.Focus()
            Return False
        End If

        If txtLastName.Text <> String.Empty Then
            LastName = txtLastName.Text
        Else
            MessageBox.Show("Please Enter Sponsors Last Name")
            txtLastName.BackColor = Color.Yellow
            txtLastName.Focus()
            Return False
        End If

        If txtAddress.Text <> String.Empty Then
            Address = txtAddress.Text
        Else
            MessageBox.Show("Please Enter Sponsors Address")
            txtAddress.BackColor = Color.Yellow
            txtAddress.Focus()
            Return False

        End If

        If txtCity.Text <> String.Empty Then
            City = txtCity.Text
        Else
            MessageBox.Show("Please Enter Sponsors City")
            txtCity.BackColor = Color.Yellow
            txtCity.Focus()
            Return False
        End If

        If txtState.Text <> String.Empty Then
            State = txtState.Text
        Else
            MessageBox.Show("Please Enter Sponsors State")
            txtState.BackColor = Color.Yellow
            txtState.Focus()
            Return False

        End If

        If txtZip.Text <> String.Empty Then
            Zip = txtZip.Text
        Else
            MessageBox.Show("Please Enter Sponsors Zip")
            txtZip.BackColor = Color.Yellow
            txtZip.Focus()
            Return False
        End If

        If txtEmail.Text <> String.Empty Then
            Email = txtEmail.Text
        Else
            MessageBox.Show("Please Enter Sponsors Email")
            txtEmail.BackColor = Color.Yellow
            txtEmail.Focus()
            Return False
        End If

        If txtPhoneNumber.Text <> String.Empty Then
            PhoneNumber = txtPhoneNumber.Text
        Else
            MessageBox.Show("Please Enter Sponsors Phone Number")
            txtPhoneNumber.BackColor = Color.Yellow
            txtPhoneNumber.Focus()
            Return False
        End If

        Return True


    End Function
#End Region
End Class