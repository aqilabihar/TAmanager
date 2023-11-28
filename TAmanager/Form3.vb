Public Class Form3
    Public Property mahasiswaNIM As String
    Dim FormMHS As New menuMHS
    Dim nim As String = My.Settings.MahasiswaNIM
    Private Sub FormMHS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Menggunakan nilai NIM yang disimpan dari form sebelumnya
        lblnim.Text = "NIM: " & nim

        ' ... (sisa kode form ini)
    End Sub
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class