Option Strict On
Option Explicit On

Public Class frmManageEvents

#Region "Button Functionality"
    ''**************************************************************************************
    ''OPEN frmAddEvent BUTTON
    ''**************************************************************************************
    Private Sub btnAddEvent_Click(sender As Object, e As EventArgs) Handles btnAddEvent.Click

        Dim AddEvent As New frmAddEvent ''Make a new form Object
        AddEvent.ShowDialog() ''Open New Form
        frmManageEvents_Load(sender, e) ''Reload frmGolfers to show changes

    End Sub
    ''**************************************************************************************
    ''DELETE BUTTON
    ''**************************************************************************************
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ''Declare Variable
        Dim Year As Integer

        ''Verify Data
        If Validation(Year) = True Then
            ''DELETE EVENT
            DeleteEvent()
            ''Reload Form
            frmManageEvents_Load(sender, e)
        End If

    End Sub
    ''**************************************************************************************
    ''Close BUTTON
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
    ''SUBROUTINE frmManageEvents_Load: Loads All Data
    ''**************************************************************************************
    Private Sub frmManageEvents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Events()
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

            OpenDB()

            strSelect = "SELECT intEventYearID, intEventYear FROM TEventYears"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            dt.Load(drSourceTable)

            cboEvents.ValueMember = "intEventYearID"
            cboEvents.DisplayMember = "intEventYear"
            cboEvents.DataSource = dt



            If cboEvents.Items.Count > 0 Then cboEvents.SelectedIndex = 0

            drSourceTable.Close()

            CloseDatabaseConnection()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try

    End Sub

    ''**************************************************************************************
    ''SUBROUTINE: cboEvents_SelectedIndexChanged: Loads Data into the text box
    ''**************************************************************************************
    Private Sub cboEvents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEvents.SelectedIndexChanged
        Try
            ''Declare Variables

            Dim strSelect As String = ""
            Dim strEvent As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            OpenDB() '' Open DataBase

            ''Set Up SQL Command Statement
            strSelect = "SELECT intEventYear From TEventYears Where intEventYearID = " & cboEvents.SelectedValue.ToString
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)

            ''inserts data into text box
            txtYearInput.Text = dt.Rows(0).Item(0).ToString
            ''Close DB Connection
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
    ''SUBROUTINE DeleteEvent: Deletes Events From TEvents
    ''**************************************************************************************
    Private Sub DeleteEvent()
        ''Declare Variables
        Dim cmdDeleteEvent As New OleDb.OleDbCommand()
        Dim intRowsAffected As Integer
        Dim intPKID As String
        Dim dt As DataTable = New DataTable
        Dim Result As DialogResult

        ''Use Selected Value from cboEvents for PrimaryKey ID
        intPKID = cboEvents.SelectedValue.ToString
        Try
            OpenDB() ''Open Database

            ''Message Box Prompt Warning User of Delete Taken Place
            Result = MessageBox.Show("Are you sure you want to Delete Event: " & cboEvents.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            cboEvents.BeginUpdate()
            ''Select Case for buttons on message box
            Select Case Result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes
                    ''If Yes Button Clicked SQL Command Statement is built
                    cmdDeleteEvent.CommandText = "Execute uspDeleteEvent '" & intPKID & "'"
                    cmdDeleteEvent.CommandType = CommandType.StoredProcedure
                    cmdDeleteEvent = New OleDb.OleDbCommand(cmdDeleteEvent.CommandText, m_conAdministrator)
                    intRowsAffected = cmdDeleteEvent.ExecuteNonQuery()

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
            cboEvents.EndUpdate()
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


#End Region

End Class