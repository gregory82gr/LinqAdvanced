using Data;

var pets = new[] {
    new Pet(1, "Goldie", PetType.Fish, 0.5),
    new Pet(2, "Whiskers", PetType.Cat, 4.2),
    new Pet(3, "Buddy", PetType.Dog, 12.8),
    new Pet(4, "Nemo", PetType.Fish, 2.8),
    new Pet(5, "Shadow", PetType.Cat, 5.1),
    new Pet(4, "Nemo", PetType.Fish, 2.8),
};
Console.WriteLine("All pets:");
foreach (var pet in pets)
{
    Console.WriteLine(pet);
}
Console.WriteLine("----------------");
Console.WriteLine("DistinctBy pets");
var distinctPets = pets.DistinctBy(p => p.Id).ToList();
foreach (var pet in distinctPets)
{
    Console.WriteLine(pet);
}
