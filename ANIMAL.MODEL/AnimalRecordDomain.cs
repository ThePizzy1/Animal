using ANIMAL.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.MODEL
{
    public class AnimalRecordDomain
    {
        public AnimalRecordDomain() { }

        public AnimalRecordDomain(int id, int recordId, int animalId, AnimalDomain animal, SystemRecordDomain systemRecord)
        {
            Id = id;
            RecordId = recordId;
            AnimalId = animalId;
            Animal = animal;
           Record=systemRecord;

        }
        public AnimalRecordDomain(int id, int recordId, int animalId)
        {
            Id = id;
            RecordId = recordId;
            AnimalId = animalId;
       

        }
        public AnimalRecordDomain(int id, int recordId)
        {
            Id = id;
            RecordId = recordId;
       


        }

        public int Id { get; set; }
        public int RecordId { get; set; }
        public int AnimalId { get; set; }

        public AnimalDomain Animal { get; set; }
        public SystemRecordDomain Record { get; set; }
    }
}
