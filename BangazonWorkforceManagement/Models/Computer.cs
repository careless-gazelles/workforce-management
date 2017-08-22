using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BangazonWorkforceManagement.Models
{
    public class Computer
    {
        [Key]
        public int ComputerId { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        public ICollection<EmployeeComputer> EmployeeComputers;
    }
}
