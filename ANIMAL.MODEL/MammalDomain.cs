using System;
using System.Collections.Generic;
using System.Text;
using ANIMAL.DAL.DataModel;
//using ANIMAL.DAL.DataModel;
namespace ANIMAL.MODEL
{
    public class MammalDomain : AnimalDomain
    {
        public MammalDomain(Mammals mammal)
        {
            AnimalId = mammal.AnimalId;
            CoatType = mammal.CoatType;
            GroomingProducts = mammal.GroomingProducts;
        }

        public int AnimalId { get; set; }
        public string CoatType { get; set; }
        public string GroomingProducts { get; set; }
        public AnimalDomain Animal { get; set; }
    }

}
