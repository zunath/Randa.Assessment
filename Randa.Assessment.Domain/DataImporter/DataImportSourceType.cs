﻿namespace Randa.Assessment.Domain.DataImporter
{
    public class DataImportSourceType
    {
        public string DataSourceId { get; set; }
        public string Name { get; set; }
        public DataImportParserType ImportParserType { get; set; }
    }
}