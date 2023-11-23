Public Class login
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Menggunakan metode CenterToScreen untuk menengahkan form
        Me.CenterToScreen()
    End Sub


    Sub switchppanel(ByVal panel As Form)
        Panel1.Controls.Clear()
        panel.TopLevel = False
        Panel1.Controls.Add(panel)
        panel.Show()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        switchppanel(loginMHS)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        switchppanel(Logindosen)
    End Sub

End Class
