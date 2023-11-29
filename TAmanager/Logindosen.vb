Imports System.Data.Odbc

Public Class Logindosen
    Dim connectionString As String = "Dsn=TAmanager;database=tugas_akhir;db=tugas_akhir;no_schema=1;port=3306;server=localhost;uid=root;user=root"
    Dim connection As New OdbcConnection(connectionString)

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim username As String = txtusername.Text
        Dim password As String = txtpassword.Text

        If AuthenticateUser(username, password) Then
            MessageBox.Show("Login berhasil!")

            ' Menyimpan informasi login untuk penggunaan di form selanjutnya
            My.Settings.DosenUsername = username
            My.Settings.Save()

            ' Buka form PMDosen
            Dim formPMDosen As New pmdosen()
            formPMDosen.Show()

            ' Menutup form login
            Me.Hide()
        Else
            MessageBox.Show("Login gagal. Silakan periksa kembali username dan password Anda.")
        End If
    End Sub

    Private Function AuthenticateUser(username As String, password As String) As Boolean
        Try
            connection.Open()
            Dim query As String = "SELECT COUNT(*) FROM Dosen WHERE Nama = ? AND TanggalLahir = ?"
            Dim cmd As New OdbcCommand(query, connection)
            cmd.Parameters.AddWithValue("@Nama", username)
            cmd.Parameters.AddWithValue("@TanggalLahir", password)

            ' Menggunakan COUNT(*) untuk memeriksa apakah dosen dengan nama dan tanggal lahir tersebut ada
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            Return count > 0
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            Return False
        Finally
            connection.Close()
        End Try
    End Function

    Private Sub Logindosen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class