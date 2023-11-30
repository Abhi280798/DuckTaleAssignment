using DuckTaleAssignment.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuckTaleAssignment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }
        [HttpGet("task1")]
        public async Task<IActionResult> Task1()
        {
            try
            {
                var result = await _assignmentService.employeeManagerResponses();
                return Ok(new { status = true, data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = false, error = ex.Message });
            }
        }
        [HttpGet("task2")]
        public async Task<IActionResult> Task2()
        {
            try
            {
                var result = await _assignmentService.employeeUnderManagerResponses();
                return Ok(new { status = true, data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = false, error = ex.Message });
            }
        }
        [HttpGet("task3")]
        public async Task<IActionResult> Task3()
        {
            try
            {
                var result = await _assignmentService.managerSalaryResponses();
                return Ok(new { status = true, data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = false, error = ex.Message });
            }
        }
        [HttpGet("task4")]
        public async Task<IActionResult> Task4()
        {
            try
            {
                var result = await _assignmentService.secondHigestSalaryEmployee();
                return Ok(new { status = true, data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = false, error = ex.Message });
            }
        }
    }
}
