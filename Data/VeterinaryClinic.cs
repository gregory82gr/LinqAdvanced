using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class VeterinaryClinic
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public VeterinaryClinic(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static List<VeterinaryClinic> GenerateMockClinics()
        {
            return new List<VeterinaryClinic>
        {
            new VeterinaryClinic(101, "Happy Paws Veterinary"),
            new VeterinaryClinic(102, "Healthy Pet Clinic"),
            new VeterinaryClinic(103, "Animal Care Center"),
        };
        }

        public override string ToString()
        {
            return $"ClinicID: {Id}, Name: {Name}";
        }
    }

}
