Imports Microsoft.VisualBasic

<Serializable()> Public Class Atividade_obj
    Private _Codigo As Integer
    Private _Nome As String
    Private _Descricao As String
    Private _Data_Inicio As Date
    Private _Data_Fim As Date
    Private _Cliente As Integer


    Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(ByVal value As Integer)
            _Codigo = value
        End Set
    End Property
    Property Cliente As Integer
        Get
            Return _Cliente
        End Get
        Set(ByVal value As Integer)
            _Cliente = value
        End Set
    End Property

    Property Nome() As String
        Get
            Nome = _Nome

        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("O nome do Armazem não pode ser vazio")
                Exit Property
            End If
            _Nome = value
        End Set
    End Property

    Property Descricao() As String
        Get
            Descricao = _Descricao
        End Get
        Set(ByVal value As String)

            _Descricao = value
        End Set
    End Property

    Property Data_Inicio As Date
        Get
            Return _Data_Inicio

        End Get
        Set(ByVal value As Date)
            _Data_Inicio = value
        End Set
    End Property
    Property Data_Fim As Date
        Get
            Return _Data_Fim
        End Get
        Set(ByVal value As Date)
            _Data_Fim = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return _Codigo & "   " & _Nome
    End Function

    Public Sub New()
        MyBase.New()
    End Sub


End Class

