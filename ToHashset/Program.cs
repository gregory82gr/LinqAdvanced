List<int> numbers = new List<int> { 5, 2, 3, 4, 1, 2, 3, 4 };

// Convert to HashSet using ToHashSet()
HashSet<int> uniqueNumbers = numbers.ToHashSet();

// Display the unique numbers
Console.WriteLine("Unique numbers:");
foreach (int number in uniqueNumbers)
{
    Console.WriteLine(number);
}