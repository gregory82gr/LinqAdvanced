using Data;

var numbers = new[] { 10, 1, 4, 6, 17, 122 };
var doubledNumbers = from number in numbers
                     select number * 2;
Console.WriteLine("-------------------------");
Console.WriteLine("Numbers");
foreach (var number in numbers)
{
    Console.WriteLine(number);
}

Console.WriteLine("Doubled Numbers");
foreach (var number in doubledNumbers)
{
    Console.WriteLine(number);
}
Console.WriteLine("-------------------------");
var words = new[] { "little", "brown", "fox" };
var wordsToUpperCase = from word in words
                       select word.ToUpper();
Console.WriteLine("words");
foreach (var word in words)
{
    Console.WriteLine(word);
}
Console.WriteLine("Words To Upper Case");
foreach (var word in wordsToUpperCase)
{
    Console.WriteLine(word);
}
Console.WriteLine("-------------------------");
List<Pet> pets = Pet.GenerateMockData();
var namesOnly = from pet in pets
            select pet.Name;
Console.WriteLine("Names Only");
foreach (var name in namesOnly)
{
    Console.WriteLine(name);
}
Console.WriteLine("-------------------------");
var heavyPets = (from pet in pets
                where pet.Weight > 4
                select pet.Type).Distinct();
Console.WriteLine("Heavy Pets");
foreach (var type in heavyPets)
{
    Console.WriteLine(type);
}
Console.WriteLine("-------------------------");
var petInitials = from pet in pets
                  orderby pet.Name
                  select $" { pet?.Name?.First()}.";
Console.WriteLine("Pet Initials");
foreach (var initial in petInitials)
{
    Console.WriteLine(initial);
}
Console.WriteLine("-------------------------");
var petsData = from pet in pets
               select $"{pet.Name} is a {pet.Type} and weighs {pet.Weight} kg";
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Pets Data");
Console.ForegroundColor = ConsoleColor.Yellow;
foreach (var data in petsData)
{
    Console.WriteLine(data);
}