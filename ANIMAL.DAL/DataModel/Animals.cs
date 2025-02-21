using System;
using System.Collections.Generic;

namespace ANIMAL.DAL.DataModel
{
    public partial class Animals
    {
        public Animals()
        {
            AdoptedNavigation = new HashSet<Adopted>();
            ReturnedAnimal = new HashSet<ReturnedAnimal>();
        }

        public int IdAnimal { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Species { get; set; }
        public string Subspecies { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public bool Neutered { get; set; }
        public bool Vaccinated { get; set; }
        public bool Microchipped { get; set; }
        public bool Trained { get; set; }
        public bool Socialized { get; set; }
        public string HealthIssues { get; set; }
        public string PersonalityDescription { get; set; }
        public bool Adopted { get; set; }
        public byte[] Picture { get; set; }
     

        public virtual Birds Birds { get; set; }
        public virtual Reptiles Reptiles { get; set; }
        public virtual ICollection<Adopted> AdoptedNavigation { get; set; }
        public virtual ICollection<ReturnedAnimal> ReturnedAnimal { get; set; }
        public virtual ICollection<FoundRecord> FoundRecord { get; set; }
        public AnimalRecord AnimalRecord { get; set; }
    }
}
