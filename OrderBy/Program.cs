using Data;
using System;
using System.Linq;

List<Student> students = Student.GetStudents();
List<Pet> pets = Pet.GenerateMockData();
List<PetOwner> petOwners = PetOwner.GenerateMockData();
List<ClinicAppointment> appointments = ClinicAppointment.GenerateMockAppointments();
List<VeterinaryClinic> clinics = VeterinaryClinic.GenerateMockClinics();


// OrderBy
Console.WriteLine("Pets ordered by name");
var petsOrderedByName = pets.OrderBy(pet => pet.Name);
foreach (var pet in petsOrderedByName)
{
    Console.WriteLine(pet);
}

Console.WriteLine("-------------------------");
Console.WriteLine("Pets ordered by name descending");
var petsOrderedByNameDescending = pets.OrderByDescending(pet => pet.Name);
foreach (var pet in petsOrderedByNameDescending)
{
    Console.WriteLine(pet);
}
Console.WriteLine("-------------------------");
Console.WriteLine("Pets ordered by Type and then by weight");
var petsOrderedByTypeAndWeight = pets.OrderBy(pet => pet.Type).ThenBy(pet => pet.Weight);
foreach (var pet in petsOrderedByTypeAndWeight)
{
    Console.WriteLine(pet);
}
Console.WriteLine("-------------------------");
Console.WriteLine("Pets ordered by Type with Comparer");
var petsOrderedByTypeWithComparer = pets.OrderBy(pet => pet, new PetByTypeComparer());
foreach (var pet in petsOrderedByTypeWithComparer)
{
    Console.WriteLine(pet);
}

Console.WriteLine("-------------------------");
//reverse
Console.WriteLine("Pets Reverse");
pets.Reverse();
foreach (var pet in pets)
{
    Console.WriteLine(pet);
}
