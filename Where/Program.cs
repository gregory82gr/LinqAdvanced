using Data;

var numbers = new[] { 10, 1, 4, 17, 122, 567 };
var evenNumbers = numbers.Where(x => x % 2 == 0);
Console.WriteLine("-------------------------");
Console.WriteLine("Numbers");
foreach (var number in numbers)
{
    Console.WriteLine(number);
}
Console.WriteLine("Even Numbers");
foreach (var number in evenNumbers)
{
    Console.WriteLine(number);
}
Console.WriteLine("-------------------------");

var pets = Pet.GenerateMockData();
var petsHeavierThan10 = pets.Where(x => x.Weight > 10);
Console.WriteLine("Pets");
foreach (var pet in pets)
{
    Console.WriteLine(pet);
}
Console.WriteLine("Pets Heavier Than 10");
foreach (var pet in petsHeavierThan10)
{
    Console.WriteLine(pet);
}
var petsHeavierThan100 = pets.Where(x => x.Weight > 100);
Console.WriteLine("Pets Heavier Than 100");
foreach (var pet in petsHeavierThan100)
{
    Console.WriteLine(pet);
}

var verySpecificPets = pets
    .Where(x => x.Weight > 4 && (x.Type == PetType.Cat || x.Type == PetType.Dog) && x.Name?.Length>4 && x.Id %2==0)
    .Select(x => $"Pet named {x.Name}, of type {x.Type} ");
Console.WriteLine("Very Specific Pets");
foreach (var pet in verySpecificPets)
{
    Console.WriteLine(pet);
}


var petIndexesSelectedByUser = new[] { 0,  2,  4};
var petsSelectedByUserAndLighterThan5Kilos =
    pets
    .Where((pet, index) => petIndexesSelectedByUser.Contains(index) && pet.Weight < 5)
    .Select(x => $"Pet named {x.Name}, of type {x.Type} ");
Console.WriteLine("Pets Selected By User And Lighter Than 5 Kilos");
foreach (var pet in petsSelectedByUserAndLighterThan5Kilos)
{
    Console.WriteLine(pet);
}
Console.WriteLine("-------------------------");

var countOfDogsHeavierThan3KilosUsingCountMethod =
    pets
    .Count(x => x.Type == PetType.Dog && x.Weight > 3);
Console.WriteLine($"Count of dogs heavier than 3 kilos using Count method: {countOfDogsHeavierThan3KilosUsingCountMethod}");
var countOfDogsHeavierThan3KilosUsingWhereMethod =
    pets
    .Where(x => x.Type == PetType.Dog && x.Weight > 3)
    .Count();
Console.WriteLine($"Count of dogs heavier than 3 kilos using Where method: {countOfDogsHeavierThan3KilosUsingWhereMethod}");
var countOfDogsHeavierThan3KilosUsingAggregateMethod =
    pets
    .Aggregate(0, (count, pet) => pet.Type == PetType.Dog && pet.Weight > 3 ? count + 1 : count);
Console.WriteLine($"Count of dogs heavier than 3 kilos using Aggregate method: {countOfDogsHeavierThan3KilosUsingAggregateMethod}");
var countOfDogsHeavierThan3KilosUsingForEachMethod =
    pets
    .Select(x => x.Type == PetType.Dog && x.Weight > 3)
    .Aggregate(0, (count, isDog) => isDog ? count + 1 : count);
Console.WriteLine($"Count of dogs heavier than 3 kilos using ForEach method: {countOfDogsHeavierThan3KilosUsingForEachMethod}");
