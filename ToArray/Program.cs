var numbers = Enumerable.Range(1, 10);

// Use LINQ to filter even numbers and convert the result to an array
var evenNumbersArray = numbers.Where(n => n % 2 == 0).ToArray();

// Display the array
Console.WriteLine("Even Numbers:");
foreach (var number in evenNumbersArray)
{
    Console.WriteLine(number);
}
