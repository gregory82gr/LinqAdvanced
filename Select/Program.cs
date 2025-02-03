using Data;
using System.Linq;

List<Student> students = Student.GetStudents();
List<Pet> pets = Pet.GenerateMockData();
List<PetOwner> petOwners = PetOwner.GenerateMockData();

BasingObjects.ShowDataAndRelationships(pets, petOwners, students);

var numbers = new[] { 10, 1, 4, 6, 17, 122 };
var doubledNumbers = numbers.Select(x => x * 2);
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

var words = new[] {"little","brown","fox" };
var wordsToUpperCase = words.Select(x => x.ToUpper());
var numberedWords = words.Select(
    (word,index) => $"{index+1}.{word}");

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

Console.WriteLine("numberedWords");

foreach (var word in numberedWords)
{
    Console.WriteLine(word);
}

Console.WriteLine("-------------------------");

var weights=pets.Select(x => x.Weight);
var heavyPetTypes=pets.
    Where(x=>x.Weight>4)
    .Select(x=>x.Type)
    .Distinct();
var petsInitials = pets
    .OrderBy(pet => pet.Name)
    .Select(pet => $"{pet.Name.First()}.");
var petsData = pets.Select(pet =>
$"Pet named {pet.Name}, of type{pet.Type} " +
$"and weight {pet.Weight}");


Console.WriteLine("weights of pets");

foreach (var weight in weights)
{
    Console.WriteLine(weight);
}

Console.WriteLine("Heavy");

foreach (var weight in heavyPetTypes)
{
    Console.WriteLine(weight);
}

Console.WriteLine("petsInitials");

foreach (var petsInitial in petsInitials)
{
    Console.WriteLine(petsInitial);
}

Console.WriteLine("petsData");

foreach (var petsDato in petsData)
{
    Console.WriteLine(petsDato);
}

Console.WriteLine("-------------------------");