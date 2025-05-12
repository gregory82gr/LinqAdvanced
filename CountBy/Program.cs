using Data;

List<Pet> pets = Pet.GenerateMockData();
Console.WriteLine("All pets:");
foreach (var pet in pets)
{
    Console.WriteLine(pet);
}
Console.WriteLine("---------------");
//Count pets by groupBy and select
var petCountByTypeOld = pets.GroupBy(pet => pet.Type)
    .Select(group => new
    {
        Type = group.Key,
        Count = group.Count()
    });

Console.WriteLine("Count pets by type using GroupBy and Select:");
foreach (var petCount in petCountByTypeOld)
{
    Console.WriteLine($"Type: {petCount.Type}, Count: {petCount.Count}");
}
Console.WriteLine("---------------");
//Count pets by type using CountBY
var petCountByType = pets.CountBy(p => p.Type);

Console.WriteLine("Count pets by type using CountBy:");

foreach (var petCount in petCountByType)
{
    Console.WriteLine($"Type: {petCount.Key}, Count: {petCount.Value}");
}


