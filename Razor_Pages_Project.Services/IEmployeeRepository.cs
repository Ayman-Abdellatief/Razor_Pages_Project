using System;
using System.Collections.Generic;
using Razor_Pages_Project.Models;

namespace Razor_Pages_Project.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Search(string searchTerm);
        IEnumerable<Employee> GetAllEmployees ();
        Employee GetEmployee(int Id);

        Employee Update(Employee updatedEmployee);
        Employee Add(Employee newEmployee);

        Employee Delete(int Id);

        IEnumerable<DeptHeadCount> EmployeeCountByDepartment(Dept? dept);
        


    }
}
