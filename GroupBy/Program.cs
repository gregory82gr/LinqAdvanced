using Data;
using System.Linq;

List<Student> students = Student.GetStudents();
List<Pet> pets = Pet.GenerateMockData();
List<PetOwner> petOwners = PetOwner.GenerateMockData();

BasingObjects.ShowDataAndRelationships(pets, petOwners, students);
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



