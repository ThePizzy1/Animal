using System;
using System.Collections.Generic;

namespace ANIMAL.DAL.DataModel
{
    public partial class Birds
    {
        public int AnimalId { get; set; }
        public string CageSize { get; set; }
        public string RecommendedToys { get; set; }
        public string Sociability { get; set; }

        public virtual Animals Animal { get; set; }
    }
}
