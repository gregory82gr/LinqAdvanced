using Data;
using System.IO.Pipes;
using System.Linq;

List<Student> students = Student.GetStudents();
List<Pet> pets = Pet.GenerateMockData();
List<PetOwner> petOwners = PetOwner.GenerateMockData();

BasingObjects.ShowDataAndRelationships(pets, petOwners, students);


Console.WriteLine("-------------------------");
var nestedListOfNumbers = new List<List<int>>
{
    new List<int>{1,2,3},
    new List<int>{4,5,6},
    new List<int>{5,6}
};

var sum=nestedListOfNumbers.SelectMany(nestedListOfNumbers => nestedListOfNumbers).Sum();
Console.WriteLine("Sum");
Console.WriteLine(sum);

Console.WriteLine("all numbers");
var veryNestedListOfNumbers = new List<List<List<int>>>
{
    new List<List<int>>
    {
        new List<int>{1,2,3},
        new List<int>{4,5,6},
        new List<int>{5,6}
    },
    new List<List<int>>
    {
        new List<int>{10,12,13},
        new List<int>{14,15}      
    }
};

var allNumbers = veryNestedListOfNumbers
    .SelectMany(innerList => innerList)
    .SelectMany(innerInnerList => innerInnerList);

foreach (var number in allNumbers)
{
    Console.WriteLine(number);
}


Console.WriteLine("-------------------------");
Console.WriteLine("flattened Pets");
var petsOfOwners = petOwners.SelectMany(person => person.Pets);
foreach (var pet in petsOfOwners)
{
    Console.WriteLine(pet);
}

Console.WriteLine("flattened Pets of Owner whose name starts with A");
var petsOfOwnersA = petOwners
                    .Where(person => person.Name.StartsWith('A'))
                    .SelectMany(person => person.Pets);
foreach (var pet in petsOfOwnersA)
{
    Console.WriteLine(pet);
}

Console.WriteLine("-------------------------");

Console.WriteLine("Cartesian Product");

var numbers = new[] { 1, 2, 3 };
var letters = new[] { 'A', 'B', 'C' };

var cartesianProduct = numbers
                    .SelectMany(
                    number=>letters,
                    (number,letter)=> $"{number},{letter} "
                    );
foreach (var pair in cartesianProduct)
{
    Console.WriteLine(pair);
}