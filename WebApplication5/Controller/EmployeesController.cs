using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Data;
using WebApplication5.Models.Entities;

namespace WebApplication5.Controller
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public IActionResult GetAllEmployees() {
           var emp = _context.MyProperty.ToList();
            return Ok(emp);
        }

        [HttpPost("Save")]
        public IActionResult Save(SaveEmployeeDTO req)
        {
            
            var emp = new Employee
            {
               Name = req.Name,
               Email = req.Email,
               Phone = req.Phone,
               Salary = req.Salary 
            };
            _context.MyProperty.Add(emp);
            _context.SaveChanges();
            return Ok(emp);
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetEmployeeByID(Guid id)
        {
            var emp = _context.MyProperty.Find(id);
            return Ok(emp);
        }
        [HttpPost("Update/{id}")]
        public IActionResult Save(Guid id,SaveEmployeeDTO req)
        {

            var emp = _context.MyProperty.Find(id);

            emp.Name = req.Name;
            emp.Email = req.Email;
            emp.Phone = req.Phone;
            emp.Salary = req.Salary;
            _context.SaveChanges();
            return Ok(emp);
        }

        [HttpGet("delete/{id}")]
        public IActionResult delete(Guid id)
        {
            var emp = _context.MyProperty.Find(id);
            _context.MyProperty.Remove(emp);
            return Ok(emp);
        }

    }
}
