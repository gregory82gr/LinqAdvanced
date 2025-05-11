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
Console.WriteLine("Pets - appointments left join");
var leftJoin = pets.GroupJoin(
    appointments,
    pet => pet.Id,
    clinicAppointment => clinicAppointment.PetId,
    (pet, clinicAppointment) => new
    {
        Pet = pet,
        Appointmens = clinicAppointment
    });
foreach (var entry in leftJoin)
{
    Console.WriteLine($"Pet: {entry.Pet.Name}, Type: {entry.Pet.Type}, Weight: {entry.Pet.Weight}kg");

    if (entry.Appointmens.Any())
    {
        foreach (var appointment in entry.Appointmens)
        {
            Console.WriteLine($"  -> Appointment at Clinic {appointment.ClinicId} on {appointment.AppointmentDate}");
        }
    }
    else
    {
        Console.WriteLine("  -> No Appointments");
    }
}

Console.WriteLine("Pets - appointments left join Right Way");
var leftJoinrw = pets.GroupJoin(
    appointments,
    pet => pet.Id,
    clinicAppointment => clinicAppointment.PetId,
    (pet, clinicAppointment) => new
    {
        Pet = pet,
        Appointmens = clinicAppointment.DefaultIfEmpty()
    }).SelectMany(
        petAppointmentPair => petAppointmentPair.Appointmens,
        (petAppointmentPair, singleAppointement) => $"Pet {petAppointmentPair.Pet.Name} has an appointment on {singleAppointement?.AppointmentDate}");

foreach (var appointment in leftJoinrw)
{
    Console.WriteLine(appointment);
}

Console.WriteLine("Pets Appoinments Left-join in more queries");
var petAppointment = pets.GroupJoin(
    appointments,
    pet => pet.Id,
    clinicAppointment => clinicAppointment.PetId,
    (pet, clinicAppointment) => new
    {
        Pet = pet,
        Appointmens = clinicAppointment.DefaultIfEmpty()
    });

var finalResult= petAppointment.SelectMany(
        petAppointmentPair => petAppointmentPair.Appointmens,
        (petAppointmentPair, singleAppointement) => 
        $"Pet {petAppointmentPair.Pet.Name} has an appointment on " +
        $"{singleAppointement?.AppointmentDate}");

foreach (var appointment in finalResult)
{
    Console.WriteLine(appointment);
}
Console.WriteLine("-------------------------");
Console.WriteLine("Pets Appoinments left-join Full info ");
// This is a left join
    var petAppointmentFull = pets.GroupJoin(
        appointments,
        pet => pet.Id,
        clinicAppointment => clinicAppointment.PetId,
        (pet, clinicAppointment) => new
        {
            Pet = pet,
            Appointmens = clinicAppointment.DefaultIfEmpty()
        });
    var finalResultFull1 = petAppointmentFull.SelectMany(
        petAppointmentPair => petAppointmentPair.Appointmens,
        (petAppointmentPair, singleAppointement) => new
        {
            Pet = petAppointmentPair.Pet,
            Appointment = singleAppointement
        });
    var finalResultFull2 = finalResultFull1.GroupJoin(clinics,
        petAppointmentPair => petAppointmentPair?.Appointment?.ClinicId,
        veterinaryClinic => veterinaryClinic.Id,
        (petAppointmentPair, clinic) => new
        {
            Pet = petAppointmentPair.Pet,
            Appointment = petAppointmentPair.Appointment,
            Clinic = clinic.DefaultIfEmpty()
        });
    var finalResultFull3 = finalResultFull2.SelectMany(
            petAppointmentPair => petAppointmentPair.Clinic,
            (petAppointmentPair, clinic) => $"{petAppointmentPair.Pet.Name} has an appointment on {petAppointmentPair.Appointment?.AppointmentDate} in {clinic?.Name}"
        );
    foreach (var appointment in finalResultFull3)
    {
        Console.WriteLine(appointment);
    }
