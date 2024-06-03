using System;
using System.Collections.Generic;

namespace ANIMAL.DAL.DataModel
{
    public partial class ReturnedAnimal
    {
        public int ReturnCode { get; set; }
        public int AdoptionCode { get; set; }
        public int AnimalId { get; set; }
        public int AdopterId { get; set; }
        public DateTime ReturnDate { get; set; }
        public string ReturnReason { get; set; }

        public virtual Adopter Adopter { get; set; }
        public virtual Adopted AdoptionCodeNavigation { get; set; }
        public virtual Animals Animal { get; set; }
    }
}
