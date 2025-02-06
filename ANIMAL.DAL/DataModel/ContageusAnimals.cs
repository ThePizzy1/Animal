using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public partial class ContageusAnimals
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public string DesisseName { get; set; }
        public string Description { get; set; }
        //potrebno nešto da znam dali je životinja i dalje zaražena i koliko je dugo zaražena
        public  DateTime StartTime { get; set; }
        public bool Contageus {  get; set; }
        public virtual Animals Animals { get; set; }
    }
}
