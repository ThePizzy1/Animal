using System;
using System.Collections.Generic;

namespace ANIMAL.DAL.DataModel
{
    public partial class Amphibians
    {
        public int AnimalId { get; set; }
        public decimal Humidity { get; set; }
        public decimal Temperature { get; set; }

        public virtual Animals Animal { get; set; }
    }
}
