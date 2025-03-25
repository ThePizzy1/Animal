﻿using System;
using System.Collections.Generic;
using System.Text;
using ANIMAL.DAL.DataModel;
using Newtonsoft.Json;
//using ANIMAL.DAL.DataModel;
namespace ANIMAL.MODEL
{
    public class FishDomain : AnimalDomain
    {
        public FishDomain(int idAnimal, string name, string family, string species, string subspecies, int age, string gender, decimal weight, decimal height, decimal length, bool neutered, bool vaccinated, bool microchipped, bool trained, bool socialized, string healthIssues, byte[] picture, string personalityDescription, bool adopted, int animalId, string tankSize, string compatibleSpecies,string recommendedItems)
            : base(idAnimal, name, family, species, subspecies, age, gender, weight, height, length, neutered, vaccinated, microchipped, trained, socialized, healthIssues,picture, personalityDescription, adopted)
        {
            AnimalId = animalId;
            TankSize = tankSize;
            CompatibleSpecies =compatibleSpecies;
            RecommendedItems = recommendedItems;
        }

        [JsonConstructor]
        public FishDomain(int idAnimal,string tankSize, string compatibleSpecies, string recommendedItems)    
        {
            AnimalId = idAnimal;
            TankSize = tankSize;
            CompatibleSpecies = compatibleSpecies;
            RecommendedItems = recommendedItems;
        }
        public FishDomain() { }
        public int AnimalId { get; set; }
        public string TankSize { get; set; }
        public string CompatibleSpecies { get; set; }
        public string RecommendedItems { get; set; }
        public virtual AnimalDomain Animal { get; set; }
    }

}
