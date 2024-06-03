using System;
using System.Collections.Generic;

namespace ANIMAL.DAL.DataModel
{
    public partial class Mammals
    {
        public int AnimalId { get; set; }
        public string CoatType { get; set; }
        public string GroomingProducts { get; set; }

        public virtual Animals Animal { get; set; }
    }
}
