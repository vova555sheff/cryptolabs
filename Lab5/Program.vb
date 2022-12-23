Imports System.Text

Module Program
    Sub Main(args As String())
        Console.OutputEncoding = Encoding.UTF8

        MillerRabinOutput()
        
        RSAOutput()
        Console.ReadKey()
    End Sub

    Private Sub MillerRabinOutput()
        Console.WriteLine($"Тест простоти Міллера — Рабіна")
        Console.WriteLine($"Тест для числа 19: {MillerRabin.IsPrime(19, 5)}")
        Console.WriteLine($"Тест для числа 25: {MillerRabin.IsPrime(25, 3)}")
        Console.WriteLine()
    End Sub

    Private Sub RSAOutput()
        Console.WriteLine($"RSA")
        Dim rsaKeys = RSAKeyGenerator.Generate(8)
        Console.WriteLine(rsaKeys.PublicKey.PrettyPrint())
        Console.WriteLine(rsaKeys.PrivateKey.PrettyPrint())

        Const digitToEncrypt = 18
        Dim cryptor = new RSACryptor()

        Dim encryptedData = cryptor.Encrypt(digitToEncrypt, rsaKeys.PublicKey)
        Dim decryptedData = cryptor.Decrypt(encryptedData, rsaKeys.PrivateKey)

        Console.WriteLine($"Вхідні дані: {digitToEncrypt}")
        Console.WriteLine($"Зашифровані дані: {encryptedData}")
        Console.WriteLine($"Розшифровані дані: {decryptedData}")
    End Sub
End Module
