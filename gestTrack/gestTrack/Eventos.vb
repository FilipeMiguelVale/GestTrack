Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Public Class Eventos

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim currentContact As Integer
    Dim adding As Boolean
    Dim supIndex As Integer


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Me.Close()
    End Sub

    Private Sub bttnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnCancel.Click
        ListBox1.Enabled = True
        If ListBox1.Items.Count > 0 Then
            currentContact = ListBox1.SelectedIndex
            If currentContact < 0 Then currentContact = 0
            ShowContact()
        Else
            ClearFields()
            LockControls()
        End If
        ShowButtons()
    End Sub

    Private Sub bttnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnOK.Click
        Try
            SaveContact()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ListBox1.Enabled = True
        Dim idx As Integer = ListBox1.FindString(txtID.Text)
        ListBox1.SelectedIndex = idx
        ShowButtons()
    End Sub

    Private Sub bttnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnDelete.Click
        If ListBox1.SelectedIndex > -1 Then
            Try
                RemoveContact(CType(ListBox1.SelectedItem, Atividade_obj).Codigo)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            If currentContact = ListBox1.Items.Count Then currentContact = ListBox1.Items.Count - 1
            If currentContact = -1 Then
                ClearFields()
                MsgBox("There are no more contacts")
            Else
                ShowContact()
            End If
        End If
    End Sub

    Private Sub bttnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttnAdd.Click
        adding = True
        ClearFields()
        HideButtons()
        ListBox1.Enabled = False
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            MsgBox("There are " & ListBox1.Items.Count.ToString &
                      " contacts in the database")
            e.Handled = True
        End If
    End Sub

    Private Sub Form1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        ' If we're not in EDIT mode, reject keystrokes
        If Not bttnOK.Visible Then
            e.Handled = True
        End If
    End Sub

    Private Function SaveContact() As Boolean
        Dim arm As New Atividade_obj
        Try
            If txtID.Text Is Nothing Or txtID.Text = "" Then
                arm.Codigo = 0
            Else
                arm.Codigo = txtID.Text
            End If

            arm.Descricao = txtDescricao.Text
            arm.Data_Inicio = DateTimePickerInicio.Value
            arm.Data_Fim = DateTimePickerFim.Value
            arm.Nome = txtNome.Text

            arm.Cliente = CType(dropCliente.Items.Item(dropCliente.SelectedIndex), Cliente_obj).NifCliente



        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        If adding Then
            SubmitContact(arm)
            ListBox1.Items.Add(arm)
        Else
            UpdateContact(arm)
            ListBox1.Items(currentContact) = arm
        End If
        Return True
    End Function

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        showAll()
        LockControls()

        CMD.CommandText = "exec GestTrack.AllActivities"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox1.Items.Clear()
        While RDR.Read
            Dim C As New Atividade_obj
            C.Codigo = RDR.Item("Codigo")
            C.Nome = RDR.Item("Nome")
            C.Descricao = RDR.Item("Descricao")
            C.Cliente = RDR.Item("Cliente")
            C.Data_Inicio = RDR.Item("Data_Inicio")
            C.Data_Fim = RDR.Item("Data_Fim")
            ListBox1.Items.Add(C)
        End While
        CN.Close()

        CMD.CommandText = "execute GestTrack.AllClients"
        CN.Open()
        RDR = CMD.ExecuteReader
        dropCliente.Items.Clear()
        While RDR.Read
            Dim C As New Cliente_obj
            C.NomeCliente = RDR.Item("Nome")
            C.EmailCliente = RDR.Item("Email")
            C.NifCliente = RDR.Item("Nif")
            C.MoradaCliente = RDR.Item("Morada")
            C.TelemovelCliente = RDR.Item("Telemovel")
            dropCliente.Items.Add(C)

        End While
        CN.Close()

        currentContact = 0
        ShowContact()
    End Sub

    Sub ShowContact()
        If ListBox1.Items.Count = 0 Or currentContact < 0 Then Exit Sub
        Dim arm As New Atividade_obj
        Dim aux As New Cliente_obj
        arm = CType(ListBox1.Items.Item(currentContact), Atividade_obj)

        txtID.Text = arm.Codigo
        txtDescricao.Text = arm.Descricao
        txtNome.Text = arm.Nome
        DateTimePickerFim.Value = arm.Data_Fim
        DateTimePickerInicio.Value = arm.Data_Inicio

        supIndex = 0
        dropCliente.SelectedIndex = -1
        For Each item In dropCliente.Items
            aux = CType(item, Cliente_obj)
            If arm.Cliente = aux.NifCliente Then
                dropCliente.SelectedIndex = supIndex

            End If
            supIndex += 1

        Next


    End Sub

    Private Sub bttnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnEdit.Click
        currentContact = ListBox1.SelectedIndex
        If currentContact <= -1 Then
            MsgBox("Please select a contact to edit")
            Exit Sub
        End If
        adding = False
        HideButtons()
        ListBox1.Enabled = False
    End Sub
    Public Sub New(ByVal sql As SqlConnection)
        InitializeComponent()
        CN = sql
        CMD = New SqlCommand
        CMD.Connection = CN
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '' Change this line...
        ''CN = New SqlConnection("data source=127.0.0.1:888;integrated security=true;initial catalog=Northwind")
        ''CN = New SqlConnection("Data Source = 127.0.0.1,888 ;Initial Catalog = GestTrackDB; uid = SA; password = sqlBD_2021")

        CMD = New SqlCommand
        CMD.Connection = CN
        ListBox1.Items.Clear()
        ClearFields()
        hideAll()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            currentContact = ListBox1.SelectedIndex
            ShowContact()
        End If
    End Sub

    Sub LockControls()
        txtID.ReadOnly = True
        txtDescricao.ReadOnly = True
        txtNome.ReadOnly = True
        DateTimePickerFim.Enabled = False
        DateTimePickerInicio.Enabled = False
        dropCliente.Enabled = False
        CheckBox1.Enabled = False

    End Sub

    Sub UnlockControls()
        txtID.ReadOnly = True
        txtDescricao.ReadOnly = False
        txtNome.ReadOnly = False
        DateTimePickerFim.Enabled = True
        DateTimePickerInicio.Enabled = True
        dropCliente.Enabled = True
        CheckBox1.Enabled = False


    End Sub

    Sub ClearFields()
        txtID.Text = ""
        txtDescricao.Text = ""
        txtNome.Text = ""
    End Sub

    Sub HideButtons()
        UnlockControls()
        bttnAdd.Visible = False
        bttnDelete.Visible = False
        bttnEdit.Visible = False
        bttnOK.Visible = True
        bttnCancel.Visible = True
    End Sub

    Sub showAll()
        Label1.Visible = True
        Label11.Visible = True
        Label2.Visible = True
        Label3.Visible = True
        Label4.Visible = True

        CheckBox1.Visible = True
        ListBox1.Visible = True
        txtID.Visible = True
        txtDescricao.Visible = True
        txtNome.Visible = True
        DateTimePickerFim.Visible = True
        DateTimePickerInicio.Visible = True
        dropCliente.Visible = True

        bttnAdd.Visible = True
        bttnDelete.Visible = True
        bttnEdit.Visible = True
        bttnOK.Visible = False
        bttnCancel.Visible = False
    End Sub

    Sub hideAll()
        Label1.Visible = False
        Label11.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        CheckBox1.Visible = False
        ListBox1.Visible = False
        txtID.Visible = False
        txtDescricao.Visible = False
        txtNome.Visible = False
        DateTimePickerFim.Visible = False
        DateTimePickerInicio.Visible = False
        bttnAdd.Visible = False
        bttnDelete.Visible = False
        bttnEdit.Visible = False
        bttnOK.Visible = False
        bttnCancel.Visible = False
        dropCliente.Visible = False
    End Sub

    Sub ShowButtons()
        LockControls()
        bttnAdd.Visible = True
        bttnDelete.Visible = True
        bttnEdit.Visible = True
        bttnOK.Visible = False
        bttnCancel.Visible = False
    End Sub

    Private Sub SubmitContact(ByVal C As Atividade_obj)
        CMD.CommandText = "INSERT GestTrack.Atividade  (Nome,Descricao,Data_Inicio,Data_Fim,Cliente) " &
                          "VALUES (@Nome,@Descricao,@DataI, @DataF,@Super) "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@Descricao", C.Descricao)
        CMD.Parameters.AddWithValue("@DataI", C.Data_Inicio.ToString("yyyy-MM-dd"))
        CMD.Parameters.AddWithValue("@DataF", C.Data_Fim.ToString("yyyy-MM-dd"))
        If C.Cliente = -1 Then
            CMD.Parameters.AddWithValue("@Super", SqlInt32.Null)
        Else
            CMD.Parameters.AddWithValue("@Super", C.Cliente)
        End If

        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub


    Private Sub UpdateContact(ByVal C As Atividade_obj)
        CMD.CommandText = "UPDATE GestTrack.Atividade " &
            "SET Nome = @Nome, " &
            "    Descricao = @Descricao, " &
            "    Data_inicio = @DataI, " &
            "    Data_Fim = @DataF " &
            "WHERE Codigo = @Codigo"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@codigo", C.Codigo)
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@Descricao", C.Descricao)
        CMD.Parameters.AddWithValue("@DataI", C.Data_Inicio.ToString("yyyy-MM-dd"))
        CMD.Parameters.AddWithValue("@DataF", C.Data_Fim.ToString("yyyy-MM-dd"))
        CMD.Parameters.AddWithValue("@Super", C.Cliente)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub

    Private Sub RemoveContact(ByVal ContactID As Integer)
        CMD.CommandText = "DELETE GestTrack.Atividade WHERE Codigo=@contactID "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@contactID", ContactID)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to delete contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            DateTimePickerFim.Visible = True
        Else
            DateTimePickerFim.Visible = False
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class