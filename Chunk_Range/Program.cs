using static System.Console;
using System.Collections.Generic;
using System.Linq;

var numbers = new List<int>(Enumerable.Range(1, 25));
var chunks = numbers.Chunk(10);

Console.WriteLine("Chunks  of 10 numbers");
foreach (var chunk in chunks)
{
    foreach (var item in chunk)
    {
        Write($"{item}, ");
    }
    WriteLine();
}
