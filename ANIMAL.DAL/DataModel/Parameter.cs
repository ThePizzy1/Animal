﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public partial class Parameter
    {
      
        public int LabId {  get; set; }//primary key
        public string ParameterName { get; set; }
        public decimal ParameterValue { get; set; }
      
        public string Remarks { get; set; }
        public string MeasurementUnits {  get; set; }

        public virtual Labs Labs {  get; set; }

    }
}
