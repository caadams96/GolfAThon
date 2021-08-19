Option Strict On
Option Explicit On
Public Class frmViewPledgeTotals
#Region "Button Functionality"
    Private Sub btnGolferPledge_Click(sender As Object, e As EventArgs) Handles btnGolferPledge.Click
        Dim GolferPledge As New frmViewGolferPledge
        GolferPledge.ShowDialog()

    End Sub

    Private Sub btnSponsorPledge_Click(sender As Object, e As EventArgs) Handles btnSponsorPledge.Click
        Dim SponsorPledge As New frmViewSponsorPledge
        SponsorPledge.ShowDialog()
    End Sub

    Private Sub btnEventPledge_Click(sender As Object, e As EventArgs) Handles tnEventPledge.Click
        Dim EventPledge As New frmViewEventPledge
        EventPledge.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub frmViewPledgeTotals_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

#End Region
End Class