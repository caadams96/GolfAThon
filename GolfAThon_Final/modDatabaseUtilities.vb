' --------------------------------------------------------------------------------
'Module that holds functions to connect/disconnect to database.
'---------------------------------------------------------------------------------
' Options
Option Explicit On
' --------------------------------------------------------------------------------


Public Module modDatabaseUtilities




    ' --------------------------------------------------------------------------------
    ' Properties
    ' --------------------------------------------------------------------------------
    ' In a 2-Tier app we connect once during FMain_Load and hold
    ' the connection open while until the application closes
    Public m_conAdministrator As OleDb.OleDbConnection

    ' SQL Server Connection string with integrated login v1
    Private m_strDatabaseConnectionStringSQLServerV1 As String = "Provider=SQLOLEDB;" &
                                                                 "Server=(Local);" &
                                                                 "Database=dbSQL1;" &
                                                                 "Integrated Security=SSPI;"

    ' SQL Server Connection string with integrated login v2
    Private m_strDatabaseConnectionStringSQLServerV2 As String = "Provider=SQLOLEDB;" &
                                                                 "Server=(Local);" &
                                                                 "Database=dbSQL1;" &
                                                                 "Trusted_Connection=True;"

    ' SQL Express Connection string                             
    Private m_strDatabaseConnectionString As String = "Provider=SQLOLEDB;" &
                                                      "Server=(Local)\SQLEXPRESS;" &
                                                      "Database=dbSQL1;" &
                                                      "User ID=sa;" &
                                                      "Password=;"



#Region "Open/Close Connection"
    ''//////////////////////////////////////////
    'Name: OpenDatabaseConnectionMSAccess
    'Abstrac: Open a connection to the database.
    '///////////////////////////////////////////

    Public Function OpenDatabaseConnectionSQLServer() As Boolean
        Dim blnResult As Boolean = False

        Try
            ''Open a Connection to the database
            m_conAdministrator = New OleDb.OleDbConnection
            m_conAdministrator.ConnectionString = m_strDatabaseConnectionStringSQLServerV1
            m_conAdministrator.Open()
            ''Success
            blnResult = True

        Catch excError As Exception
            MessageBox.Show(excError.Message)

        End Try
        Return blnResult
    End Function


    Public Function CloseDatabaseConnection() As Boolean
        Dim blnResult As Boolean = False

        Try
            If m_conAdministrator IsNot Nothing Then
                If m_conAdministrator.State <> ConnectionState.Closed Then
                    m_conAdministrator.Close()
                End If
                m_conAdministrator = Nothing
            End If
            blnResult = True

        Catch excError As Exception
            MessageBox.Show(excError.Message)

        End Try
        Return blnResult
    End Function

#End Region

End Module