using LinqToDB;
using LinqToDB.Data;
using MySql.Data.MySqlClient;
using TestWork1.Models;

namespace TestWork1.InfrastructureDbContext;

public class AppDataContext(DataOptions<AppDataContext> options) : DataConnection(options.Options)
{
    public ITable<Cost> Costs => this.GetTable<Cost>();

    public void ExecuteSqlScript(string sqlScript)
    {
        this.Execute(sqlScript);
    }
}