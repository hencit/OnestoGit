Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.Odbc
Imports System.IO

Public Class rptStock
    Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Stock.rpt"
    Dim val1, val2 As String
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
    Dim DS2 As New DataSet

    Private Sub rptStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Value = CDate(GetSysInit("tanggal_stock"))
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "MM-yyyy"

        cbSort.Items.Add("Sort DEPTID")
        cbSort.Items.Add("Sort STOCKID")
        cbSort.SelectedIndex = 0

        cbType.Items.Add("All")
        cbType.Items.Add("Outstanding")
        cbType.Items.Add("Stock Habis")
        cbType.SelectedIndex = 0
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        val1 = "rpt_gaji_"
        val2 = "cetak"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim dateFrom1 As String
        Dim dateTo1 As String
        Dim karyawanID1 As String

        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "yyyy/MM/dd"
        dateFrom1 = dtpFrom.Text

        strSQL = "exec RPT_Gaji '" & dateFrom1 & "' , '" & dateTo1 & "' , '" & karyawanID1 & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "RPT_Gaji_")

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Report Gaji"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("RPT_Gaji_"))

        '-----------------MENAMBAH PARAMETER FILTER KE CR--------------------------
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterdate As String

        filterdate = "Period : " & dtpFrom.Text



        Dim filter As String = filterdate

        crParameterDiscreteValue.Value = filter
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("filterscode")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Sub getPenjualan()
        Dim hasRecords As Boolean = False
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
                .Columns.Add("KETERANGAN", 100)
            End With
            Dim bedaHari As Integer

            Dim dateFrom As String
            dtpFrom.Format = DateTimePickerFormat.Custom
            dtpFrom.CustomFormat = "yyyy-MM"
            dateFrom = dtpFrom.Text + "-01"

            Dim m_date As Date = CDate(dateFrom)
            Dim m_Period As String = DatePart(DateInterval.Year, m_date).ToString + "-" + DatePart(DateInterval.Month, m_date).ToString + "-" + GetLastDayOfMonth(m_date.Month, m_date.Year).Day.ToString
            Dim m_scan_batch As String = DatePart(DateInterval.Month, m_date).ToString + "-" + DatePart(DateInterval.Year, m_date).ToString
            If DatePart(DateInterval.Month, m_date) < 10 Then
                m_scan_batch = "0" + m_scan_batch
            End If

            dtpPeriodNow = m_Period
            dtpPeriod = dateFrom

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
                "FROM OPENQUERY(MEGA, 'SELECT DEPTID,STOCKID,CURQTY,STOCKNAME FROM " + Chr(34) + GetSysInit("etstore_master_stock") + Chr(34) + "')c)cc ON aa.STOCKID = cc.STOCKID "

            If cbType.SelectedIndex = 2 Then 'Jika type yang dipilih adalah habis
                cmd3 = cmd3 + "WHERE aa.CANCEL = 1 "
            ElseIf cbType.SelectedIndex = 1 Then
                cmd3 = cmd3 + "WHERE aa.CANCEL = 0 "
            End If

            cmd3 = cmd3 + "GROUP BY cc.DEPTID,aa.STOCKID,cc.STOCKNAME,aa.QTYSCAN,cc.CURQTY,aa.CANCEL,aa.scan_batch "

            If cbType.SelectedIndex = 1 Then 'Jika type yang dipilih adalah bukan yang statusnya habis
                cmd3 = cmd3 + "HAVING SUM(aa.QTY)>AA.QTYSCAN "
            End If

            If cbSort.SelectedIndex = 0 Then
                cmd4 = "ORDER BY aa.STOCKID"
            Else
                cmd4 = "ORDER BY cc.DEPTID"
            End If

            TextBox1.Text = cmd1 + cmd2 + cmd3 + cmd4

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
                    lvwItem.SubItems.Add(IIf(DS2.Tables("_transaksi").Rows(i).Item("CANCEL").ToString = "False", "", "Habis"))
                    ListView1.Items.Add(lvwItem)
                Next i
            End If
            

        Catch ex As Exception
            If ConnectionState.Open = True Then cn.Close()
            MsgBox("Error code: " + ex.Message)
        End Try
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Cursor = Cursors.WaitCursor
        getPenjualan()
        Cursor = Cursors.Default
    End Sub
End Class