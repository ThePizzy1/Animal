using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public partial class VetVisits
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string TypeOfVisit {  get; set; }

        public string Notes { get; set; }

        public Animals Animals { get; set; }



    }
}
