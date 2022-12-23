using System.Text;
using Lab9;

Console.OutputEncoding = Encoding.UTF8;

const string plainText = "VK data";

var hasher = new MD5Hasher();
var hashedData = hasher.ComputeHash(plainText);

Console.WriteLine($"Вхідні дані: {plainText}");
Console.WriteLine($"Захешовані дані: {hashedData}");

Console.ReadKey();