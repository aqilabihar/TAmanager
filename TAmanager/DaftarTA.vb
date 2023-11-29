Imports System.Data.Odbc
Imports System.Data.SqlClient

Public Class DaftarTA


    Private Sub FormPendaftaranTugasAkhir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' Ambil NIM mahasiswa yang sedang login dari My.Settings
            Dim nimMahasiswa As String = My.Settings.MahasiswaNIM

            ' Cek apakah mahasiswa sudah mendaftarkan tugas akhir sebelumnya
            If SudahMendaftar(nimMahasiswa) Then
                MessageBox.Show("Anda sudah mendaftarkan tugas akhir sebelumnya. Hanya satu pendaftaran diperbolehkan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

            ' Isi combo box dengan daftar dosen pembimbing
            IsiDosenPembimbingComboBox()
        End Sub

        ' Fungsi untuk mengecek apakah mahasiswa sudah mendaftar tugas akhir sebelumnya
        Private Function SudahMendaftar(nim As String) As Boolean
        ' Gantilah ini dengan implementasi sesuai dengan kebutuhan Anda
        ' Misalnya, lakukan kueri ke database untuk memeriksa apakah mahasiswa sudah mendaftar
        ' Saya asumsikan bahwa ada kolom di tabel TugasAkhir yang menyimpan NIM mahasiswa
        Using connection As New OdbcConnection("Dsn=TAmanager;database=tugas_akhir;db=tugas_akhir;no_schema=1;port=3306;server=localhost;uid=root;user=root")
            connection.Open()
            Dim query As String = "SELECT COUNT(*) FROM TugasAkhir WHERE Mahasiswa_NIM = ?"
            Using command As New OdbcCommand(query, connection)
                command.Parameters.AddWithValue("nim", nim)
                Dim count As Integer = CInt(command.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    End Function

        ' Mengisi combo box dengan daftar dosen pembimbing
        Private Sub IsiDosenPembimbingComboBox()
        ' Gantilah ini dengan implementasi sesuai dengan kebutuhan Anda
        ' Misalnya, lakukan kueri ke database untuk mendapatkan daftar dosen pembimbing
        ' Saya asumsikan bahwa Anda memiliki tabel Dosen dengan kolom NIP dan NamaDosen
        Using connection As New OdbcConnection("Dsn=TAmanager;database=tugas_akhir;db=tugas_akhir;no_schema=1;port=3306;server=localhost;uid=root;user=root")
            connection.Open()
            Dim query As String = "SELECT NIP, Nama FROM Dosen"
            Using command As New OdbcCommand(query, connection)
                Dim reader As OdbcDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim nip As String = reader("NIP").ToString()
                    Dim namaDosen As String = reader("Nama").ToString()
                    dosen.Items.Add($"{nip} - {namaDosen}")
                End While
            End Using
        End Using
    End Sub

    ' Tombol Simpan untuk menyimpan data pendaftaran
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles daftar.Click
        ' Ambil NIM mahasiswa yang sedang login dari My.Settings
        Dim nimMahasiswa As String = My.Settings.MahasiswaNIM

        ' Ambil NIP dari combo box Dosen Pembimbing
        Dim nipDosenPembimbing As String = dosen.Text.Split("-"c)(0).Trim()

        ' Gantilah ini dengan implementasi sesuai dengan kebutuhan Anda
        ' Misalnya, lakukan INSERT ke database untuk menyimpan data pendaftaran tugas akhir
        Using connection As New OdbcConnection("Dsn=TAmanager;database=tugas_akhir;db=tugas_akhir;no_schema=1;port=3306;server=localhost;uid=root;user=root")
            connection.Open()
            Dim query As String = "INSERT INTO TugasAkhir (Mahasiswa_NIM, Judul, Dosen_Pembimbing_NIP, Tanggal_Pendaftaran) VALUES (?, ?, ?, ?)"
            Using command As New OdbcCommand(query, connection)
                command.Parameters.AddWithValue("nim", nimMahasiswa)
                command.Parameters.AddWithValue("judul", judul.Text)
                command.Parameters.AddWithValue("nip", nipDosenPembimbing)
                command.Parameters.AddWithValue("tanggal_pendaftaran", DateTime.Now)
                command.ExecuteNonQuery()
                MessageBox.Show("Pendaftaran tugas akhir berhasil.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Using
        End Using
    End Sub

    ' Tombol Hapus untuk menghapus data pendaftaran jika sudah ada



End Class