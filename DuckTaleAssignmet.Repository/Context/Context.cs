using DuckTaleAssignmet.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DuckTaleAssignmet.Repository.Context
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _config;
        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }
        public DbSet<Employee> Employee { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connetionString = _config["DefaultConnection:ConnectionString"];
            optionsBuilder.UseSqlServer(connetionString);
        }
    }
}
