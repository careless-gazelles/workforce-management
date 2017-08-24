Select t.Name, t.StartDate, t.EndDate
From TrainingProgram t
Join TrainingPgmEmp tp
On tp.TrainingProgramId = t.TrainingProgramId
Join Employee e
On e.EmployeeId = tp.EmployeeId
Where t.StartDate >= GETDATE() 
And e.EmployeeId = 2

select * from TrainingProgram
select * from TrainingPgmEmp

insert into TrainingProgram (EndDate, MaxAttendees, [Name], StartDate) values (GETDATE(), 40, 'Basket Weaving', GETDATE())

select x.Program, x.Employee from (
Select t.Name 'Program', t.StartDate, t.EndDate, tp.EmployeeId, e.EmployeeId 'Employee'
From TrainingProgram t
Left Join TrainingPgmEmp tp
On tp.TrainingProgramId = t.TrainingProgramId
left Join Employee e
On e.EmployeeId = tp.EmployeeId
where e.EmployeeId = 2 or e.EmployeeId is NULL
and t.StartDate >= GETDATE() 
)x  where x.Employee is NULL
