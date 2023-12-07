Imports System.Data.Odbc
Imports System.Data.SqlClient

Public Class Progress

    ' Pada saat load form
    Private Sub FormInputMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set tanggal ke tanggal sekarang
        DateTimePicker1.Value = DateTime.Now

        ' Ambil NIM mahasiswa dari My.Settings
        Dim nimMahasiswa As String = My.Settings.MahasiswaNIM

        ' Gantilah ini dengan implementasi sesuai dengan kebutuhan Anda
        ' Misalnya, lakukan kueri ke database untuk mendapatkan nama mahasiswa berdasarkan NIM
        Using connection As New OdbcConnection("Dsn=TAmanager;database=tugas_akhir;db=tugas_akhir;no_schema=1;port=3306;server=localhost;uid=root;user=root")
            connection.Open()
            Dim query As String = "SELECT Nama FROM Mahasiswa WHERE NIM = ?"
            Using command As New OdbcCommand(query, connection)
                command.Parameters.AddWithValue("nim", nimMahasiswa)
                Dim reader As OdbcDataReader = command.ExecuteReader()
                If reader.Read() Then
                    ' Set nama mahasiswa ke label atau kontrol lainnya
                    nama.Text = reader("Nama").ToString()
                Else
                    ' Pesan jika NIM tidak ditemukan
                    MessageBox.Show("NIM mahasiswa tidak valid.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Close()
                End If
            End Using
        End Using
    End Sub

    ' Tombol Simpan untuk menyimpan monitoring progress
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles input.Click
        ' Ambil NIM mahasiswa dari My.Settings
        Dim nimMahasiswa As String = My.Settings.MahasiswaNIM
        ' Ambil tanggal dari kontrol DateTimePicker
        Dim tanggalMonitoring As DateTime = DateTimePicker1.Value
        ' Ambil tahap dari kontrol TextBox (sesuaikan dengan kontrol yang Anda gunakan)
        Dim tahap As String = tahapan.Text

        Dim catatan As String = txtcatatan.Text

        ' Gantilah ini dengan implementasi sesuai dengan kebutuhan Anda
        ' Misalnya, lakukan INSERT ke database untuk menyimpan data monitoring progress
        Using connection As New OdbcConnection("Dsn=TAmanager;database=tugas_akhir;db=tugas_akhir;no_schema=1;port=3306;server=localhost;uid=root;user=root")
            connection.Open()
            Dim query As String = "INSERT INTO MonitoringProgres (Mahasiswa_NIM, Tanggal_monitoring, Tahap, catatan) VALUES (?, ?, ?, ?)"
            Using command As New OdbcCommand(query, connection)
                command.Parameters.AddWithValue("nim", nimMahasiswa)
                command.Parameters.AddWithValue("tanggal", tanggalMonitoring)
                command.Parameters.AddWithValue("tahap", tahap)
                command.Parameters.AddWithValue("catatan", catatan)
                command.ExecuteNonQuery()
                MessageBox.Show("Monitoring progress berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Tambahkan logika lain yang diperlukan setelah menyimpan
                ' Contoh: Me.Close() untuk menutup formulir setelah menyimpan
            End Using
        End Using
    End Sub

    ' ...
End Class