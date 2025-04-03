using ANIMAL.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.MODEL
{
    public class ContageusAnimalsDomain
    {
        public ContageusAnimalsDomain() { 
        }

        public ContageusAnimalsDomain(int id, int animalId, string desisseName, string description, AnimalDomain animals)
        {
            Id = id;
            AnimalId = animalId;
            DesisseName = desisseName;
            Description = description;
            Animals = animals;
        }
        public ContageusAnimalsDomain(int id, int animalId, string desisseName, string description,bool contageus)
        {
            Id = id;
            AnimalId = animalId;
            DesisseName = desisseName;
            Description = description;
        Contageus = contageus;
        }
        public ContageusAnimalsDomain(int id, int animalId, string desisseName, string description, bool contageus,DateTime startTime)
        {
            Id = id;
            AnimalId = animalId;
            DesisseName = desisseName;
            Description = description;
            Contageus = contageus;
            StartTime=startTime;
        }
        public ContageusAnimalsDomain(int id, bool contageus)
        {
            Id = id;
    
            Contageus = contageus;
        }

        public ContageusAnimalsDomain( int animalId, string desisseName,DateTime startTime, string description, bool contageus)
        {
          
            AnimalId = animalId;
            DesisseName = desisseName;
            StartTime= startTime;
            Description = description;
            Contageus = contageus;
        }
        public int Id { get; set; }
        public int AnimalId { get; set; }

        public string DesisseName { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public bool Contageus { get; set; }


        public AnimalDomain Animals { get; set; }
    }
}
