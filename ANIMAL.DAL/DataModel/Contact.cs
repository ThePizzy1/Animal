using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int AdopterId { get; set; }
        public virtual Adopter Adopter { get; set; }//fali ti za tablicu
    }
}
