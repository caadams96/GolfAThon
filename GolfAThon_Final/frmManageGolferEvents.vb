Option Strict On
Option Explicit On

Public Class frmManageGolferEvents

#Region "Button Functionality"
    ''**************************************************************************************
    ''ADD Golfer To Event BUTTON
    ''**************************************************************************************
    Private Sub btnAddGolfer_Click(sender As Object, e As EventArgs) Handles btnAddGolfer.Click
        Add_GolferEvent()
        frmManageGolferEvents_Load(sender, e)
    End Sub
    ''**************************************************************************************
    ''DROP Golfer Drop Event BUTTON
    ''**************************************************************************************
    Private Sub btnDropGolfer_Click(sender As Object, e As EventArgs) Handles btnDropGolfer.Click
        Delete_EventGolfer()
        frmManageGolferEvents_Load(sender, e)

    End Sub
    ''**************************************************************************************
    ''CLOSE BUTTON
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
    ''SUBROUTINE frmManageGolferEvents_Load: Loads All Data
    ''**************************************************************************************
    Private Sub frmManageGolferEvents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_CurrentEventYear()
        Load_AvailableGolfers()
        Load_CurrentEventGolfers()
    End Sub
    ''**************************************************************************************
    ''SUBROUTINE Load_CurrentEventYear: Loads Current Event Year
    ''**************************************************************************************
    Private Sub Load_CurrentEventYear()
        Try
            ''Declare Variables
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable
            ''Open Database
            OpenDB()
            ''Create SQL SELECT STATMENT
            strSelect = "Select * From vCurrentEventYear"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)

            cboCurrentEvent.BeginUpdate()

            cboCurrentEvent.ValueMember = "intEventYearID"
            cboCurrentEvent.DisplayMember = "intEventYear"
            cboCurrentEvent.DataSource = dt

            ''End combobox update and close DB connection
            cboCurrentEvent.EndUpdate()
            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub
    ''**************************************************************************************
    ''SUBROUTINE Load_AvailableGolfers: Loads Availble Golfers
    ''**************************************************************************************
    Private Sub Load_AvailableGolfers()
        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            OpenDB()

            strSelect = "Select * From vAvailableGolfers"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)

            lstAvailableGolfers.ValueMember = "intGolferID"
            lstAvailableGolfers.DisplayMember = "AvailableGolfers"
            lstAvailableGolfers.DataSource = dt

            lstAvailableGolfers.EndUpdate()
            drSourceTable.Close()
            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub
    ''**************************************************************************************
    ''SUBROUTINE Load_CurrentEventGolfers: Loads Current Event Golfers
    ''**************************************************************************************
    Private Sub Load_CurrentEventGolfers()
        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            OpenDB()

            strSelect = "Select * From vCurrentEventGolfers"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)

            lstEventGolfers.ValueMember = "intGolferID"
            lstEventGolfers.DisplayMember = "CurrentGolfers"
            lstEventGolfers.DataSource = dt

            lstEventGolfers.EndUpdate()
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
    ''SUBROUTINE Add_GolferEvent: ADD Golfer To TGolferEventYears
    ''**************************************************************************************
    Private Sub Add_GolferEvent()
        Try
            ''Declare Variables
            Dim intPKID As Integer
            Dim cmdAddEventGolfer As New OleDb.OleDbCommand()
            Dim intRowsAffected As Integer
            Dim SelectedAvailableGolfer As String
            Dim SelectedEventYear As String

            SelectedAvailableGolfer = lstAvailableGolfers.SelectedValue.ToString
            SelectedEventYear = cboCurrentEvent.SelectedValue.ToString

            lstEventGolfers.BeginUpdate()
            lstAvailableGolfers.BeginUpdate()

            OpenDB()

            cmdAddEventGolfer.CommandText = "EXECUTE uspAddGolferEvent '" & intPKID & "','" & SelectedAvailableGolfer & "','" & SelectedEventYear & "'"
            cmdAddEventGolfer.CommandType = CommandType.StoredProcedure
            cmdAddEventGolfer = New OleDb.OleDbCommand(cmdAddEventGolfer.CommandText, m_conAdministrator)
            intRowsAffected = cmdAddEventGolfer.ExecuteNonQuery()

            CloseDatabaseConnection()

            If intRowsAffected > 0 Then
                MessageBox.Show("Insert Successful Event Golfer Has Been Added.")
            Else
                MessageBox.Show("Insert failed")
            End If

            lstEventGolfers.EndUpdate()
            lstAvailableGolfers.EndUpdate()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub
    ''**************************************************************************************
    ''SUBROUTINE Delete_GolferEvent: Delete Golfer From TGolferEventYears
    ''**************************************************************************************
    Private Sub Delete_EventGolfer()

        Try
            Dim cmdDeleteEventGolfer As New OleDb.OleDbCommand()
            Dim intRowsAffected As Integer
            Dim SelectedEventGolfer As String
            Dim SelectedEventYear As String
            Dim result As DialogResult


            SelectedEventGolfer = lstEventGolfers.SelectedValue.ToString ''SelectedEventGolfer will Serve as The PrimaryKeyID
            SelectedEventYear = cboCurrentEvent.SelectedValue.ToString

            result = MessageBox.Show("Are you sure you want to Delete Golfer From Current Event?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            lstEventGolfers.BeginUpdate()
            lstAvailableGolfers.BeginUpdate()

            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes

                    lstAvailableGolfers.BeginUpdate()
                    OpenDB()
                    cmdDeleteEventGolfer.CommandText = "EXECUTE uspDeleteEventGolfer '" & SelectedEventGolfer & "','" & SelectedEventYear & "'"
                    cmdDeleteEventGolfer.CommandType = CommandType.StoredProcedure
                    cmdDeleteEventGolfer = New OleDb.OleDbCommand(cmdDeleteEventGolfer.CommandText, m_conAdministrator)
                    intRowsAffected = cmdDeleteEventGolfer.ExecuteNonQuery()



                    If intRowsAffected > 0 Then
                        MessageBox.Show("Dropped Golfer From Current Event.")
                    Else
                        MessageBox.Show("Insert failed")
                    End If
                    CloseDatabaseConnection()

            End Select

            lstEventGolfers.EndUpdate()
            lstAvailableGolfers.EndUpdate()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub
#End Region

End Class