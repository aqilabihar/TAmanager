Imports System.Data.Odbc

Public Class MonitoringProgress
    ' Pada saat load form, isi combo box dengan tugas akhir yang berhubungan dengan NIP dosen
    Private Sub FormMonitoringTugasAkhir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ambil NIP dosen yang sedang login dari My.Settings
        Dim nipDosen As String = My.Settings.NIPdsn

        ' Isi combo box dengan tugas akhir yang berhubungan dengan NIP dosen
        IsiComboTugasAkhir(nipDosen)
    End Sub

    ' Fungsi untuk mengisi combo box dengan tugas akhir yang berhubungan dengan NIP dosen
    Private Sub IsiComboTugasAkhir(nipDosen As String)
        ' Gantilah ini dengan implementasi sesuai dengan kebutuhan Anda
        ' Misalnya, lakukan kueri ke database untuk mendapatkan tugas akhir yang berhubungan dengan NIP dosen
        Using connection As New OdbcConnection("Dsn=TAmanager;database=tugas_akhir;db=tugas_akhir;no_schema=1;port=3306;server=localhost;uid=root;user=root")
            connection.Open()
            Dim query As String = "SELECT ID_TugasAkhir, Judul FROM TugasAkhir WHERE Dosen_Pembimbing_NIP = ?"
            Using command As New OdbcCommand(query, connection)
                command.Parameters.AddWithValue("nipDosen", nipDosen)
                Using reader As OdbcDataReader = command.ExecuteReader()
                    ' Clear items di combo box sebelum menambahkan yang baru
                    ComboBox1.Items.Clear()

                    ' Tambahkan judul tugas akhir ke dalam combo box
                    While reader.Read()
                        Dim idTugasAkhir As Integer = CInt(reader("ID_TugasAkhir"))
                        Dim judulTugasAkhir As String = reader("Judul").ToString()
                        ComboBox1.Items.Add(New KeyValuePair(Of Integer, String)(idTugasAkhir, judulTugasAkhir))
                    End While
                End Using
            End Using
        End Using
    End Sub

    ' Tombol Tampilkan Progress untuk menampilkan progress tugas akhir yang dipilih
    Private Sub btnTampilkanProgress_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Ambil ID_TugasAkhir yang dipilih dari combo box
        Dim idTugasAkhir As Integer
        If ComboBox1.SelectedItem IsNot Nothing Then
            idTugasAkhir = DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of Integer, String)).Key
        Else
            MessageBox.Show("Pilih tugas akhir terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Gantilah ini dengan implementasi sesuai dengan kebutuhan Anda
        ' Misalnya, lakukan kueri ke database untuk mendapatkan progress tugas akhir
        Using connection As New OdbcConnection("Dsn=TAmanager;database=tugas_akhir;db=tugas_akhir;no_schema=1;port=3306;server=localhost;uid=root;user=root")
            connection.Open()
            Dim query As String = "SELECT Mahasiswa.Nama AS NamaMahasiswa, TugasAkhir.Judul, EvaluasiPenilaian.Nilai, EvaluasiPenilaian.Tanggal_Evaluasi " &
                                  "FROM TugasAkhir " &
                                  "JOIN Mahasiswa ON TugasAkhir.Mahasiswa_NIM = Mahasiswa.NIM " &
                                  "LEFT JOIN EvaluasiPenilaian ON TugasAkhir.ID_TugasAkhir = EvaluasiPenilaian.TugasAkhir_ID " &
                                  "WHERE TugasAkhir.ID_TugasAkhir = ?"
            Using command As New OdbcCommand(query, connection)
                command.Parameters.AddWithValue("idTugasAkhir", idTugasAkhir)
                Using adapter As New OdbcDataAdapter(command)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)

                    ' Tampilkan hasil progress di data grid
                    DataGridView1.DataSource = dataTable
                End Using
            End Using
        End Using
    End Sub

    ' ...
End Class