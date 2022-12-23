Public Class RsaKey
    Public ReadOnly N As Integer
    Public ReadOnly E As Integer
    Public ReadOnly D As Integer?

    Public ReadOnly KeyType As RSAKeyType

    Public Sub New(ByVal n As Integer, ByVal e As Integer)
        Me.N = n
        Me.E = e
        KeyType = RSAKeyType.Public
    End Sub

    Public Sub New(ByVal n As Integer, ByVal d As Integer, ByVal e As Integer)
        Me.N = n
        Me.D = d
        Me.E = e
        KeyType = RSAKeyType.Private
    End Sub

    Public Function PrettyPrint() As String
        If KeyType = RSAKeyType.Public
            Console.WriteLine("Відкритий ключ:")
            Console.WriteLine($"n: {N}")
            Console.WriteLine($"e: {E}")
        ElseIf KeyType = RSAKeyType.Private
            Console.WriteLine("Зaкритий ключ:")
            Console.WriteLine($"n: {N}")
            Console.WriteLine($"e: {E}")
            Console.WriteLine($"d: {D}")
        End If
    End Function
End Class