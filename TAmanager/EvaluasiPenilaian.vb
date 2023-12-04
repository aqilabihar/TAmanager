Imports System.Data.Odbc

Public Class EvaluasiPenilaian
    ' Pada saat load form, isi combo box dengan daftar judul tugas akhir yang belum dievaluasi
    Dim connection As OdbcConnection
    Dim command As OdbcCommand
    Dim adapter As OdbcDataAdapter
    Dim dataTable As DataTable

    ' Pada saat load form, isi combo box dengan judul tugas akhir berhubungan dengan NIP dosen
    Private Sub FormEvaluasiDosen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IsiComboJudul()
    End Sub

    ' Mengisi combo box dengan daftar judul tugas akhir yang berhubungan dengan NIP dosen
    Private Sub IsiComboJudul()
        ' Ambil NIP dosen yang sedang login dari My.Settings
        Dim nipDosen As String = My.Settings.NIPdsn

        ' Gantilah ini dengan implementasi sesuai dengan kebutuhan Anda
        ' Misalnya, lakukan kueri ke database untuk mendapatkan daftar judul tugas akhir berhubungan dengan NIP dosen
        Using connection As New OdbcConnection("Dsn=TAmanager;database=tugas_akhir;db=tugas_akhir;no_schema=1;port=3306;server=localhost;uid=root;user=root")
            connection.Open()
            Dim query As String = "SELECT DISTINCT TugasAkhir.Judul " &
                                  "FROM TugasAkhir " &
                                  "WHERE TugasAkhir.Dosen_Pembimbing_NIP = ?"
            Using command As New OdbcCommand(query, connection)
                command.Parameters.AddWithValue("nip", nipDosen)
                Dim reader As OdbcDataReader = command.ExecuteReader()
                While reader.Read()
                    ComboBox1.Items.Add(reader("Judul").ToString())
                End While
            End Using
        End Using
    End Sub

    ' Tombol Tampilkan untuk menampilkan hasil evaluasi
    Private Sub btnTampilkanEvaluasi_Click(sender As Object, e As EventArgs) Handles btntampil.Click

        ' Ambil NIP dosen yang sedang login dari My.Settings
        Dim nipDosen As String = My.Settings.NIPdsn
        ' Ambil judul yang dipilih dari combo box
        If ComboBox1 IsNot Nothing AndAlso ComboBox1.SelectedItem IsNot Nothing Then
            Dim judulTugasAkhir As String = ComboBox1.SelectedItem.ToString()
            Using connection As New OdbcConnection("Dsn=TAmanager;database=tugas_akhir;db=tugas_akhir;no_schema=1;port=3306;server=localhost;uid=root;user=root")
                connection.Open()
                Dim query As String = "SELECT Mahasiswa.Nama AS NamaMahasiswa, Dosen.Nama AS NamaDosen, EvaluasiPenilaian.Nilai, EvaluasiPenilaian.Ulasan " &
                                      "FROM EvaluasiPenilaian " &
                                      "JOIN TugasAkhir ON EvaluasiPenilaian.TugasAkhir_ID = TugasAkhir.ID_TugasAkhir " &
                                      "JOIN Mahasiswa ON TugasAkhir.Mahasiswa_NIM = Mahasiswa.NIM " &
                                      "JOIN Dosen ON EvaluasiPenilaian.Dosen_NIP = Dosen.NIP " &
                                      "WHERE TugasAkhir.Judul = ? AND EvaluasiPenilaian.Dosen_NIP = ?"
                Using command As New OdbcCommand(query, connection)
                    command.Parameters.AddWithValue("judul", judulTugasAkhir)
                    command.Parameters.AddWithValue("nip", nipDosen)
                    Dim adapter As New OdbcDataAdapter(command)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)

                    ' Tampilkan hasil evaluasi di data grid
                    DataGridView1.DataSource = dataTable
                End Using
            End Using
        Else
            MessageBox.Show("Harap pilih judul sebelum mengeklik 'Tampilkan'.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        ' Gantilah ini dengan implementasi sesuai dengan kebutuhan Anda
        ' Misalnya, lakukan kueri ke database untuk mendapatkan hasil evaluasi berdasarkan judul dan NIP dosen

    End Sub

    ' Tombol Simpan Evaluasi untuk menyimpan atau mengupdate hasil evaluasi
    Private Sub btnSimpanEvaluasi_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Ambil NIP dosen yang sedang login dari My.Settings
        Dim nipDosen As String = My.Settings.NIPdsn
        ' Ambil judul yang dipilih dari combo box
        Dim judulTugasAkhir As String = ComboBox1.SelectedItem.ToString()

        ' Gantilah ini dengan implementasi sesuai dengan kebutuhan Anda
        ' Misalnya, lakukan kueri ke database untuk menyimpan atau mengupdate hasil evaluasi
        Using connection As New OdbcConnection("Dsn=TAmanager;database=tugas_akhir;db=tugas_akhir;no_schema=1;port=3306;server=localhost;uid=root;user=root")
            connection.Open()
            Dim queryInsert As String = "INSERT INTO EvaluasiPenilaian (TugasAkhir_ID, Dosen_NIP, Nilai, Ulasan, Tanggal_Evaluasi) " &
                                       "VALUES ((SELECT ID_TugasAkhir FROM TugasAkhir WHERE Judul = ?), ?, ?, ?, ?)"
            Dim queryUpdate As String = "UPDATE EvaluasiPenilaian " &
                                       "SET Nilai = ?, Ulasan = ?, Tanggal_Evaluasi = ? " &
                                       "WHERE TugasAkhir_ID = (SELECT ID_TugasAkhir FROM TugasAkhir WHERE Judul = ?) AND Dosen_NIP = ?"

            Using commandInsert As New OdbcCommand(queryInsert, connection)
                commandInsert.Parameters.AddWithValue("judul", judulTugasAkhir)
                commandInsert.Parameters.AddWithValue("nip", nipDosen)
                commandInsert.Parameters.AddWithValue("nilai", txtnilai.Text)
                commandInsert.Parameters.AddWithValue("ulasan", txteval.Text)
                commandInsert.Parameters.AddWithValue("tanggal", DateTime.Now)
                commandInsert.ExecuteNonQuery()
            End Using

            Using commandUpdate As New OdbcCommand(queryUpdate, connection)
                commandUpdate.Parameters.AddWithValue("nilai", txtNilai.Text)
                commandUpdate.Parameters.AddWithValue("ulasan", txteval.Text)
                commandUpdate.Parameters.AddWithValue("tanggal", DateTime.Now)
                commandUpdate.Parameters.AddWithValue("judul", judulTugasAkhir)
                commandUpdate.Parameters.AddWithValue("nip", nipDosen)
                commandUpdate.ExecuteNonQuery()
            End Using

            MessageBox.Show("Evaluasi tugas akhir berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub

    ' Fungsi untuk menyegarkan atau perbarui tampilan data evaluasi
    Private Sub RefreshDataEvaluasi()
        ' Gantilah ini dengan implementasi sesuai dengan kebutuhan Anda
        ' Misalnya, panggil kembali data evaluasi dan perbarui tampilan
        ' Sesuaikan ini sesuai dengan kontrol atau tampilan yang Anda gunakan untuk menampilkan data evaluasi
        ' Contoh: dgvEvaluasi.DataSource = AmbilDataEvaluasi()
    End Sub

    ' Fungsi untuk menyegarkan atau perbarui tampilan data evaluasi


    ' Tombol Tampilkan Evaluasi untuk menampilkan evaluasi yang sudah ada


    ' ...

    ' Pada saat load form, panggil metode untuk menampilkan evaluasi yang sudah ada
    Private Sub FormEvaluasiTugasAkhirDosen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Panggil metode untuk menampilkan evaluasi yang sudah ada
        btnTampilkanEvaluasi_Click(sender, e)
    End Sub
End Class