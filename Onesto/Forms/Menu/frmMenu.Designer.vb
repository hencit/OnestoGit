<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GantiPasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogOutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserCardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TugasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TemplateTugasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TugasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DepartemenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TaskManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DelegasiTugasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.StockGudangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GajiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaporanTugasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportKaryawanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportPenjualanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.LaporanStockGudangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 540)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(784, 22)
        Me.StatusStrip.TabIndex = 0
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(121, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.UserToolStripMenuItem, Me.TaskManagementToolStripMenuItem, Me.StockToolStripMenuItem, Me.LaporanToolStripMenuItem, Me.DataToolStripMenuItem, Me.WindowToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.WindowToolStripMenuItem
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(784, 24)
        Me.MenuStrip.TabIndex = 1
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.GantiPasswordToolStripMenuItem, Me.LogOutToolStripMenuItem1})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'GantiPasswordToolStripMenuItem
        '
        Me.GantiPasswordToolStripMenuItem.Name = "GantiPasswordToolStripMenuItem"
        Me.GantiPasswordToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.GantiPasswordToolStripMenuItem.Text = "Ganti Password"
        '
        'LogOutToolStripMenuItem1
        '
        Me.LogOutToolStripMenuItem1.Name = "LogOutToolStripMenuItem1"
        Me.LogOutToolStripMenuItem1.Size = New System.Drawing.Size(155, 22)
        Me.LogOutToolStripMenuItem1.Text = "Log Out"
        '
        'UserToolStripMenuItem
        '
        Me.UserToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserCardToolStripMenuItem, Me.TugasToolStripMenuItem, Me.DepartemenToolStripMenuItem})
        Me.UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        Me.UserToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.UserToolStripMenuItem.Text = "Master"
        '
        'UserCardToolStripMenuItem
        '
        Me.UserCardToolStripMenuItem.Name = "UserCardToolStripMenuItem"
        Me.UserCardToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.UserCardToolStripMenuItem.Text = "User"
        '
        'TugasToolStripMenuItem
        '
        Me.TugasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TemplateTugasToolStripMenuItem1, Me.TugasToolStripMenuItem1})
        Me.TugasToolStripMenuItem.Name = "TugasToolStripMenuItem"
        Me.TugasToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.TugasToolStripMenuItem.Text = "Tugas"
        '
        'TemplateTugasToolStripMenuItem1
        '
        Me.TemplateTugasToolStripMenuItem1.Name = "TemplateTugasToolStripMenuItem1"
        Me.TemplateTugasToolStripMenuItem1.Size = New System.Drawing.Size(159, 22)
        Me.TemplateTugasToolStripMenuItem1.Text = "Template Tugas"
        '
        'TugasToolStripMenuItem1
        '
        Me.TugasToolStripMenuItem1.Name = "TugasToolStripMenuItem1"
        Me.TugasToolStripMenuItem1.Size = New System.Drawing.Size(159, 22)
        Me.TugasToolStripMenuItem1.Text = "Tugas"
        '
        'DepartemenToolStripMenuItem
        '
        Me.DepartemenToolStripMenuItem.Name = "DepartemenToolStripMenuItem"
        Me.DepartemenToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.DepartemenToolStripMenuItem.Text = "Departemen"
        '
        'TaskManagementToolStripMenuItem
        '
        Me.TaskManagementToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DelegasiTugasToolStripMenuItem})
        Me.TaskManagementToolStripMenuItem.Name = "TaskManagementToolStripMenuItem"
        Me.TaskManagementToolStripMenuItem.Size = New System.Drawing.Size(125, 20)
        Me.TaskManagementToolStripMenuItem.Text = "Tugas Management"
        '
        'DelegasiTugasToolStripMenuItem
        '
        Me.DelegasiTugasToolStripMenuItem.Name = "DelegasiTugasToolStripMenuItem"
        Me.DelegasiTugasToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.DelegasiTugasToolStripMenuItem.Text = "Delegasi Tugas"
        '
        'StockToolStripMenuItem
        '
        Me.StockToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingToolStripMenuItem, Me.ToolStripSeparator1, Me.StockGudangToolStripMenuItem})
        Me.StockToolStripMenuItem.Name = "StockToolStripMenuItem"
        Me.StockToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.StockToolStripMenuItem.Text = "Stock"
        '
        'SettingToolStripMenuItem
        '
        Me.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem"
        Me.SettingToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SettingToolStripMenuItem.Text = "Setting"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'StockGudangToolStripMenuItem
        '
        Me.StockGudangToolStripMenuItem.Name = "StockGudangToolStripMenuItem"
        Me.StockGudangToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.StockGudangToolStripMenuItem.Text = "Stock Gudang"
        '
        'LaporanToolStripMenuItem
        '
        Me.LaporanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GajiToolStripMenuItem, Me.LaporanTugasToolStripMenuItem, Me.LaporanStockGudangToolStripMenuItem})
        Me.LaporanToolStripMenuItem.Name = "LaporanToolStripMenuItem"
        Me.LaporanToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.LaporanToolStripMenuItem.Text = "Laporan"
        '
        'GajiToolStripMenuItem
        '
        Me.GajiToolStripMenuItem.Name = "GajiToolStripMenuItem"
        Me.GajiToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.GajiToolStripMenuItem.Text = "Laporan Gaji"
        '
        'LaporanTugasToolStripMenuItem
        '
        Me.LaporanTugasToolStripMenuItem.Name = "LaporanTugasToolStripMenuItem"
        Me.LaporanTugasToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.LaporanTugasToolStripMenuItem.Text = "Laporan Tugas"
        '
        'DataToolStripMenuItem
        '
        Me.DataToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportKaryawanToolStripMenuItem, Me.ImportPenjualanToolStripMenuItem})
        Me.DataToolStripMenuItem.Name = "DataToolStripMenuItem"
        Me.DataToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.DataToolStripMenuItem.Text = "Data"
        '
        'ImportKaryawanToolStripMenuItem
        '
        Me.ImportKaryawanToolStripMenuItem.Name = "ImportKaryawanToolStripMenuItem"
        Me.ImportKaryawanToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ImportKaryawanToolStripMenuItem.Text = "Import Karyawan"
        '
        'ImportPenjualanToolStripMenuItem
        '
        Me.ImportPenjualanToolStripMenuItem.Name = "ImportPenjualanToolStripMenuItem"
        Me.ImportPenjualanToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ImportPenjualanToolStripMenuItem.Text = "Import Penjualan"
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.WindowToolStripMenuItem.Text = "Window"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(764, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.Visible = False
        '
        'LaporanStockGudangToolStripMenuItem
        '
        Me.LaporanStockGudangToolStripMenuItem.Name = "LaporanStockGudangToolStripMenuItem"
        Me.LaporanStockGudangToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.LaporanStockGudangToolStripMenuItem.Text = "Laporan Stock Gudang"
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frmMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Onesto"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents UserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserCardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TaskManagementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TugasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DepartemenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TemplateTugasToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TugasToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DelegasiTugasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportKaryawanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportPenjualanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaporanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GajiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaporanTugasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogOutToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GantiPasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StockToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StockGudangToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LaporanStockGudangToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
