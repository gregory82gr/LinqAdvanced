var numbers = new[] { 10, 1, 4, 6, 17, 122 };
var sumOfNumbers = numbers.Aggregate(0, (sum, nextNumber) => sum + nextNumber);
Console.WriteLine("-------------------------");
Console.WriteLine("sumOfNumbers:{0}", sumOfNumbers);
Console.WriteLine("-------------------------");

var sentence = "The quick brown fox jumps over the lazy dog";

var longestWord = sentence.Split(' ')
    .Aggregate("", 
        (longest, next) => 
            next.Length > longest.Length ? next : longest);
Console.WriteLine("longestWord:{0}", longestWord);


Console.WriteLine("-------------------------");

var allLengthsOfSentenceWords = sentence.Split(' ')
    .Aggregate(Enumerable.Empty<int>(),
        (current, next) =>
            current.Append(next.Length));
Console.WriteLine("allLengthsOfSentenceWords:");
foreach (var length in allLengthsOfSentenceWords)
{
    Console.WriteLine(length);
}
Console.WriteLine("-------------------------");

var letters = new[] { 'a', 'b', 'c', 'd' };
var concatenatedLetters = letters.Aggregate("",(current, next) => current + next);
Console.WriteLine("concatenatedLetters:{0}", concatenatedLetters);
Console.WriteLine("-------------------------");
var concatenatedLettersWithCommma =
    letters.Aggregate("",
        (current, next) => $"{current},{next}");
Console.WriteLine("concatenatedLettersWithCommma:{0}", concatenatedLettersWithCommma);
Console.WriteLine("-------------------------");
var countOfLetters = letters.Aggregate(0, (count, next) => count + 1);
Console.WriteLine("countOfLetters:{0}", countOfLetters);
Console.WriteLine("-------------------------");
int factorial = 10;
var factorialOfTen = Enumerable.Range(1, factorial)
    .Aggregate(1, (factorial, next) => factorial * next);
Console.WriteLine("factorialOfTen:{0}", factorialOfTen);
Console.WriteLine("-------------------------");
int factorialBase = 10;
var factorialOfBase = Enumerable.Range(1, factorialBase-1)
    .Aggregate(10, (factorial, next) => factorial * (factorialBase - next));
Console.WriteLine("factorialOfBase:{0}", factorialOfBase);
Console.WriteLine("-------------------------");
