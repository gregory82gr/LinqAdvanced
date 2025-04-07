using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PetOwner
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Pet> Pets { get; set; }

        public PetOwner(int id, string name, List<Pet> pets)
        {
            Id = id;
            Name = name;
            Pets = pets;
        }

        public static List<PetOwner> GenerateMockData()
        {
            List<Pet> pets = Pet.GenerateMockData();
            return new List<PetOwner>
            {
                new PetOwner(1, "Alice", new List<Pet> { 
                    pets.ElementAt(0), 
                    pets.ElementAt(1) 
                }),
                new PetOwner(2, "Bob", new List<Pet> {
                    pets.ElementAt(2) 
                }),
                new PetOwner(3, "Charlie", new List<Pet> { 
                    pets.ElementAt(3), 
                    pets.ElementAt(4) 
                })
            };
        }

        public override string ToString()
        {
            return $"PetOwnerID: {Id}, Name: {Name}, Pets: [\n{ string.Join(",\n ", Pets)}]";
        }
    }
}
