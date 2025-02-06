using ANIMAL.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.MODEL
{
    public class MedicinesDomain
    {
        //dodaj tablicu povjest dolest i spoji sve tablice bolesti na jednu i napravi da se sprema id životinje trajanje bolesti datum updata itd. kako bi mogli pratit sve.
        //
        public  MedicinesDomain() { }

        public MedicinesDomain(int id,  string nameOfMedicines, string descriptio, string vetUsername, decimal amountOfMedicine, string mesurmentUnit, int medicationIntake, string frequencyOfMedicationUse, bool usage)
        {
            Id = id;
          
            NameOfMedicines = nameOfMedicines;
            Description = descriptio;
            VetUsername = vetUsername;
            AmountOfMedicine = amountOfMedicine;
            MesurmentUnit = mesurmentUnit;
            MedicationIntake = medicationIntake;
            FrequencyOfMedicationUse = frequencyOfMedicationUse;
            Usage = usage;
        }

        public MedicinesDomain(int id, string nameOfMedicines, string descriptio, string vetUsername, decimal amountOfMedicine, string mesurmentUnit, int medicationIntake, string frequencyOfMedicationUse, bool usage, AnimalDomain animal)
        {
            Id=id;
          
            NameOfMedicines=nameOfMedicines;
            Description = descriptio;
            VetUsername = vetUsername;
           
            AmountOfMedicine = amountOfMedicine;
            MesurmentUnit = mesurmentUnit;
            MedicationIntake = medicationIntake;
            FrequencyOfMedicationUse = frequencyOfMedicationUse;
            Usage = usage; 
            Animal = animal;

        }
        public MedicinesDomain(int id, decimal amountOfMedicine, string mesurmentUnit, int medicationIntake, string frequencyOfMedicationUse)
        {
            Id = id;

        

            AmountOfMedicine = amountOfMedicine;
            MesurmentUnit = mesurmentUnit;
            MedicationIntake = medicationIntake;
          

        }
        public MedicinesDomain(int id, bool usage)//Da mogu samo izmjeniti taj parametar kad trebam, dali živtinja još koristi te ljekove
        {
            Id = id;
            Usage = usage;
        }

        public int Id { get; set; }
        public int AnimalId { get; set; }
        public string NameOfMedicines { get; set; }
        public string Description { get; set; }
        public string VetUsername { get; set; }
        public decimal AmountOfMedicine { get; set; }
        public string MesurmentUnit { get; set; }
        public int MedicationIntake { get; set; }
        public string FrequencyOfMedicationUse { get; set; }
        public bool Usage { get; set; }
        public AnimalDomain Animal { get; set; }

    }
}
