using System;
using System.Collections.Generic;
using System.Text;
using ANIMAL.DAL.DataModel;
//using ANIMAL.DAL.DataModel;
namespace ANIMAL.MODEL
{
    public class MammalDomain : AnimalDomain
    {
        public MammalDomain(int idAnimal, string name, string family, string species, string subspecies, int age, string gender, decimal weight, decimal height, decimal length, bool neutered, bool vaccinated, bool microchipped, bool trained, bool socialized, string healthIssues, string personalityDescription, bool adopted, int animalId, string coatType, string groomingProducts)
            : base(idAnimal, name, family, species, subspecies, age, gender, weight, height, length, neutered, vaccinated, microchipped, trained, socialized, healthIssues, personalityDescription, adopted)
        {
            AnimalId = animalId;
            CoatType = coatType;
            GroomingProducts = groomingProducts;
        }

        public int AnimalId { get; set; }
        public string CoatType { get; set; }
        public string GroomingProducts { get; set; }
    }

}
