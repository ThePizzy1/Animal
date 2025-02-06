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
        public bool Complited { get; set; }
        public virtual Animals Animals { get; set; }//ovo si zaboravila

    }
}
