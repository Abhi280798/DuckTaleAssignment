using DuckTaleAssignmet.Repository.Context;
using DuckTaleAssignmet.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace DuckTaleAssignmet.Repository.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly ApplicationContext _dbContext;
        public AssignmentRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Employee>> GetAll()
        {
            return await _dbContext.Employee.ToListAsync();
        }
    }
}
