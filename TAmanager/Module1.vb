Imports System.Data.Odbc

Module Module1
    Public conn As OdbcConnection
    Public da As OdbcDataAdapter
    Public ds As DataSet
    Public cmd As OdbcCommand
    Public rd As OdbcDataReader

    Public strcon As String

    Public Sub konek()
        strcon = "Dsn=TAmanager;database=tugas_akhir;db=tugas_akhir;no_schema=1;port=3306;server=localhost;uid=root;user=root"
        conn = New OdbcConnection(strcon)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
End Module

