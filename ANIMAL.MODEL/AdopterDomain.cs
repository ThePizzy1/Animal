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

        public AdopterDomain()
        {
            
        }
        public AdopterDomain(int id, string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password, int numAdoptedAnimals, int numReturnedAnimals, bool flag, string registerId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Residence = residence;
            Username = username;
            Password = password;
            NumberOfAdoptedAnimals = numAdoptedAnimals;
            NumberOfReturnedAnimals = numReturnedAnimals;
            Flag = flag;
            RegisterId = registerId;
        }
        public AdopterDomain(int id, string firstName, string lastName, DateTime dateOfBirth, string residence, string username, int numAdoptedAnimals, int numReturnedAnimals)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Residence = residence;
            Username = username;
            NumberOfAdoptedAnimals = numAdoptedAnimals;
            NumberOfReturnedAnimals = numReturnedAnimals;
        
        }
        public AdopterDomain(int id, string firstName, string lastName, DateTime dateOfBirth, string residence, string username, string password, int numberOfAdoptedAnimals, int numberOfReturnedAnimals, ICollection<AdoptedDomain> adopted, ICollection<ReturnedAnimalDomain> returnedAnimal,bool flag, string registerId)
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
            Flag = flag;
            RegisterId = registerId;
        }

        public AdopterDomain(int id, string firstName, string lastName, string residence, DateTime dateOfBirth, int numAdoptedAnimals, int numReturnedAnimals)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Residence = residence;
            DateOfBirth = dateOfBirth;
            this.numAdoptedAnimals = numAdoptedAnimals;
            this.numReturnedAnimals = numReturnedAnimals;
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
        public bool Flag { get; set; }
        public string RegisterId { get; set; }
        public ICollection<AdoptedDomain> Adopted { get; set; } = new List<AdoptedDomain>();
        public ICollection<ReturnedAnimalDomain> ReturnedAnimal { get; set; } = new List<ReturnedAnimalDomain>();
    }

}
