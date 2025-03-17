using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public partial class Labs
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Animals Animal { get; set; }
    
    }
}
