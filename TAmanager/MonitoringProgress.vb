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
                        ' Ganti CInt dengan CType untuk menghindari exception jika ID_TugasAkhir tidak dapat dikonversi menjadi Integer
                        Dim idTugasAkhir As Integer = CType(reader("ID_TugasAkhir"), Integer)
                        Dim judulTugasAkhir As String = reader("Judul").ToString()
                        ComboBox1.Items.Add(New KeyValuePair(Of Integer, String)(idTugasAkhir, judulTugasAkhir))
                    End While
                End Using
            End Using
        End Using
    End Sub

    ' Tombol Tampilkan Progress untuk menampilkan progress tugas akhir yang dipilih
    Private Sub TampilkanMonitoringProgress()
        ' Pastikan ada item yang dipilih dalam combo box
        If ComboBox1.SelectedItem IsNot Nothing Then
            ' Gantilah connection_string_here dengan string koneksi ke database yang sesuai dengan sistem Anda.
            Using connection As New OdbcConnection("Dsn=TAmanager;database=tugas_akhir;db=tugas_akhir;no_schema=1;port=3306;server=localhost;uid=root;user=root")
                connection.Open()

                ' Ambil ID_TugasAkhir yang dipilih dari combo box
                Dim selectedItem As KeyValuePair(Of Integer, String) = DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of Integer, String))
                Dim idTugasAkhir As Integer = selectedItem.Key

                ' Kueri untuk mengambil data monitoring progress berdasarkan ID_TugasAkhir
                Dim query As String = "SELECT Catatan, Tahap, Tanggal_Monitoring " &
                                      "FROM MonitoringProgres " &
                                      "WHERE Mahasiswa_NIM = (SELECT Mahasiswa_NIM FROM TugasAkhir WHERE ID_TugasAkhir = ?)"

                Using command As New OdbcCommand(query, connection)
                    command.Parameters.AddWithValue("idTugasAkhir", idTugasAkhir)

                    ' Baca data dan tampilkan di DataGridView
                    Using adapter As New OdbcDataAdapter(command)
                        Dim dataTable As New DataTable()
                        adapter.Fill(dataTable)

                        ' Tampilkan data di DataGridView
                        DataGridView1.DataSource = dataTable
                    End Using
                End Using
            End Using
        End If
    End Sub

    Private Sub cmbJudulTugasAkhir_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Panggil fungsi untuk menampilkan monitoring progress saat pemilihan combo box berubah
        TampilkanMonitoringProgress()
    End Sub
End Class