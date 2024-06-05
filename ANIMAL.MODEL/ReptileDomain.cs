using System;
using System.Collections.Generic;
using System.Text;
using ANIMAL.DAL.DataModel;
//using ANIMAL.DAL.DataModel;
namespace ANIMAL.MODEL
{
    public class ReptileDomain : AnimalDomain
    {
        public ReptileDomain(int idAnimal, string name, string family, string species, string subspecies, int age, string gender, decimal weight, decimal height, decimal length, bool neutered, bool vaccinated, bool microchipped, bool trained, bool socialized, string healthIssues, string personalityDescription, bool adopted, int animalId, string tankSize, string sociability,string compatibleSpecies, string recommendedItems)
            : base(idAnimal, name, family, species, subspecies, age, gender, weight, height, length, neutered, vaccinated, microchipped, trained, socialized, healthIssues, personalityDescription, adopted)
        {
            AnimalId = animalId;
            TankSize = tankSize;
            Sociability = sociability;
            CompatibleSpecies = compatibleSpecies;
            RecommendedItems = recommendedItems;
        }

        public int AnimalId { get; set; }
        public string TankSize { get; set; }
        public string Sociability { get; set; }
        public string CompatibleSpecies { get; set; }
        public string RecommendedItems { get; set; }
        public AnimalDomain Animal { get; set; }
    }

}
