Public Class GaloisField2Exp8

    Public Const GaloisFieldConst As Integer = &H11b

    Public Shared Function Mul02(ByVal b As Byte) As Byte
        Dim bShiftRight7 As Integer = b >> 7
        Dim bShiftLeft1 As Integer = Convert.ToInt32(b) << 1

        Dim result = If(bShiftRight7, bShiftLeft1 Xor GaloisFieldConst, bShiftLeft1)

        Return Convert.ToByte(result)
    End Function

    Public Shared Function Mul03(ByVal b As Byte) As Byte
        Return Mul02(b) Xor b
    End Function
End Class