using System;
using System.Collections.Generic;
using System.Text;
using ANIMAL.DAL.DataModel;
//using ANIMAL.DAL.DataModel;
namespace ANIMAL.MODEL
{
    public class ReptileDomain : AnimalDomain
    {
        public ReptileDomain(Reptiles reptile)
        {
            AnimalId = reptile.AnimalId;
            TankSize = reptile.TankSize;
            Sociability = reptile.Sociability;
            CompatibleSpecies = reptile.CompatibleSpecies;
            RecommendedItems = reptile.RecommendedItems;
        }

        public int AnimalId { get; set; }
        public string TankSize { get; set; }
        public string Sociability { get; set; }
        public string CompatibleSpecies { get; set; }
        public string RecommendedItems { get; set; }
        public AnimalDomain Animal { get; set; }
    }

}
