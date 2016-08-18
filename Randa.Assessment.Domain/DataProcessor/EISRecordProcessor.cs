using Newtonsoft.Json;
using Randa.Assessment.Domain.Contracts.DataImporter;
using Randa.Assessment.Domain.Contracts.DataProcessor;
using Randa.Assessment.Domain.Contracts.Repository;
using Randa.Assessment.Domain.DataImporter;
using Randa.Assessment.Domain.DataRecord;

namespace Randa.Assessment.Domain.DataProcessor
{
    public class EISRecordProcessor: IDataRecordProcessor
    {
        public EISRecordProcessor()
        {
            
        }

        public void Process(DataImportEventRow row)
        {
            EISDataRecord record = JsonConvert.DeserializeObject<EISDataRecord>(row.JSON);
            record.CleanDistrictId();
            record.CleanSchoolId();
            record.CleanFirstName();
            record.CleanLastName();
            record.CleanUSID();
        }
    }
}
