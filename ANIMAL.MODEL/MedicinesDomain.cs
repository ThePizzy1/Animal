using ANIMAL.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.MODEL
{
    public class MedicinesDomain
    {
        //dodaj tablicu povjest bolest i spoji sve tablice bolesti na jednu i napravi da se sprema id životinje trajanje bolesti datum updata itd. kako bi mogli pratit sve.
        //
        public  MedicinesDomain() { }

        public MedicinesDomain(int id, int animalId, string nameOfMedicines, string descriptio, string vetUsername)
        {
            Id = id;
            AnimalId = animalId;
            NameOfMedicines = nameOfMedicines;
            Description = descriptio;
            VetUsername = vetUsername;
        }

        public MedicinesDomain(int id, int animalId, string nameOfMedicines, string descriptio, string vetUsername,AnimalDomain animal )
        {
            Id=id;
            AnimalId = animalId;
            NameOfMedicines=nameOfMedicines;
            Description = descriptio;
            VetUsername = vetUsername;
            Animal = animal;
        }


        public int Id { get; set; }
        public int AnimalId { get; set; }
        public string NameOfMedicines { get; set; }
        public string Description { get; set; }
        public string VetUsername { get; set; }

        public AnimalDomain Animal { get; set; }

    }
}
