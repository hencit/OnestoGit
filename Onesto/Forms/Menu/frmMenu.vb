Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmMenu
    'Dim strConnection As String = My.Settings.ConnStr
    'Dim cn As SqlConnection = New SqlConnection(strConnection)
    'Dim cmd As SqlCommand
    Dim val1, val2 As String
    Dim menuheader As String = "Onesto"
    Private Sub frmMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = menuheader
        FrmLogin.ShowDialog()
    End Sub
   
    Private Sub frmMenu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Anda yakin ingin keluar dari aplikasi?", vbCritical + vbOKCancel, Me.Text) = vbCancel Then
            e.Cancel = True
        End If
    End Sub
    Private m_ChildFormNumber As Integer

    Private Sub UserCardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserCardToolStripMenuItem.Click
        val1 = "mt_user_"
        val2 = "buka"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        frmUser.MdiParent = Me
        frmUser.Show()
        frmUser.BringToFront()
    End Sub

    Private Sub DepartemenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepartemenToolStripMenuItem.Click
        val1 = "mt_dept_"
        val2 = "buka"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        frmDept.MdiParent = Me
        frmDept.Show()
        frmDept.BringToFront()
    End Sub

    Private Sub TemplateTugasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TemplateTugasToolStripMenuItem1.Click
        val1 = "mt_template_"
        val2 = "buka"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        frmTemplateTugas.MdiParent = Me
        frmTemplateTugas.Show()
        frmTemplateTugas.BringToFront()
    End Sub

    Private Sub TugasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TugasToolStripMenuItem1.Click
        val1 = "mt_tugas_"
        val2 = "buka"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        frmTugas.MdiParent = Me
        frmTugas.Show()
        frmTugas.BringToFront()
    End Sub

    Private Sub DelegasiTugasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelegasiTugasToolStripMenuItem.Click
        val1 = "tr_tugas_"
        val2 = "buka"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        frmDelegasiTugasList.MdiParent = Me
        frmDelegasiTugasList.Show()
        frmDelegasiTugasList.BringToFront()
    End Sub

    Private Sub ImportKaryawanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportKaryawanToolStripMenuItem.Click
        val1 = "im_karyawan_"
        val2 = "buka"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        frmImportKaryawan.MdiParent = Me
        frmImportKaryawan.Show()
        frmImportKaryawan.BringToFront()
    End Sub

    Private Sub ImportPenjualanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportPenjualanToolStripMenuItem.Click
        val1 = "im_penjualan_"
        val2 = "buka"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        frmImportPenjualan.MdiParent = Me
        frmImportPenjualan.Show()
        frmImportPenjualan.BringToFront()
    End Sub

    Private Sub GajiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GajiToolStripMenuItem.Click
        val1 = "rpt_gaji_"
        val2 = "buka"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        rptGaji.MdiParent = Me
        rptGaji.Show()
        rptGaji.BringToFront()
    End Sub

    Private Sub LaporanTugasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanTugasToolStripMenuItem.Click
        val1 = "rpt_tugas_"
        val2 = "buka"
        If otorisasi(val1 + val2) = False Then
            MsgBox("Anda tidak mempunyai otorisasi " + val2 + " modul ini!,Silahkan hubungi administrator anda untuk diberikan otorisasi", vbCritical)
            Exit Sub
        End If

        rptTugas.MdiParent = Me
        rptTugas.Show()
        rptTugas.BringToFront()
    End Sub

    Private Sub LogOutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutToolStripMenuItem1.Click
        If MsgBox("Anda yakin log out?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            Me.Text = menuheader
            FrmLogin.ShowDialog()
        End If
    End Sub

    Private Sub GantiPasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GantiPasswordToolStripMenuItem.Click
        frmGantiPassword.MdiParent = Me
        frmGantiPassword.Show()
        frmGantiPassword.BringToFront()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.MdiParent = Me
        frmAbout.Show()
        frmAbout.BringToFront()
    End Sub

    Private Sub StockGudangToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockGudangToolStripMenuItem.Click
        frmStock.MdiParent = Me
        frmStock.Show()
        frmStock.BringToFront()
    End Sub

    Private Sub SettingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingToolStripMenuItem.Click
        frmSysStockGudang.MdiParent = Me
        frmSysStockGudang.Show()
        frmSysStockGudang.BringToFront()
    End Sub
End Class