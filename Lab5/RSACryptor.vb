Imports System.Numerics

Public Class RSACryptor
    Public Function Encrypt(ByVal plainData As BigInteger, ByVal publicKey As RsaKey) As BigInteger
        Return BigInteger.Pow(plainData, publicKey.E) Mod publicKey.N
    End Function

    Public Function Decrypt(ByVal encryptedData As BigInteger, ByVal privateKey As RsaKey) As BigInteger
        Return BigInteger.Pow(encryptedData, privateKey.D) Mod privateKey.N
    End Function
End Class