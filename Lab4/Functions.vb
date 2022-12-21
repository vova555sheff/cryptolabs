Public Class GCDResult
    Public Property D As Integer
    Public Property X As Integer
    Public Property Y As Integer
End Class

Public Class Functions
    Public Shared Function GCDEx(ByVal a As Integer, ByVal b As Integer) As GCDResult
        If a = 0 Then
            Return New GCDResult With {.D = b, .X = 0, .Y = 1 }
        End If

        Dim r0 = a
        Dim r1 = b
        Dim x0 = 1
        Dim x1 = 0
        Dim y0 = 0
        Dim y1 = 1

        While r1 <> 0
            Dim q As Integer = r0 \ r1

            Dim rTuple = (r0:=r1, r1:=r0 - q * r1)
            Dim xTuple = (x0:=x1, x1:=x0 - q * x1)
            Dim yTuple = (y0:=y1, y1:=y0 - q * y1)

            r0 = rTuple.r0
            r1 = rTuple.r1
            x0 = xTuple.x0
            x1 = xTuple.x1
            y0 = yTuple.y0
            y1 = yTuple.y1
        End While

        Return New GCDResult With { .D = r0, .X = x0, .Y = y0 }
    End Function

    Public Shared Function InverseElement(ByVal a As Integer, ByVal n As Integer) As Integer
        Dim gcd = GCDEx(a, n)

        Return (gcd.X Mod n + n) Mod n
    End Function

    Public Shared Function Phi(ByVal n As Integer) As Integer
        Dim output = 1
        For i = 2 To n - 1
            If GCDEx(i, n).d = 1 Then
                output += 1
            End If
        Next
        Return output
    End Function

    Public Shared Function InverseElement2(ByVal a As Integer, ByVal p As Integer) As Integer
        Return If(IsPrimeNumber(p), 
                  ModuleMultiplication(a, p - 2, p), 
                  ModuleMultiplication(a, Phi(p) - 1, p))
    End Function

    Private Shared Function IsPrimeNumber(ByVal number As Integer) As Boolean
        For i = 2 To number - 1
            If number Mod i = 0 Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Shared Function ModuleMultiplication(ByVal x As Integer, ByVal y As Integer, ByVal n As Integer) As Integer
        If y = 0 Then Return 1

        Dim p = ModuleMultiplication(x, y / 2, n) Mod n
        p = p * p Mod n

        Return If(y Mod 2 = 0, p, x * p Mod n)
    End Function
End Class
