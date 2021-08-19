''<Developed By Corey Adams>
''<Programming2>
''<8/18/21>

Option Strict On
Option Explicit On

Public Class frmMainMenu
    ''**************************************************************************************
    ''OPEN frmManageGolfers BUTTON
    ''**************************************************************************************
    Private Sub btnGolfers_Click(sender As Object, e As EventArgs) Handles btnGolfers.Click
        Dim Golfers As New frmManageGolfers
        Golfers.ShowDialog()
    End Sub
    ''**************************************************************************************
    ''EXIT BUTTON
    ''**************************************************************************************
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
    ''**************************************************************************************
    ''OPEN frmManageEvents BUTTON
    ''**************************************************************************************
    Private Sub btnEvents_Click(sender As Object, e As EventArgs) Handles btnEvents.Click
        Dim Events As New frmManageEvents
        Events.ShowDialog()
    End Sub
    ''**************************************************************************************
    ''OPEN frmManageGolferEvents BUTTON
    ''**************************************************************************************
    Private Sub btnGolferEvents_Click(sender As Object, e As EventArgs) Handles btnGolferEvents.Click
        Dim GolferEvents As New frmManageGolferEvents
        GolferEvents.ShowDialog()
    End Sub
    ''**************************************************************************************
    ''OPEN frmManageSponsors BUTTON
    ''**************************************************************************************
    Private Sub btnSponsors_Click(sender As Object, e As EventArgs) Handles btnSponsors.Click
        Dim Sponsors As New frmManageSponsors
        Sponsors.ShowDialog()
    End Sub
    ''**************************************************************************************
    ''OPEN frmManageGolferEventYearSponsors BUTTON
    ''**************************************************************************************
    Private Sub btnGolferEventYearSponsors_Click(sender As Object, e As EventArgs) Handles btnGolferEventYearSponsors.Click
        Dim GolferEventYearSponsors As New frmManageGolferEventYearSponsors
        GolferEventYearSponsors.ShowDialog()
    End Sub
    ''**************************************************************************************
    ''OPEN frmViewPledgeTotals BUTTON
    ''**************************************************************************************
    Private Sub btnViewPledge_Click(sender As Object, e As EventArgs) Handles btnViewPledge.Click
        Dim Pledges As New frmViewPledgeTotals
        Pledges.ShowDialog()
    End Sub

    Private Sub frmMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
