using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Vet
    {
        public int Id { get; set; }
        public int ClinicAppointmentId { get; set; }  // Assume each Vet is assigned to one appointment
        public string VetName { get; set; }
        public int ClinicId { get; set; }

        public Vet(int id, int clinicAppointmentId, string vetName, int clinicId)
        {
            Id = id;
            ClinicAppointmentId = clinicAppointmentId;
            VetName = vetName;
            ClinicId = clinicId;
        }

        public override string ToString()
        {
            return $"VetID: {Id}, Name: {VetName}, ClinicID: {ClinicId}, AppointmentID: {ClinicAppointmentId}";
        }

        public static List<Vet> GenerateMockVets()
        {
            return new List<Vet>
        {
            new Vet( 1, 1, "Dr. Smith",   101),  // Dr. Smith → appointment #1
            new Vet( 2, 2, "Dr. Johnson", 102),  // → appointment #2
            new Vet( 3, 3, "Dr. Kim",     103),  // → appointment #3
            new Vet( 4, 4, "Dr. Brown",   101),  // → appointment #4
            new Vet( 5, 5, "Dr. Lee",     103),  // → appointment #5
        };
        }
    }


}
