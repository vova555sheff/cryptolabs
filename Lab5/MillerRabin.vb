Public Class MillerRabin
    Public Shared Function IsPrime(ByVal n As Integer, ByVal k As Integer) As Boolean
        If n < 2 OrElse n Mod 2 = 0 Then Return n = 2

        Dim s = n - 1
        While s Mod 2 = 0
            s >>= 1
        End While

        Dim r = New Random()
        For i = 0 To k - 1
            Dim a = r.[Next](n - 1) + 1
            Dim temp = s
            Dim [mod] As Long = 1
            Dim j = 0

            While j < temp
                [mod] = [mod] * a Mod n
                Threading.Interlocked.Increment(j)
            End While
            While temp <> n - 1 AndAlso [mod] <> 1 AndAlso [mod] <> n - 1
                [mod] = [mod] * [mod] Mod n
                temp *= 2
            End While

            If [mod] <> n - 1 AndAlso temp Mod 2 = 0 Then
                Return False
            End If
        Next
        Return True
    End Function
End Class
