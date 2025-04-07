using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Pet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public PetType Type { get; set; }
        public double Weight { get; set; }

        public Pet(int id, string name, PetType type, double weight)
        {
            Id = id;
            Name = name;
            Type = type;
            Weight = weight;
        }

        public static List<Pet> GenerateMockData()
        {
            return new List<Pet>
            {
                new Pet(1, "Goldie", PetType.Fish, 0.5),
                new Pet(2, "Whiskers", PetType.Cat, 4.2),
                new Pet(3, "Buddy", PetType.Dog, 12.8),
                new Pet(4, "Nemo", PetType.Fish, 0.3),
                new Pet(5, "Shadow", PetType.Cat, 5.1),
                new Pet(6, "Dora", PetType.Dog, 2.8),
            };
        }

        public override string ToString()
        {
            return $"PetID: {Id}, Name: {Name}, Type: {Type}, Weight: {Weight} kg";
        }
    }
}
