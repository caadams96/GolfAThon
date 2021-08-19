Option Strict On
Option Explicit On
Public Class frmAddSponsor

#Region "Button Functionality"
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim strFirstName As String = ""
        Dim strLastNAme As String = ""
        Dim strAddress As String = ""
        Dim strCity As String = ""
        Dim strState As String = ""
        Dim strZip As String = ""
        Dim strPhoneNumber As String = ""
        Dim strEmail As String = ""
        If Validation(strFirstName, strLastNAme, strAddress, strCity, strState, strZip, strPhoneNumber, strEmail) = True Then
            Add_Sponsor(strFirstName, strLastNAme, strAddress, strCity, strState, strZip, strPhoneNumber, strEmail)
        End If
    End Sub


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
    Private Sub frmAddSponsor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



#End Region

#Region "Stored Procedures"
    ''**************************************************************************************
    ''SUBROUTINE Add_Sponsor: Adds New Sponsor inside DataBase
    ''**************************************************************************************

    Private Sub Add_Sponsor(ByVal FirstName As String, ByVal LastName As String, ByVal Address As String, ByVal City As String, ByVal State As String, ByVal Zip As String, ByVal PhoneNumber As String, ByVal Email As String)
        ''Declare Variables
        Dim cmdAddSponsor As New OleDb.OleDbCommand()
        Dim intRowsAffected As Integer
        Dim intPKID As Integer


        Try
            OpenDB() '' Open DataBase
            ''Set up SQL Command Statement
            cmdAddSponsor.CommandText = "EXECUTE uspAddSponsor '" & intPKID & "','" & FirstName & "','" & LastName & "','" & Address & "','" & City & "','" & State & "','" & Zip & "','" & PhoneNumber & "','" & Email & "'"
            cmdAddSponsor.CommandType = CommandType.StoredProcedure
            cmdAddSponsor = New OleDb.OleDbCommand(cmdAddSponsor.CommandText, m_conAdministrator)
            intRowsAffected = cmdAddSponsor.ExecuteNonQuery()
            CloseDatabaseConnection() ''Close DataBase

            ''If any Rows have been affected then a prompt will let user know
            ''If no rows have been affected prompt will let user notify user
            If intRowsAffected > 0 Then
                MessageBox.Show("Insert Succesful Sponsor " & LastName & " Has Been Added .")
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