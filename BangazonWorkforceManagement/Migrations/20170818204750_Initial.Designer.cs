using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BangazonWorkforceManagement.Models;

namespace BangazonWorkforceManagement.Migrations
{
    [DbContext(typeof(BangazonWorkforceManagementContext))]
    [Migration("20170818204750_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BangazonWorkforceManagement.Models.Computer", b =>
                {
                    b.Property<int>("ComputerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Make")
                        .IsRequired();

                    b.Property<string>("Manufacturer")
                        .IsRequired();

                    b.Property<DateTime>("PurchaseDate");

                    b.HasKey("ComputerId");

                    b.ToTable("Computer");
                });

            modelBuilder.Entity("BangazonWorkforceManagement.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<double?>("Budget");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("BangazonWorkforceManagement.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentId");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.Property<bool>("Supervisor");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("BangazonWorkforceManagement.Models.EmployeeComputer", b =>
                {
                    b.Property<int>("EmployeeComputerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ComputerId");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("EmployeeComputerId");

                    b.HasIndex("ComputerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeComputer");
                });

            modelBuilder.Entity("BangazonWorkforceManagement.Models.TrainingPgmEmp", b =>
                {
                    b.Property<int>("TrainingPgmEmpId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<int>("TrainingProgramId");

                    b.HasKey("TrainingPgmEmpId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TrainingProgramId");

                    b.ToTable("TrainingPgmEmp");
                });

            modelBuilder.Entity("BangazonWorkforceManagement.Models.TrainingProgram", b =>
                {
                    b.Property<int>("TrainingProgramId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("MaxAttendees");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.HasKey("TrainingProgramId");

                    b.ToTable("TrainingProgram");
                });

            modelBuilder.Entity("BangazonWorkforceManagement.Models.Employee", b =>
                {
                    b.HasOne("BangazonWorkforceManagement.Models.Department", "Departments")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BangazonWorkforceManagement.Models.EmployeeComputer", b =>
                {
                    b.HasOne("BangazonWorkforceManagement.Models.Computer", "Computer")
                        .WithMany()
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BangazonWorkforceManagement.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BangazonWorkforceManagement.Models.TrainingPgmEmp", b =>
                {
                    b.HasOne("BangazonWorkforceManagement.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BangazonWorkforceManagement.Models.TrainingProgram", "TrainingProgram")
                        .WithMany()
                        .HasForeignKey("TrainingProgramId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
