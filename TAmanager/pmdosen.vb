Public Class pmdosen
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Menggunakan metode CenterToScreen untuk menengahkan form
        Me.CenterToScreen()
    End Sub
    Private Sub FormPMDosen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Menggunakan informasi login yang disimpan untuk mengatur data di form PMDosen
        Dim username As String = My.Settings.DosenUsername
        Lblwelkum.Text = "Selamat datang, " & username & "!"
    End Sub
End Class