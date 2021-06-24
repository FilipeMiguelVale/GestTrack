Imports System.Data.SqlClient

Public Class F_principal

    Dim CN = New SqlConnection("Data Source = 127.0.0.1,888 ;Initial Catalog = GestTrackDB; uid = SA; password = sqlBD_2021")

    Private Sub F_principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
        Dim frm As Armazem = New Armazem(CN)
        frm.ShowDialog()
        ''Armazem.ShowDialog()
        Me.Show()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Me.Hide()
        Dim frm As Clientes = New Clientes(CN)
        frm.ShowDialog()
        ''Clientes.ShowDialog()
        Me.Show()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Hide()
        Dim frm As Orcamentos = New Orcamentos(CN)
        frm.ShowDialog()
        ''Orcamentos.ShowDialog()
        Me.Show()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
        Dim frm As Eventos = New Eventos(CN)
        frm.ShowDialog()
        ''Eventos.ShowDialog()
        Me.Show()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Hide()
        Dim frm As Faturas = New Faturas(CN)
        frm.ShowDialog()
        ''Faturas.ShowDialog()
        Me.Show()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.Hide()
        Dim frm As Funcionarios = New Funcionarios(CN)
        frm.ShowDialog()
        ''Funcionarios.ShowDialog()
        Me.Show()
    End Sub
End Class