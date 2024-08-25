using LinqToDB;
using LinqToDB.AspNet;
using Microsoft.Extensions.DependencyInjection;
using TestWork1.InfrastructureDbContext;
using TestWork1.RepositoryAbstractions;
using TestWork1.RepositoryImplementations;
using TestWork1.ServicesAbstractions;
using TestWork1.ServicesImplementations;

namespace TestWork1;

public class Program
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();
        var connectionString = "server=localhost;user=root;password=admin;database=new_schema;port=3306;CharSet=utf8;";

        services.AddLinqToDBContext<AppDataContext>((provider, options)=> options.UseMySqlData(connectionString));
        services.AddScoped<ICostsRepository, CostsRepository>();
        services.AddScoped<ICostsService, CostsService>();

        var serviceProvider = services.BuildServiceProvider();

        var service = serviceProvider.GetService<ICostsService>();
        service.PrepareDatabase();
        service.SolveTask();
    }
}
