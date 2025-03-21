﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public partial class Medicines
    {

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
        public virtual Animals Animal { get; set; }

    }
}
