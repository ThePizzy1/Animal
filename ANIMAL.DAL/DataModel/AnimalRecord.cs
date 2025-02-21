using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public partial class AnimalRecord
    {
      
        public int RecordId { get; set; }
        public int AnimalId { get; set; }//primary key

        public virtual Animals Animal { get; set; }
        public virtual SystemRecord Record { get; set; }
    }
}
