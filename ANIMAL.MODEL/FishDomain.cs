using System;
using System.Collections.Generic;
using System.Text;
using ANIMAL.DAL.DataModel;
//using ANIMAL.DAL.DataModel;
namespace ANIMAL.MODEL
{
    public class FishDomain : AnimalDomain
    {
        public FishDomain(Fish fish)
        {
            AnimalId = fish.AnimalId;
            TankSize = fish.TankSize;
            CompatibleSpecies = fish.CompatibleSpecies;
            RecommendedItems = fish.RecommendedItems;
        }

        public int AnimalId { get; set; }
        public string TankSize { get; set; }
        public string CompatibleSpecies { get; set; }
        public string RecommendedItems { get; set; }
        public AnimalDomain Animal { get; set; }
    }

}
