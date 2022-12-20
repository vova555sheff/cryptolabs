Imports System.Text

Module Program
    Sub Main(args As String())
        Console.OutputEncoding = Encoding.UTF8

        Const plainText = "програмнезабезпечення"

        Dim cryptor = new Cryptor("крипто", "шифр")

        Dim encryptedData = cryptor.Encrypt(plainText)
        Dim decryptedData = cryptor.Decrypt(encryptedData)

        Console.WriteLine($"Вхідні дані: {plainText}")
        Console.WriteLine($"Зашифровані дані: {encryptedData}")
        Console.WriteLine($"Розшифровані дані: {decryptedData}")

        Console.ReadKey()
    End Sub
End Module
