Imports System.Data.Odbc

Public Class ArsipRiwayat
    Private Sub ArsipRiwayat_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    ' Mengisi combo box dengan daftar judul tugas akhir
    Private Sub IsiComboJudul()
        ' Gantilah ini dengan implementasi sesuai dengan kebutuhan Anda
        ' Misalnya, lakukan kueri ke database untuk mendapatkan daftar judul tugas akhir
        Using connection As New OdbcConnection("Dsn=TAmanager;database=tugas_akhir;db=tugas_akhir;no_schema=1;port=3306;server=localhost;uid=root;user=root")
            connection.Open()
            Dim query As String = "SELECT Judul FROM TugasAkhir"
            Using command As New OdbcCommand(query, connection)
                Dim reader As OdbcDataReader = command.ExecuteReader()
                While reader.Read()
                    ComboBox1.Items.Add(reader("Judul").ToString())
                End While
            End Using
        End Using
    End Sub

    ' Tombol Tampilkan untuk menampilkan informasi tugas akhir
    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Ambil judul yang dipilih dari combo box
        Dim judulTugasAkhir As String = ComboBox1.SelectedItem.ToString()

        ' Gantilah ini dengan implementasi sesuai dengan kebutuhan Anda
        ' Misalnya, lakukan kueri ke database untuk mendapatkan informasi tugas akhir berdasarkan judul
        Using connection As New OdbcConnection("Dsn=TAmanager;database=tugas_akhir;db=tugas_akhir;no_schema=1;port=3306;server=localhost;uid=root;user=root")
            connection.Open()
            Dim query As String = "SELECT Mahasiswa.Nama AS NamaMahasiswa, Dosen.Nama AS NamaDosen, TugasAkhir.Judul " &
                                  "FROM TugasAkhir " &
                                  "JOIN Mahasiswa ON TugasAkhir.Mahasiswa_NIM = Mahasiswa.NIM " &
                                  "JOIN Dosen ON TugasAkhir.Dosen_Pembimbing_NIP = Dosen.NIP " &
                                  "WHERE TugasAkhir.Judul = ?"
            Using command As New OdbcCommand(query, connection)
                command.Parameters.AddWithValue("judul", judulTugasAkhir)
                Dim reader As OdbcDataReader = command.ExecuteReader()
                If reader.Read() Then
                    ' Tampilkan informasi pada label atau kontrol lainnya
                    txtmhs.Text = "Nama Mahasiswa: " & reader("NamaMahasiswa").ToString()
                    txtdsn.Text = "Nama Dosen Pembimbing: " & reader("NamaDosen").ToString()
                    txtjudul.Text = "Judul Tugas Akhir: " & reader("Judul").ToString()
                Else
                    ' Pesan jika tidak ada data yang ditemukan
                    MessageBox.Show("Tidak ada data tugas akhir yang sesuai dengan judul yang dipilih.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Using
        End Using
    End Sub

    ' ...

    ' Pada saat load form, isi combo box dengan judul tugas akhir
    Private Sub FormPenampilArsip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IsiComboJudul()
    End Sub
End Class