using System;
using System.Collections.Generic;

namespace ANIMAL.DAL.DataModel
{
    public partial class Reptiles
    {
        public int AnimalId { get; set; }
        public string TankSize { get; set; }
        public string Sociability { get; set; }
        public string CompatibleSpecies { get; set; }
        public string RecommendedItems { get; set; }

        public virtual Animals Animal { get; set; }
    }
}
