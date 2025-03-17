using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.MODEL
{
    public class ParameterDomain
    {    //parametri iz labaratorijskih nalaza pošto svaki nalaz ne mora nužno imat iste parametre pa ovako samo dodamo listu željenih, svaki parametar ima id lab nalaza 
         //planiram napravit da se prvo napravi nalaz spremi te da se parametri dodaju poslje lap te tako znaju koji je id nalaza
         //Napravi da je ID PRAMETAR = ID LAB
        public ParameterDomain() { }
        public ParameterDomain(string parameterName, decimal parameterValue, string remarks, string measurementUnits)
        {
           
        
            ParameterName = parameterName;
            ParameterValue = parameterValue;
            Remarks = remarks;
            MeasurementUnits = measurementUnits;
        }

      
    
        public string ParameterName { get; set; }
        public decimal ParameterValue { get; set; }
        public string Remarks { get; set; }
        public string MeasurementUnits { get; set; }




    }
}
