using TestWork1.InfrastructureDbContext;
using TestWork1.Models;
using TestWork1.RepositoryAbstractions;
using TestWork1.ServicesAbstractions;

namespace TestWork1.ServicesImplementations;

public class CostsService(ICostsRepository repository, AppDataContext context) : ICostsService
{
    private const string _filename = "Costs.sql";
    public void PrepareDatabase()
    {
        var folderPath = $"{Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName)}\\Script";
        var filePath = Path.Combine(folderPath, _filename);
        using var streamReader = new StreamReader(File.OpenRead(filePath));
        var sqlScript = streamReader.ReadToEnd();
        context.ExecuteSqlScript(sqlScript);
    }

    public void SolveTask()
    {
        var costs = repository.GetAll().OrderBy(x => x.StartDate).ToList();
        var currentMergedCost = costs.First();
        var mergedCosts = new List<Cost>();
        for (var i = 1; i < costs.Count; i++)
        {
            if (costs[i].AdultsMainWeekday == currentMergedCost.AdultsMainWeekday)
            {
                currentMergedCost.EndDate = costs[i].EndDate;
            }
            else
            {
                mergedCosts.Add(currentMergedCost);
                currentMergedCost = costs[i];
            }
        }

        repository.DeleteAll();
        repository.AddRange(mergedCosts);
    }
}