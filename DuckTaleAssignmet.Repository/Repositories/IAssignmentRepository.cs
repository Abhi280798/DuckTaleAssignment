using DuckTaleAssignmet.Repository.Entities;

namespace DuckTaleAssignmet.Repository.Repositories
{
    public interface IAssignmentRepository
    {
        Task<List<Employee>> GetAll();
    }
}
