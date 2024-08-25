using TestWork1.Models;

namespace TestWork1.RepositoryAbstractions;

public interface ICostsRepository
{
    public List<Cost> GetAll();
    public void DeleteAll();
    public void AddRange(List<Cost> costs);
}