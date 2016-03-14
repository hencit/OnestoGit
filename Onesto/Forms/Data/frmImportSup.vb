Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc
Public Class frmImportSup
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_FrmCallerId As String

    Dim strConnection2 As String = My.Settings.ConnStr2
    Dim cn2 As New OdbcConnection(strConnection2)
    Dim strSQL As String
    Dim comm As OdbcCommand
    Dim myReader As OdbcDataReader
    Dim val1, val2 As String

    Private Sub frmImportSup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("SUPPID", 50)
            .Columns.Add("SUPPNAME", 150)
            .Columns.Add("NOAC", 100)
            .Columns.Add("NAMAAC", 100)
        End With

        strSQL = "SELECT SUPPID,SUPPNAME,NOAC,NAMAAC FROM APSUP143 "

        cn2.Open()
        comm = New OdbcCommand(strSQL, cn2)
        myReader = comm.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0)))
            lvItem.Tag = intCurrRow 'ID
            lvItem.SubItems.Add(myReader.Item(1))
            If myReader.IsDBNull(myReader.GetOrdinal("NOAC")) Then
                lvItem.SubItems.Add("")
            Else
                lvItem.SubItems.Add(myReader.Item(2))
            End If
            If myReader.IsDBNull(myReader.GetOrdinal("NAMAAC")) Then
                lvItem.SubItems.Add("")
            Else
                lvItem.SubItems.Add(myReader.Item(3))
            End If
            If intCurrRow Mod 2 = 0 Then
                lvItem.BackColor = Color.Lavender
            Else
                lvItem.BackColor = Color.White
            End If
            lvItem.UseItemStyleForSubItems = True

            ListView1.Items.Add(lvItem)
            intCurrRow += 1
        End While

        myReader.Close()
        cn2.Close()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        'val1 = "im_supplier_"
        'val2 = "import"
        'If otorisasi(val1 + val2) = False Then
        '    MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
        '    Exit Sub
        'End If

        Cursor = Cursors.WaitCursor
        Dim suppid, suppname, noac, namaac As String

        If MsgBox("Anda yakin mau melakukan import data supplier?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            'Hapus data master sebelumnya
            Try
                cmd = New SqlCommand("sp_im_sup_DEL", cn)
                cmd.CommandType = CommandType.StoredProcedure
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()

                'Insert data master baru
                For i = 0 To ListView1.Items.Count - 1

                    suppid = ListView1.Items(i).SubItems.Item(0).Text
                    suppname = ListView1.Items(i).SubItems.Item(1).Text
                    If ListView1.Items(i).SubItems.Item(2).Text = "" Then
                        noac = ""
                    Else
                        noac = ListView1.Items(i).SubItems.Item(2).Text
                    End If
                    If ListView1.Items(i).SubItems.Item(3).Text = "" Then
                        namaac = ""
                    Else
                        namaac = ListView1.Items(i).SubItems.Item(3).Text
                    End If

                    cmd = New SqlCommand("sp_im_sup_INS", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm11 As SqlParameter = cmd.Parameters.Add("@SUPPID", SqlDbType.NVarChar, 50)
                    prm11.Value = suppid
                    Dim prm12 As SqlParameter = cmd.Parameters.Add("@SUPPNAME", SqlDbType.NVarChar, 50)
                    prm12.Value = suppname
                    Dim prm13 As SqlParameter = cmd.Parameters.Add("@NOAC", SqlDbType.NVarChar, 50)
                    prm13.Value = noac
                    Dim prm14 As SqlParameter = cmd.Parameters.Add("@NAMAAC", SqlDbType.NVarChar, 50)
                    prm14.Value = namaac
                    Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_code", SqlDbType.NVarChar, 50)
                    prm15.Value = My.Settings.UserName

                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                    ListView1.Items(i).Checked = True

                Next
                MsgBox("Import data supplier berhasil", vbInformation)
            Catch ex As Exception
                MsgBox("Error Message: " + ex.Message)
                If ConnectionState.Open = True Then cn.Close()
            End Try
        End If
        Cursor = Cursors.Default
        Me.Close()
    End Sub
End Class