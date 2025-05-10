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
Console.WriteLine("Pets Appoinments info");

var petsAppoinmentsInfo = pets.Join(
    appointments,
    pet => pet.Id,
    clinicAppointment => clinicAppointment.PetId,
    (pet, clinicAppointment) => $"{pet.Name} has an appointment on {clinicAppointment.AppointmentDate}"
    );
foreach (var appointment in petsAppoinmentsInfo)
{
    Console.WriteLine(appointment);
}

Console.WriteLine("Pets Appoinments Full info");

var petsAppoinmentsFullInfo = pets.Join(
    appointments,
    pet => pet.Id,
    clinicAppointment => clinicAppointment.PetId,
    (pet, clinicAppointment) => new
    {
        Pet = pet,
        Appointment = clinicAppointment
    }).Join(clinics,
      petAppointmentPair => petAppointmentPair.Appointment.ClinicId,
      veterinaryClinic => veterinaryClinic.Id,
      (petAppointmentPair, clinic) => $"{petAppointmentPair.Pet.Name} has an appointment on {petAppointmentPair.Appointment.AppointmentDate} in {clinic.Name}"
    );

foreach (var appointment in petsAppoinmentsFullInfo)
{
    Console.WriteLine(appointment);
}
Console.WriteLine("-------------------------");
Console.WriteLine("Pets Appoinments Full info in more queries");
var petAppointment= pets.Join(
    appointments,
    pet => pet.Id,
    clinicAppointment => clinicAppointment.PetId,
    (pet, clinicAppointment) => new
    {
        Pet = pet,
        Appointment = clinicAppointment
    });
var petAppointmentWithClinics = petAppointment.Join(
    clinics,
    petAppointmentPair => petAppointmentPair.Appointment.ClinicId,
    veterinaryClinic => veterinaryClinic.Id,
    (petAppointmentPair, clinic) => new
    {
        Pet = petAppointmentPair.Pet,
        Appointment = petAppointmentPair.Appointment,
        Clinic = clinic
    });

var finalResult = petAppointmentWithClinics.Select(
    petAppointmentPair => $"{petAppointmentPair.Pet.Name} has an appointment on " +
                          $"{petAppointmentPair.Appointment.AppointmentDate} in " +
                          $"{petAppointmentPair.Clinic.Name}"
    );
foreach (var appointment in finalResult)
{
    Console.WriteLine(appointment);
}

Console.WriteLine("-------------------------");
