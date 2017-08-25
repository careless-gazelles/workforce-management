using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonWorkforceManagement.Models.ViewModels
{
    public class EmployeeEditViewModel
    {
        public List<Computer> Computers { get; set; }
        public int ComputerId { get; set; }
        public Employee Employee { get; set; }
        public EmployeeComputer EmployeeComputer { get; set; }

    }
}
