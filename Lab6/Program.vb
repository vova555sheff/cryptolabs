Imports System.Text

Module Program
    Sub Main(args As String())
        Console.OutputEncoding = Encoding.UTF8

        Mul02Output()
        Mul03Output()

        Console.ReadKey()
    End Sub

    Private Sub Mul02Output()
        Const mul02Input = &HD4
        Const mul02ExpectedResult = &HB3

        Dim result = GaloisField2Exp8.Mul02(mul02Input)
        Console.WriteLine($"Mul02 для {mul02Input.ToString("X2")}: {result.ToString("X2")}")
        Console.WriteLine($"Перевірка Mul02: {result = mul02ExpectedResult}")
        Console.WriteLine()
    End Sub

    Private Sub Mul03Output()
        Const mul03Input = &HBF
        Const mul03ExpectedResult = &HDA

        Dim result = GaloisField2Exp8.Mul03(mul03Input)
        Console.WriteLine($"Mul03 для {mul03Input.ToString("X2")}: {result.ToString("X2")}")
        Console.WriteLine($"Перевірка Mul03: {result = mul03ExpectedResult}")
    End Sub
End Module
