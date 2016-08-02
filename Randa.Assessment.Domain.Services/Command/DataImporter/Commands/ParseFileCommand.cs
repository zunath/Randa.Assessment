namespace Randa.Assessment.Domain.Services.Command.DataImporter.Commands
{
    public class ParseFileCommand
    {
        public string DataSourceId { get; private set; }

        public ParseFileCommand(string dataSourceId)
        {
            DataSourceId = dataSourceId;
        }
    }
}
