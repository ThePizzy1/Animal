using ANIMAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public partial class FoundRecord
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public DateTime Date { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
    
        public string OwnerName { get; set; }
        public string OwnerSurname { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public string OwnerOIB { get; set; }



        public virtual Animals Animal { get; set; }
        public virtual ApplicationUser User { get; set; }


        public string RegisterId { get; set; }
    }
}
