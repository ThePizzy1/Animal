using ANIMAL.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
//using ANIMAL.DAL.DataModel;

namespace ANIMAL.MODEL
{
    public class AdopterDomain
    {
        private int numAdoptedAnimals;
        private int numReturnedAnimals;

        public AdopterDomain(int id, string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password, int numAdoptedAnimals, int numReturnedAnimals)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Residence = residence;
            Username = username;
            Password = password;
            this.numAdoptedAnimals = numAdoptedAnimals;
            this.numReturnedAnimals = numReturnedAnimals;
        }

        public AdopterDomain(int id, string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password, int numberOfAdoptedAnimals, int numberOfReturnedAnimals, ICollection<AdoptedDomain> adopted, ICollection<ReturnedAnimalDomain> returnedAnimal)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Residence = residence;
            Username = username;
            Password = password;
            NumberOfAdoptedAnimals = numberOfAdoptedAnimals;
            NumberOfReturnedAnimals = numberOfReturnedAnimals;
            Adopted = adopted;
            ReturnedAnimal = returnedAnimal;
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
