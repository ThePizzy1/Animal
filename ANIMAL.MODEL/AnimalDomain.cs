using ANIMAL.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
//using ANIMAL.DAL.DataModel;

namespace ANIMAL.MODEL
{
    public class AnimalDomain
    {
        public AnimalDomain() { }
        public AnimalDomain(Animals animal)
        {
            IdAnimal = animal.IdAnimal;
            Name = animal.Name;
            Family = animal.Family;
            Species = animal.Species;
            Subspecies = animal.Subspecies;
            Age = animal.Age;
            Gender = animal.Gender;
            Weight = animal.Weight;
            Height = animal.Height;
            Length = animal.Length;
            Neutered = animal.Neutered;
            Vaccinated = animal.Vaccinated;
            Microchipped = animal.Microchipped;
            Trained = animal.Trained;
            Socialized = animal.Socialized;
            HealthIssues = animal.HealthIssues;
            PersonalityDescription = animal.PersonalityDescription;
           
            Adopted = animal.Adopted;
        }

        public int IdAnimal { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Species { get; set; }
        public string Subspecies { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public bool Neutered { get; set; }
        public bool Vaccinated { get; set; }
        public bool Microchipped { get; set; }
        public bool Trained { get; set; }
        public bool Socialized { get; set; }
        public string HealthIssues { get; set; }
        public string PersonalityDescription { get; set; }
       
        public bool Adopted { get; set; }
    }
}
