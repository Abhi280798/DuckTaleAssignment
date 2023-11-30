
using DuckTaleAssignmet.Dto;

namespace DuckTaleAssignment.Service
{
    public interface IAssignmentService
    {
        Task<List<EmployeeManagerResponse>> employeeManagerResponses();
        Task<List<TotalEmployeeUnderManager>> employeeUnderManagerResponses();
        Task<List<ManagerNameSalaryResponse>> managerSalaryResponses();
        Task<SecondHigestSlaryEmployeeDetails> secondHigestSalaryEmployee();
    }
}
