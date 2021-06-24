Imports Microsoft.VisualBasic

<Serializable()> Public Class Material_obj

    Private _Codigo As Integer
    Private _Nome As String
    Private _Categoria As Integer
    Private _Valor As Integer
    Private _Iva As Integer
    Private _Super As Integer
    Private _Fatura As Integer
    Private _Armazem As Integer


    Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(ByVal value As Integer)
            _Codigo = value
        End Set
    End Property
    Property Super As Integer
        Get
            Return _Super
        End Get
        Set(ByVal value As Integer)
            _Super = value
        End Set
    End Property

    Property Fatura As Integer
        Get
            Return _Fatura
        End Get
        Set(ByVal value As Integer)
            _Fatura = value
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
    Property Armazem As Integer
        Get
            Return _Armazem
        End Get
        Set(ByVal value As Integer)
            _Armazem = value
        End Set
    End Property
    Property Categoria As Integer
        Get
            Return _Categoria
        End Get
        Set(ByVal value As Integer)
            _Categoria = value
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

    Property Nome() As String
        Get
            Nome = _Nome

        End Get
        Set(ByVal value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("O nome do Material não pode ser vazio")
                Exit Property
            End If
            _Nome = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return _Codigo & "   " & _Nome & "      " & _Valor & "€"
    End Function

    Public Sub New()
        MyBase.New()
    End Sub


End Class

