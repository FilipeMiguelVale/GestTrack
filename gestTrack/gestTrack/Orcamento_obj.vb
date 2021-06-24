Imports Microsoft.VisualBasic

<Serializable()> Public Class Orcamento_obj
    Private _Codigo As Integer
    Private _Nome As String
    Private _Validade As Integer
    Private _Valor As Integer
    Private _Iva As Integer
    Private _Data As Date
    Private _Atividade As Integer


    Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(ByVal value As Integer)
            _Codigo = value
        End Set
    End Property
    Property Atividade As Integer
        Get
            Return _Atividade
        End Get
        Set(ByVal value As Integer)
            _Atividade = value
        End Set
    End Property

    Property Nome() As String
        Get
            Nome = _Nome

        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("O nome do Orçamento não pode ser vazio")
                Exit Property
            End If
            _Nome = value
        End Set
    End Property


    Property validade As Integer
        Get
            Return _Validade
        End Get
        Set(ByVal value As Integer)
            _Validade = value
        End Set
    End Property

    Property Valor As Integer
        Get
            Return _Valor
        End Get
        Set(ByVal value As Integer)
            _Valor = value
        End Set
    End Property

    Property Iva As Integer
        Get
            Return _Iva
        End Get
        Set(ByVal value As Integer)
            _Iva = value
        End Set
    End Property



    Property Data As Date
        Get
            Return _Data

        End Get
        Set(ByVal value As Date)
            _Data = value
        End Set
    End Property


    Overrides Function ToString() As String
        Return _Codigo & "   " & _Nome
    End Function

    Public Sub New()
        MyBase.New()
    End Sub


End Class

