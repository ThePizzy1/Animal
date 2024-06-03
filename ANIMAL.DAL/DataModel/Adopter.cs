using System;
using System.Collections.Generic;

namespace ANIMAL.DAL.DataModel
{
    public partial class Adopter
    {
        public Adopter()
        {
            Adopted = new HashSet<Adopted>();
            ReturnedAnimal = new HashSet<ReturnedAnimal>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Residence { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int NumAdoptedAnimals { get; set; }
        public int NumReturnedAnimals { get; set; }

        public virtual ICollection<Adopted> Adopted { get; set; }
        public virtual ICollection<ReturnedAnimal> ReturnedAnimal { get; set; }
    }
}
