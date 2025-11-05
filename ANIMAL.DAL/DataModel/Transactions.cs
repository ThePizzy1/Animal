using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public partial class Transactions
    {//razlika ovoga i funds, ovdije je i za uplate i za isplate više za to što se dešava na samom računu nego samo za donacije
        public int Id { get; set; }
        public string Iban { get; set; }//sa kojeg //Balans fk na Iban//ovo se zapisuje u funds
        public string IbanAnimalShelter { get; set; }//na koji //funds fk na Iban//i ovo se upisuje u funds
        public string Type { get; set; }//isplata uplata
        public DateTime Date { get; set; }
        public decimal Cost {  get; set; }
        public string Purpose { get; set; }

        [ForeignKey("IbanAnimalShelter")]
        public Balans Balans { get; set; }
        [ForeignKey("Iban")]
        public Funds Funds { get; set; }
    }
}
