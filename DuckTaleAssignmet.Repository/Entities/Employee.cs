
namespace DuckTaleAssignmet.Repository.Entities
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; } 
        public int? ManagerID { get; set; }

        // Navigation property for the manager
        public Employee Manager { get; set; }
        public int EmployeeSalary { get; set; }

    }
}
