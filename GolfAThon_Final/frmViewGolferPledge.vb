Option Strict On
Option Explicit On

Public Class frmViewGolferPledge

#Region "Button Functionality"
    ''**************************************************************************************
    ''Buton Exit
    ''**************************************************************************************
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
    ''**************************************************************************************
    ''Show Pledge Button 
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
    ''SUBROUTINE frmViewGolferPledge_Load: Loads Data
    ''**************************************************************************************
    Private Sub frmViewGolferPledge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Events()
        Load_Names()
    End Sub

    ''**************************************************************************************
    ''SUBROUTINE Load_Events: Loads Event Data
    ''**************************************************************************************
    Private Sub Load_Events()
        Try
            ''Declare Variables

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            OpenDB() ''Open DataBase

            ''Set Up SQL Statement
            strSelect = "SELECT intEventYearID, intEventYear FROM TEventYears"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)

            cboEvents.ValueMember = "intEventYearID"
            cboEvents.DisplayMember = "intEventYear"
            cboEvents.DataSource = dt


            ''Set First Event to Display
            If cboEvents.Items.Count > 0 Then cboEvents.SelectedIndex = 0

            ''Close 
            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try



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

            OpenDB() '' Open Database

            Dim GolferID As Integer = cboNames.SelectedIndex + 1
            Dim EventID As Integer = cboEvents.SelectedIndex + 1

            ''Set up SQL SELECT Statement
            strSelect = $"SELECT SUM(TGEYS.monPledgeAmount) as EventGolferPledgeSum FROM TGolfers as TG JOIN TGolferEventYearSponsors as TGEYS ON TG.intGolferID = TGEYS.intGolferID Where TG.intGolferID = {GolferID} and TGEYS.intEventYearID = {EventID}"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)

            Result = dt.Rows(0).ItemArray(0).ToString
            txtPledge.Text = FormatCurrency(Result) '' Show Result

            ''Close Database
            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub




#End Region

End Class