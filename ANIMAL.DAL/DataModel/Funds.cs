using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public partial class Funds
    {
        public int Id { get; set; }
         public int AdopterId { get; set; }
        public decimal Amount {  get; set; }
        public string Purpose { get; set; }
        public DateTime DateTimed { get; set; }
        

    }
}
