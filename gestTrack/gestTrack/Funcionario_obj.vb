Imports Microsoft.VisualBasic

<Serializable()> Public Class Funcionario_obj
    Private _Codigo As Integer
    Private _Nome As String
    Private _Email As String
    Private _Morada As String
    Private _Telemovel As String
    Private _NIF As Integer
    Private _Super As Integer
    Private _Date As Date

    Property CodigoFuncionario As Integer
        Get
            Return _Codigo
        End Get
        Set(ByVal value As Integer)
            _Codigo = value
        End Set
    End Property

    Property NomeFuncionario() As String
        Get
            NomeFuncionario = _Nome
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("O nome do Armazem não pode ser vazio")
                Exit Property
            End If
            _Nome = value
        End Set
    End Property

    Property EmailFuncionario() As String
        Get
            EmailFuncionario = _Email
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("O nome do Armazem não pode ser vazio")
                Exit Property
            End If
            _Email = value
        End Set
    End Property

    Property MoradaFuncionario() As String
        Get
            MoradaFuncionario = _Morada
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("A Morada do Armazem não pode ser vazia")
                Exit Property
            End If
            _Morada = value
        End Set
    End Property

    Property TelemovelFuncionario() As String
        Get
            TelemovelFuncionario = _Telemovel
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                value = ""
            End If
            _Telemovel = value
        End Set
    End Property

    Property NifFuncionario As Integer
        Get
            Return _NIF
        End Get
        Set(ByVal value As Integer)
            _NIF = value
        End Set
    End Property

    Property SuperFuncionario As Integer
        Get
            Return _Super
        End Get
        Set(ByVal value As Integer)
            _Super = value
        End Set
    End Property

    Property DateFuncionario As Date
        Get
            Return _Date
        End Get
        Set(ByVal value As Date)
            _Date = value
        End Set
    End Property


    Overrides Function ToString() As String
        Return _Codigo & "   " & _Nome
    End Function

    Public Sub New()
        MyBase.New()
    End Sub


End Class

