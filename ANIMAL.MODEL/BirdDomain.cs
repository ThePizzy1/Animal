using System;
using System.Collections.Generic;
using System.Text;
using ANIMAL.DAL.DataModel;
using Newtonsoft.Json;
//using ANIMAL.DAL.DataModel;
namespace ANIMAL.MODEL
{
    public class BirdDomain : AnimalDomain
    {
        public BirdDomain(int idAnimal, string name, string family, string species, string subspecies, int age, string gender, decimal weight, decimal height, decimal length, bool neutered, bool vaccinated, bool microchipped, bool trained, bool socialized, string healthIssues, byte[] picture, string personalityDescription, bool adopted, int animalId, string cageSize, string recommendedToys, string sociability)
            : base(idAnimal, name, family, species, subspecies, age, gender, weight, height, length, neutered, vaccinated, microchipped, trained, socialized, healthIssues, picture, personalityDescription, adopted)
        {
            AnimalId = animalId;
            CageSize = cageSize;
            RecommendedToys = recommendedToys;
            Sociability = sociability;
        }
        //nije htjelo bez ovoga baca grešku 
        //https://stackoverflow.com/questions/59198417/deserialization-of-reference-types-without-parameterless-constructor-is-not-supp RJEŠENJE
        [JsonConstructor]
        public BirdDomain(int idAnimal, string cageSize, string recommendedToys, string sociability)
      
        {
            AnimalId = idAnimal;
            CageSize = cageSize;
            RecommendedToys = recommendedToys;
            Sociability = sociability;
        }
        public BirdDomain() { }
        public int AnimalId { get; set; }
        public string CageSize { get; set; }
        public string RecommendedToys { get; set; }
        public string Sociability { get; set; }
        public virtual AnimalDomain Animal { get; set; }
     
    }

}
