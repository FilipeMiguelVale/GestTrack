Public Class Initial
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Me.Hide()
        F_principal.ShowDialog()

        Me.Close()
    End Sub
End Class
