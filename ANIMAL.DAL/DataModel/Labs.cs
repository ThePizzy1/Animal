﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public partial class Labs
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public List<Parameter> Parameters { get; set; }
        public DateTime DateTime { get; set; }
        public Animals Animals { get; set; }

    }
}
