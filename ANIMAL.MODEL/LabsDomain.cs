using ANIMAL.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.MODEL
{     
    public class LabsDomain
    {
        public LabsDomain() { }
        public LabsDomain(int id, int animalId, DateTime dateTime, AnimalDomain animals)
        {
            Id = id;
            AnimalId = animalId;         
            DateTime = dateTime;
            Animals = animals;
        }
        public LabsDomain(int id, int animalId,DateTime dateTime)
        {
            Id = id;
            AnimalId = animalId;
            DateTime = dateTime;
        }
        public LabsDomain(int animalId, DateTime dateTime)
        {
    
            AnimalId = animalId;
            DateTime = dateTime;
        }
        public LabsDomain(int id, int animalId)
        {
            Id = id;
            AnimalId = animalId;
 
        }

        public int Id { get; set; }
        public int AnimalId { get; set; }
        public DateTime DateTime { get; set; }
        public AnimalDomain Animals { get; set; }
    }
}
