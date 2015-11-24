Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmSysStockGudang
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Private Sub frmSysStockGudang_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Value = CDate(GetSysInit("tanggal_stock"))
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "MM-yyyy"
    End Sub

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        Try
            Dim dateFrom As String
            dtpFrom.Format = DateTimePickerFormat.Custom
            dtpFrom.CustomFormat = "yyyy-MM"
            dateFrom = dtpFrom.Text + "-01"
            UpdSysInit("tanggal_stock", dateFrom)

            MsgBox("Setting berhasil disimpan!", vbInformation, Me.Text)
            Me.Close()
        Catch ex As Exception
            MsgBox("Error message : " + ex.Message, vbCritical)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub
End Class