﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{   //dodaj image tipa da je novost kao letak 
    public partial class News
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }

        public byte[] Picture { get; set; }

    }
}
