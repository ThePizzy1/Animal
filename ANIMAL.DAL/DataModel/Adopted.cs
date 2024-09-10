using System;
using System.Collections.Generic;

namespace ANIMAL.DAL.DataModel
{
    public partial class Adopted
    {
        public Adopted()
        {
            ReturnedAnimal = new HashSet<ReturnedAnimal>();
        }

        public int Code { get; set; }
        public int AnimalId { get; set; }
        public int AdopterId { get; set; }
        public DateTime AdoptionDate { get; set; }
      
        public virtual Adopter Adopter { get; set; }
        public virtual Animals Animal { get; set; }
        public virtual ICollection<ReturnedAnimal> ReturnedAnimal { get; set; }
    }
}
