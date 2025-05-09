using Data;

var nestedListOfNumbers = new List<List<int>>
{
    new List<int> { 1, 2, 3 },
    new List<int> { 4, 5, 6 },
    new List<int> { 5,6 }
};

var flatListOfNumbers = from number in nestedListOfNumbers
                        from innerNumber in number
                        select innerNumber;

Console.WriteLine("Flat list of numbers using query syntax:");
foreach (var number in flatListOfNumbers)
{
    Console.WriteLine(number);
}

Console.WriteLine("---------------------------");

var numbers = new List<int> { 1, 2, 3, 4, 5 };
var letters = new List<string> { "A", "B", "C" };

var cartesianProduct = from number in numbers
                       from letter in letters
                       select new { Number = number, Letter = letter };
Console.WriteLine("Cartesian product using query syntax:");
foreach (var item in cartesianProduct)
{
    Console.WriteLine($"Number: {item.Number}, Letter: {item.Letter}");
}
Console.WriteLine("---------------------------");

var veryNestedListOfNumbers = new List<List<List<int>>>
{
    new List<List<int>>
    {
        new List<int> { 1, 2 },
        new List<int> { 3, 4 }
    },
    new List<List<int>>
    {
        new List<int> { 5, 6 },
        new List<int> { 7, 8 }
    }
};
var flatListOfNumbers2 = from number in veryNestedListOfNumbers
                         from innerList in number
                         from innerNumber in innerList
                         select innerNumber;

Console.WriteLine("Flat list of numbers from a very nested list using query syntax:");
foreach (var number in flatListOfNumbers2)
{
    Console.WriteLine(number);
}