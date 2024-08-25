using LinqToDB;
using TestWork1.InfrastructureDbContext;
using TestWork1.Models;
using TestWork1.RepositoryAbstractions;

namespace TestWork1.RepositoryImplementations;

public class CostsRepository(AppDataContext context) : ICostsRepository
{
    public List<Cost> GetAll()
    {
        return context.Costs.ToList();
    }

    public void DeleteAll()
    {
        var costs = GetAll();
        foreach (var cost in costs)
        {
            context.Costs.Delete(c=>c.Id == cost.Id);
        }
    }

    public void AddRange(List<Cost> costs)
    {
        foreach (var cost in costs)
        {
            context.Insert(cost);
        }
    }
}
