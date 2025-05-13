
var numbers = new[] { 1, 2, 3, 4, 5,17,122 };
var numbers2 = new[] { 16 };

Console.WriteLine("All numbers:");
foreach (var number in numbers)
{
    Console.WriteLine(number);
};
Console.WriteLine("----------------");
var singleLargerThan100 = numbers.Single(x => x > 100);
Console.WriteLine("Single larger than 100: " + singleLargerThan100);
Console.WriteLine("----------------");
//var singleLargerThan15 = numbers.Single(x => x > 15);
//Console.WriteLine("SingleOrDefault larger than 15: " + singleLargerThan15);
//Console.WriteLine("----------------");
var singleElement=numbers2.Single();
Console.WriteLine("Single element: " + singleElement);
Console.WriteLine("----------------");
var singleElementEqualsTo18 = numbers.SingleOrDefault(x => x == 18);
Console.WriteLine("SingleOrDefault equals to 18: " + singleElementEqualsTo18);
Console.WriteLine("----------------");