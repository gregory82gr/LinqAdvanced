using Data;

var numbers = new[] { 10, 2, 9, 4, 8, 6, 7, 3, 1, 5 };
Console.WriteLine("Numbers before sorting:");
foreach (var number in numbers)
{
    Console.WriteLine(number);
}
Console.WriteLine("---------------------------");
var sortedNumbers = from number in numbers
                    orderby number
                    select number;
Console.WriteLine("Sorted numbers using query syntax:");
foreach (var number in sortedNumbers)
{
    Console.WriteLine(number);
}
Console.WriteLine("---------------------------");
var sortedNumbersDescending = from number in numbers
                              orderby number descending
                              select number;
Console.WriteLine("Sorted numbers in descending order using query syntax:");
foreach (var number in sortedNumbersDescending)
{
    Console.WriteLine(number);
}
Console.WriteLine("---------------------------");
List<Pet> pets = Pet.GenerateMockData();
var petsOrderedByName = from pet in pets
                        orderby pet.Name
                        select pet;
Console.WriteLine("Pets ordered by name using query syntax:");
foreach (var pet in petsOrderedByName)
{
    Console.WriteLine(pet);
}
Console.WriteLine("---------------------------");
var petsOrderedByTypeAndWeight = from pet in pets
                                 orderby pet.Type, pet.Weight
                                 select pet;
Console.WriteLine("Pets ordered by type and then by weight using query syntax:");
foreach (var pet in petsOrderedByTypeAndWeight)
{
    Console.WriteLine(pet);
}

Console.WriteLine("---------------------------");
// Reverse
Console.WriteLine("Pets in reverse order:");
var reversedPets = (from pet in pets
                    orderby pet.Name
                    select pet).Reverse();
foreach (var pet in reversedPets)
{
    Console.WriteLine(pet);
}
Console.WriteLine("---------------------------");