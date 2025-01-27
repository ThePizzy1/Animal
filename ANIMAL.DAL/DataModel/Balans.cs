using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public partial class Balans
    {
        public int Id {  get; set; }
        public string Iban { get; set;}
        public decimal Balance { get; set;}
        public DateTime LastUpdated { get; set;}
        public string Password { get; set;}
        public string Type { get; set;}


    }
}
