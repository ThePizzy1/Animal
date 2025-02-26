using ANIMAL.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.MODEL
{       //TREBA MAKNUT LIST PARAMETAR
    public class LabsDomain
    {
        public LabsDomain() { }
        public LabsDomain(int id, int animalId, List<Parameter> parameters, DateTime dateTime, AnimalDomain animals)
        {
            Id = id;
            AnimalId = animalId;
            Parameters = parameters;
            DateTime = dateTime;
            Animals = animals;
        }
        public LabsDomain(int id, int animalId, List<Parameter> parameters, DateTime dateTime)
        {
            Id = id;
            AnimalId = animalId;
            Parameters = parameters;
            DateTime = dateTime;
        }
        public LabsDomain(int id,  List<Parameter> parameters)
        {
            Id = id;
            
            Parameters = parameters;
          
        }
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public List<Parameter> Parameters { get; set; }
        public DateTime DateTime { get; set; }
        public AnimalDomain Animals { get; set; }
    }
}
