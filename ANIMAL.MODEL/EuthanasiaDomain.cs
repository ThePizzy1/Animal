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
        public EuthanasiaDomain(int id, int animalId, DateTime date, string nameOfDesissse)
        {
            Id = id;
            AnimalId = animalId;
            Date = date;
            NameOfDesissse = nameOfDesissse;
      
        }
        public EuthanasiaDomain(int id, DateTime date, bool complited)
        {
            Id = id;
            Date = date;
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
