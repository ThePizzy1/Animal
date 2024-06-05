using ANIMAL.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
//using ANIMAL.DAL.DataModel;

namespace ANIMAL.MODEL
{
    public class AdopterDomain
    {
        public AdopterDomain(Adopter adopter)
        {
            Id = adopter.Id;
            FirstName = adopter.FirstName;
            LastName = adopter.LastName;
            DateOfBirth = adopter.DateOfBirth;
            Residence = adopter.Residence;
            Username = adopter.Username;
            Password = adopter.Password;
            NumberOfAdoptedAnimals = adopter.NumAdoptedAnimals;
            NumberOfReturnedAnimals = adopter.NumReturnedAnimals;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Residence { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int NumberOfAdoptedAnimals { get; set; }
        public int NumberOfReturnedAnimals { get; set; }

        public ICollection<AdoptedDomain> Adopted { get; set; } = new List<AdoptedDomain>();
        public ICollection<ReturnedAnimalDomain> ReturnedAnimal { get; set; } = new List<ReturnedAnimalDomain>();
    }

}
