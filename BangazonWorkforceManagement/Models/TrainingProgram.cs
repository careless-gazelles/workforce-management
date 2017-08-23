using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonWorkforceManagement.Models
{
    public class TrainingProgram
    {
        [Key]
        public int TrainingProgramId { get; set; }
        [Required]
        public string Name { get; set;}
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        public int MaxAttendees { get; set; }

        public ICollection <TrainingPgmEmp> TrainingProgramEmps { get; set; }

    }
}
