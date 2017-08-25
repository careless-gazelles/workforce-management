using BangazonWorkforceManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonWorkforceManagement.ViewModels
{
    public class TrainingProgramDetailViewModel
    {
        public TrainingProgram TrainingProgram { get; set; }
        public List<Employee> EmployeesAttending { get; set; }
    }
}