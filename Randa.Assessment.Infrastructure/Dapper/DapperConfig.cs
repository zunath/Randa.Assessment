using Dapper.Extensions.Linq.Core.Configuration;
using Dapper.Extensions.Linq.Mapper;
using Dapper.Extensions.Linq.Sql;

namespace Randa.Assessment.Infrastructure.Dapper
{
    public class DapperConfig
    {
        public static void Initialize()
        {
            DapperConfiguration
                .Use()
                .UseClassMapper(typeof(AutoClassMapper<>))
                .UseContainer<DapperContainer>(delegate {  })
                .UseSqlDialect(new SqlServerDialect())
                .FromAssembly("Randa.Assessment.Domain")
                .Build();
        }
    }
}
