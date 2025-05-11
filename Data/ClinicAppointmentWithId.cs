using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ClinicAppointmentWithId
    {
        public int Id { get; set; }           // ← new
        public int ClinicId { get; set; }
        public int PetId { get; set; }
        public DateTime AppointmentDate { get; set; }

        public ClinicAppointmentWithId(int id, int clinicId, int petId, DateTime appointmentDate)
        {
            Id = id;
            ClinicId = clinicId;
            PetId = petId;
            AppointmentDate = appointmentDate;
        }

        public static List<ClinicAppointmentWithId> GenerateMockAppointmentsWithId() =>
            new List<ClinicAppointmentWithId>
            {
            new ClinicAppointmentWithId(1, 101, 1, DateTime.Now.AddDays(1)),  // Goldie
            new ClinicAppointmentWithId(2, 102, 2, DateTime.Now.AddDays(2)),  // Whiskers
            new ClinicAppointmentWithId(3, 103, 2, DateTime.Now.AddDays(5)),  // Whiskers
            new ClinicAppointmentWithId(4, 101, 3, DateTime.Now.AddDays(3)),  // Buddy
            new ClinicAppointmentWithId(5, 103, 4, DateTime.Now.AddDays(4)),  // Nemo
            };

        public override string ToString() =>
            $"AppointmentID: {Id}, ClinicID: {ClinicId}, PetID: {PetId}, Date: {AppointmentDate}";
    }

}
