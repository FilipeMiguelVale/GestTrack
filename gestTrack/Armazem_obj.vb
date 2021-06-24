Imports Microsoft.VisualBasic

<Serializable()> Public Class Armazem_obj
    Private _Codigo As Integer
    Private _Nome As String
    Private _Morada As String
    Private _Telemovel As String


    Property IdArmazem As Integer
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("O Codigo do Armazem não pode ser vazio")
                Exit Property
            End If
            _Codigo = value
        End Set
    End Property

    Property ArmazemId As Integer
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("O Codigo do Armazem não pode ser vazio")
                Exit Property
            End If
            _Codigo = value
        End Set
    End Property


    Property NomeArmazem() As String
        Get
            NomeArmazem = _Nome
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("O nome do Armazem não pode ser vazio")
                Exit Property
            End If
            _Nome = value
        End Set
    End Property

    Property MoradaArmazem() As String
        Get
            MoradaArmazem = _Morada
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("A Morada do Armazem não pode ser vazia")
                Exit Property
            End If
            _Morada = value
        End Set
    End Property

    Property TelemovelArmazem() As String
        Get
            TelemovelArmazem = _Telemovel
        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("O Telemovel do Armazem não pode ser vazio")
                Exit Property
            End If
            _Telemovel = value
        End Set
    End Property


    Overrides Function ToString() As String
        Return _Codigo & "   " & _Nome
    End Function

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal CompanyName As String,
                   ByVal LastName As String, ByVal FirstName As String)
        MyBase.New()
        Me.ContactName = LastName & ", " & FirstName
        Me.CompanyName = CompanyName
    End Sub

    Public Sub New(ByVal CompanyName As String)
        MyBase.New()
        Me.CompanyName = CompanyName
    End Sub
End Class

