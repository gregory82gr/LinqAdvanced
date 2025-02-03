using Data;
using System.Linq;

List<Student> students = Student.GetStudents();
List<Pet> pets = Pet.GenerateMockData();
List<PetOwner> petOwners = PetOwner.GenerateMockData();

ShowDataAndRelationships(pets, petOwners, students);


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



static void ShowDataAndRelationships(List<Pet> pets, List<PetOwner> petOwners, List<Student> students)
{
    Console.WriteLine("Students");
    foreach (var student in students)
    {
        Console.WriteLine(student);
    }
    Console.WriteLine("-------------------------");

    Console.WriteLine("Pets");
    foreach (var pet in pets)
    {
        Console.WriteLine(pet);
    }
    Console.WriteLine("-------------------------");

    
    Console.WriteLine("Pets Owner");
    foreach (var owner in petOwners)
    {
        Console.WriteLine(owner);
    }
    Console.WriteLine("-------------------------");
}
