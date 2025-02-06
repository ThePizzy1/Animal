using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public partial class Euthanasia
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public DateTime Date { get; set; }
        public string NameOfDesissse { get; set; }
        //potrebno nešto da znam da je radnja 100% izvršena
        public bool Complited { get; set; }

        public virtual Animals Animals { get; set; }

    }
}
