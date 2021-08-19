Option Strict On
Option Explicit On
Public Class frmViewEventPledge

#Region "Button Functionality"
    ''**************************************************************************************
    ''EXIT BUTTON
    ''**************************************************************************************
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
    ''**************************************************************************************
    ''Load Pledge Button
    ''**************************************************************************************
    Private Sub btnPledgeSum_Click(sender As Object, e As EventArgs) Handles btnPledgeSum.Click
        Load_Pledge()
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
    ''SUBROUTINE frmViewEventPledge_Load: Loads Data
    ''**************************************************************************************
    Private Sub frmViewEventPledge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
    ''SUBROUTINE Load_Pledge: Loads Pledge Data
    ''**************************************************************************************
    Private Sub Load_Pledge()
        Try
            ''Declare Variables

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable
            Dim Result As String

            OpenDB()
            Dim EventID As Integer = cboEvents.SelectedIndex + 1
            strSelect = $"SELECT SUM(TGEYS.monPledgeAmount) as EventPledgeSum FROM TGolfers as TG JOIN TGolferEventYearSponsors as TGEYS ON TG.intGolferID = TGEYS.intGolferID Where TGEYS.intEventYearID = {EventID}"

            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader



            dt.Load(drSourceTable)

            Result = dt.Rows(0).Item(0).ToString


            txtPledge.Text = FormatCurrency(Result)


            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub




#End Region

End Class