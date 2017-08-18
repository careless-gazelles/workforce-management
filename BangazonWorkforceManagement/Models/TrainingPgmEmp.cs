using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonWorkforceManagement.Models
{
    public class TrainingPgmEmp
    {
        [Key]
        public int TrainingPgmEmpId { get; set;}
        [Required]
        public int TrainingProgramId { get; set;}

        public TrainingProgram TrainingProgram { get; set;}
        
        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set;}


    }
}
