using System; 
using System.Linq; 
using Microsoft.EntityFrameworkCore; 
using Microsoft.Extensions.DependencyInjection; 
using BangazonWorkforceManagement.Models; 
using System.Threading.Tasks; 
 
namespace BangazonWorkForceManagement.Data //Worked on by Ollie, August 18th, 2017
{ 
    public static class DbInitializer 
    { 
        public static void Initialize(IServiceProvider serviceProvider) 
        { 
            using (var context = new BangazonContext(serviceProvider.GetRequiredService<DbContextOptions<BangazonContext>>())) 
            { 
                if(context.Department.Any()) 
                { 
                    return; //db is already seeded
                }

                var department = new Department []
                {
                    new Department()
                    {
                        Name = "Hitta",
                        Budget = 100000
                    },
                    new Department()
                    {
                        Name = "Ladies Hit Squad",
                        Budget = 58949294
                    }
                };
                foreach(Department d in department)
                {
                    context.Department.Add(d);
                }
                context.SaveChanges();

                var employee = new Employee[]
                {
                    new Employee()
                    {
                        FirstName = "Tay",
                        LastName = "K-47",
                        DepartmentId = 1,
                    },
                    new Employee()
                    {
                        FirstName = "Nessly",
                        LastName = "24K",
                        DepartmentId = 2
                    },
                    new Employee()
                    {
                        FirstName = "Young",
                        LastName = "Chop",
                        DepartmentId = 1
                    },
                    new Employee()
                    {
                        FirstName = "Eli",
                        LastName = "Sostre",
                        DepartmentId = 2
                    }                  
                };
                foreach(Employee e in employee)
                {
                    context.Employee.Add(e);
                }
                context.SaveChanges();

                var trainingProgram = new TrainingProgram[]
                {
                    new TrainingProgram()
                    {
                        Name = "Halloween Scare Tactics",
                        StartDate = 10/12/2017,
                        EndDate = 10/26/2017,
                        MaxAttendees = 27
                    },
                    new TrainingProgram()
                    {
                        Name = "Thot Avoidance 101",
                        StartDate = 7/12/2017,
                        EndDate = 7/15/2017,
                        MaxAttendees = 99
                    },
                    new TrainingProgram()
                    {
                        Name = "Pop Xans Like a Pro",
                        StartDate = 9/12/2017,
                        EndDate = 10/12/2017,
                        MaxAttendees = 27
                    }
                };
                foreach (TrainingProgram t in trainingProgram)
                {
                    context.TraingProgram.Add(t);
                }
                context.SaveChanges();

                var trainingProgramEmp = new TrainingPgmEmp[]
                {
                    new TrainingProgramEmp()
                    {
                        EmployeeId = 1,
                        TrainingProgramId = 1
                    },
                    new TrainingProgramEmp()
                    {
                        EmployeeId = 1,
                        TrainingProgramId = 2
                    },
                    new TrainingProgramEmp()
                    {
                        EmployeeId = 1,
                        TrainingProgramId = 3
                    },
                    new TrainingProgramEmp()
                    {
                        EmployeeId = 2,
                        TrainingProgramId = 2
                    },
                    new TrainingProgramEmp()
                    {
                        EmployeeId = 2,
                        TrainingProgramId = 3
                    },
                    new TrainingProgramEmp()
                    {
                        EmployeeId = 3,
                        TrainingProgramId = 3
                    }
                };
                foreach(TrainingProgramEmp z in trainingProgramEmp)
                {
                    context.TrainingProgramEmp.Add(z);
                }
                context.SaveChanges();
            }
        }
    }
}