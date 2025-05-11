using Data;
using System.Linq;

List<Pet> pets = Pet.GenerateMockData();
Console.WriteLine("Pets");
foreach (var pet in pets)
{
    Console.WriteLine(pet);
}
Console.WriteLine("-------------------------");
var totalWeightByPetTypeOldWay = pets
    .GroupBy(pet => pet.Type)
    .Select(group => new
    {
        PetType = group.Key,
        TotalWeight = group.Sum(pet => pet.Weight)
    });
Console.WriteLine("Total Weight By Pet Type Old Way");
foreach (var petType in totalWeightByPetTypeOldWay)
{
    Console.WriteLine($"Pet Type: {petType.PetType}, Total Weight: {petType.TotalWeight}");
}
Console.WriteLine("-------------------------");
Console.WriteLine("Total Weight By Pet Type New Way");
var totalWeightByPetType = pets
    .AggregateBy(
        pet => pet.Type,
        0f,
        (totalWeight, pet) => (float)(totalWeight + pet.Weight));
foreach (var petType in totalWeightByPetType)
{
    Console.WriteLine($"Pet Type: {petType.Key}, Total Weight: {petType.Value}");
}