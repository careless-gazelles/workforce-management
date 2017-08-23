using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BangazonWorkforceManagement.Models;
using BangazonWorkforceManagement.ViewModels;

namespace BangazonWorkforceManagement.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly BangazonWorkforceManagementContext _context;

        public EmployeesController(BangazonWorkforceManagementContext context)
        {
            _context = context;    
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var bangazonWorkforceManagementContext = _context.Employee.Include(e => e.Departments);
            return View(await bangazonWorkforceManagementContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Departments)
                .Include(e => e.EmployeeComputers)
                .Include(e => e.TrainingPgmEmps)
                .SingleOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            var employeeView = new EmployeeDetailViewModel();
            employeeView.Employee = employee;
            foreach (var item in employee.EmployeeComputers)
            {
                var empComputer = _context.Computer.SingleOrDefault(c => c.ComputerId == item.ComputerId);
                employeeView.ComputerList.Add(empComputer);
            }
            foreach (var item in employee.TrainingPgmEmps)
            {
                employeeView.FuturePrograms = _context.TrainingProgram.Where(t => t.TrainingProgramId == item.TrainingProgramId && t.StartDate > DateTime.Now).Select(t => t).ToList();

                employeeView.AttendedPrograms = _context.TrainingProgram.Where(t => t.TrainingProgramId == item.TrainingProgramId && t.StartDate <= DateTime.Now).Select(t => t).ToList();

                employeeView.NotAttendingPrograms = _context.TrainingProgram.(t => t.TrainingProgramId != item.TrainingProgramId && t.StartDate > DateTime.Now);
            }

            return View(employeeView);
        }

        private object EmployeeDetailViewModel()
        {
            throw new NotImplementedException();
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,FirstName,LastName,DepartmentId,StartDate,Supervisor")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "Name", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,FirstName,LastName,DepartmentId,StartDate,Supervisor")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Departments)
                .SingleOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.EmployeeId == id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }
    }
}
