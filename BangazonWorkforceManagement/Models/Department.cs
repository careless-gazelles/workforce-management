using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonWorkforceManagement.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string Name { get; set; }
        public double? Budget { get; set; }
<<<<<<< HEAD
        public object Employee { get; internal set; }
=======
        public ICollection<Employee> Employees { get; set; }
>>>>>>> 9b7a8ee39fb527f44fc42a7ba6a5f835470dad08
    }
}
