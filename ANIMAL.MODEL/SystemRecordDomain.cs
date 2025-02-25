using System;
using System.Collections.Generic;
using System.Text;

namespace ANIMAL.MODEL
{
    public class SystemRecordDomain
    {
        public SystemRecordDomain() { }
        public SystemRecordDomain(int id, int recordNumber, string recordName, string recordDescription)
        {
            Id = id;
            RecordNumber = recordNumber;
            RecordName = recordName;
            RecordDescription = recordDescription;
        }
        public SystemRecordDomain( int recordNumber, string recordName, string recordDescription)
        {
           
            RecordNumber = recordNumber;
            RecordName = recordName;
            RecordDescription = recordDescription;
        }

        public int Id { get; set; }
        public int RecordNumber { get; set; }
        public string RecordName { get; set; }
        public string RecordDescription { get; set; }
    }
}
