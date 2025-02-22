using Data;
using System.IO.Pipes;
using System.Linq;

List<Student> students = Student.GetStudents();
List<Pet> pets = Pet.GenerateMockData();
List<PetOwner> petOwners = PetOwner.GenerateMockData();

BasingObjects.ShowDataAndRelationships(pets, petOwners, students);


Console.WriteLine("-------------------------");

bool isNemoPresentVersion1 = pets.Contains(
    new Pet(4, "Nemo", PetType.Fish, 0.3)
    );
Console.WriteLine("isNemoPresentVersion1:{0}", isNemoPresentVersion1);

bool isNemoPresentVersion2 = pets.Contains(
    pets[3]
    );
Console.WriteLine("isNemoPresentVersion2:{0}", isNemoPresentVersion2);


bool isNemoPresentCustomComparerVersion1 = pets.Contains(
    new Pet(4, "Nemo", PetType.Fish, 0.3),
    new PetComparerById()
    );
Console.WriteLine("isNemoPresentCustomComparerVersion1:{0}", isNemoPresentCustomComparerVersion1);