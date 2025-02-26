using ANIMAL.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public class FundsDomain
    {


        public FundsDomain() { }
        public FundsDomain( int adopterId, decimal amount, string purpose, DateTime dateTime)
        {
          
            AdopterId = adopterId;
            Amount = amount;
            Purpose = purpose;
            DateTime = dateTime;

        }
        public FundsDomain(int id, int adopterId, decimal amount, string purpose, DateTime dateTime, AdopterDomain adopter)
        {
            Id = id;
            AdopterId = adopterId;
            Amount = amount;
            Purpose = purpose;
            DateTime = dateTime;
            Adopter = adopter;
        }
        public FundsDomain(int id, int adopterId, decimal amount, string purpose, DateTime dateTime)
        {
            Id = id;
            AdopterId = adopterId;
            Amount = amount;
            Purpose = purpose;
            DateTime = dateTime;
         
        }
        public int Id { get; set; }
        public int AdopterId { get; set; }
        public decimal Amount { get; set; }
        public string Purpose { get; set; }
        public DateTime DateTime { get; set; }

        public AdopterDomain Adopter { get; set; }
    }
}
