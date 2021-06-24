<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Armazem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Armazem))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.CodeID = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TelefoneID = New System.Windows.Forms.TextBox()
        Me.MoradaID = New System.Windows.Forms.TextBox()
        Me.NomeID = New System.Windows.Forms.TextBox()
        Me.bttnOK = New System.Windows.Forms.Button()
        Me.bttnEdit = New System.Windows.Forms.Button()
        Me.bttnCancel = New System.Windows.Forms.Button()
        Me.bttnAdd = New System.Windows.Forms.Button()
        Me.bttnDelete = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ListBoxFuncionarios = New System.Windows.Forms.ListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ComboBoxFuncionarios = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.LabelToAdd = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(92, 84)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(167, 0)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(183, 151)
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(16, 192)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(369, 100)
        Me.ListBox1.TabIndex = 2
        '
        'CodeID
        '
        Me.CodeID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CodeID.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.CodeID.Location = New System.Drawing.Point(492, 234)
        Me.CodeID.Margin = New System.Windows.Forms.Padding(5)
        Me.CodeID.Name = "CodeID"
        Me.CodeID.ReadOnly = True
        Me.CodeID.Size = New System.Drawing.Size(120, 26)
        Me.CodeID.TabIndex = 123
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label11.Location = New System.Drawing.Point(487, 201)
        Me.Label11.Margin = New System.Windows.Forms.Padding(5, 1, 5, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 25)
        Me.Label11.TabIndex = 122
        Me.Label11.Text = "Codigo"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label3.Location = New System.Drawing.Point(487, 337)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 5, 5, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 25)
        Me.Label3.TabIndex = 120
        Me.Label3.Text = "Telefone"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.Location = New System.Drawing.Point(487, 277)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 5, 5, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 25)
        Me.Label2.TabIndex = 118
        Me.Label2.Text = "Morada"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.Location = New System.Drawing.Point(625, 201)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 1, 5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 25)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "Nome"
        '
        'TelefoneID
        '
        Me.TelefoneID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TelefoneID.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.TelefoneID.Location = New System.Drawing.Point(489, 364)
        Me.TelefoneID.Margin = New System.Windows.Forms.Padding(5, 1, 5, 5)
        Me.TelefoneID.Name = "TelefoneID"
        Me.TelefoneID.ReadOnly = True
        Me.TelefoneID.Size = New System.Drawing.Size(608, 26)
        Me.TelefoneID.TabIndex = 121
        '
        'MoradaID
        '
        Me.MoradaID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MoradaID.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.MoradaID.Location = New System.Drawing.Point(489, 304)
        Me.MoradaID.Margin = New System.Windows.Forms.Padding(5, 1, 5, 5)
        Me.MoradaID.Name = "MoradaID"
        Me.MoradaID.ReadOnly = True
        Me.MoradaID.Size = New System.Drawing.Size(467, 26)
        Me.MoradaID.TabIndex = 119
        '
        'NomeID
        '
        Me.NomeID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NomeID.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.NomeID.Location = New System.Drawing.Point(625, 234)
        Me.NomeID.Margin = New System.Windows.Forms.Padding(5)
        Me.NomeID.Name = "NomeID"
        Me.NomeID.ReadOnly = True
        Me.NomeID.Size = New System.Drawing.Size(473, 26)
        Me.NomeID.TabIndex = 117
        '
        'bttnOK
        '
        Me.bttnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bttnOK.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.bttnOK.Location = New System.Drawing.Point(843, 544)
        Me.bttnOK.Margin = New System.Windows.Forms.Padding(5)
        Me.bttnOK.Name = "bttnOK"
        Me.bttnOK.Size = New System.Drawing.Size(171, 48)
        Me.bttnOK.TabIndex = 127
        Me.bttnOK.Text = "OK"
        Me.bttnOK.Visible = False
        '
        'bttnEdit
        '
        Me.bttnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bttnEdit.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.bttnEdit.Location = New System.Drawing.Point(708, 544)
        Me.bttnEdit.Margin = New System.Windows.Forms.Padding(5)
        Me.bttnEdit.Name = "bttnEdit"
        Me.bttnEdit.Size = New System.Drawing.Size(171, 48)
        Me.bttnEdit.TabIndex = 125
        Me.bttnEdit.Text = "Edit"
        '
        'bttnCancel
        '
        Me.bttnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bttnCancel.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.bttnCancel.Location = New System.Drawing.Point(563, 544)
        Me.bttnCancel.Margin = New System.Windows.Forms.Padding(5)
        Me.bttnCancel.Name = "bttnCancel"
        Me.bttnCancel.Size = New System.Drawing.Size(171, 48)
        Me.bttnCancel.TabIndex = 126
        Me.bttnCancel.Text = "Cancel"
        Me.bttnCancel.Visible = False
        '
        'bttnAdd
        '
        Me.bttnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bttnAdd.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.bttnAdd.Location = New System.Drawing.Point(488, 544)
        Me.bttnAdd.Margin = New System.Windows.Forms.Padding(5)
        Me.bttnAdd.Name = "bttnAdd"
        Me.bttnAdd.Size = New System.Drawing.Size(171, 48)
        Me.bttnAdd.TabIndex = 124
        Me.bttnAdd.Text = "Add"
        '
        'bttnDelete
        '
        Me.bttnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bttnDelete.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.bttnDelete.Location = New System.Drawing.Point(918, 544)
        Me.bttnDelete.Margin = New System.Windows.Forms.Padding(5)
        Me.bttnDelete.Name = "bttnDelete"
        Me.bttnDelete.Size = New System.Drawing.Size(171, 48)
        Me.bttnDelete.TabIndex = 128
        Me.bttnDelete.Text = "Delete"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 158)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 1, 5, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 25)
        Me.Label4.TabIndex = 131
        Me.Label4.Text = "Armazens"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 313)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 1, 5, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 25)
        Me.Label5.TabIndex = 133
        Me.Label5.Text = "Material"
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 16
        Me.ListBox2.Location = New System.Drawing.Point(17, 347)
        Me.ListBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(369, 100)
        Me.ListBox2.TabIndex = 132
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 468)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 1, 5, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 25)
        Me.Label6.TabIndex = 135
        Me.Label6.Text = "Funcionarios"
        '
        'ListBoxFuncionarios
        '
        Me.ListBoxFuncionarios.FormattingEnabled = True
        Me.ListBoxFuncionarios.ItemHeight = 16
        Me.ListBoxFuncionarios.Location = New System.Drawing.Point(18, 502)
        Me.ListBoxFuncionarios.Margin = New System.Windows.Forms.Padding(4)
        Me.ListBoxFuncionarios.Name = "ListBoxFuncionarios"
        Me.ListBoxFuncionarios.Size = New System.Drawing.Size(369, 100)
        Me.ListBoxFuncionarios.TabIndex = 134
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.Location = New System.Drawing.Point(128, 468)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(33, 23)
        Me.Button1.TabIndex = 136
        Me.Button1.Text = "+"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Red
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.Location = New System.Drawing.Point(167, 468)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(33, 23)
        Me.Button2.TabIndex = 137
        Me.Button2.Text = "-"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'ComboBoxFuncionarios
        '
        Me.ComboBoxFuncionarios.FormattingEnabled = True
        Me.ComboBoxFuncionarios.Location = New System.Drawing.Point(492, 259)
        Me.ComboBoxFuncionarios.Name = "ComboBoxFuncionarios"
        Me.ComboBoxFuncionarios.Size = New System.Drawing.Size(383, 24)
        Me.ComboBoxFuncionarios.TabIndex = 138
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Red
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.Location = New System.Drawing.Point(126, 313)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(33, 23)
        Me.Button3.TabIndex = 140
        Me.Button3.Text = "-"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.Location = New System.Drawing.Point(87, 313)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(33, 23)
        Me.Button4.TabIndex = 139
        Me.Button4.Text = "+"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'LabelToAdd
        '
        Me.LabelToAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelToAdd.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.LabelToAdd.Location = New System.Drawing.Point(489, 226)
        Me.LabelToAdd.Margin = New System.Windows.Forms.Padding(5, 1, 5, 5)
        Me.LabelToAdd.Name = "LabelToAdd"
        Me.LabelToAdd.Size = New System.Drawing.Size(128, 25)
        Me.LabelToAdd.TabIndex = 141
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(358, 0)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(183, 151)
        Me.PictureBox3.TabIndex = 142
        Me.PictureBox3.TabStop = False
        '
        'Armazem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1255, 646)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.LabelToAdd)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.ComboBoxFuncionarios)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ListBoxFuncionarios)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.bttnOK)
        Me.Controls.Add(Me.bttnEdit)
        Me.Controls.Add(Me.bttnCancel)
        Me.Controls.Add(Me.bttnAdd)
        Me.Controls.Add(Me.bttnDelete)
        Me.Controls.Add(Me.CodeID)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TelefoneID)
        Me.Controls.Add(Me.MoradaID)
        Me.Controls.Add(Me.NomeID)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Armazem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Armazem"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents CodeID As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TelefoneID As TextBox
    Friend WithEvents MoradaID As TextBox
    Friend WithEvents NomeID As TextBox
    Friend WithEvents bttnOK As Button
    Friend WithEvents bttnEdit As Button
    Friend WithEvents bttnCancel As Button
    Friend WithEvents bttnAdd As Button
    Private WithEvents bttnDelete As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ListBoxFuncionarios As ListBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ComboBoxFuncionarios As ComboBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents LabelToAdd As Label
    Friend WithEvents PictureBox3 As PictureBox
End Class
