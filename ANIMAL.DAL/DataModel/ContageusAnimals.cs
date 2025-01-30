using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public partial class ContageusAnimals
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }

        public string DesisseName { get; set; }
        public string Description { get; set; }

        public virtual Animals Animals { get; set; }
    }
}
