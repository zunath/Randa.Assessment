
using System;
using System.Collections;
using System.Collections.Generic;

namespace Randa.Assessment.Domain.Services.Contracts.DataImporter
{
    public interface IDataImportParser
    {
        IEnumerable ParseFile (string filePath);
    }
}
