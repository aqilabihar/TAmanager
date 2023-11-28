Public Class menuMHS
    Public Property mahasiswaNIM As String

    Sub switchppanel(ByVal panel As Form)
        Panel1.Controls.Clear()
        panel.TopLevel = False
        Panel1.Controls.Add(panel)
        panel.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

    End Sub
End Class