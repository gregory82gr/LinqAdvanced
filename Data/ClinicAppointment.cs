using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ClinicAppointment
    {
        public int ClinicId { get; set; }
        public int PetId { get; set; }
        public DateTime AppointmentDate { get; set; }

        public ClinicAppointment(int clinicId, int petId, DateTime appointmentDate)
        {
            ClinicId = clinicId;
            PetId = petId;
            AppointmentDate = appointmentDate;
        }

        public static List<ClinicAppointment> GenerateMockAppointments()
        {
            return new List<ClinicAppointment>
        {
            new ClinicAppointment(101, 1, DateTime.Now.AddDays(1)), // Goldie
            new ClinicAppointment(102, 2, DateTime.Now.AddDays(2)),
            new ClinicAppointment(103, 2, DateTime.Now.AddDays(5)),// Whiskers
            new ClinicAppointment(101, 3, DateTime.Now.AddDays(3)), // Buddy
            new ClinicAppointment(103, 4, DateTime.Now.AddDays(4)) // Nemo
            
        };
        }

        public override string ToString()
        {
            return $"ClinicID: {ClinicId}, PetID: {PetId}, Appointment Date: {AppointmentDate}";
        }
    }

}
