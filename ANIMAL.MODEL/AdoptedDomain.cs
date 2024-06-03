using ANIMAL.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
//using ANIMAL.DAL.DataModel;
namespace ANIMAL.MODEL
{
    public class AdoptedDomain
    {
        public AdoptedDomain(Adopted adopted)
        {
            Code = adopted.Code;
            AnimalId = adopted.AnimalId;
            AdopterId = adopted.AdopterId;
            AdoptionDate = adopted.AdoptionDate;
        }

        public int Code { get; set; }
        public int AnimalId { get; set; }
        public int AdopterId { get; set; }
        public DateTime AdoptionDate { get; set; }
        public AdopterDomain Adopter { get; set; }
        public AnimalDomain Animal { get; set; }
    }

}
