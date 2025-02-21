using ANIMAL.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.MODEL
{
    public class AnimalRecordDomain
    {
        public AnimalRecordDomain() { }

        public AnimalRecordDomain( int recordId, int animalId, AnimalDomain animal, SystemRecordDomain systemRecord)
        {
         
            RecordId = recordId;
            AnimalId = animalId;
            Animal = animal;
           Record=systemRecord;

        }
        public AnimalRecordDomain( AnimalDomain animal, SystemRecordDomain systemRecord)
        {
          
     
            Animal = animal;
            Record = systemRecord;

        }
        public AnimalRecordDomain( int recordId, int animalId)
        {
          
            RecordId = recordId;
            AnimalId = animalId;
       

        }


        public int RecordId { get; set; }
        public int AnimalId { get; set; }

        public AnimalDomain Animal { get; set; }
        public SystemRecordDomain Record { get; set; }
    }
}
