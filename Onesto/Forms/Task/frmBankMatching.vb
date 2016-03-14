Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO 'Karena menggunakan openfiledialog maka perlu import library ini

Public Class frmBankMatching
    Dim cn As OleDbConnection
    Dim cm As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim dt As DataTable

    Dim strConnection As String = My.Settings.ConnStr
    Dim cn2 As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim dsSearch As New DataSet
    Private Sub frmBankMatching_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ReadDBF()
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub FillDataGridView(ByVal Query As String)
        da = New OleDbDataAdapter(Query, cn)
        dt = New DataTable
        da.fill(dt)

        With DataGridView1
            .DataSource = dt
            .Columns(0).HeaderText = "Kode_Bank"
            .Columns(1).HeaderText = "SANDI"
            .Columns(2).HeaderText = "TGL"
            .Columns(3).HeaderText = "DEBIT"
            .Columns(4).HeaderText = "KREDIT"
            .Columns(5).HeaderText = "SALDO"
            .Columns(6).HeaderText = "KETERANGAN"
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

        searchSuppID()
    End Sub

    Sub searchSuppID()
        dsSearch = New DataSet
        Dim row As DataRow

        Try
            For i = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(i).Cells(4).Value > 0 Then
                    cmd = New SqlCommand("sp_im_sup_QUERY", cn2)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm2 As SqlParameter = cmd.Parameters.Add("@query", SqlDbType.NVarChar, 200)
                    prm2.Value = DataGridView1.Rows(i).Cells(6).Value.ToString

                    cn2.Open()
                    Dim myReader As SqlDataReader = cmd.ExecuteReader()

                    While myReader.Read
                        'row = dsSearch.Tables(0).NewRow

                        'row(0) = myReader.Item(0)
                        'row(1) = myReader.Item(1)
                        'row(2) = myReader.Item(2)
                        'row(3) = myReader.Item(3)
                        'row(4) = myReader.Item(4)

                        ''Add Values to Row here 
                        'dsSearch.Tables(0).Rows.Add(row)

                        TextBox1.Text = TextBox1.Text + vbCrLf + CStr(myReader.GetInt32(0)) + " " + myReader.GetString(1) + " " + myReader.GetString(2) + " " + myReader.GetString(3) + " " + myReader.GetString(4)
                    End While

                    myReader.Close()
                    cn2.Close()
                End If

            Next

            'With DataGridView2
            '    .DataSource = dsSearch.Tables(0)
            '    .Columns(0).HeaderText = "JUMLAH MATCH"
            '    .Columns(1).HeaderText = "SUPPID"
            '    .Columns(2).HeaderText = "SUPPNAME"
            '    .Columns(3).HeaderText = "NOAC"
            '    .Columns(4).HeaderText = "NAMAAC"
            '    .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            'End With
        Catch ex As Exception
            'MsgBox(ex.Message)
            cn2.Close()
        End Try

    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        If OpenFileDialog1.FileName <> "" Then
            Dim FilePath As String = OpenFileDialog1.FileName

            Try
                'OPEN CONNECTION TO test.xls
                cn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" & _
               "Data Source=" + FilePath + ";" & _
               "Extended Properties=Excel 12.0 Macro;")

                cn.Open()

                'Load file from test.xls into DataGridView1
                FillDataGridView("select Kode_Bank,SANDI,TGL,DEBIT,KREDIT,SALDO,KETERANGAN from [Sheet1$]")


                cn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                cn.Close()
            End Try

        End If
    End Sub

    Sub ReadDBF()
        Dim ConnectionString As String
        'Dim FilePath As String = "G:\Adie P\Bank Matching\Data POS underdos"
        Dim FilePath As String = GetSysInit("et_store_dos_purchase")
        Dim DBF_File As String = "APBUY075"

        ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & FilePath & ";Extended Properties=dBase IV"
        Dim dBaseConnection As New System.Data.OleDb.OleDbConnection(ConnectionString)
        dBaseConnection.Open()
        Try

            Dim datestart As Date = "2007-06-20"
            Dim dateend As Date = "2007-06-26"
            Dim QueryDBF As String = "SELECT * FROM APBUY075 WHERE TGLFAKTUR = #" + dateend + "# "

            Dim dBaseCommand As New System.Data.OleDb.OleDbCommand(QueryDBF, dBaseConnection)
            Dim dBaseDataReader As System.Data.OleDb.OleDbDataReader = dBaseCommand.ExecuteReader(CommandBehavior.SequentialAccess)

            'While dBaseDataReader.Read
            '    MsgBox(dBaseDataReader(0).ToString)
            'End While

           

            dBaseConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            dBaseConnection.Close()
        End Try

    End Sub

    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox(DataGridView1.Rows.Count)
        searchSuppID()
    End Sub
End Class