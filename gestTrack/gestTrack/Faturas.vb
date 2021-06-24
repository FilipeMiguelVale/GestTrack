Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Public Class Faturas

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
                RemoveContact(CType(ListBox1.SelectedItem, Faturas_obj).Codigo)
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
        Dim arm As New Faturas_obj
        Try
            If txtID.Text Is Nothing Or txtID.Text = "" Then
                arm.Codigo = 0
            Else
                arm.Codigo = txtID.Text
            End If

            arm.Descricao = txtDescricao.Text
            arm.Nome = txtNome.Text
            arm.Data = DateTimePicker1.Value

            If dropMovimento.SelectedIndex = -1 Then
                arm.Movimento = -1
            Else
                arm.Movimento = CType(dropMovimento.Items.Item(dropMovimento.SelectedIndex), Movimento_obj).Atividade
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

        CMD.CommandText = "execute GestTrack.AllBills"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox1.Items.Clear()
        dropMovimento.Items.Clear()
        While RDR.Read
            Dim C As New Faturas_obj
            C.Codigo = RDR.Item("Numero")
            C.Nome = RDR.Item("Nome")
            C.Descricao = RDR.Item("Descricao")
            C.Movimento = Convert.ToInt32(IIf(RDR.IsDBNull(RDR.GetOrdinal("Codigo_Movimento")), 0, RDR.Item("Codigo_Movimento")))
            C.Data = RDR.Item("Data")
            ListBox1.Items.Add(C)
        End While
        CN.Close()


        CMD.CommandText = "execute GestTrack.AllMovements"
        CN.Open()
        RDR = CMD.ExecuteReader
        dropMovimento.Items.Clear()
        While RDR.Read
            Dim C As New Movimento_obj
            C.Codigo = RDR.Item("Codigo")
            C.Nome = RDR.Item("Nome")
            C.Descricao = RDR.Item("Descricao")
            C.Data = RDR.Item("Data")
            C.Funcionario = RDR.Item("Codigo_Funcionario")
            C.Atividade = RDR.Item("Codigo_Atividade")
            dropMovimento.Items.Add(C)
        End While
        CN.Close()

        currentContact = 0
        ShowContact()
    End Sub

    Sub ShowContact()
        If ListBox1.Items.Count = 0 Or currentContact < 0 Then Exit Sub
        Dim arm As New Faturas_obj
        Dim aux As New Movimento_obj
        arm = CType(ListBox1.Items.Item(currentContact), Faturas_obj)

        txtID.Text = arm.Codigo
        txtDescricao.Text = arm.Descricao
        txtNome.Text = arm.Nome
        DateTimePicker1.Value = arm.Data
        supIndex = 0
        dropMovimento.SelectedIndex = -1
        For Each item In dropMovimento.Items
            aux = CType(item, Movimento_obj)
            If arm.Movimento = aux.Codigo Then
                dropMovimento.SelectedIndex = supIndex
            End If
            supIndex += 1
        Next

        CMD.CommandText = "select GestTrack.calcBillValue(" + arm.Codigo.ToString + ")"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        While RDR.Read
            txtValor.Text = RDR.Item("").ToString() + "€"
        End While
        CN.Close()
        CMD.CommandText = "select GestTrack.calcIvaValue(" + arm.Codigo.ToString + ")"
        CN.Open()
        RDR = CMD.ExecuteReader
        While RDR.Read
            txtIva.Text = RDR.Item("").ToString() + "€"
        End While
        CN.Close()

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

    Sub LockControls()
        txtID.ReadOnly = True
        txtDescricao.ReadOnly = True
        txtNome.ReadOnly = True
        dropMovimento.Enabled = False
        DateTimePicker1.Enabled = False


    End Sub

    Sub UnlockControls()
        txtID.ReadOnly = True
        txtDescricao.ReadOnly = False
        txtNome.ReadOnly = False
        dropMovimento.AllowDrop = False
        dropMovimento.Enabled = True
        DateTimePicker1.Enabled = True


    End Sub

    Sub ClearFields()
        txtID.Text = ""
        txtDescricao.Text = ""
        txtNome.Text = ""
        dropMovimento.Text = "Select"
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
        Label4.Visible = True
        Label9.Visible = True
        Label5.Visible = True
        Label3.Visible = True
        txtValor.Visible = True
        txtIva.Visible = True

        dropMovimento.Visible = True
        ListBox1.Visible = True
        txtID.Visible = True
        txtDescricao.Visible = True
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
        Label4.Visible = False
        Label9.Visible = False
        Label5.Visible = False
        Label3.Visible = False
        txtValor.Visible = False
        txtIva.Visible = False
        dropMovimento.Visible = False
        ListBox1.Visible = False
        txtID.Visible = False
        txtDescricao.Visible = False
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

    Private Sub SubmitContact(ByVal C As Faturas_obj)
        CMD.CommandText = "INSERT GestTrack.Fatura  (Nome,Descricao,[Data],Codigo_Movimento) " &
                          "VALUES (@Nome,@Descricao,@Data,@Super) "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@Descricao", C.Descricao)
        CMD.Parameters.AddWithValue("@Data", C.Data.ToString("yyyy-MM-dd"))
        If C.Movimento = -1 Then
            CMD.Parameters.AddWithValue("@Super", SqlInt32.Null)
        Else
            CMD.Parameters.AddWithValue("@Super", C.Movimento)
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


    Private Sub UpdateContact(ByVal C As Faturas_obj)
        CMD.CommandText = "UPDATE GestTrack.Fatura " &
            "SET Nome = @Nome, " &
            "    Descricao = @Descricao, " &
            "    [Data] = @Data, " &
            "    Codigo_Movimento = @Super " &
            "WHERE Numero = @Codigo"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@Descricao", C.Descricao)
        CMD.Parameters.AddWithValue("@Data", C.Data.ToString("yyyy-MM-dd"))
        CMD.Parameters.AddWithValue("@Super", C.Movimento)
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
        CMD.CommandText = "DELETE GestTrack.Fatura WHERE Codigo=@contactID "
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


    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            currentContact = ListBox1.SelectedIndex
            ShowContact()
        End If
    End Sub
End Class