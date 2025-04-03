using ANIMAL.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ANIMAL.MODEL
{
    public class TransactionsDomain
    {
        public TransactionsDomain(){}
        public TransactionsDomain(int id, string iban, string ibanAnimalShelter, string type, DateTime date, decimal cost, string purpose) 
        {
            Id      = id;
            Iban    = iban;
            IbanAnimalShelter = ibanAnimalShelter;
            Type    = type;
            Date    = date;
            Cost    = cost;
            Purpose = purpose;
        }

        public TransactionsDomain( string iban, string ibanAnimalShelter, string type, DateTime date, decimal cost, string purpose)
        {
           
            Iban = iban;
            IbanAnimalShelter = ibanAnimalShelter;
            Type = type;
            Date = date;
            Cost = cost;
            Purpose = purpose;
        }


        public int Id { get; set; }
        public string Iban { get; set; }
        public string IbanAnimalShelter { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
        public string Purpose { get; set; }


        public FundsDomain Funds { get; set; }
        public BalansDomain Balans { get; set; }
    }
}
