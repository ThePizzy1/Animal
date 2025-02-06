using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.MODEL
{
    public class ParameterDomain
    {//parametri iz labaratorijskih nalaza pošto svaki nalaz ne mora nužno imat iste parametre pa ovako samo dodamo listu željenih, svaki parametar ima id lab nalaza 
        //planiram napravit da se prvo napravi nalaz spremi te da se parametri ažuriraju te tako znaju koji je id nalaza
        public ParameterDomain() { }
        public ParameterDomain(int id, string parameterName, decimal parameterValue, string remarks, string measurementUnits)
        {
            Id = id;
        
            ParameterName = parameterName;
            ParameterValue = parameterValue;
            Remarks = remarks;
            MeasurementUnits = measurementUnits;
        }

        public int Id { get; set; }
    
        public string ParameterName { get; set; }
        public decimal ParameterValue { get; set; }
        public string Remarks { get; set; }
        public string MeasurementUnits { get; set; }




    }
}
