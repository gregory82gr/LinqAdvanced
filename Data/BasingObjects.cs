using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static  class BasingObjects
    {
        public static void ShowDataAndRelationships(List<Pet> pets, List<PetOwner> petOwners, List<Student> students)
        {
            Console.WriteLine("Students");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("-------------------------");

            Console.WriteLine("Pets");
            foreach (var pet in pets)
            {
                Console.WriteLine(pet);
            }
            Console.WriteLine("-------------------------");


            Console.WriteLine("Pets Owner");
            foreach (var owner in petOwners)
            {
                Console.WriteLine(owner);
            }
            Console.WriteLine("-------------------------");
        }

    }
}
