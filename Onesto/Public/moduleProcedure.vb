Imports System.Data.SqlClient
Imports System.Data.OleDb

Module moduleProcedure
    Public str_user_name As String
    Public str_user_access As String
    Public p_Group As String
    Public p_CompanyName As String

    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Public Sub UpdSysInit(ByVal code As String, ByVal value As String)
        Try
            cmd = New SqlCommand("update sys_init set value = '" + value + "' where code = '" + code + "' ", cn)

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
        Catch ex As Exception
            MsgBox("Error message : " + ex.Message, vbCritical)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
        
    End Sub
End Module
