using System; 
using System.Linq; 
using Microsoft.EntityFrameworkCore; 
using Microsoft.Extensions.DependencyInjection; 
using BangazonWorkforceManagement.Models; 
using System.Threading.Tasks;
 
namespace BangazonWorkforceManagement.Data //Worked on by Ollie, August 18th, 2017
{ 
    public static class DBInitializer 
    { 
        public static void Initialize(IServiceProvider serviceProvider) 
        { 
            using (var context = new BangazonWorkforceManagementContext(serviceProvider.GetRequiredService<DbContextOptions<BangazonWorkforceManagementContext>>())) 
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
                        StartDate = new DateTime(2017, 10, 12),
                        EndDate = new DateTime(2017, 10, 26),
                        MaxAttendees = 27
                    },
                    new TrainingProgram()
                    {
                        Name = "Thot Avoidance 101",
                        StartDate = new DateTime(2017, 7, 12),
                        EndDate = new DateTime(2017, 7, 15),
                        MaxAttendees = 99
                    },
                    new TrainingProgram()
                    {
                        Name = "Pop Xans Like a Pro",
                        StartDate = new DateTime(2017, 9, 12),
                        EndDate = new DateTime(2017, 12, 9),
                        MaxAttendees = 42
                    }
                };
                foreach (TrainingProgram t in trainingProgram)
                {
                    context.TrainingProgram.Add(t);
                }
                context.SaveChanges();

                var trainingProgramEmp = new TrainingPgmEmp[]
                {
                    new TrainingPgmEmp()
                    {
                        EmployeeId = 1,
                        TrainingProgramId = 1
                    },
                    new TrainingPgmEmp()
                    {
                        EmployeeId = 1,
                        TrainingProgramId = 2
                    },
                    new TrainingPgmEmp()
                    {
                        EmployeeId = 1,
                        TrainingProgramId = 3
                    },
                    new TrainingPgmEmp()
                    {
                        EmployeeId = 2,
                        TrainingProgramId = 2
                    },
                    new TrainingPgmEmp()
                    {
                        EmployeeId = 2,
                        TrainingProgramId = 3
                    },
                    new TrainingPgmEmp()
                    {
                        EmployeeId = 3,
                        TrainingProgramId = 3
                    }
                };
                foreach(TrainingPgmEmp z in trainingProgramEmp)
                {
                    context.TrainingPgmEmp.Add(z);
                }
                context.SaveChanges();

                var computer = new Computer[]
                {
                    new Computer()
                    {
                        Manufacturer = "Apple",
                        Make = "MacBook Pro",
                        PurchaseDate = new DateTime(2017, 04, 20)
                    },
                    new Computer()
                    {
                        Manufacturer = "Dell",
                        Make = "Inspiron",
                        PurchaseDate = new DateTime(2017, 02, 8)
                    },
                    new Computer()
                    {
                        Manufacturer = "Lenovo",
                        Make = "Yoga Pro 3",
                        PurchaseDate = new DateTime(2017, 07, 10)
                    },
                    new Computer()
                    {
                        Manufacturer = "Toshiba",
                        Make = "Whatever",
                        PurchaseDate = new DateTime(2017, 08, 20)
                    }
                };
                foreach(Computer c in computer)
                {
                    context.Computer.Add(c);
                }
                context.SaveChanges();

                var employeeComputer = new EmployeeComputer[]
                {
                    new EmployeeComputer()
                    {
                        EmployeeId = 1,
                        ComputerId = 1
                    },
                    new EmployeeComputer()
                    {
                        EmployeeId = 2,
                        ComputerId = 2
                    },
                    new EmployeeComputer()
                    {
                        EmployeeId = 3,
                        ComputerId = 3
                    }
                };
                foreach (EmployeeComputer ec in employeeComputer)
                {
                    context.EmployeeComputer.Add(ec);
                }
                context.SaveChanges();
            }
        }
    }
}