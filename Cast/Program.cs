// An object array where each element is an integer (boxed as object)
object[] numberObjects = { 10, 20, 30, 40, 50 };

// Use Cast<int>() to convert the object array to IEnumerable<int>
var numbers = numberObjects.Cast<int>();

// Use LINQ operations on the converted collection
int sum = numbers.Sum();
Console.WriteLine($"Sum: {sum}");

// Filter the numbers to get only those greater than 25
var filteredNumbers = numbers.Where(n => n > 25);
Console.WriteLine("Numbers greater than 25:");
foreach (var number in filteredNumbers)
{
    Console.WriteLine(number);
}