using Data;
using System.Linq;

var numbers = new[] { 1, 2, 3, 4, 5, 6 };
var words = new[] { "one", "two", "three", "four", "five", "six" };

var zipped = numbers.Zip(words, (number, word) => $"{number} - {word}");
Console.WriteLine("Zipped:");
foreach (var item in zipped)
{
    Console.WriteLine(item);
}
Console.WriteLine("-------------------------");

var moreNnumbers = new[] { 1, 2, 3, 4, 5, 6,7,8 };
var moreWords = new[] { "one", "two", "three", "four", "five", "six" };
var zippedMore = numbers.Zip(moreWords, (number, word) => $"{number} - {word}");
Console.WriteLine("Zipped with more numbers:");
foreach (var item in zippedMore)
{
    Console.WriteLine(item);
}
Console.WriteLine("-------------------------");
var moreWords2 = new[] { "one", "two", "three", "four", "five", "six", "seven", "eight" };
var zippedMore2 = numbers.Zip(moreWords2, (number, word) => $"{number} - {word}");
Console.WriteLine("Zipped with more words:");
for (int i = 0; i < zippedMore2.Count(); i++)
{
    Console.WriteLine(zippedMore2.ElementAt(i));
}
Console.WriteLine("-------------------------");

var countries = new[] { "USA", "Canada", "Mexico" };
var currencies = new[] { "USD", "CAD", "MXN" };

var countryCurrencyDictionary = countries.Zip(currencies, 
    (country, currency) => new { country, currency })
    .ToDictionary(x => x.country, x => x.currency);
Console.WriteLine("Country-Currency Dictionary:");
foreach (var kvp in countryCurrencyDictionary)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}
Console.WriteLine("-------------------------");

var points = new[] 
{ 
    new Point(10,10),
    new Point(10,11),
    new Point(11,12),
    new Point(11,14),
    new Point(12,16)
};

var distances = points.Zip(points.Skip(1),
    (point1, point2) => Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2)));
Console.WriteLine("Distances between points:");
foreach (var distance in distances)
{
    Console.WriteLine(distance);
}
Console.WriteLine("-------------------------");