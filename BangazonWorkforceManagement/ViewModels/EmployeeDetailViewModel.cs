using BangazonWorkforceManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonWorkforceManagement.ViewModels
{
    public class EmployeeDetailViewModel
    {
        public Employee Employee { get; set; }
        public List<Computer> ComputerList { get; set; } = new List<Computer>();
        public List<TrainingProgram> FuturePrograms { get; set; } = new List<TrainingProgram>();
        public List<TrainingProgram> AttendedPrograms { get; set; } = new List<TrainingProgram>();
        public List<TrainingProgram> NotAttendingPrograms { get; set; } = new List<TrainingProgram>();
    }
}
