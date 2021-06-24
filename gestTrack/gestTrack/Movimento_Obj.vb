Imports Microsoft.VisualBasic

<Serializable()> Public Class Movimento_obj
    Private _Codigo As Integer
    Private _Nome As String
    Private _Descricao As String
    Private _Data As Date
    Private _Funcionario As Integer
    Private _Atividade As Integer


    Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(ByVal value As Integer)
            _Codigo = value
        End Set
    End Property
    Property Funcionario As Integer
        Get
            Return _Funcionario
        End Get
        Set(ByVal value As Integer)
            _Funcionario = value
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
                Throw New Exception("O nome do Movimento não pode ser vazio")
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
    Property Data As Date
        Get
            Return _Data

        End Get
        Set(ByVal value As Date)
            _Data = value
        End Set
    End Property
    Overrides Function ToString() As String
        Return _Codigo & "   " & _Nome & "   " & _Descricao
    End Function

    Public Sub New()
        MyBase.New()
    End Sub


End Class

