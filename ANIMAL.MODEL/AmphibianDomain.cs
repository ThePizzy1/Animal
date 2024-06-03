using System;
using System.Collections.Generic;
using System.Text;
using ANIMAL.DAL.DataModel;
//
namespace ANIMAL.MODEL
{
   
        public class AmphibianDomain : AnimalDomain
        {
           
            public AmphibianDomain(Amphibians amphibian) 
            {
                Humidity = amphibian.Humidity;
                Temperature = amphibian.Temperature;
            }
             public decimal Humidity { get; set; }
            public decimal Temperature { get; set; }
        public AnimalDomain Animal { get; set; }

    }


    }
