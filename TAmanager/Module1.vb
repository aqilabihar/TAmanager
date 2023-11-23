Imports System.Data.Odbc

Module Module1
    Public conn As OdbcConnection
    Public da As OdbcDataAdapter
    Public ds As DataSet
    Public cmd As OdbcCommand
    Public rd As OdbcDataReader

    Public strcon As String

    Public Sub konek()
        strcon = "Driver={MySQL ODBC 8.2 Driver};database=ta;server=localhost;uid=root"
        conn = New OdbcConnection(strcon)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
End Module

