using Data;
using System;
using System.Linq;

List<Student> students = Student.GetStudents();
List<Pet> pets = Pet.GenerateMockData();
List<PetOwner> petOwners = PetOwner.GenerateMockData();
List<ClinicAppointment> appointments = ClinicAppointment.GenerateMockAppointments();
List<ClinicAppointmentWithId> appointmentsWithId = ClinicAppointmentWithId.GenerateMockAppointmentsWithId();
List<VeterinaryClinic> clinics = VeterinaryClinic.GenerateMockClinics();
List<Vet> vets = Vet.GenerateMockVets();

Console.WriteLine("Pets");
foreach (var pet in pets)
{
    Console.WriteLine(pet);
}
Console.WriteLine("-------------------------");
Console.WriteLine("Pet Owners");
foreach (var petOwner in petOwners)
{
    Console.WriteLine(petOwner);
}
Console.WriteLine("-------------------------");
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
Console.WriteLine("Veterinary Vets");
foreach (var vet in vets)
{
    Console.WriteLine(vet);
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
Console.WriteLine("Pets Appoinments Full info with Vets");
var petAppt = pets.Join(
    appointmentsWithId,
    pet => pet.Id,
    appt => appt.PetId,
    (pet, appt) => new { pet, appt }
);

var petApptWithClinic = petAppt.Join(
    clinics,
    pa => pa.appt.ClinicId,
    c => c.Id,
    (pa, c) => new { pa.pet, pa.appt, clinic = c }
);

var petApptWithClinicAndVet = petApptWithClinic.Join(
    vets,
    pc => pc.appt.Id,              // ← join on Appointment.Id
    vet => vet.ClinicAppointmentId,
    (pc, v) => new { pc.pet, pc.appt, pc.clinic, vet = v }
);

var final = petApptWithClinicAndVet.Select(x =>
    $"Pet {x.pet.Name} has an appointment on " +
    $"{x.appt.AppointmentDate:d} in " +
    $"{x.clinic.Name} with " +
    $"{x.vet.VetName}"
);

foreach (var line in final)
    Console.WriteLine(line);
Console.WriteLine("-------------------------");
Console.WriteLine("Pets Appoinments Full info with Vets and Pet Owners Query syntax");
var fullSchedule =
    from owner in petOwners
    from pet in owner.Pets
    join appt in appointmentsWithId on pet.Id equals appt.PetId
    join clinic in clinics on appt.ClinicId equals clinic.Id
    join vet in vets on appt.Id equals vet.ClinicAppointmentId
    select new
    {
        OwnerName = owner.Name,
        PetName = pet.Name,
        Date = appt.AppointmentDate,
        ClinicName = clinic.Name,
        VetName = vet.VetName
    };

foreach (var e in fullSchedule)
{
    Console.WriteLine(
      $"{e.OwnerName}’s pet {e.PetName} has an appointment on " +
      $"{e.Date:d} at {e.ClinicName} with {e.VetName}");
}
Console.WriteLine("-------------------------");
Console.WriteLine("Pets Appoinments Full info with Vets and Pet Owners Method syntax");
var fullScheduleMethod = petOwners
    .SelectMany(owner => owner.Pets,
        (owner, pet) => new { owner, pet })
    .Join(appointmentsWithId,
        petOwner => petOwner.pet.Id,
        appt => appt.PetId,
        (petOwner, appt) => new { petOwner, appt })
    .Join(clinics,
        petAppt => petAppt.appt.ClinicId,
        clinic => clinic.Id,
        (petAppt, clinic) => new { petAppt, clinic })
    .Join(vets,
        petApptWithClinic => petApptWithClinic.petAppt.appt.Id,
        vet => vet.ClinicAppointmentId,
        (petApptWithClinic, vet) => new
        {
            OwnerName = petApptWithClinic.petAppt.petOwner.owner.Name,
            PetName = petApptWithClinic.petAppt.petOwner.pet.Name,
            Date = petApptWithClinic.petAppt.appt.AppointmentDate,
            ClinicName = petApptWithClinic.clinic.Name,
            VetName = vet.VetName
        });

foreach (var e in fullScheduleMethod)
{
    Console.WriteLine(
      $"{e.OwnerName}’s pet {e.PetName} has an appointment on " +
      $"{e.Date:d} at {e.ClinicName} with {e.VetName}");
}
Console.WriteLine("-------------------------");
