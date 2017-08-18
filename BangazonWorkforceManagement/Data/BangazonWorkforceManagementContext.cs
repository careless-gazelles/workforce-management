using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BangazonWorkforceManagement.Models;

namespace BangazonWorkforceManagement.Models
{
    public class BangazonWorkforceManagementContext : DbContext
    {
        public BangazonWorkforceManagementContext (DbContextOptions<BangazonWorkforceManagementContext> options)
            : base(options)
        {
        }

        public DbSet<BangazonWorkforceManagement.Models.Department> Department { get; set; }

        public DbSet<BangazonWorkforceManagement.Models.Employee> Employee { get; set; }

        public DbSet<BangazonWorkforceManagement.Models.TrainingProgram> TrainingProgram { get; set; }

        public DbSet<BangazonWorkforceManagement.Models.TrainingPgmEmp> TrainingPgmEmp { get; set; }
    }
}
