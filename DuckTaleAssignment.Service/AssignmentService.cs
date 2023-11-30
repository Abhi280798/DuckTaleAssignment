using DuckTaleAssignmet.Dto;
using DuckTaleAssignmet.Repository.Repositories;

namespace DuckTaleAssignment.Service
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        public AssignmentService(IAssignmentRepository assignmentRepository) 
        {
            _assignmentRepository = assignmentRepository;
        }
        public async Task<List<EmployeeManagerResponse>> employeeManagerResponses()
        {
            var data = await _assignmentRepository.GetAll();
            var result = data.Select(x=> new EmployeeManagerResponse()
            {
                EmployeeName = x.Name,
                ManagerName = x.ManagerID == null ? null : x.Manager.Name
            }).ToList();
            return result;
        }

        public async Task<List<TotalEmployeeUnderManager>> employeeUnderManagerResponses()
        {
            try
            {
                var data = await _assignmentRepository.GetAll();
                var result = data.Where(a=>a.ManagerID!=null).GroupBy(x => new { x.Manager.Name }).Select(m =>
                new TotalEmployeeUnderManager()
                {
                    ManagerName = m.Key.Name,
                    TotalEmployees = m.Count()
                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<ManagerNameSalaryResponse>> managerSalaryResponses()
        {
            var data = await _assignmentRepository.GetAll();
            var result = data.Where(x=>x.ManagerID!=null).GroupBy(a => new { a.Manager.Name, a.Manager.EmployeeSalary }).Select(m=>
            new ManagerNameSalaryResponse()
            {
                ManagerName = m.Key.Name,
                ManagerSlary = m.Key.EmployeeSalary
            }).ToList();
            return result;
        }

        public async Task<SecondHigestSlaryEmployeeDetails> secondHigestSalaryEmployee()
        {
            var data = await _assignmentRepository.GetAll();
            var result = data.OrderByDescending(x=>x.EmployeeSalary).Skip(1).Take(1)
                .Select(m=>new SecondHigestSlaryEmployeeDetails
                {
                    EmployeeName = m.Name,
                    ManagerName = m.Manager.Name,
                    Salary = m.EmployeeSalary
                }).FirstOrDefault();
            return result;
        }
    }
}
