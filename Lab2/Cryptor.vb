Public Class Cryptor
    Private ReadOnly _availableChars As String

    Private ReadOnly _size As Integer
    Private ReadOnly _matrixColNumber As Integer

    Private _matrix As Char()()

    Public Sub New(ByVal availableChars As String, ByVal size As Integer)
        _availableChars = availableChars
        _size = size
        _matrixColNumber = availableChars.Length / size

        PrepareMatrix()
    End Sub

    Private Sub PrepareMatrix()
        _matrix = New Char(_matrixColNumber - 1)() {}

        For i = 0 To _matrixColNumber - 1
            _matrix(i) = _availableChars.Skip(i * _size).Take(_size).ToArray()
        Next
    End Sub

    Public Function Encrypt(ByVal source As String) As String
        If Equals(source, Nothing) Then Throw New ArgumentNullException(NameOf(source))

        Dim calculatedPositionsInMatrix = (From character In source 
                Let i = _matrix.[Select](Function(a, idx) (a, idx)).Where(Function(tuple) tuple.a.Contains(character)).[Select](Function(tuple) tuple.idx).[Single]() 
                Let j = _matrix(i).[Select](Function(a, idx) (a, idx)).Where(Function(tuple) tuple.a = character).[Select](Function(tuple) tuple.idx).[Single]() 
                Select (i, j)).ToList()

        Dim numbers = calculatedPositionsInMatrix.[Select](Function(res) res.Item1).ToList()
        numbers.AddRange(calculatedPositionsInMatrix.[Select](Function(res) res.Item2))

        Dim result = New List(Of String)()
        For i = 0 To source.Length - 1
            Dim data = numbers.Skip(i * 2).Take(2).ToList()
            Dim movedData = data.Select(Function(n) n + 1).ToList()
            result.Add(String.Join("", movedData))
        Next

        Return String.Join(" ", result)
    End Function

    Public Function Decrypt(ByVal source As String) As String
        Dim rawNumbers = source.Split(" ", StringSplitOptions.RemoveEmptyEntries).SelectMany(Function(n) n).[Select](Function(n) Integer.Parse(n.ToString())).ToList()
        Dim movedNumbers = rawNumbers.Select(Function(n) n - 1)

        Dim indexes = movedNumbers.Chunk(rawNumbers.Count / 2).ToList()

        Return String.Join("", indexes(0).Zip(indexes(1)).[Select](Function(idx) _matrix(idx.First)(idx.Second)))
    End Function
End Class
