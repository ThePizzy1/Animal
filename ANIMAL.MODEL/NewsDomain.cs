using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.MODEL
{
    public class NewsDomain
    {


        public NewsDomain() { }
        public NewsDomain(int id, string name, string description, DateTime dateTime) { 
        
            Id = id;
            Name = name;
            Description = description;
            DateTime = dateTime;
        
        }

        public NewsDomain( string name, string description, DateTime dateTime)
        {

           
            Name = name;
            Description = description;
            DateTime = dateTime;

        }

        public NewsDomain(int id, string name, string description, DateTime dateTime, byte[] picture = null)
        {
            Id = id;
            Name = name;
            Description = description;
            DateTime = dateTime;
            Picture = picture;
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public byte[] Picture { get; set; }

    }
}
