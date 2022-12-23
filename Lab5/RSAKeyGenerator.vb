Imports Lab4

Public Class RSAKeyGenerator
    Public Shared Function Generate(primeKeyBitLength As Integer) As RSAKeys
        Dim pqPair = GeneratePQ(primeKeyBitLength)

        Dim n = pqPair.P * pqPair.Q
        Dim phi = (pqPair.P - 1) * (pqPair.Q - 1)

        Console.WriteLine($"p: {pqPair.P}, q: {pqPair.Q}")
        Console.WriteLine($"phi: {phi}")

        Dim e = 2

        While e < phi
            If Functions.GcdEx(e, phi).d = 1 Then
                Exit While
            End If
            e += 1
        End While

        Dim d = Functions.InverseElement(e, phi)

        Dim publicKey = new RsaKey(n, e)
        Dim privateKey = new RsaKey(n, d, e)

        Return New RSAKeys With { .PublicKey = publicKey, .PrivateKey = privateKey }
    End Function


    Private Shared Function GeneratePQ(primeKeyBitLength As Integer) As PQPair
        Dim p = -1

        Dim random = New Random()
        Dim randomBytes = New Byte((primeKeyBitLength + 8 - 1) \ 8 - 1) {}
        random.NextBytes(randomBytes)
        If randomBytes.Length <> 4 Then
            randomBytes = randomBytes.Concat(Enumerable.Repeat(DirectCast(Nothing, Byte), 4 - randomBytes.Length)).ToArray()
        End If

        Dim number = BitConverter.ToInt32(randomBytes, 0)

        While True
            If MillerRabin.IsPrime(number, 10) Then
                If p = -1 Then
                    p = number
                    number += 1
                    Continue While
                End If

                Dim second = number
                Return New PQPair With {.P = p, .Q = second }
            End If

            number += 1
        End While

        Throw New Exception("Прості числа не знайдені")
    End Function
    
End Class

Public Class RSAKeys
    Public Property PublicKey As RsaKey
    Public Property PrivateKey As RsaKey
End Class

Public Class PQPair
    Public Property P As Integer
    Public Property Q As Integer
End Class