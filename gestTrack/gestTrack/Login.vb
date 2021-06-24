Public Class Initial
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Me.Hide()
        F_principal.ShowDialog()

        Me.Close()
    End Sub

    Private Sub Initial_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
