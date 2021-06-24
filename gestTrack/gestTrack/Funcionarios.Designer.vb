<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Funcionarios
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Funcionarios))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.bttnOK = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.bttnEdit = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bttnCancel = New System.Windows.Forms.Button()
        Me.bttnAdd = New System.Windows.Forms.Button()
        Me.txtTelemovel = New System.Windows.Forms.TextBox()
        Me.txtNIF = New System.Windows.Forms.TextBox()
        Me.txtMorada = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.bttnDelete = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.dropSupervisor = New System.Windows.Forms.ComboBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(69, 68)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(119, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(137, 123)
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'txtID
        '
        Me.txtID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtID.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtID.Location = New System.Drawing.Point(425, 134)
        Me.txtID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(91, 22)
        Me.txtID.TabIndex = 141
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label11.Location = New System.Drawing.Point(421, 107)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 1, 4, 4)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 20)
        Me.Label11.TabIndex = 140
        Me.Label11.Text = "ID"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label4.Location = New System.Drawing.Point(421, 393)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 20)
        Me.Label4.TabIndex = 138
        Me.Label4.Text = "Supervisor"
        '
        'bttnOK
        '
        Me.bttnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bttnOK.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.bttnOK.Location = New System.Drawing.Point(687, 463)
        Me.bttnOK.Margin = New System.Windows.Forms.Padding(4)
        Me.bttnOK.Name = "bttnOK"
        Me.bttnOK.Size = New System.Drawing.Size(128, 39)
        Me.bttnOK.TabIndex = 134
        Me.bttnOK.Text = "OK"
        Me.bttnOK.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 14
        Me.ListBox1.Location = New System.Drawing.Point(24, 134)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(368, 368)
        Me.ListBox1.Sorted = True
        Me.ListBox1.TabIndex = 133
        '
        'bttnEdit
        '
        Me.bttnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bttnEdit.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.bttnEdit.Location = New System.Drawing.Point(586, 463)
        Me.bttnEdit.Margin = New System.Windows.Forms.Padding(4)
        Me.bttnEdit.Name = "bttnEdit"
        Me.bttnEdit.Size = New System.Drawing.Size(128, 39)
        Me.bttnEdit.TabIndex = 131
        Me.bttnEdit.Text = "Edit"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label9.Location = New System.Drawing.Point(655, 279)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 4, 4, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 20)
        Me.Label9.TabIndex = 124
        Me.Label9.Text = "Data"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label6.Location = New System.Drawing.Point(421, 336)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 20)
        Me.Label6.TabIndex = 126
        Me.Label6.Text = "Telemovel"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label5.Location = New System.Drawing.Point(421, 279)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 20)
        Me.Label5.TabIndex = 122
        Me.Label5.Text = "NIF"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label3.Location = New System.Drawing.Point(421, 218)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 20)
        Me.Label3.TabIndex = 120
        Me.Label3.Text = "Morada"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.Location = New System.Drawing.Point(421, 169)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 20)
        Me.Label2.TabIndex = 118
        Me.Label2.Text = "Email"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.Location = New System.Drawing.Point(525, 107)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 1, 4, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 20)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "Nome"
        '
        'bttnCancel
        '
        Me.bttnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bttnCancel.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.bttnCancel.Location = New System.Drawing.Point(477, 463)
        Me.bttnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.bttnCancel.Name = "bttnCancel"
        Me.bttnCancel.Size = New System.Drawing.Size(128, 39)
        Me.bttnCancel.TabIndex = 132
        Me.bttnCancel.Text = "Cancel"
        Me.bttnCancel.Visible = False
        '
        'bttnAdd
        '
        Me.bttnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bttnAdd.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.bttnAdd.Location = New System.Drawing.Point(421, 463)
        Me.bttnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.bttnAdd.Name = "bttnAdd"
        Me.bttnAdd.Size = New System.Drawing.Size(128, 39)
        Me.bttnAdd.TabIndex = 130
        Me.bttnAdd.Text = "Add"
        '
        'txtTelemovel
        '
        Me.txtTelemovel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTelemovel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtTelemovel.Location = New System.Drawing.Point(423, 358)
        Me.txtTelemovel.Margin = New System.Windows.Forms.Padding(4, 1, 4, 4)
        Me.txtTelemovel.Name = "txtTelemovel"
        Me.txtTelemovel.ReadOnly = True
        Me.txtTelemovel.Size = New System.Drawing.Size(159, 22)
        Me.txtTelemovel.TabIndex = 127
        '
        'txtNIF
        '
        Me.txtNIF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNIF.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtNIF.Location = New System.Drawing.Point(423, 302)
        Me.txtNIF.Margin = New System.Windows.Forms.Padding(4, 1, 4, 4)
        Me.txtNIF.Name = "txtNIF"
        Me.txtNIF.ReadOnly = True
        Me.txtNIF.Size = New System.Drawing.Size(193, 22)
        Me.txtNIF.TabIndex = 123
        '
        'txtMorada
        '
        Me.txtMorada.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMorada.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtMorada.Location = New System.Drawing.Point(423, 240)
        Me.txtMorada.Margin = New System.Windows.Forms.Padding(4, 1, 4, 4)
        Me.txtMorada.Name = "txtMorada"
        Me.txtMorada.ReadOnly = True
        Me.txtMorada.Size = New System.Drawing.Size(457, 22)
        Me.txtMorada.TabIndex = 121
        '
        'txtEmail
        '
        Me.txtEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmail.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(423, 191)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(4, 1, 4, 4)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(351, 22)
        Me.txtEmail.TabIndex = 119
        '
        'txtNome
        '
        Me.txtNome.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNome.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.txtNome.Location = New System.Drawing.Point(525, 134)
        Me.txtNome.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.ReadOnly = True
        Me.txtNome.Size = New System.Drawing.Size(356, 22)
        Me.txtNome.TabIndex = 117
        '
        'bttnDelete
        '
        Me.bttnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bttnDelete.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.bttnDelete.Location = New System.Drawing.Point(743, 463)
        Me.bttnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.bttnDelete.Name = "bttnDelete"
        Me.bttnDelete.Size = New System.Drawing.Size(128, 39)
        Me.bttnDelete.TabIndex = 137
        Me.bttnDelete.Text = "Delete"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(658, 302)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(213, 20)
        Me.DateTimePicker1.TabIndex = 142
        '
        'dropSupervisor
        '
        Me.dropSupervisor.FormattingEnabled = True
        Me.dropSupervisor.Location = New System.Drawing.Point(423, 417)
        Me.dropSupervisor.Name = "dropSupervisor"
        Me.dropSupervisor.Size = New System.Drawing.Size(220, 21)
        Me.dropSupervisor.TabIndex = 143
        '
        'Funcionarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(941, 525)
        Me.Controls.Add(Me.dropSupervisor)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.bttnOK)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.bttnEdit)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bttnCancel)
        Me.Controls.Add(Me.bttnAdd)
        Me.Controls.Add(Me.txtTelemovel)
        Me.Controls.Add(Me.txtNIF)
        Me.Controls.Add(Me.txtMorada)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.bttnDelete)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Funcionarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Funcionarios"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents txtID As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents bttnOK As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents bttnEdit As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents bttnCancel As Button
    Friend WithEvents bttnAdd As Button
    Friend WithEvents txtTelemovel As TextBox
    Friend WithEvents txtNIF As TextBox
    Friend WithEvents txtMorada As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtNome As TextBox
    Private WithEvents bttnDelete As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents dropSupervisor As ComboBox
End Class
