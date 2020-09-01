using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Razor_Pages_Project.Models;

namespace Razor_Pages_Project.Services
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public SqlEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Employee Add(Employee newEmployee)
        {
            context.Database.ExecuteSqlRaw("spInsertEmployee {0}, {1}, {2}, {3}",
                                 newEmployee.Name,
                                 newEmployee.Email,
                                 newEmployee.PhotoPath,
                                 newEmployee.Department);
            return newEmployee;
       
    }

        public Employee Delete(int Id)
        {
            Employee employee= context.Employees.Find(Id);
            if(employee !=null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
                return employee;
            }
            return employee;
        }

        public IEnumerable<DeptHeadCount> EmployeeCountByDepartment(Dept? dept)
        {
            IEnumerable<Employee> query = context.Employees;
            if (dept.HasValue)
            {
                query = query.Where(e => e.Department == dept.Value);
            }
            return query.GroupBy(e => e.Department).Select(g => new DeptHeadCount()
            {
                Department = g.Key.Value,
                Count = g.Count()
            }).ToList();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
          return   context.Employees.FromSqlRaw<Employee>("Select * from Employees").ToList(); 
        }

        public Employee GetEmployee(int Id)
        {
            return context.Employees.FromSqlRaw<Employee>("sp_Get_Employee_By_ID {0}", Id).ToList().FirstOrDefault();
        }

        public IEnumerable<Employee> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return context.Employees;
            }
            return context.Employees.Where(e => e.Name.Contains(searchTerm) || e.Email.Contains(searchTerm));
        }

        public Employee Update(Employee updatedEmployee)
        {
            var employee = context.Employees.Attach(updatedEmployee);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedEmployee;
        }
    }
}
