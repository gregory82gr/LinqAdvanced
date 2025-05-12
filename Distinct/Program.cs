using Data;


var numbersWithDuplicates = new[] { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };
Console.WriteLine("All numbers:");
foreach (var number in numbersWithDuplicates)
{
    Console.WriteLine(number);
};
Console.WriteLine("----------------");
var distinctNumbers = numbersWithDuplicates.Distinct().ToList();
Console.WriteLine("Distinct numbers:");
foreach (var number in distinctNumbers)
{
    Console.WriteLine(number);
}
Console.WriteLine("----------------");
var pets= new[] {
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
Console.WriteLine("Distinct pets:Wrong Approach");
var distinctPets = pets.Distinct().ToList();
foreach (var pet in distinctPets)
{
    Console.WriteLine(pet);
}
Console.WriteLine("----------------");
Console.WriteLine("Distinct pets:Right Approach");
var distinctPets2 = pets.Distinct(new PetComparerById()).ToList();
foreach (var pet in distinctPets2)
{
    Console.WriteLine(pet);
}
