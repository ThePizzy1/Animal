using ANIMAL.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.MODEL
{
    public class ContactDomain
    {  //dodaj pročitano
        public ContactDomain() { }
        public ContactDomain(int id, string name, string email, string description, int adopterId, AdopterDomain adopter)
        {
            Id = id;
            Name = name; 
            Email = email; 
            Description = description;
            AdopterId = adopterId;
            Adopter = adopter;
        }

        public ContactDomain(int id, string name, string email, string description, int adopterId, bool read)
        {
            Id = id;
            Name = name;
            Email = email;
            Description = description;
            AdopterId = adopterId;
            Read = read;
        }
        public ContactDomain( string name, string email, string description, int adopterId)
        {
         
            Name = name;
            Email = email;
            Description = description;
            AdopterId = adopterId;

        }
        public ContactDomain(bool read)
        {
            Read = read;
          
        }





        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public bool Read {  get; set; }
        public int AdopterId { get; set; }
        public AdopterDomain Adopter { get; set; }
    }
}
