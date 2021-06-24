Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Public Class Funcionarios

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
                RemoveContact(CType(ListBox1.SelectedItem, Funcionario_obj).CodigoFuncionario)
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
        Dim arm As New Funcionario_obj
        Try
            If txtID.Text Is Nothing Or txtID.Text = "" Then
                arm.CodigoFuncionario = 0
            Else
                arm.CodigoFuncionario = txtID.Text
            End If

            arm.EmailFuncionario = txtEmail.Text
            arm.MoradaFuncionario = txtMorada.Text
            arm.NifFuncionario = txtNIF.Text
            arm.NomeFuncionario = txtNome.Text
            arm.TelemovelFuncionario = txtTelemovel.Text
            arm.DateFuncionario = DateTimePicker1.Value

            If dropSupervisor.SelectedIndex = -1 Then
                arm.SuperFuncionario = -1
            Else
                arm.SuperFuncionario = CType(ListBox1.Items.Item(dropSupervisor.SelectedIndex), Funcionario_obj).CodigoFuncionario
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

        CMD.CommandText = "execute GestTrack.AllEmployes"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox1.Items.Clear()
        dropSupervisor.Items.Clear()
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
            ListBox1.Items.Add(C)
            dropSupervisor.Items.Add(C.NomeFuncionario)
        End While
        CN.Close()
        currentContact = 0
        ShowContact()
    End Sub

    Sub ShowContact()
        If ListBox1.Items.Count = 0 Or currentContact < 0 Then Exit Sub
        Dim arm As New Funcionario_obj
        Dim aux As New Funcionario_obj
        arm = CType(ListBox1.Items.Item(currentContact), Funcionario_obj)

        txtID.Text = arm.CodigoFuncionario
        txtEmail.Text = arm.EmailFuncionario
        txtMorada.Text = arm.MoradaFuncionario
        txtNIF.Text = arm.NifFuncionario
        txtNome.Text = arm.NomeFuncionario
        txtTelemovel.Text = arm.TelemovelFuncionario
        DateTimePicker1.Value = arm.DateFuncionario
        supIndex = 0
        dropSupervisor.SelectedIndex = -1
        For Each item In ListBox1.Items
            aux = CType(item, Funcionario_obj)
            If arm.SuperFuncionario = aux.CodigoFuncionario Then
                dropSupervisor.SelectedIndex = supIndex

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
        txtEmail.ReadOnly = True
        txtMorada.ReadOnly = True
        txtNIF.ReadOnly = True
        txtNome.ReadOnly = True
        txtTelemovel.ReadOnly = True
        dropSupervisor.Enabled = False
        DateTimePicker1.Enabled = False


    End Sub

    Sub UnlockControls()
        txtID.ReadOnly = True
        txtEmail.ReadOnly = False
        txtMorada.ReadOnly = False
        txtNIF.ReadOnly = False
        txtNome.ReadOnly = False
        txtTelemovel.ReadOnly = False
        dropSupervisor.AllowDrop = False
        dropSupervisor.Enabled = True
        DateTimePicker1.Enabled = True


    End Sub

    Sub ClearFields()
        txtID.Text = ""
        txtEmail.Text = ""
        txtMorada.Text = ""
        txtNIF.Text = ""
        txtNome.Text = ""
        txtTelemovel.Text = ""
        dropSupervisor.Text = "Select"
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
        Label6.Visible = True
        Label9.Visible = True

        dropSupervisor.Visible = True
        ListBox1.Visible = True
        txtID.Visible = True
        txtEmail.Visible = True
        txtMorada.Visible = True
        txtNIF.Visible = True
        txtNome.Visible = True
        txtTelemovel.Visible = True
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
        Label6.Visible = False
        Label9.Visible = False
        dropSupervisor.Visible = False
        ListBox1.Visible = False
        txtID.Visible = False
        txtEmail.Visible = False
        txtMorada.Visible = False
        txtNIF.Visible = False
        txtNome.Visible = False
        txtTelemovel.Visible = False
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

    Private Sub SubmitContact(ByVal C As Funcionario_obj)
        CMD.CommandText = "INSERT GestTrack.Funcionario  (Nome,Email,Nif,Morada,DNasc,Telemovel,Super_Interno) " &
                          "VALUES (@Nome,@Email,@Nif, @Morada,@Dnasc, @Telemovel,@Super) "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Nome", C.NomeFuncionario)
        CMD.Parameters.AddWithValue("@Email", C.EmailFuncionario)
        CMD.Parameters.AddWithValue("@Nif", C.NifFuncionario)
        CMD.Parameters.AddWithValue("@Dnasc", C.DateFuncionario.ToString("yyyy-MM-dd"))
        CMD.Parameters.AddWithValue("@Morada", C.MoradaFuncionario)
        CMD.Parameters.AddWithValue("@Telemovel", C.TelemovelFuncionario)
        If C.SuperFuncionario = -1 Then
            CMD.Parameters.AddWithValue("@Super", SqlInt32.Null)
        Else
            CMD.Parameters.AddWithValue("@Super", C.SuperFuncionario)
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


    Private Sub UpdateContact(ByVal C As Funcionario_obj)
        CMD.CommandText = "UPDATE GestTrack.Funcionario " &
            "SET Nome = @Nome, " &
            "    Email = @Email, " &
            "    Nif = @Nif, " &
            "    Dnasc = @Dnasc, " &
            "    Morada = @Morada, " &
            "    Telemovel = @Telemovel, " &
            "    Super_Interno = @Super " &
            "WHERE N_Interno = @Codigo"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Nome", C.NomeFuncionario)
        CMD.Parameters.AddWithValue("@Email", C.EmailFuncionario)
        CMD.Parameters.AddWithValue("@Nif", C.NifFuncionario)
        CMD.Parameters.AddWithValue("@Dnasc", C.DateFuncionario)
        CMD.Parameters.AddWithValue("@Morada", C.MoradaFuncionario)
        CMD.Parameters.AddWithValue("@Telemovel", C.TelemovelFuncionario)
        CMD.Parameters.AddWithValue("@Super", C.SuperFuncionario)
        CMD.Parameters.AddWithValue("@Codigo", C.CodigoFuncionario)
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
        CMD.CommandText = "DELETE GestTrack.Funcionario WHERE N_Interno=@contactID "
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