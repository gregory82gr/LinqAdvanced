using Data;
using System;
using System.Linq;

List<Student> students = Student.GetStudents();
List<Pet> pets = Pet.GenerateMockData();
List<PetOwner> petOwners = PetOwner.GenerateMockData();
List<ClinicAppointment> appointments = ClinicAppointment.GenerateMockAppointments();
List<VeterinaryClinic> clinics = VeterinaryClinic.GenerateMockClinics();

BasingObjects.ShowDataAndRelationships(pets, petOwners, students);
Console.WriteLine("Clinic Appointments");
foreach (var appointment in appointments)
{
    Console.WriteLine(appointment);
}
Console.WriteLine("-------------------------");
Console.WriteLine("Veterinary Clinics");
foreach (var clinic in clinics)
{
    Console.WriteLine(clinic);
}
Console.WriteLine("-------------------------");
Console.WriteLine("Pets - Groupby by type");

var groupedPets= from pet in pets
                 group pet by pet.Type;
foreach(var group in groupedPets)
{
    Console.WriteLine($"Pet Type: {group.Key}");
    foreach (var pet in group)
    {
        Console.WriteLine($"  -> {pet.Name}");
    }
}
Console.WriteLine("-------------------------");
Console.WriteLine("Pets - Weight sums by type");

var groupedPetsWeight = from pet in pets
                        group pet by pet.Type into petGroup
                        select new
                        {
                            PetType = petGroup.Key,
                            TotalWeight = petGroup.Sum(pet => pet.Weight)
                        };
foreach (var group in groupedPetsWeight)
{
    Console.WriteLine($"Pet Type: {group.PetType}, Total Weight: {group.TotalWeight}");
}

Console.WriteLine("-------------------------");
Console.WriteLine("Pets - Weight sums by type with dictionary");

var groupedPetsWeight1 = groupedPets.ToDictionary(
    group => group.Key,
    group => group.Sum(pet => pet.Weight)
    );

foreach (var group in groupedPetsWeight1)
{
    Console.WriteLine($"Pet Type: {group.Key}, Total Weight: {group.Value}");
}

Console.WriteLine("-------------------------");
Console.WriteLine("Pets - pets owner initials group by");

var groupedPetsOwnerInitials = (from person in petOwners
                               group person by person.Name.First())
                               .ToDictionary(
                                   grouping => grouping.Key,
                                   grouping => string.Join(", ", 
                                   from person in grouping
                                   from pet in person.Pets
                                   select pet.Name));

foreach (var group in groupedPetsOwnerInitials)
{
    Console.WriteLine($"{group.Key}. {group.Value}");
}

Console.WriteLine("-------------------------");
Console.WriteLine("Pets - min max weights by type");

var groupedPetsMinMaxWeight = from pet in pets
                              group pet by Math.Floor(pet.Weight) into petGroup
                              orderby petGroup.Key
                              let petsOrderedByWeight = from pet in petGroup
                                                        orderby pet.Weight
                                                        select pet
                              select new
                              {
                                  Weight = petGroup.Key,
                                  PetWithMinWeight = petsOrderedByWeight.First(),
                                  PetWithMaxWeight = petsOrderedByWeight.Last()
                              };

var groupedPetsMinMaxWeightAsString=from groupedPet in groupedPetsMinMaxWeight
                                    select $"{groupedPet.Weight}kg: {groupedPet.PetWithMinWeight.Name} - {groupedPet.PetWithMaxWeight.Name}";

foreach (var group in groupedPetsMinMaxWeightAsString)
{
    Console.WriteLine(group);
}