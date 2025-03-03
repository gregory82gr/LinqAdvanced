// Example 1: Creating an empty sequence of integers.
IEnumerable<int> emptyNumbers = Enumerable.Empty<int>();
Console.WriteLine("Count of emptyNumbers: " + emptyNumbers.Count());
// Output: Count of emptyNumbers: 0

// Example 2: Combining an empty sequence with a non-empty sequence.
IEnumerable<int> numbers = new[] { 1, 2, 3 };
IEnumerable<int> combined = emptyNumbers.Concat(numbers);
Console.WriteLine("Combined sequence:");
foreach (var num in combined)
{
    Console.WriteLine(num);
}
// Output: 1, 2, 3

