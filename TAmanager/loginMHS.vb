
Imports System.Data.Odbc
Imports System.Windows

Public Class loginMHS
    ' Ganti dengan informasi koneksi yang sesuai dengan database Anda
    Dim connectionString As String = "Dsn=TAmanager;database=tugas_akhir;db=tugas_akhir;no_schema=1;port=3306;server=localhost;uid=root;user=root"

    Dim connection As New OdbcConnection(connectionString)

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nim As String = TextBox1.Text
        Dim password As String = TextBox2.Text

        If AuthenticateMahasiswa(nim, password) Then
            MessageBox.Show("Login berhasil!")

            ' Menyimpan informasi login untuk penggunaan di form selanjutnya
            My.Settings.MahasiswaNIM = nim
            My.Settings.Save()

            ' Buka form MHS
            Dim FormMHS As New menuMHS

            FormMHS.Show()
            FormMHS.mahasiswaNIM = nim

            ' Menutup form login
            Me.Hide()
            login.Hide()

        Else
            MessageBox.Show("Login gagal. Silakan periksa kembali NIM dan password Anda.")
        End If
    End Sub

    Private Function AuthenticateMahasiswa(nim As String, password As String) As Boolean
        Try
            connection.Open()
            Dim query As String = "SELECT COUNT(*) FROM Mahasiswa WHERE Nim = ? AND Tanggal_Lahir = ?"
            Dim cmd As New OdbcCommand(query, connection)
            cmd.Parameters.AddWithValue("@Nim", nim)
            cmd.Parameters.AddWithValue("@TanggalLahir", password)

            ' Menggunakan COUNT(*) untuk memeriksa apakah mahasiswa dengan NIM dan tanggal lahir tersebut ada
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            Return count > 0
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            Return False
        Finally
            connection.Close()
        End Try
    End Function

    Private Sub loginMHS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
End Class