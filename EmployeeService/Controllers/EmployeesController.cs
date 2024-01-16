using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeService.Models;
using EmployeeService.DTO;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public EmployeesController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            return _context.Employees.Select(e => new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Title = e.Title
            });
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<EmployeeDTO> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return null;
            }
            EmployeeDTO EmpDTO = new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Title = employee.Title
            };
            return EmpDTO;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<string> PutEmployee(int id, EmployeeDTO EmpDTO)
        {
            if (id != EmpDTO.EmployeeId)
            {
                return "更新員工紀錄失敗";
            }
            Employee employee = await _context.Employees.FindAsync(id);
            employee.FirstName = EmpDTO.FirstName;
            employee.LastName = EmpDTO.LastName;
            employee.Title = EmpDTO.Title;
            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return "更新員工紀錄失敗";
                }
                else
                {
                    throw;
                }
            }

            return "更新員工紀錄成功";
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<string> PostEmployee(EmployeeDTO EmpDTO)
        {
            Employee employee = new Employee
            {
                FirstName = EmpDTO.FirstName,
                LastName = EmpDTO.LastName,
                Title = EmpDTO.Title
            };
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return $"新增員工成功，員工編號為{employee.EmployeeId}";
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return "刪除員工紀錄失敗";
            }
            try
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException ex)
            {
                return "刪除員工關聯紀錄失敗";
            }
            return "刪除員工紀錄成功";
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
