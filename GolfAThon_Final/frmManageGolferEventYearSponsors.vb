Public Class frmManageGolferEventYearSponsors
#Region "Button Functionality"
    ''**************************************************************************************
    ''ADD SPONSOR To  GolferEvent BUTTON
    ''**************************************************************************************
    Private Sub btnAddSponsor_Click(sender As Object, e As EventArgs) Handles btnAddSponsor.Click
        Dim AddSponsor As New frmAddGolferEventYearSponsor
        AddSponsor.ShowDialog()
        frmManageGolferEventYearSponsors_Load(sender, e)

    End Sub
    ''**************************************************************************************
    ''REFRESH LIST BUTTON
    ''**************************************************************************************
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Select_GolferEventYearSponsor()
    End Sub
    ''**************************************************************************************
    ''ADD Golfer To Event BUTTON
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
    ''SUBROUTINE frmManageGolferEventYearSponsors_Load: Loads Data
    ''**************************************************************************************
    Private Sub frmManageGolferEventYearSponsors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Names()
        Load_Events()

    End Sub
    ''**************************************************************************************
    ''SUBROUTINE cboEventYears_SelectedIndexChanged: Refreshes the list when index is changed
    ''**************************************************************************************
    Private Sub cboEventYears_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEventYears.SelectedIndexChanged
        Select_GolferEventYearSponsor()
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

            OpenDB()

            strSelect = "SELECT intEventYearID, intEventYear FROM TEventYears"

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


#End Region

#Region "Stored Procedures"
    ''**************************************************************************************
    ''SUBROUTINE Select_GolferEventYearSponsor: Loads GolferEventYearSponsor
    ''**************************************************************************************
    Private Sub Select_GolferEventYearSponsor()
        Try
            ''Declare Variables 
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            Dim SelectedEventGolfer As String
            Dim SelectedEventYear As String



            OpenDB()

            SelectedEventGolfer = cboGolfers.SelectedIndex + 1
            SelectedEventYear = cboEventYears.SelectedIndex + 1
            lstGolferEventYearSponsors.BeginUpdate()

            strSelect = "Select Sponsor from vGolferEventYearSponsors Where GolferID = '" & SelectedEventGolfer & "'and EventYearID = '" & SelectedEventYear & "'"
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)

            lstGolferEventYearSponsors.ValueMember = "SponsorID"
            lstGolferEventYearSponsors.DisplayMember = "Sponsor"
            lstGolferEventYearSponsors.DataSource = dt


            lstGolferEventYearSponsors.EndUpdate()
            drSourceTable.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub


#End Region

End Class