using System;
using System.Collections.Generic;
using System.Text;
using ANIMAL.DAL.DataModel;
using Newtonsoft.Json;
//
namespace ANIMAL.MODEL
{
   
        public class AmphibianDomain : AnimalDomain
        {
           
            public AmphibianDomain(int idAnimal, string name, string family, string species, string subspecies, int age, string gender, decimal weight, decimal height, decimal length, bool neutered, bool vaccinated, bool microchipped, bool trained, bool socialized, string healthIssues, byte[] picture, string personalityDescription, bool adopted, int animalId, decimal humidity, decimal temperature)
            : base(idAnimal, name, family, species, subspecies, age, gender, weight, height, length, neutered, vaccinated, microchipped, trained, socialized, healthIssues,picture, personalityDescription, adopted)
             {
                AnimalId = animalId;
                Humidity = humidity;
                Temperature =temperature;
            }
        [JsonConstructor]
        public AmphibianDomain(int idAnimal, decimal humidity, decimal temperature)
        {
            AnimalId = idAnimal;
            Humidity = humidity;
            Temperature = temperature;
        }
        public AmphibianDomain() { }
        public int AnimalId { get; set; }
        public decimal Humidity { get; set; }
        public decimal Temperature { get; set; }
        public virtual Animals Animal { get; set; }

        }

}
