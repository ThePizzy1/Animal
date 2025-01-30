using ANIMAL.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public class FoundRecordDomain
    {
        public FoundRecordDomain() { }
        public FoundRecordDomain(int id, int animalId, DateTime date, string adress, string description, string ownerName, string ownerSurname, string ownerPhoneNumber, string ownerOIB, string registerId, AnimalDomain animal)
        {
            Id = id;
            AnimalId = animalId;
            Date = date;
            Adress = adress;
            Description = description;
            OwnerName = ownerName;
            OwnerSurname = ownerSurname;
            OwnerPhoneNumber = ownerPhoneNumber;
            OwnerOIB = ownerOIB;
            RegisterId = registerId;
            Animal = animal;
        }
        public FoundRecordDomain(int id, int animalId, DateTime date, string adress, string description, string ownerName, string ownerSurname, string ownerPhoneNumber, string ownerOIB, string registerId)
        {
            Id = id;
            AnimalId = animalId;
            Date = date;
            Adress = adress;
            Description = description;
            OwnerName = ownerName;
            OwnerSurname = ownerSurname;
            OwnerPhoneNumber = ownerPhoneNumber;
            OwnerOIB = ownerOIB;
            RegisterId = registerId;
          
        }

        public int Id { get; set; }
        public int AnimalId { get; set; }
        public DateTime Date { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }

        public string OwnerName { get; set; }
        public string OwnerSurname { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public string OwnerOIB { get; set; }
        public string RegisterId { get; set; }


        public AnimalDomain Animal { get; set; }
     

    
    }
}
