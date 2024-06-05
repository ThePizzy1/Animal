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
        public AnimalDomain(int idAnimal, string name, string family, string species, string subspecies, int age, string gender, decimal weight, decimal height, decimal length, bool neutered, bool vaccinated, bool microchipped, bool trained, bool socialized, string healthIssues, string personalityDescription, bool adopted)
        {
            IdAnimal = idAnimal;
            Name = name;
            Family = family;
            Species = species;
            Subspecies = subspecies;
            Age = age;
            Gender = gender;
            Weight = weight;
            Height = height;
            Length = length;
            Neutered = neutered;
            Vaccinated = vaccinated;
            Microchipped = microchipped;
            Trained = trained;
            Socialized = socialized;
            HealthIssues = healthIssues;
            PersonalityDescription = personalityDescription;
            Adopted = adopted;
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
