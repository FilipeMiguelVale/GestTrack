Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Public Class Orcamentos

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
                RemoveContact(CType(ListBox1.SelectedItem, Orcamento_obj).Codigo)
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
        Dim arm As New Orcamento_obj
        Try
            If txtID.Text Is Nothing Or txtID.Text = "" Then
                arm.Codigo = 0
            Else
                arm.Codigo = txtID.Text
            End If

            arm.Valor = txtValor.Text
            arm.Iva = txtIva.Text
            arm.validade = txtValidade.Text
            arm.Nome = txtNome.Text
            arm.Data = DateTimePicker1.Value

            If dropAtividade.SelectedIndex = -1 Then
                arm.Atividade = -1
            Else
                arm.Atividade = CType(ListBox1.Items.Item(dropAtividade.SelectedIndex), Orcamento_obj).Atividade
            End If



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

        CMD.CommandText = "execute GestTrack.AllBudget"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox1.Items.Clear()
        dropAtividade.Items.Clear()
        While RDR.Read
            Dim C As New Orcamento_obj
            C.Codigo = RDR.Item("Codigo")
            C.Nome = RDR.Item("Nome")
            C.validade = RDR.Item("Validade")
            C.Valor = RDR.Item("Valor")
            C.Iva = RDR.Item("iva")
            C.Atividade = Convert.ToInt32(IIf(RDR.IsDBNull(RDR.GetOrdinal("Atividade_Codigo")), 0, RDR.Item("Atividade_Codigo")))
            C.Data = RDR.Item("Data_Realizado")
            ListBox1.Items.Add(C)
        End While
        CN.Close()

        CMD.CommandText = "execute GestTrack.AllActivities"
        CN.Open()
        RDR = CMD.ExecuteReader
        dropAtividade.Items.Clear()
        While RDR.Read
            Dim C As New Atividade_obj
            C.Codigo = RDR.Item("Codigo")
            C.Nome = RDR.Item("Nome")
            C.Descricao = RDR.Item("Descricao")
            C.Cliente = RDR.Item("Cliente")
            C.Data_Inicio = RDR.Item("Data_Inicio")
            C.Data_Fim = RDR.Item("Data_Fim")
            dropAtividade.Items.Add(C)
        End While
        CN.Close()

        currentContact = 0
        ShowContact()
    End Sub

    Sub ShowContact()
        If ListBox1.Items.Count = 0 Or currentContact < 0 Then Exit Sub
        Dim arm As New Orcamento_obj
        Dim aux As New Atividade_obj
        arm = CType(ListBox1.Items.Item(currentContact), Orcamento_obj)

        txtID.Text = arm.Codigo
        txtValor.Text = arm.Valor
        txtIva.Text = arm.Iva
        txtValidade.Text = arm.validade
        txtNome.Text = arm.Nome
        DateTimePicker1.Value = arm.Data
        supIndex = 0
        dropAtividade.SelectedIndex = -1
        For Each item In dropAtividade.Items
            aux = CType(item, Atividade_obj)
            If arm.Atividade = aux.Codigo Then
                dropAtividade.SelectedIndex = supIndex
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

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '' Change this line...
        ''CN = New SqlConnection("data source=127.0.0.1:888;integrated security=true;initial catalog=Northwind")
        CN = New SqlConnection("Data Source = 127.0.0.1,888 ;Initial Catalog = GestTrackDB; uid = SA; password = sqlBD_2021")

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
        txtValor.ReadOnly = True
        txtIva.ReadOnly = True
        txtValidade.ReadOnly = True
        txtNome.ReadOnly = True
        dropAtividade.Enabled = False
        DateTimePicker1.Enabled = False


    End Sub

    Sub UnlockControls()
        txtID.ReadOnly = True
        txtValor.ReadOnly = False
        txtIva.ReadOnly = False
        txtValidade.ReadOnly = False
        txtNome.ReadOnly = False
        dropAtividade.AllowDrop = False
        dropAtividade.Enabled = True
        DateTimePicker1.Enabled = True


    End Sub

    Sub ClearFields()
        txtID.Text = ""
        txtValor.Text = ""
        txtIva.Text = ""
        txtValidade.Text = ""
        txtNome.Text = ""
        dropAtividade.Text = "Select"
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
        Label5.Visible = True
        Label9.Visible = True

        dropAtividade.Visible = True
        ListBox1.Visible = True
        txtID.Visible = True
        txtValor.Visible = True
        txtIva.Visible = True
        txtValidade.Visible = True
        txtNome.Visible = True
        DateTimePicker1.Visible = True

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
        Label5.Visible = False
        Label9.Visible = False
        dropAtividade.Visible = False
        ListBox1.Visible = False
        txtID.Visible = False
        txtValor.Visible = False
        txtIva.Visible = False
        txtValidade.Visible = False
        txtNome.Visible = False
        DateTimePicker1.Visible = False
        bttnAdd.Visible = False
        bttnDelete.Visible = False
        bttnEdit.Visible = False
        bttnOK.Visible = False
        bttnCancel.Visible = False
    End Sub

    Sub ShowButtons()
        LockControls()
        bttnAdd.Visible = True
        bttnDelete.Visible = True
        bttnEdit.Visible = True
        bttnOK.Visible = False
        bttnCancel.Visible = False
    End Sub

    Private Sub SubmitContact(ByVal C As Orcamento_obj)
        CMD.CommandText = "INSERT GestTrack.Orcamento  (Nome,Validade,valor,iva,Data_Realizado,Atividade_Codigo) " &
                          "VALUES (@Nome,@Validade,@Valor, @Iva,@Data,@Super) "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@Validade", C.validade)
        CMD.Parameters.AddWithValue("@Valor", C.Valor)
        CMD.Parameters.AddWithValue("@Iva", C.Iva)
        CMD.Parameters.AddWithValue("@Data", C.Data.ToString("yyyy-MM-dd"))
        If C.Atividade = -1 Then
            CMD.Parameters.AddWithValue("@Super", SqlInt32.Null)
        Else
            CMD.Parameters.AddWithValue("@Super", C.Atividade)
        End If

        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update Orçamento in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub


    Private Sub UpdateContact(ByVal C As Orcamento_obj)
        CMD.CommandText = "UPDATE GestTrack.Orcamento " &
            "SET Nome = @Nome, " &
            "    Validade = @Validade, " &
            "    valor = @Valor, " &
            "    iva = @Iva, " &
            "    Data_Realizado = @Data, " &
            "    Atividade_Codigo = @Super " &
            "WHERE N_Interno = @Codigo"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@Validade", C.validade)
        CMD.Parameters.AddWithValue("@Valor", C.Valor)
        CMD.Parameters.AddWithValue("@Iva", C.Iva)
        CMD.Parameters.AddWithValue("@Data", C.Data.ToString("yyyy-MM-dd"))
        CMD.Parameters.AddWithValue("@Super", C.Atividade)
        CMD.Parameters.AddWithValue("@Codigo", C.Codigo)
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
        CMD.CommandText = "DELETE GestTrack.Orcamento WHERE Codigo=@contactID "
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

End Class