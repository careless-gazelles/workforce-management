using BangazonWorkforceManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonWorkforceManagement.ViewModels
{
    public class DepartmentDetailViewModel
    {
        public Department Department { get; set; }
        public List<Employee> EmployeeList { get; set; } = new List<Employee>();
    }
}
