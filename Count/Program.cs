using Data;

List<Pet> pets = Pet.GenerateMockData();
Console.WriteLine("All pets:");
foreach (var pet in pets)
{
    Console.WriteLine(pet);
}

//Count pets
int petCount = pets.Count();
Console.WriteLine($"Total number of pets: {petCount}");
Console.WriteLine("---------------");
//Count pets by type
int fishCount = pets.Count(pet => pet.Type == PetType.Fish);
Console.WriteLine($"Total number of fish: {fishCount}");
Console.WriteLine("---------------");
//Count dogs more than 10Kg
int dogCount = pets.Count(pet => pet.Type == PetType.Dog && pet.Weight > 10);
Console.WriteLine($"Total number of dogs more than 10Kg: {dogCount}");
Console.WriteLine("---------------");
//LongCount
long longCount = pets.LongCount();
Console.WriteLine($"Total number of pets (using LongCount): {longCount}");
Console.WriteLine("---------------");


