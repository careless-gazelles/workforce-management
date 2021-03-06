using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BangazonWorkforceManagement.Models;

namespace BangazonWorkforceManagement.Controllers
/**
* Class: ComputerController
* Purpose: The ComputerController class is used to interact with the Computer table in the SQL database.
* Author: Built through scaffolding, Adam worked on GET: Computers/Delete/5
*/
{
    public class ComputersController : Controller
    {
        private readonly BangazonWorkforceManagementContext _context;

        public ComputersController(BangazonWorkforceManagementContext context)
        {
            _context = context;    
        }

        // GET: Computers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Computer.ToListAsync());
        }

        // GET: Computers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computer = await _context.Computer
                .SingleOrDefaultAsync(m => m.ComputerId == id);
            if (computer == null)
            {
                return NotFound();
            }

            return View(computer);
        }

        // GET: Computers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Computers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComputerId,Manufacturer,Make,PurchaseDate")] Computer computer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(computer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(computer);
        }

        // GET: Computers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computer = await _context.Computer.SingleOrDefaultAsync(m => m.ComputerId == id);
            if (computer == null)
            {
                return NotFound();
            }
            return View(computer);
        }

        // POST: Computers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComputerId,Manufacturer,Make,PurchaseDate")] Computer computer)
        {
            if (id != computer.ComputerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(computer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComputerExists(computer.ComputerId))
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
            return View(computer);
        }

        // GET: Computers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // get ComputerId from Computer
            var computer = await _context.Computer.SingleOrDefaultAsync(m => m.ComputerId == id);
            // get ComputerId from EmployeeComputer
            var employeeComp = await _context.EmployeeComputer.FirstOrDefaultAsync(m => m.ComputerId == id);

            // employeeComp will not be null if it has been assigned to an employee
            if (employeeComp != null)
            {
                //Assigned this in order to use an if/else statment in Computers/Delete.cshtml
                computer.Make = "Cannot delete";
            }

            return View(computer);
        }

        // POST: Computers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var computer = await _context.Computer.SingleOrDefaultAsync(m => m.ComputerId == id);
            _context.Computer.Remove(computer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ComputerExists(int id)
        {
            return _context.Computer.Any(e => e.ComputerId == id);
        }
    }
}
