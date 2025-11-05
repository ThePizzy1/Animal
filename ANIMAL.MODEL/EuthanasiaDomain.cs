using ANIMAL.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.DAL.DataModel
{
    public class EuthanasiaDomain
    {
        public EuthanasiaDomain()
        {

        }

        public EuthanasiaDomain(int id, int animalId, DateTime date, string nameOfDesissse, AnimalDomain animal)
        {
            Id = id;
            AnimalId = animalId;
            Date = date;
            NameOfDesissse = nameOfDesissse;
            Animal = animal;
        }
        public EuthanasiaDomain(int id, int animalId, DateTime date, string nameOfDesissse, bool complited)
        {
            Id = id;
            AnimalId = animalId;
            Date = date;
            NameOfDesissse = nameOfDesissse;
            Complited = complited;
      
        }
        public EuthanasiaDomain(int id, DateTime date)
        {
            Id = id;
            Date = date;
         
        }
        public EuthanasiaDomain(int id,  bool complited)
        {
            Id = id;
            Complited = complited;
        }
        public EuthanasiaDomain( int animalId, DateTime date, string nameOfDesissse, bool complited)
        {
         
            AnimalId = animalId;
            Date = date;
            NameOfDesissse = nameOfDesissse;
            Complited = complited;
        }

        public int Id { get; set; }
        public int AnimalId { get; set; }
        public DateTime Date { get; set; }
        public string NameOfDesissse { get; set; }
        public bool Complited { get; set; }
        public AnimalDomain Animal { get; set; }

    }
}
