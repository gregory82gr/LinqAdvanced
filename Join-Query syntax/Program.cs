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
Console.WriteLine("Pets Appoinments info-two tables");

var innerJoin=from pet in pets
              join appointment in appointments
              on pet.Id equals appointment.PetId
              select new { pet.Name, appointment.AppointmentDate };

foreach (var record in innerJoin)
{
    Console.WriteLine($"{record.Name} has an appointment on {record.AppointmentDate}");
}

Console.WriteLine("-------------------------");
Console.WriteLine("Pets Appoinments info-three tables");
var innnerjoinThreeTables = from pet in pets
                            join appointment in appointments
                                on pet.Id equals appointment.PetId
                            join clinic in clinics
                                on appointment.ClinicId equals clinic.Id
                            select $"{pet.Name} has an appointment on {appointment.AppointmentDate} in {clinic.Name}";

foreach (var appointment in innnerjoinThreeTables)
{
    Console.WriteLine(appointment);
}

Console.WriteLine("-------------------------");
Console.WriteLine("Pets Appoinments info-Left join");

var leftJoin = from pet in pets
               join appointment in appointments
                on pet.Id equals appointment.PetId into petAppointments
               from appointment in petAppointments.DefaultIfEmpty()
               select new { pet.Name, appointment?.AppointmentDate };

foreach (var record in leftJoin)
{
    Console.WriteLine($"{record.Name} has an appointment on {record.AppointmentDate}");
}