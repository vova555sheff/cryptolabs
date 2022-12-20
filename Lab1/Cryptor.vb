Public Class Cryptor
    Private ReadOnly _verticalKey As String
    Private ReadOnly _horizontalKey As String

    Private _maxLength As Integer
    Private _verticalSorter As Integer()
    Private _horizontalSorter As Integer()

    Public Sub New(ByVal verticalKey As String, ByVal horizontalKey As String, ByVal Optional defaultValue As Char = "."c)
        _verticalKey = verticalKey
        _horizontalKey = horizontalKey
        Init()
    End Sub

    Private Sub Init()
        _maxLength = _verticalKey.Length * _horizontalKey.Length

        _verticalSorter = _verticalKey.[Select](Function(x, i) New KeyValuePair(Of Integer, Char)(i, x)).OrderBy(Function(k) k.Value).[Select](Function(x) x.Key).ToArray()

        _horizontalSorter = _horizontalKey.[Select](Function(x, i) New KeyValuePair(Of Integer, Char)(i, x)).OrderBy(Function(k) k.Value).[Select](Function(x) x.Key).ToArray()
    End Sub

    Public Function Encrypt(ByVal value As String) As String
        If value.Length > _maxLength Then Throw New ArgumentException(NameOf(value), "вхідні дані повинні відповідати розмірності ключів")

        value = value.PadRight(_maxLength)

        Dim originalMatrix = GenerateMatrix(value)

        Dim horizontallySorted = originalMatrix.Zip(_horizontalKey).OrderBy(Function(a) a.Second).[Select](Function(a) a.First).ToArray()

        Dim transposedMatrix = Transpose(horizontallySorted)

        Dim verticallySorted = transposedMatrix.Zip(_verticalKey).OrderBy(Function(a) a.Second).[Select](Function(a) a.First).ToArray()

        Return String.Join("", verticallySorted.SelectMany(Function(i) i))
    End Function

    Public Function Decrypt(ByVal value As String) As String
        If value.Length > _maxLength Then Throw New ArgumentException(NameOf(value), "вхідні дані повинні відповідати розмірності ключів")

        Dim originalMatrix = GenerateMatrix(value, True)

        Dim verticallySorted = originalMatrix.Zip(_verticalSorter).OrderBy(Function(a) a.Second).[Select](Function(a) a.First).ToArray()

        Dim transposed = Transpose(verticallySorted)

        Dim horizontallySorted = transposed.Zip(_horizontalSorter).OrderBy(Function(a) a.Second).[Select](Function(a) a.First).ToArray()

        Return String.Join("", horizontallySorted.SelectMany(Function(a) a))
    End Function

    Private Function GenerateMatrix(ByVal value As String, ByVal Optional invert As Boolean = False) As Char()()
        Dim width = If(invert, _horizontalKey.Length, _verticalKey.Length)
        Dim height = If(invert, _verticalKey.Length, _horizontalKey.Length)

        Dim result = New Char(height - 1)() {}

        Dim valueAsArray = value.ToArray()
        For i = 0 To height - 1
            result(i) = valueAsArray.Skip(i * width).Take(width).ToArray()
        Next

        Return result
    End Function

    Private Shared Function Transpose(Of T)(ByVal source As T()()) As T()()
        Dim width = source(0).Length

        Dim out = New T(width - 1)() {}

        For i = 0 To width - 1
            out(i) = source.[Select](Function(s) s(i)).ToArray()
        Next

        Return out
    End Function

End Class
