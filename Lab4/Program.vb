Imports System
Imports System.Text

Module Program
    Sub Main(args As String())
        Console.OutputEncoding = Encoding.UTF8

        GCDOutput()
        InverseElementOutput()
        PhiOutput()
        InverseElement2Output()
    End Sub

    Private Sub GCDOutput()
        Const gcdInputA = 612
        Const gcdInputB = 342
        Dim result = Functions.GCDEx(gcdInputA, gcdInputB)
        Console.WriteLine($"GCDEX для {gcdInputA} і {gcdInputB}: D={result.D}, X={result.X}, Y={result.Y}")
        Dim test = gcdInputA * result.X + gcdInputB * result.Y
        Console.WriteLine($"Перевірка GCDEX: {test = result.D}")
        Console.WriteLine()
    End Sub

    Private Sub InverseElementOutput()
        Const inputA = 5
        Const inputN = 18
        Dim result = Functions.InverseElement(inputA, inputN)
        Console.WriteLine($"InverseElement для {inputA} і {inputN}: {result}")
        Dim test = (inputA * result) Mod inputN
        Console.WriteLine($"Перевірка InverseElement: {test = 1}")
        Console.WriteLine()
    End Sub

    Private Sub PhiOutput()
        Const input = 18
        Dim result = Functions.Phi(input)
        Console.WriteLine($"Phi для {input}: {result}")
        Console.WriteLine($"Перевірка Phi: {result = 6}")
        Console.WriteLine()
    End Sub

    Private Sub InverseElement2Output()
        Const inputA = 5
        Const inputN = 18
        Dim result = Functions.InverseElement2(inputA, inputN)
        Console.WriteLine($"InverseElement2 для {inputA} і {inputN}: {result}")
        Dim test = (inputA * result) Mod inputN
        Console.WriteLine($"Перевірка InverseElement2: {test = 1}")
        Console.WriteLine()
    End Sub
End Module
