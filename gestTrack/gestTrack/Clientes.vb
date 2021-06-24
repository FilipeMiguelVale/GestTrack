Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class Clientes
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
        Dim idx As Integer = ListBox1.FindString(txtNIF.Text)
        ListBox1.SelectedIndex = idx
        ShowButtons()
    End Sub

    Private Sub bttnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnDelete.Click
        If ListBox1.SelectedIndex > -1 Then
            Try
                RemoveContact(CType(ListBox1.SelectedItem, Cliente_obj).NifCliente)
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
        Dim arm As New Cliente_obj
        Try

            arm.EmailCliente = txtEmail.Text
            arm.MoradaCliente = txtMorada.Text
            arm.NifCliente = txtNIF.Text
            arm.NomeCliente = txtNome.Text
            arm.TelemovelCliente = txtTelemovel.Text



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

        CMD.CommandText = "execute GestTrack.AllClients"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox1.Items.Clear()
        While RDR.Read
            Dim C As New Cliente_obj
            C.NomeCliente = RDR.Item("Nome")
            C.EmailCliente = RDR.Item("Email")
            C.NifCliente = RDR.Item("Nif")
            C.MoradaCliente = RDR.Item("Morada")
            C.TelemovelCliente = RDR.Item("Telemovel")
            ListBox1.Items.Add(C)

        End While
        CN.Close()
        currentContact = 0
        ShowContact()
    End Sub

    Sub ShowContact()
        If ListBox1.Items.Count = 0 Or currentContact < 0 Then Exit Sub
        Dim arm As New Cliente_obj
        Dim aux As New Cliente_obj
        arm = CType(ListBox1.Items.Item(currentContact), Cliente_obj)

        txtEmail.Text = arm.EmailCliente
        txtMorada.Text = arm.MoradaCliente
        txtNIF.Text = arm.NifCliente
        txtNome.Text = arm.NomeCliente
        txtTelemovel.Text = arm.TelemovelCliente

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
        txtEmail.ReadOnly = True
        txtMorada.ReadOnly = True
        txtNIF.ReadOnly = True
        txtNome.ReadOnly = True
        txtTelemovel.ReadOnly = True


    End Sub

    Sub UnlockControls()
        txtEmail.ReadOnly = False
        txtMorada.ReadOnly = False
        txtNIF.ReadOnly = False
        txtNome.ReadOnly = False
        txtTelemovel.ReadOnly = False


    End Sub

    Sub ClearFields()
        txtEmail.Text = ""
        txtMorada.Text = ""
        txtNIF.Text = ""
        txtNome.Text = ""
        txtTelemovel.Text = ""
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
        Label2.Visible = True
        Label3.Visible = True
        Label5.Visible = True
        Label6.Visible = True

        ListBox1.Visible = True
        txtEmail.Visible = True
        txtMorada.Visible = True
        txtNIF.Visible = True
        txtNome.Visible = True
        txtTelemovel.Visible = True

        bttnAdd.Visible = True
        bttnDelete.Visible = True
        bttnEdit.Visible = True
        bttnOK.Visible = False
        bttnCancel.Visible = False
    End Sub

    Sub hideAll()
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        ListBox1.Visible = False
        txtEmail.Visible = False
        txtMorada.Visible = False
        txtNIF.Visible = False
        txtNome.Visible = False
        txtTelemovel.Visible = False
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

    Private Sub SubmitContact(ByVal C As Cliente_obj)
        CMD.CommandText = "INSERT GestTrack.Cliente  (Nome,Email,Nif,Morada,Telemovel) " &
                          "VALUES (@Nome,@Email,@Nif, @Morada, @Telemovel) "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Nome", C.NomeCliente)
        CMD.Parameters.AddWithValue("@Email", C.EmailCliente)
        CMD.Parameters.AddWithValue("@Nif", C.NifCliente)
        CMD.Parameters.AddWithValue("@Morada", C.MoradaCliente)
        CMD.Parameters.AddWithValue("@Telemovel", C.TelemovelCliente)

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


    Private Sub UpdateContact(ByVal C As Cliente_obj)
        CMD.CommandText = "UPDATE GestTrack.Cliente " &
            "SET Nome = @Nome, " &
            "    Email = @Email, " &
            "    Morada = @Morada, " &
            "    Telemovel = @Telemovel " &
            "WHERE Nif = @Nif"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Nome", C.NomeCliente)
        CMD.Parameters.AddWithValue("@Email", C.EmailCliente)
        CMD.Parameters.AddWithValue("@Nif", C.NifCliente)
        CMD.Parameters.AddWithValue("@Morada", C.MoradaCliente)
        CMD.Parameters.AddWithValue("@Telemovel", C.TelemovelCliente)
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
        CMD.CommandText = "DELETE GestTrack.Cliente WHERE Nif=@contactID "
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