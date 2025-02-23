using Data;
using System.Linq;

List<Student> students = Student.GetStudents();
List<Pet> pets = Pet.GenerateMockData();
List<PetOwner> petOwners = PetOwner.GenerateMockData();

BasingObjects.ShowDataAndRelationships(pets, petOwners, students);
Console.WriteLine("-------------------------");
Console.WriteLine("Pets weights by Type Lookup");
var petsWeightByTypeLookUp = pets.ToLookup(
    pet=>pet.Type,
    pet => pet.Weight
    );
foreach (var group in petsWeightByTypeLookUp)
{
    // Print the key (pet type)
    Console.WriteLine($"Pet Type: {group.Key}");

    // Iterate over the weights in the group and print each weight
    foreach (var weight in group)
    {
        Console.WriteLine($"  Weight: {weight}");
    }
}

Console.WriteLine("weights sum by Type with dictionary");
var sumWeightsPerType = petsWeightByTypeLookUp.ToDictionary(
    lookup=>lookup.Key,
    lookup=>lookup.Sum()
    );

foreach (var entry in sumWeightsPerType)
{
    Console.WriteLine($"Pet Type: {entry.Key}, Total Weight: {entry.Value}");
}

Console.WriteLine("weights  by Type with Group by");
var groupings = pets.GroupBy(
    pet => pet.Type,
    pet => pet.Weight
    );
foreach (var group in groupings)
{
    Console.WriteLine($"Pet Type: {group.Key}");

    foreach (var weight in group)
    {
        Console.WriteLine($"  Weight: {weight}");
    }
}

Console.WriteLine("weights sum by Type with Group by");
var sumWeightsPerType2 = groupings.ToDictionary(
    lookup => lookup.Key,
    lookup => lookup.Sum()
    );
foreach (var entry in sumWeightsPerType2)
{
    Console.WriteLine($"Pet Type: {entry.Key}, Total Weight: {entry.Value}");
}

Console.WriteLine("weights sum by Type with Group by Approach 2");
var dict = pets.GroupBy(p => p.Type).ToDictionary(grp => grp.Key, grp => grp.Sum(p => p.Weight));
foreach (var item in dict)
{
    Console.WriteLine("{0} = {1}", item.Key, item.Value);
}

Console.WriteLine("-------------------------");
var personsInitialsToPetsMapping = petOwners.
                                 GroupBy(person => person.Name.First())
                                 .ToDictionary(
                                    grouping => grouping.Key + ".",
                                    grouping => string.Join(", ", grouping
                                        .SelectMany(person => person.Pets)
                                        .Select(pet => pet.Name)));
                                  


foreach (var pet in personsInitialsToPetsMapping)
{
    Console.WriteLine(pet);
}
Console.WriteLine("-------------------------");
Console.WriteLine("Students by branch");
IEnumerable<IGrouping<string, Student>> GroupByMS = Student.GetStudents().GroupBy(s => s.Barnch);

foreach (IGrouping<string, Student> group in GroupByMS)
{
    Console.WriteLine(group.Key + " : " + group.Count());
    //Iterate through each student of a group
    foreach (var student in group)
    {
        Console.WriteLine("  Name :" + student.Name + ", Age: " + student.Age + ", Gender :" + student.Gender);
    }
}



