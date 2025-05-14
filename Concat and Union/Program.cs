using Data;
var numbers1 = new List<int> { 1, 2, 3,4,5 };
var numbers2 = new List<int> { 4, 5, 6, 7, 8, 9, 10 };

Console.WriteLine("Numbers1:");
foreach (var number in numbers1)
{
    Console.WriteLine(number);
}
Console.WriteLine("----------------");
Console.WriteLine("Numbers2:");
foreach (var number in numbers2)
{
    Console.WriteLine(number);
}
Console.WriteLine("----------------");
// Concat
var concatenatedNumbers = numbers1.Concat(numbers2);
Console.WriteLine("Concatenated numbers:");
foreach (var number in concatenatedNumbers)
{
    Console.WriteLine(number);
}
Console.WriteLine("----------------");
// Union
var unionNumbers = numbers1.Union(numbers2);
Console.WriteLine("Union numbers:");
foreach (var number in unionNumbers)
{
    Console.WriteLine(number);
}
Console.WriteLine("----------------");
//Union of pets
var pets1 = new[] {
   new Pet(1, "Goldie", PetType.Fish, 0.5),
   new Pet(2, "Whiskers", PetType.Cat, 4.2)
};
var pets2 = new[] {
     new Pet(1, "Goldie", PetType.Fish, 0.5),
    new Pet(5, "Shadow", PetType.Cat, 5.1)
};

var unionPets = pets1.Union(pets2);
Console.WriteLine("Union pets without comparer:");
foreach (var pet in unionPets)
{
    Console.WriteLine(pet);
}
Console.WriteLine("----------------");
// Union of pets with comparer
var unionPetsWithComparer = pets1.Union(pets2, new PetComparerById());
Console.WriteLine("Union pets with comparer:");
foreach (var pet in unionPetsWithComparer)
{
    Console.WriteLine(pet);
}
Console.WriteLine("----------------");