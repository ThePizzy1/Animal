using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.MODEL
{
    public class BalansDomain
    {
        public BalansDomain() { }

        public BalansDomain(int id, string iban, decimal balance, DateTime lastUpdated, string password, string type)
        {
            Id = id;
            Iban = iban;
            Balance = balance;
            LastUpdated = lastUpdated;
            Password = password;
            Type = type;
        }
        public BalansDomain(int id, decimal balance)
        {
            Id=id;
            Balance=balance;
        }
        public int Id { get; set; }
        public string Iban { get; set; }
        public decimal Balance { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
    }
}
