using System.Data;

namespace Project.Infrastructure.Database.SQL
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
