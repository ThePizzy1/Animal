using System;
using System.Collections.Generic;
using System.Text;
using ANIMAL.DAL.DataModel;
//using ANIMAL.DAL.DataModel;
namespace ANIMAL.MODEL
{
    public class BirdDomain: AnimalDomain
    {
        public BirdDomain(Birds bird) 
        {
            AnimalId = bird.AnimalId;
            CageSize = bird.CageSize;
            RecommendedToys = bird.RecommendedToys;
            Sociability = bird.Sociability;
        }

        public int AnimalId { get; set; }
        public string CageSize { get; set; }
        public string RecommendedToys { get; set; }
        public string Sociability { get; set; }
        public AnimalDomain Animal { get; set; }
    }

}
