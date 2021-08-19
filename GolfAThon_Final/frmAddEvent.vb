Option Strict On
Option Explicit On

Public Class frmAddEvent
#Region "Button Functionality"
    ''**************************************************************************************
    ''ADD EVENT BUTTON
    ''**************************************************************************************
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ''Declare Variable
        Dim Year As Integer
        ''Verify Data
        If Validation(Year) Then
            ''ADD EVENT
            AddEvent(Year)
        End If
    End Sub
    ''**************************************************************************************
    ''CLOSE BUTTON
    ''**************************************************************************************
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
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

#Region "Stored Procedures"
    ''**************************************************************************************
    ''SUBROUTINE AddEvent: Adds Event to TEvents
    ''**************************************************************************************
    Private Sub AddEvent(ByVal Year As Integer)
        ''Declare Variables
        Dim cmdAddEvent As New OleDb.OleDbCommand()
        Dim intRowsAffected As Integer
        Dim intPKID As Integer

        Try
            OpenDB() ''Open Database

            ''Set up SQL Command
            cmdAddEvent.CommandText = "EXECUTE uspAddEvent '" & intPKID & "','" & Year & "'"
            cmdAddEvent.CommandType = CommandType.StoredProcedure
            cmdAddEvent = New OleDb.OleDbCommand(cmdAddEvent.CommandText, m_conAdministrator)
            intRowsAffected = cmdAddEvent.ExecuteNonQuery()

            ''If any Rows have been affected then a prompt will let user know
            ''If no rows have been affected prompt will let user notify user
            If intRowsAffected > 0 Then
                MessageBox.Show("Insert Succesful EventYear " & Year & " Has Been Added")
            Else
                MessageBox.Show("Insert failed")

            End If


            CloseDatabaseConnection() ''Close Database 
            Close() ''Close form

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try

    End Sub
#End Region

#Region "Validation"
    ''**************************************************************************************
    ''FUNCTION VALIDATION 
    ''**************************************************************************************
    Public Function Validation(ByRef Year As Integer) As Boolean
        ''Set textbox backcolor to white
        txtYearInput.BackColor = Color.White
        ''If the textbox is not empty then the variable will get assigned
        ''If the textbox is empty error prompt will occur
        If txtYearInput.Text <> String.Empty Then
            Year = CInt(txtYearInput.Text)
        Else
            MessageBox.Show("Please Enter Event Year")
            txtYearInput.BackColor = Color.Yellow
            txtYearInput.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub frmAddEvent_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
#End Region

End Class