using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{//Ovo je za donacije da se vidi ko šalje točno sa kojeg računa i vidi se ko je logiran itd
    public partial class Funds
    {
        public int Id { get; set; }
         public int AdopterId { get; set; }
        public decimal Amount {  get; set; }
        public string Purpose { get; set; }
        public DateTime DateTimed { get; set; }
        public string Iban { get; set; }
        public Adopter  Adopter { get; set; }
        
    }
}
