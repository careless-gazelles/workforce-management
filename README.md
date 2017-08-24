# Bangazon
## Workforce Management System (WMS)
This web app allows a user to view, edit, and add information for employees, departments, computers, and training programs in the Bangazon company workforce.

## Requirements for using the WMS

### Visual Studio
Install [Visual Studio](https://www.visualstudio.com/downloads/).

Run the installer that gets downloaded, and on the first window that appears, click "Individual Components" at the top of the screen. Make sure the following items are checked:
 * .NET Core runtime
 * ASP.NET Web development tools
 * Nuget package manager
 * SQL Server LocalDB
 * Entity Framework 6
Click `Install` at the bottom.

### Git Bash
Install [Git Bash](https://git-scm.com/downloads). This will allow you to access the "terminal" within the Windows environment without having to use PowerShell.

## How to Use the WMS
From your Git Bash terminal:

```
mkdir [name of directory]
cd [name of directory]
git clone htthttps://github.com/careless-gazelles/workforce-management.git
```

Open the Solution file within Visual Studio (BangazonWorkforceManagement.sln).  
Click the Tools tab, then select the NuGet Package Manager.
From the Package Manager Console terminal type the following:

``Update-Database``

Run the web app by clicking the green arrow at the top of Visual Studio's menu. Your browser window will open and display the web application.

## How to Interact with the WMS Web App
### Homepage
The homepage displays a default view without any Bangazon-specific information. 
The navigation bar displays the following clickable links: Departments, Employees, Computers, Training Programs


### Departments
The Departments page lists all departments as well as their respective budgets.
The user can click "Create New" to add a new department, edit an existing department, see department details, or delete a department from the system.

After clicking "Details" for an individual department, the user will view all employees in that department.

### Employees
The Employees page lists each employee's first and last name as well as the assigned department. 
The user can edit employee information or delete an individual employee from this page.

### Computers
The Computers page lists all computers in the system. 
The user can click "Create New" to add a new computer, edit an existing computer, see computer details, or delete a computer from the system.

After clicking "Details" for an individual computer, user will view the manufacturer, make, and purchase date of the selected computer and have the option to edit that information.

### Training Programs
The Training Programs page lists each training program's name, start date, end date, and max attendees. 
The user can edit training program information, view details, or delete an individual training program from this page.

After clicking "Details" for an individual training program, user will view the name, start date, end date, and max attendeeds for the selected training program.

