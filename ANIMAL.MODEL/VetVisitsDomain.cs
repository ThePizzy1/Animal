using ANIMAL.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.MODEL
{
    public class VetVisitsDomain
    {


        public VetVisitsDomain() { }
        public VetVisitsDomain(int id,int animalId,DateTime startTime, DateTime endTime, string typeOfVisit, string notes, AnimalDomain animal ) 
        { 

            Id = id;
            AnimalId = animalId;
            StartTime = startTime;         
            EndTime = endTime;
            TypeOfVisit = typeOfVisit;
            Notes = notes;
            Animal = animal;

        }
        public VetVisitsDomain(int id, int animalId, DateTime startTime, DateTime endTime, string typeOfVisit, string notes)
        {

            Id = id;
            AnimalId = animalId;
            StartTime = startTime;
            EndTime = endTime;
            TypeOfVisit = typeOfVisit;
            Notes = notes;
        }

        public int Id { get; set; }
        public int AnimalId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string TypeOfVisit { get; set; }

        public string Notes { get; set; }

        public AnimalDomain Animal { get; set; }
    }
}
