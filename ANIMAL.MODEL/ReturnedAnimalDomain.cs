using System;
using System.Collections.Generic;
using System.Text;
using ANIMAL.DAL.DataModel;
//using ANIMAL.DAL.DataModel;
namespace ANIMAL.MODEL
{
    public class ReturnedAnimalDomain
    {
        public ReturnedAnimalDomain(ReturnedAnimal returnedAnimal)
        {
            ReturnCode = returnedAnimal.ReturnCode;
            AdoptionCode = returnedAnimal.AdoptionCode;
            AnimalId = returnedAnimal.AnimalId;
            AdopterId = returnedAnimal.AdopterId;
            ReturnDate = returnedAnimal.ReturnDate;
            ReturnReason = returnedAnimal.ReturnReason;
        }

        public int ReturnCode { get; set; }
        public int AdoptionCode { get; set; }
        public int AnimalId { get; set; }
        public int AdopterId { get; set; }
        public DateTime ReturnDate { get; set; }
        public string ReturnReason { get; set; }
        public AnimalDomain Animal { get; set; }
        public AdoptedDomain AdoptionCodeNavigation { get; set; }
        public AdopterDomain Adopter { get; set; }
    }

}
