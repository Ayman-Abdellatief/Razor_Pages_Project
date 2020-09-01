using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Razor_Pages_Project.Models;

namespace Razor_Pages_Project.Services
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Mary", Department = Dept.HR,
                    Email = "mary@pragimtech.com", PhotoPath="Rose.jpg" },
                new Employee() { Id = 2, Name = "John", Department = Dept.IT,
                    Email = "john@pragimtech.com", PhotoPath="Ali.jpg" },
                new Employee() { Id = 3, Name = "Sara", Department = Dept.IT,
                    Email = "sara@pragimtech.com", PhotoPath="Rose.jpg" },
                new Employee() { Id = 4, Name = "David", Department = Dept.Payroll,
                    Email = "david@pragimtech.com" },
            };
        }

        public Employee Add(Employee newEmployee)
        {
            newEmployee.Id = _employeeList.Max(e => e.Id)+1;
            _employeeList.Add(newEmployee);
            return newEmployee;
        }

        public Employee Delete(int Id)
        {
            var EmployeeToDelete = _employeeList.FirstOrDefault(e => e.Id == Id);

            if (EmployeeToDelete != null)
            {
                _employeeList.Remove(EmployeeToDelete);
            }
            return EmployeeToDelete;
        }

        public IEnumerable<DeptHeadCount> EmployeeCountByDepartment(Dept? dept)
        {
            IEnumerable<Employee> query = _employeeList;
            if(dept.HasValue)
            {
                query =query.Where(e => e.Department == dept.Value);
            }
            return query.GroupBy(e => e.Department).Select(g => new DeptHeadCount()
            {
                Department = g.Key.Value,
                Count = g.Count()
            }).ToList();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.SingleOrDefault(e => e.Id == Id);
           }

        public IEnumerable<Employee> Search(string searchTerm)
        {
            if(string.IsNullOrEmpty(searchTerm))
            {
                return _employeeList;
            }
            return _employeeList.Where(e => e.Name.Contains(searchTerm) || e.Email.Contains(searchTerm));
        }

        public Employee Update(Employee updatedEmployee)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == updatedEmployee.Id);

            if(employee != null)
            {
                employee.Name = updatedEmployee.Name;
                employee.Email = updatedEmployee.Email;
                employee.Department = updatedEmployee.Department;
                employee.PhotoPath = updatedEmployee.PhotoPath;
            }

            return employee;
        }
    }
}
