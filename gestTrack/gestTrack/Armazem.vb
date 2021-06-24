Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Public Class Armazem

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim currentContact As Integer
    Dim adding As Boolean
    Dim toAdd = 0
    Dim options = ""


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Me.Close()
    End Sub

    Private Sub bttnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnCancel.Click

        If options = "listar" Then

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

        ElseIf options = "material" Then
            ListBox3.Enabled = True
            If ListBox3.Items.Count > 0 Then
                currentContact = ListBox3.SelectedIndex
                If currentContact < 0 Then currentContact = 0
                ShowMaterial()
            Else
                ClearFields()
                LockControls()
            End If
            ShowButtons()
        End If

    End Sub

    Private Sub bttnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnOK.Click
        If options = "listar" Then
            Try
                SaveContact()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            ListBox1.Enabled = True
            Dim idx As Integer = ListBox1.FindString(CodeID.Text)
            ListBox1.SelectedIndex = idx
            ShowButtons()
        ElseIf options = "material" Then
            Try
                SaveMaterial()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            ListBox3.Enabled = True
            Dim idx As Integer = ListBox3.FindString(CodeID.Text)
            ListBox3.SelectedIndex = idx
            ShowButtons()
        End If


    End Sub

    Private Sub bttnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnDelete.Click
        If options = "listar" Then
            If ListBox1.SelectedIndex > -1 Then
                Try
                    RemoveContact(CType(ListBox1.SelectedItem, Armazem_obj).IdArmazem)
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
        ElseIf options = "material" Then
            If ListBox3.SelectedIndex > -1 Then
                Try
                    RemoveMaterial(CType(ListBox3.SelectedItem, Material_obj).Codigo)
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Exit Sub
                End Try
                ListBox3.Items.RemoveAt(ListBox3.SelectedIndex)
                If currentContact = ListBox3.Items.Count Then currentContact = ListBox3.Items.Count - 1
                If currentContact = -1 Then
                    ClearFields()
                    MsgBox("There are no more contacts")
                Else
                    ShowMaterial()
                End If
            End If

        End If
    End Sub

    Private Sub bttnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttnAdd.Click
        If options = "listar" Then
            adding = True
            ClearFields()
            HideButtons()
            ListBox1.Enabled = False
        ElseIf options = "material" Then
            adding = True
            ClearFields()
            HideButtons()
            ListBox3.Enabled = False
            CN.Open()
            Dim RDR As SqlDataReader

            CMD.CommandText = "exec GestTrack.AllWarehouse"
            RDR = CMD.ExecuteReader
            ComboBox3.Items.Clear()
            While RDR.Read
                Dim C As New Armazem_obj
                C.IdArmazem = RDR.Item("Codigo")
                C.NomeArmazem = RDR.Item("Nome")
                C.MoradaArmazem = RDR.Item("Morada")
                C.TelemovelArmazem = IIf(RDR.IsDBNull(RDR.GetOrdinal("Telemovel")), "", RDR.Item("Telemovel"))
                ComboBox3.Items.Add(C)
            End While
            CN.Close()

            CMD.CommandText = "exec GestTrack.AllBills "
            CN.Open()
            RDR = CMD.ExecuteReader
            ComboBox4.Items.Clear()
            While RDR.Read
                Dim C As New Faturas_obj
                C.Codigo = RDR.Item("Numero")
                C.Nome = RDR.Item("Nome")
                C.Descricao = RDR.Item("Descricao")
                C.Movimento = Convert.ToInt32(IIf(RDR.IsDBNull(RDR.GetOrdinal("Codigo_Movimento")), 0, RDR.Item("Codigo_Movimento")))
                C.Data = RDR.Item("Data")
                ComboBox4.Items.Add(C)
            End While
            CN.Close()
            CMD.CommandText = "exec GestTrack.AllMaterial "
            CN.Open()
            RDR = CMD.ExecuteReader
            ComboBox2.Items.Clear()
            While RDR.Read
                Dim C As New Material_obj
                C.Codigo = RDR.Item("Codigo")
                C.Nome = RDR.Item("Nome")
                C.Categoria = RDR.Item("Categoria")
                C.Valor = RDR.Item("valor")
                C.Iva = RDR.Item("iva")
                C.Super = IIf(RDR.IsDBNull(RDR.GetOrdinal("Super_Codigo")), -1, RDR.Item("Super_Codigo"))
                C.Fatura = IIf(RDR.IsDBNull(RDR.GetOrdinal("Fatura_Numero")), -1, RDR.Item("Fatura_Numero"))
                C.Armazem = IIf(RDR.IsDBNull(RDR.GetOrdinal("Codigo_Armazem")), -1, RDR.Item("Codigo_Armazem"))
                ComboBox2.Items.Add(C)
            End While
            CN.Close()
        End If
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
        Dim contact As New Armazem_obj
        Try
            contact.NomeArmazem = NomeID.Text
            contact.MoradaArmazem = MoradaID.Text
            contact.TelemovelArmazem = TelefoneID.Text

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        If adding Then
            SubmitContact(contact)
            ListBox1.Items.Add(contact)
        Else
            UpdateContact(contact)
            ListBox1.Items(currentContact) = contact
        End If
        Return True
    End Function

    Private Function SaveMaterial() As Boolean
        Dim contact As New Material_obj
        Try

            contact.Iva = txtIva.Text
            contact.Nome = NomeID.Text
            contact.Valor = txtValor.Text
            If CodeID.Text = "" Then
                contact.Codigo = -1
            Else
                contact.Codigo = CodeID.Text
            End If

            If ComboBox1.SelectedIndex = -1 Then
                contact.Categoria = -1
            Else
                contact.Categoria = ComboBox1.SelectedIndex + 1
            End If
            If ComboBox2.SelectedIndex = -1 Then
                contact.Super = -1
            Else
                contact.Super = CType(ComboBox2.Items.Item(ComboBox2.SelectedIndex), Material_obj).Codigo
            End If
            If ComboBox4.SelectedIndex = -1 Then
                contact.Fatura = -1
            Else
                contact.Fatura = CType(ComboBox4.Items.Item(ComboBox4.SelectedIndex), Faturas_obj).Codigo
            End If
            If ComboBox3.SelectedIndex = -1 Then
                contact.Armazem = -1
            Else
                contact.Armazem = CType(ComboBox3.Items.Item(ComboBox3.SelectedIndex), Armazem_obj).IdArmazem
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        If adding Then
            SubmitMaterial(contact)
            ListBox3.Items.Add(contact)
        Else
            UpdateMaterial(contact)
            ListBox3.Items(currentContact) = contact
        End If
        Return True
    End Function

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        options = "listar"
        HideFormMaterial()
        list()
    End Sub

    Sub list()
        showAll()
        ShowLeft()
        CMD.CommandText = "execute GestTrack.AllWarehouse"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox1.Items.Clear()
        While RDR.Read
            Dim C As New Armazem_obj
            C.IdArmazem = RDR.Item("Codigo")
            C.NomeArmazem = RDR.Item("Nome")
            C.MoradaArmazem = RDR.Item("Morada")
            C.TelemovelArmazem = IIf(RDR.IsDBNull(RDR.GetOrdinal("Telemovel")), "", RDR.Item("Telemovel"))
            ListBox1.Items.Add(C)
        End While
        CN.Close()
        currentContact = 0
        ShowContact()
    End Sub

    Sub listMaterial()
        CMD.CommandText = "execute GestTrack.AllMaterial"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox3.Items.Clear()
        While RDR.Read
            Dim C As New Material_obj
            C.Codigo = RDR.Item("Codigo")
            C.Nome = RDR.Item("Nome")
            C.Categoria = RDR.Item("Categoria")
            C.Valor = RDR.Item("valor")
            C.Iva = RDR.Item("iva")
            C.Super = IIf(RDR.IsDBNull(RDR.GetOrdinal("Super_Codigo")), -1, RDR.Item("Super_Codigo"))
            C.Fatura = IIf(RDR.IsDBNull(RDR.GetOrdinal("Fatura_Numero")), -1, RDR.Item("Fatura_Numero"))
            C.Armazem = IIf(RDR.IsDBNull(RDR.GetOrdinal("Codigo_Armazem")), -1, RDR.Item("Codigo_Armazem"))
            ListBox3.Items.Add(C)
        End While
        CN.Close()
        currentContact = 0
        ShowContact()
    End Sub

    Sub ShowContact()
        If ListBox1.Items.Count = 0 Or currentContact < 0 Then Exit Sub
        Dim arm As New Armazem_obj
        arm = CType(ListBox1.Items.Item(currentContact), Armazem_obj)
        CodeID.Text = arm.IdArmazem
        NomeID.Text = arm.NomeArmazem
        MoradaID.Text = arm.MoradaArmazem
        TelefoneID.Text = arm.TelemovelArmazem

        CMD.CommandText = "exec GestTrack.MaterialByWarehouseCode "
        CMD.CommandText += CodeID.Text


        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox2.Items.Clear()
        While RDR.Read
            Dim C As New Material_obj

            C.Codigo = RDR.Item("Codigo")
            C.Nome = RDR.Item("Nome")
            C.Categoria = RDR.Item("Categoria")
            C.Valor = RDR.Item("valor")
            C.Iva = RDR.Item("iva")
            C.Super = IIf(RDR.IsDBNull(RDR.GetOrdinal("Super_Codigo")), -1, RDR.Item("Super_Codigo"))
            C.Fatura = IIf(RDR.IsDBNull(RDR.GetOrdinal("Fatura_Numero")), -1, RDR.Item("Fatura_Numero"))
            C.Armazem = IIf(RDR.IsDBNull(RDR.GetOrdinal("Codigo_Armazem")), -1, RDR.Item("Codigo_Armazem"))
            ListBox2.Items.Add(C)
        End While
        CN.Close()
        CMD.CommandText = "exec GestTrack.EmployeeByWarehouse "
        CMD.CommandText += CodeID.Text
        CN.Open()
        RDR = CMD.ExecuteReader
        ListBoxFuncionarios.Items.Clear()
        While RDR.Read
            Dim C As New Funcionario_obj
            C.CodigoFuncionario = RDR.Item("N_Interno")
            C.NomeFuncionario = RDR.Item("Nome")
            C.EmailFuncionario = RDR.Item("Email")
            C.NifFuncionario = RDR.Item("Nif")
            C.MoradaFuncionario = RDR.Item("Morada")
            C.TelemovelFuncionario = RDR.Item("Telemovel")
            C.SuperFuncionario = Convert.ToInt32(IIf(RDR.IsDBNull(RDR.GetOrdinal("Super_Interno")), 0, RDR.Item("Super_Interno")))
            C.DateFuncionario = RDR.Item("DNasc")
            ListBoxFuncionarios.Items.Add(C)
        End While
        CN.Close()

    End Sub

    Sub ShowMaterial()
        If ListBox3.Items.Count = 0 Or currentContact < 0 Then Exit Sub
        Dim arm As New Material_obj
        arm = CType(ListBox3.Items.Item(currentContact), Material_obj)
        CodeID.Text = arm.Codigo
        NomeID.Text = arm.Nome
        txtIva.Text = arm.Iva
        txtValor.Text = arm.Valor


        CMD.CommandText = "exec GestTrack.AllMaterialExceptMe "
        CMD.CommandText += arm.Codigo.ToString()

        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ComboBox1.Text = ""
        ComboBox1.SelectedIndex = arm.Categoria - 1
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox2.Items.Clear()
        While RDR.Read
            Dim C As New Material_obj
            C.Codigo = RDR.Item("Codigo")
            C.Nome = RDR.Item("Nome")
            C.Categoria = RDR.Item("Categoria")
            C.Valor = RDR.Item("valor")
            C.Iva = RDR.Item("iva")
            C.Super = IIf(RDR.IsDBNull(RDR.GetOrdinal("Super_Codigo")), -1, RDR.Item("Super_Codigo"))
            C.Fatura = IIf(RDR.IsDBNull(RDR.GetOrdinal("Fatura_Numero")), -1, RDR.Item("Fatura_Numero"))
            C.Armazem = IIf(RDR.IsDBNull(RDR.GetOrdinal("Codigo_Armazem")), -1, RDR.Item("Codigo_Armazem"))
            ComboBox2.Items.Add(C)
        End While
        CN.Close()
        Dim aux As Material_obj
        Dim supIndex = 0
        ComboBox2.SelectedIndex = -1
        For Each item In ComboBox2.Items
            aux = CType(item, Material_obj)
            If arm.Super = aux.Codigo Then
                ComboBox2.SelectedIndex = supIndex
            End If
            supIndex += 1

        Next

        CMD.CommandText = "exec GestTrack.AllWarehouse "
        CN.Open()
        RDR = CMD.ExecuteReader
        ComboBox3.Items.Clear()
        While RDR.Read
            Dim C As New Armazem_obj
            C.IdArmazem = RDR.Item("Codigo")
            C.NomeArmazem = RDR.Item("Nome")
            C.MoradaArmazem = RDR.Item("Morada")
            C.TelemovelArmazem = IIf(RDR.IsDBNull(RDR.GetOrdinal("Telemovel")), "", RDR.Item("Telemovel"))
            ComboBox3.Items.Add(C)
        End While
        CN.Close()
        Dim armm As Armazem_obj
        supIndex = 0
        ComboBox3.SelectedIndex = -1
        For Each item In ComboBox3.Items
            armm = CType(item, Armazem_obj)
            If arm.Armazem = armm.IdArmazem Then
                ComboBox3.SelectedIndex = supIndex
            End If
            supIndex += 1
        Next

        CMD.CommandText = "exec GestTrack.AllBills "
        CN.Open()
        RDR = CMD.ExecuteReader
        ComboBox4.Items.Clear()
        While RDR.Read
            Dim C As New Faturas_obj
            C.Codigo = RDR.Item("Numero")
            C.Nome = RDR.Item("Nome")
            C.Descricao = RDR.Item("Descricao")
            C.Movimento = Convert.ToInt32(IIf(RDR.IsDBNull(RDR.GetOrdinal("Codigo_Movimento")), 0, RDR.Item("Codigo_Movimento")))
            C.Data = RDR.Item("Data")
            ComboBox4.Items.Add(C)
        End While
        CN.Close()
        Dim fac As Faturas_obj

        supIndex = 0
        ComboBox4.SelectedIndex = -1
        For Each item In ComboBox4.Items
            fac = CType(item, Faturas_obj)
            If arm.Fatura = fac.Codigo Then
                ComboBox4.SelectedIndex = supIndex
            End If
            supIndex += 1
        Next

    End Sub

    Private Sub bttnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnEdit.Click
        If options = "listar" Then
            currentContact = ListBox1.SelectedIndex
            If currentContact <= -1 Then
                MsgBox("Please select a contact to edit")
                Exit Sub
            End If
            adding = False
            HideButtons()
            ListBox1.Enabled = False
        ElseIf options = "material" Then
            currentContact = ListBox3.SelectedIndex
            If currentContact <= -1 Then
                MsgBox("Please select a contact to edit")
                Exit Sub
            End If
            adding = False
            HideButtons()
            ListBox3.Enabled = False
        End If
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

        ''CMD = New SqlCommand
        ''CMD.Connection = CN
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBoxFuncionarios.Items.Clear()

        ClearFields()
        hideAll()
        hideLeft()
        HideFormMaterial()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            currentContact = ListBox1.SelectedIndex
            ShowContact()
        End If
    End Sub

    Sub LockControls()
        CodeID.ReadOnly = True
        NomeID.ReadOnly = True
        MoradaID.ReadOnly = True
        TelefoneID.ReadOnly = True
        txtIva.ReadOnly = True
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        txtValor.ReadOnly = True


    End Sub

    Sub UnlockControls()
        CodeID.ReadOnly = True
        NomeID.ReadOnly = False
        MoradaID.ReadOnly = False
        TelefoneID.ReadOnly = False
        txtIva.ReadOnly = False
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        txtValor.ReadOnly = False
    End Sub

    Sub ClearFields()
        CodeID.Text = ""
        NomeID.Text = ""
        MoradaID.Text = ""
        TelefoneID.Text = ""
        txtIva.Text = ""
        txtValor.Text = ""
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
        ComboBoxFuncionarios.Visible = False
        LabelToAdd.Visible = False
        toAdd = 0
        Label1.Visible = True
        Label11.Visible = True
        Label2.Visible = True
        Label3.Visible = True
        Label4.Visible = True
        Label5.Visible = True
        Label6.Visible = True


        CodeID.Visible = True
        NomeID.Visible = True
        MoradaID.Visible = True
        TelefoneID.Visible = True
        bttnAdd.Visible = True
        bttnDelete.Visible = True
        bttnEdit.Visible = True
        bttnOK.Visible = False
        bttnCancel.Visible = False
        Button1.Visible = True
        Button2.Visible = True
        Button3.Visible = True
        Button4.Visible = True
        ListBox1.Visible = True
        ListBox2.Visible = True
        ListBoxFuncionarios.Visible = True

    End Sub

    Sub showFormMaterial()
        Label1.Visible = True
        Label10.Visible = True
        Label11.Visible = True
        Label12.Visible = True
        Label13.Visible = True
        Label9.Visible = True
        Label8.Visible = True
        Label7.Visible = True
        CodeID.Visible = True
        NomeID.Visible = True
        txtIva.Visible = True
        txtValor.Visible = True
        ListBox3.Visible = True

        bttnAdd.Visible = True
        bttnDelete.Visible = True
        bttnEdit.Visible = True
        bttnOK.Visible = False
        bttnCancel.Visible = False

        ComboBox1.Visible = True
        ComboBox2.Visible = True
        ComboBox3.Visible = True
        ComboBox4.Visible = True

    End Sub

    Sub HideFormMaterial()
        Label1.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False
        Label13.Visible = False
        Label9.Visible = False
        Label8.Visible = False
        Label7.Visible = False
        CodeID.Visible = False
        NomeID.Visible = False
        txtIva.Visible = False
        txtValor.Visible = False
        ListBox3.Visible = False

        bttnAdd.Visible = False
        bttnDelete.Visible = False
        bttnEdit.Visible = False
        bttnOK.Visible = False
        bttnCancel.Visible = False


        ComboBox1.Visible = False
        ComboBox2.Visible = False
        ComboBox3.Visible = False
        ComboBox4.Visible = False

    End Sub

    Sub hideAll()
        LabelToAdd.Visible = False
        ComboBoxFuncionarios.Visible = False
        Label1.Visible = False
        Label11.Visible = False
        Label2.Visible = False
        Label3.Visible = False

        CodeID.Visible = False
        NomeID.Visible = False
        MoradaID.Visible = False
        TelefoneID.Visible = False
        bttnAdd.Visible = False
        bttnDelete.Visible = False
        bttnEdit.Visible = False
        bttnOK.Visible = False
        bttnCancel.Visible = False



    End Sub

    Sub hideLeft()
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        ListBox1.Visible = False
        ListBox2.Visible = False
        ListBoxFuncionarios.Visible = False
        Button1.Visible = False
        Button2.Visible = False
        Button3.Visible = False
        Button4.Visible = False
    End Sub

    Sub ShowLeft()
        Label4.Visible = True
        Label5.Visible = True
        Label6.Visible = True
        ListBox1.Visible = True
        ListBox2.Visible = True
        ListBoxFuncionarios.Visible = True
        Button1.Visible = True
        Button2.Visible = True
        Button3.Visible = True
        Button4.Visible = True
    End Sub

    Sub ShowButtons()
        LockControls()
        bttnAdd.Visible = True
        bttnDelete.Visible = True
        bttnEdit.Visible = True
        bttnOK.Visible = False
        bttnCancel.Visible = False
    End Sub

    Private Sub SubmitContact(ByVal C As Armazem_obj)
        CMD.CommandText = "INSERT GestTrack.Armazem  (Nome, Morada, Telemovel) " &
                          "VALUES (@Nome, @Morada, @Telemovel) "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Morada", C.MoradaArmazem)
        CMD.Parameters.AddWithValue("@Nome", C.NomeArmazem)
        CMD.Parameters.AddWithValue("@Telemovel", C.TelemovelArmazem)
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


    Private Sub UpdateContact(ByVal C As Armazem_obj)
        CMD.CommandText = "UPDATE GestTrack.Armazem " &
            "SET Nome = @Nome, " &
            "    Morada = @Morada, " &
            "    Telemovel = @Telemovel " &
            "WHERE Codigo = @Codigo"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Codigo", C.IdArmazem)
        CMD.Parameters.AddWithValue("@Morada", C.MoradaArmazem)
        CMD.Parameters.AddWithValue("@Nome", C.NomeArmazem)
        CMD.Parameters.AddWithValue("@Telemovel", C.TelemovelArmazem)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub

    Private Sub SubmitMaterial(ByVal C As Material_obj)
        CMD.CommandText = "INSERT GestTrack.Material  (Nome,Categoria,valor, iva,Super_Codigo,Fatura_Numero,Codigo_Armazem) " &
                          "VALUES (@Nome, @Categoria, @valor, @iva, @Super_Codigo, @Fatura_Numero, @Codigo_Armazem) "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@Categoria", C.Categoria)
        CMD.Parameters.AddWithValue("@valor", C.Valor)
        CMD.Parameters.AddWithValue("@iva", C.Iva)
        If C.Super = -1 Then
            CMD.Parameters.AddWithValue("@Super_Codigo", SqlInt32.Null)
        Else
            CMD.Parameters.AddWithValue("@Super_Codigo", C.Super)
        End If
        If C.Fatura = -1 Then
            CMD.Parameters.AddWithValue("@Fatura_Numero", SqlInt32.Null)
        Else
            CMD.Parameters.AddWithValue("@Fatura_Numero", C.Fatura)
        End If
        If C.Armazem = -1 Then
            CMD.Parameters.AddWithValue("@Codigo_Armazem", SqlInt32.Null)
        Else
            CMD.Parameters.AddWithValue("@Codigo_Armazem", C.Armazem)
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


    Private Sub UpdateMaterial(ByVal C As Material_obj)
        CMD.CommandText = "UPDATE GestTrack.Material " &
            "SET Nome = @Nome, " &
            "    Categoria = @Categoria, " &
            "    valor = @valor, " &
            "    iva = @iva, " &
            "    Super_Codigo = @Super_Codigo, " &
            "    Fatura_Numero = @Fatura_Numero, " &
            "    Codigo_Armazem = @Codigo_Armazem " &
            "WHERE Codigo = @Codigo"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@Categoria", C.Categoria)
        CMD.Parameters.AddWithValue("@valor", C.Valor)
        CMD.Parameters.AddWithValue("@iva", C.Iva)
        If C.Super = -1 Then
            CMD.Parameters.AddWithValue("@Super_Codigo", SqlInt32.Null)
        Else
            CMD.Parameters.AddWithValue("@Super_Codigo", C.Super)
        End If
        If C.Fatura = -1 Then
            CMD.Parameters.AddWithValue("@Fatura_Numero", SqlInt32.Null)
        Else
            CMD.Parameters.AddWithValue("@Fatura_Numero", C.Fatura)
        End If
        If C.Armazem = -1 Then
            CMD.Parameters.AddWithValue("@Codigo_Armazem", SqlInt32.Null)
        Else
            CMD.Parameters.AddWithValue("@Codigo_Armazem", C.Armazem)
        End If
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
        CMD.CommandText = "DELETE GestTrack.Armazem WHERE Codigo=@contactID "
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

    Private Sub RemoveMaterial(ByVal ContactID As Integer)
        CMD.CommandText = "DELETE GestTrack.Material WHERE Codigo=@contactID "
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

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Material_Armazem.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If toAdd = 3 Then
            Dim mat As New Funcionario_obj
            mat = CType(ComboBoxFuncionarios.Items.Item(ComboBoxFuncionarios.SelectedIndex), Funcionario_obj)

            AddFuncionario(mat, CType(ListBox1.Items.Item(currentContact), Armazem_obj).IdArmazem)
            toAdd = 0
            ComboBoxFuncionarios.Visible = False
            LabelToAdd.Visible = False
            showAll()
            list()
        Else
            hideAll()
            toAdd = 3
            ComboBoxFuncionarios.Visible = True
            LabelToAdd.Text = "Funcionario"
            LabelToAdd.Visible = True

            CMD.CommandText = "exec GestTrack.EmployeeNotInWarehouse "
            CMD.CommandText += CodeID.Text
            CN.Open()

            ComboBoxFuncionarios.SelectedIndex = -1
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            ComboBoxFuncionarios.Items.Clear()
            While RDR.Read
                Dim C As New Funcionario_obj
                C.CodigoFuncionario = RDR.Item("N_Interno")
                C.NomeFuncionario = RDR.Item("Nome")
                C.EmailFuncionario = RDR.Item("Email")
                C.NifFuncionario = RDR.Item("Nif")
                C.MoradaFuncionario = RDR.Item("Morada")
                C.TelemovelFuncionario = RDR.Item("Telemovel")
                C.SuperFuncionario = Convert.ToInt32(IIf(RDR.IsDBNull(RDR.GetOrdinal("Super_Interno")), 0, RDR.Item("Super_Interno")))
                C.DateFuncionario = RDR.Item("DNasc")
                ComboBoxFuncionarios.Items.Add(C)
            End While
            CN.Close()
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If toAdd = 1 Then
            Dim mat As New Material_obj
            mat = CType(ComboBoxFuncionarios.Items.Item(ComboBoxFuncionarios.SelectedIndex), Material_obj)

            UpdateMaterial(mat, CType(ListBox1.Items.Item(currentContact), Armazem_obj).IdArmazem)
            toAdd = 0
            ComboBoxFuncionarios.Visible = False
            LabelToAdd.Visible = False
            showAll()
            list()

        Else
            hideAll()
            toAdd = 1
            ComboBoxFuncionarios.Visible = True
            LabelToAdd.Text = "Material"
            LabelToAdd.Visible = True

            CMD.CommandText = "exec GestTrack.MaterialNotInWarehouseCode "
            CMD.CommandText += CodeID.Text


            CN.Open()
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            ComboBoxFuncionarios.Items.Clear()
            ComboBoxFuncionarios.SelectedIndex = -1
            While RDR.Read
                Dim C As New Material_obj

                C.Codigo = RDR.Item("Codigo")
                C.Nome = RDR.Item("Nome")
                C.Categoria = RDR.Item("Categoria")
                C.Valor = RDR.Item("valor")
                C.Iva = RDR.Item("iva")
                C.Super = IIf(RDR.IsDBNull(RDR.GetOrdinal("Super_Codigo")), -1, RDR.Item("Super_Codigo"))
                C.Fatura = IIf(RDR.IsDBNull(RDR.GetOrdinal("Fatura_Numero")), -1, RDR.Item("Fatura_Numero"))
                C.Armazem = IIf(RDR.IsDBNull(RDR.GetOrdinal("Codigo_Armazem")), -1, RDR.Item("Codigo_Armazem"))
                ComboBoxFuncionarios.Items.Add(C)
            End While
            CN.Close()
        End If
    End Sub

    Private Sub UpdateMaterial(ByVal C As Material_obj, ByVal armazem As Integer)
        CMD.CommandText = "UPDATE GestTrack.Material " &
            "SET Codigo_Armazem = @armazem " &
            "WHERE Codigo = @Codigo"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Codigo", C.Codigo)
        If armazem = -1 Then
            CMD.Parameters.AddWithValue("@armazem", SqlInt32.Null)
        Else
            CMD.Parameters.AddWithValue("@armazem", armazem)
        End If


        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub

    Private Sub AddFuncionario(ByVal C As Funcionario_obj, ByVal armazem As Integer)
        CMD.CommandText = "INSERT GestTrack.Funcionario_Usa (Codigo_Func,Codigo_Arm) " &
                          "VALUES (@Codigo, @armazem) "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Codigo", C.CodigoFuncionario)
        If armazem = -1 Then
            CMD.Parameters.AddWithValue("@armazem", SqlInt32.Null)
        Else
            CMD.Parameters.AddWithValue("@armazem", armazem)
        End If


        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub

    Private Sub RemoveFuncionario(ByVal C As Funcionario_obj, ByVal armazem As Integer)
        CMD.CommandText = "DELETE GestTrack.Funcionario_Usa WHERE Codigo_Func=@Codigo and Codigo_Arm=@armazem  "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Codigo", C.CodigoFuncionario)
        If armazem = -1 Then
            CMD.Parameters.AddWithValue("@armazem", SqlInt32.Null)
        Else
            CMD.Parameters.AddWithValue("@armazem", armazem)
        End If


        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If toAdd = 2 Then
            Dim mat As New Material_obj
            mat = CType(ComboBoxFuncionarios.Items.Item(ComboBoxFuncionarios.SelectedIndex), Material_obj)

            UpdateMaterial(mat, -1)
            toAdd = 0
            ComboBoxFuncionarios.Visible = False
            LabelToAdd.Visible = False
            showAll()
            list()

        Else
            hideAll()
            toAdd = 2
            ComboBoxFuncionarios.Visible = True
            LabelToAdd.Text = "Material"
            LabelToAdd.Visible = True

            CMD.CommandText = "exec GestTrack.MaterialByWarehouseCode "
            CMD.CommandText += CodeID.Text


            CN.Open()
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            ComboBoxFuncionarios.Items.Clear()
            ComboBoxFuncionarios.SelectedIndex = -1
            While RDR.Read
                Dim C As New Material_obj

                C.Codigo = RDR.Item("Codigo")
                C.Nome = RDR.Item("Nome")
                C.Categoria = RDR.Item("Categoria")
                C.Valor = RDR.Item("valor")
                C.Iva = RDR.Item("iva")
                C.Super = IIf(RDR.IsDBNull(RDR.GetOrdinal("Super_Codigo")), -1, RDR.Item("Super_Codigo"))
                C.Fatura = IIf(RDR.IsDBNull(RDR.GetOrdinal("Fatura_Numero")), -1, RDR.Item("Fatura_Numero"))
                C.Armazem = IIf(RDR.IsDBNull(RDR.GetOrdinal("Codigo_Armazem")), -1, RDR.Item("Codigo_Armazem"))
                ComboBoxFuncionarios.Items.Add(C)
            End While
            CN.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If toAdd = 4 Then
            Dim mat As New Funcionario_obj
            mat = CType(ComboBoxFuncionarios.Items.Item(ComboBoxFuncionarios.SelectedIndex), Funcionario_obj)

            RemoveFuncionario(mat, CType(ListBox1.Items.Item(currentContact), Armazem_obj).IdArmazem)
            toAdd = 0
            ComboBoxFuncionarios.Visible = False
            LabelToAdd.Visible = False
            showAll()
            list()
        Else
            hideAll()
            toAdd = 4
            ComboBoxFuncionarios.Visible = True
            LabelToAdd.Text = "Funcionario"
            LabelToAdd.Visible = True

            CMD.CommandText = "exec GestTrack.EmployeeByWarehouse "
            CMD.CommandText += CodeID.Text
            CN.Open()

            ComboBoxFuncionarios.SelectedIndex = -1
            Dim RDR As SqlDataReader
            RDR = CMD.ExecuteReader
            ComboBoxFuncionarios.Items.Clear()
            While RDR.Read
                Dim C As New Funcionario_obj
                C.CodigoFuncionario = RDR.Item("N_Interno")
                C.NomeFuncionario = RDR.Item("Nome")
                C.EmailFuncionario = RDR.Item("Email")
                C.NifFuncionario = RDR.Item("Nif")
                C.MoradaFuncionario = RDR.Item("Morada")
                C.TelemovelFuncionario = RDR.Item("Telemovel")
                C.SuperFuncionario = Convert.ToInt32(IIf(RDR.IsDBNull(RDR.GetOrdinal("Super_Interno")), 0, RDR.Item("Super_Interno")))
                C.DateFuncionario = RDR.Item("DNasc")
                ComboBoxFuncionarios.Items.Add(C)
            End While
            CN.Close()
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        options = "material"
        hideAll()
        hideLeft()
        showFormMaterial()
        listMaterial()
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False

    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged
        If ListBox3.SelectedIndex > -1 Then
            currentContact = ListBox3.SelectedIndex
            ShowMaterial()
        End If
    End Sub


End Class