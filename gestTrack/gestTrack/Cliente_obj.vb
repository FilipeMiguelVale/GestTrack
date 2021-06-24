Imports Microsoft.VisualBasic

<Serializable()> Public Class Cliente_obj
    Private _Nome As String
    Private _Email As String
    Private _Morada As String
    Private _Telemovel As String
    Private _NIF As Integer


    Property NomeCliente() As String
        Get
            NomeCliente = _Nome
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("O nome do Armazem não pode ser vazio")
                Exit Property
            End If
            _Nome = value
        End Set
    End Property

    Property EmailCliente() As String
        Get
            EmailCliente = _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property

    Property MoradaCliente() As String
        Get
            MoradaCliente = _Morada
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("A Morada do Armazem não pode ser vazia")
                Exit Property
            End If
            _Morada = value
        End Set
    End Property

    Property TelemovelCliente() As String
        Get
            TelemovelCliente = _Telemovel
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                value = ""
            End If
            _Telemovel = value
        End Set
    End Property

    Property NifCliente As Integer
        Get
            Return _NIF
        End Get
        Set(ByVal value As Integer)
            _NIF = value
        End Set
    End Property


    Overrides Function ToString() As String
        Return _NIF & "   " & _Nome
    End Function

    Public Sub New()
        MyBase.New()
    End Sub


End Class

