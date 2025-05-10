using _Introduction;


var numbers = new[] { 1, 2, 3, 4, 5,122,256 };
var words = new[] { "little", "brown", "fox" };
Console.WriteLine("CLASIC-Any.IsAny(numbers, x => x > 100);");
var isAnyNumberLargerThan100 = Any.IsAny(numbers, x => x > 100);
Console.WriteLine($"Is any number larger than 100? {isAnyNumberLargerThan100}");
var isAnyNumberOdd = Any.IsAny(numbers, x => x % 2 != 0);
Console.WriteLine($"Is any number odd? {isAnyNumberOdd}");
var isAnyWordLongerThan3 = Any.IsAny(words, x => x.Length > 3);
Console.WriteLine($"Is any word longer than 3? {isAnyWordLongerThan3}");

Console.WriteLine("-------------------------");
Console.WriteLine("GENERIC -Any.IsAny<int>(numbers, x => x > 100)");

var isAnyNumberLargerThan100Generic = Any.IsAny<int>(numbers, x => x > 100);
Console.WriteLine($"Is any number larger than 100? {isAnyNumberLargerThan100Generic}");
var isAnyNumberOddGeneric = Any.IsAny<int>(numbers, x => x % 2 != 0);
Console.WriteLine($"Is any number odd? {isAnyNumberOddGeneric}");
var isAnyWordLongerThan3Generic = Any.IsAny<string>(words, x => x.Length > 3);
Console.WriteLine($"Is any word longer than 3? {isAnyWordLongerThan3Generic}");

Console.WriteLine("-------------------------");
Console.WriteLine("GENERIC -EXTENSION -numbers.IsAnyAsExtension(x => x > 100)");
var isAnyNumberLargerThan100GenericExtension = numbers.IsAnyAsExtension(x => x > 100);
Console.WriteLine($"Is any number larger than 100? {isAnyNumberLargerThan100GenericExtension}");
var isAnyNumberOddGenericExtension = numbers.IsAnyAsExtension(x => x % 2 != 0);
Console.WriteLine($"Is any number odd? {isAnyNumberOddGenericExtension}");
var isAnyWordLongerThan3GenericExtension = words.IsAnyAsExtension(x => x.Length > 3);
Console.WriteLine($"Is any word longer than 3? {isAnyWordLongerThan3GenericExtension}");
Console.WriteLine("-------------------------");
Console.WriteLine("LINQ -numbers.Any(x => x > 100)");
var isAnyNumberLargerThan100LINQ = numbers.Any(x => x > 100);
Console.WriteLine($"Is any number larger than 100? {isAnyNumberLargerThan100LINQ}");
var isAnyNumberOddLINQ = numbers.Any(x => x % 2 != 0);
Console.WriteLine($"Is any number odd? {isAnyNumberOddLINQ}");
var isAnyWordLongerThan3LINQ = words.Any(x => x.Length > 3);
Console.WriteLine($"Is any word longer than 3? {isAnyWordLongerThan3LINQ}");
Console.WriteLine("-------------------------");

Console.WriteLine("-------------------------");
Console.WriteLine("GENERIC -EXTENSION-WithoutCondition");
var isAnyNumberGenericExtensionWithoutCondition = numbers.IsAnyAsExtensionWithoutCondition();
Console.WriteLine($"Is any number?  {isAnyNumberGenericExtensionWithoutCondition}");

Console.WriteLine("-------------------------");
Console.WriteLine("GENERIC -EXTENSION-ERRORS");

try
{
    var isAnyNumberLargerThan100GenericExtensionError = numbers?.IsAnyAsExtension(null);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

numbers = null;
try
{
    var isAnyNumberLargerThan100GenericExtensionError = numbers.IsAnyAsExtension(null);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
