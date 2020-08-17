using System;
using System.Collections.Generic;
using Razor_Pages_Project.Models;

namespace Razor_Pages_Project.Services
{
    public interface IEmployeeRepository
    {
    IEnumerable<Employee> GetAllEmployees ();
        Employee GetEmployee(int Id);
    }
}
