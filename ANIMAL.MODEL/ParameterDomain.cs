using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.MODEL
{
    public class ParameterDomain
    {//parametri iz labaratorijskih nalaza pošto svaki nalaz ne mora nužno imat iste parametre pa ovako samo dodamo listu željenih, svaki parametar ima id lab nalaza 
        //planiram napravit da se prvo napravi nalaz spremi te da se parametri ažuriraju te tako znaju koji je id nalaza
        public ParameterDomain() { }
        public ParameterDomain(int id, int labId, string parameterName, string parameterValue, string remarks, string measurementUnits)
        {
            Id = id;
            LabId = labId;
            ParameterName = parameterName;
            ParameterValue = parameterValue;
            Remarks = remarks;
            MeasurementUnits = measurementUnits;
        }

        public int Id { get; set; }
        public int LabId { get; set; }
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
        public string Remarks { get; set; }
        public string MeasurementUnits { get; set; }




    }
}
