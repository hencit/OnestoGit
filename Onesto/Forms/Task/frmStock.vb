Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.IO
Public Class frmStock
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim sqlreader As SqlDataReader

    Dim strConnection2 As String = My.Settings.ConnStr2
    Dim cn2 As New OdbcConnection(strConnection2)
    Dim strSQL As String
    Dim cmd1, cmd2, cmd3, cmd4 As String
    Dim comm As OdbcCommand
    Dim myReader As OdbcDataReader

    Dim path, path_header, path_detail, ext, tanggal, bulan, tahun As String
    Dim dtpPeriod, dtpPeriodNow As Date
    Dim val1, val2 As String

    Dim DS2 As New DataSet
    Dim flagSave, flagClose As Boolean

    Private Sub frmStock_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("APAKAH DATA SCAN SUDAH DISIMPAN ?", vbYesNo + vbCritical, Me.Text) = vbYes Then

        Else
            MsgBox("Harap menunggu data sedang disimpan", vbInformation)
            flagClose = True
            btnSimpan_Click(sender, e)
        End If
        
    End Sub

    Private Sub frmStock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtScanCode.Text = "" Then
                txtScanCode.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub frmStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cbSort.Items.Add("Sort DEPTID")
        cbSort.Items.Add("Sort STOCKID")
        cbSort.SelectedIndex = 0

        txtScanCode.Focus()
        Timer1.Enabled = True
        flagSave = False

        dtpFrom.Value = CDate(GetSysInit("tanggal_stock"))
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "MM-yyyy"

    End Sub

    Sub getPenjualan()
        Dim hasRecords As Boolean = False

        dtpFrom.Value = CDate(GetSysInit("tanggal_stock"))
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "MM-yyyy"

        Try
            With ListView1
                .Clear()
                .View = View.Details
                .Columns.Add("DEPT ID", 100)
                .Columns.Add("STOCK ID", 100)
                .Columns.Add("STOCK NAME", 200)
                .Columns.Add("SALES QTY", 100, HorizontalAlignment.Right)
                .Columns.Add("SCAN QTY", 100, HorizontalAlignment.Right)
                .Columns.Add("STOCK QTY", 100, HorizontalAlignment.Right)
            End With

            Dim bedaHari As Integer
            Dim m_date As Date = CDate(GetSysInit("tanggal_stock"))
            Dim m_Period As String = DatePart(DateInterval.Year, m_date).ToString + "-" + DatePart(DateInterval.Month, m_date).ToString + "-" + GetLastDayOfMonth(m_date.Month, m_date.Year).Day.ToString
            Dim m_scan_batch As String = DatePart(DateInterval.Month, m_date).ToString + "-" + DatePart(DateInterval.Year, m_date).ToString
            If DatePart(DateInterval.Month, m_date) < 10 Then
                m_scan_batch = "0" + m_scan_batch
            End If
            'dtpPeriodNow = GetServerDate()
            dtpPeriodNow = m_Period
            dtpPeriod = GetSysInit("tanggal_stock")

            bedaHari = DateDiff(DateInterval.Day, dtpPeriod, dtpPeriodNow)

            'Response.Write(CStr(dtpPeriod) + " " + CStr(dtpPeriodNow) + " " + CStr(rangeHari))

            cmd1 = ""
            cmd2 = ""
            cmd3 = ""
            strSQL = "SELECT path_header, path_detail FROM sys_path"

            Dim DA As New SqlDataAdapter(strSQL, cn)
            Dim DS As New DataSet
            Dim DT As DataTable
            DA.Fill(DS, "_path")

            DT = DS.Tables("_path")

            ext = ".dat"

            cmd1 = "SELECT ISNULL(cc.DEPTID,0) as DEPTID,aa.STOCKID,cc.STOCKNAME,SUM(aa.QTY) as QTY,aa.QTYSCAN,cc.CURQTY,aa.CANCEL, aa.scan_batch FROM ("

            For q = 0 To bedaHari - 1
                If CInt(dtpPeriod.Month) < 10 Then
                    bulan = "0" + CStr(dtpPeriod.Month)
                Else
                    bulan = dtpPeriod.Month
                End If

                tahun = dtpPeriod.Year

                If CInt(dtpPeriod.Day) < 10 Then
                    tanggal = "0" + CStr(dtpPeriod.Day)
                Else
                    tanggal = dtpPeriod.Day
                End If

                '---------------- Start GetPenjualan PerHari --------------------------
                For z = 0 To DT.Rows.Count - 1
                    path_header = DT.Rows(z).Item("path_header")
                    path_detail = DT.Rows(z).Item("path_detail")

                    path = path_header + path_detail + "\" + tahun + "-" + bulan + "\IT" + bulan + "" + tanggal + ext
                    'path = "G:\MEGA\DATA\POS06\2014-09\0924.dat"

                    If File.Exists(path) Then

                        cmd2 = cmd2 + "SELECT a.STOCKID,a.QTY,ISNULL(b.QTYSCAN,0) as QTYSCAN,ISNULL(b.cancel,0) as CANCEL, b.scan_batch " & _
                            "FROM OPENQUERY(MEGA, 'SELECT STOCKID,QTY FROM " + Chr(34) + path + Chr(34) + " WHERE ISVOID = FALSE') a " & _
                            "LEFT JOIN sqlserver.dbo.linq_penjualan b ON a.STOCKID = b.STOCKID AND b.scan_batch = '" + m_scan_batch + "' "
                        cmd2 = cmd2 + " UNION ALL "
                    End If
                Next
                '---------------- END GetPenjualan PerHari --------------------------
                dtpPeriod = dtpPeriod.AddDays(1)

            Next

            If cmd2 <> "" Then
                cmd2 = cmd2.Remove(cmd2.Length - 11)
                hasRecords = True
            Else
                hasRecords = False
            End If

            cmd3 = ") aa INNER JOIN (SELECT c.DEPTID,c.STOCKID,c.CURQTY,c.STOCKNAME " & _
                "FROM OPENQUERY(MEGA, 'SELECT DEPTID,STOCKID,CURQTY,STOCKNAME FROM " + Chr(34) + GetSysInit("etstore_master_stock") + Chr(34) + "')c)cc ON aa.STOCKID = cc.STOCKID " & _
                "WHERE aa.CANCEL = 0 GROUP BY cc.DEPTID,aa.STOCKID,cc.STOCKNAME,aa.QTYSCAN,cc.CURQTY,aa.CANCEL,aa.scan_batch " & _
                "HAVING SUM(aa.QTY)>AA.QTYSCAN "

            If cbSort.SelectedIndex = 0 Then
                cmd4 = "ORDER BY aa.STOCKID"
            Else
                cmd4 = "ORDER BY cc.DEPTID"
            End If

            If hasRecords = True Then
                Dim DA2 As New SqlDataAdapter(cmd1 + cmd2 + cmd3 + cmd4, cn)
                DA2.SelectCommand.CommandTimeout = 600
                DS2 = New DataSet
                DA2.Fill(DS2, "_transaksi")

                Dim lvwItem As ListViewItem
                For i As Integer = 0 To DS2.Tables("_transaksi").Rows.Count - 1
                    lvwItem = New ListViewItem
                    lvwItem.Text = DS2.Tables("_transaksi").Rows(i).Item("DEPTID").ToString
                    lvwItem.SubItems.Add(DS2.Tables("_transaksi").Rows(i).Item("STOCKID").ToString)
                    lvwItem.SubItems.Add(DS2.Tables("_transaksi").Rows(i).Item("STOCKNAME").ToString)
                    lvwItem.SubItems.Add(DS2.Tables("_transaksi").Rows(i).Item("QTY").ToString)
                    lvwItem.SubItems.Add(DS2.Tables("_transaksi").Rows(i).Item("QTYSCAN").ToString)
                    lvwItem.SubItems.Add(DS2.Tables("_transaksi").Rows(i).Item("CURQTY").ToString)
                    ListView1.Items.Add(lvwItem)
                Next i
            End If

        Catch ex As Exception
            If ConnectionState.Open = True Then cn.Close()
            MsgBox("Error code: " + ex.Message)
        End Try
    End Sub

    Private Sub btnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScan.Click
        Dim flag As Boolean = False
        
        Try
            For i = 0 To ListView1.Items.Count - 1
                If txtScanCode.Text = ListView1.Items(i).SubItems(1).Text Then
                    ListView1.Items(i).SubItems(4).Text = CStr(CInt(ListView1.Items(i).SubItems(4).Text) + 1)
                    flag = True
                    flagSave = True
                    Exit For
                End If
            Next

            If flag = False Then
                MsgBox("Stock yang discan tidak ada dalam daftar tunggu!", vbCritical)
            End If

            txtScanCode.Text = ""

        Catch ex As Exception
            If ConnectionState.Open = True Then cn.Close()
            MsgBox("Error code: " + ex.Message)
        End Try
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        Cursor = Cursors.WaitCursor
        getPenjualan()
        Cursor = Cursors.Default
    End Sub

    Private Sub txtScanCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtScanCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnScan_Click(sender, e)
        End If
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Cursor = Cursors.WaitCursor
        getPenjualan()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        Cursor = Cursors.WaitCursor
        Try
            Dim m_date As Date = CDate(GetSysInit("tanggal_stock"))
            Dim m_scan_batch As String = DatePart(DateInterval.Month, m_date).ToString + "-" + DatePart(DateInterval.Year, m_date).ToString
            If DatePart(DateInterval.Month, m_date) < 10 Then
                m_scan_batch = "0" + m_scan_batch
            End If

            For i = 0 To ListView1.Items.Count - 1
                cmd = New SqlCommand("sp_linq_penjualan_SCAN", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@STOCKID", SqlDbType.NVarChar, 50)
                prm1.Value = ListView1.Items(i).SubItems(1).Text
                Dim prm2 As SqlParameter = cmd.Parameters.Add("@QTYSCAN", SqlDbType.Int)
                prm2.Value = CInt(ListView1.Items(i).SubItems(4).Text)
                Dim prm3 As SqlParameter = cmd.Parameters.Add("@scan_batch", SqlDbType.NVarChar, 10)
                prm3.Value = m_scan_batch
                Dim prm10 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
                prm10.Value = My.Settings.UserName

                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

            Next
            MsgBox("Data berhasil disimpan", vbInformation)
            flagSave = True

            If flagClose = False Then
                btnRefresh_Click(sender, e)
            End If

            flagClose = False
        Catch ex As Exception
            If ConnectionState.Open = True Then cn.Close()
            MsgBox("Error code: " + ex.Message)
        End Try
        Cursor = Cursors.Default

    End Sub

    Private Sub btnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHabis.Click
        If ListView1.SelectedItems.Count > 0 Then
            If MsgBox("Anda yakin melaporkan item ini habis?", vbYesNo + vbCritical, Me.Text) = vbYes Then
                'val1 = "tr_stock_"
                'val2 = "batal"
                'If otorisasi(val1 + val2) = False Then
                '    MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
                '    Exit Sub
                'End If

                Try
                    Dim m_date As Date = CDate(GetSysInit("tanggal_stock"))
                    Dim m_scan_batch As String = DatePart(DateInterval.Month, m_date).ToString + "-" + DatePart(DateInterval.Year, m_date).ToString
                    If DatePart(DateInterval.Month, m_date) < 10 Then
                        m_scan_batch = "0" + m_scan_batch
                    End If

                    cmd = New SqlCommand("sp_linq_penjualan_BATAL", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm1 As SqlParameter = cmd.Parameters.Add("@STOCKID", SqlDbType.NVarChar, 50)
                    prm1.Value = ListView1.SelectedItems.Item(0).SubItems(1).Text
                    Dim prm3 As SqlParameter = cmd.Parameters.Add("@scan_batch", SqlDbType.NVarChar, 10)
                    prm3.Value = m_scan_batch
                    Dim prm10 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
                    prm10.Value = My.Settings.UserName

                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    btnRefresh_Click(sender, e)
                    MsgBox("Stock berhasil dilaporkan habis", vbInformation)
                Catch ex As Exception
                    If ConnectionState.Open = True Then cn.Close()
                    MsgBox("Error code: " + ex.Message)
                End Try

            End If
        Else
            MsgBox("Silahkan pilih tugas terlebih dahulu!", vbCritical)
            ListView1.Focus()
        End If
        
    End Sub
End Class