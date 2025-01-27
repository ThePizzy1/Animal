using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public partial class Parameter
    {
        public int Id { get; set; }
        public int LabId { get; set; }
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
        public string Remarks { get; set; }
        public string MeasurementUnits {  get; set; }
        
    }
}
