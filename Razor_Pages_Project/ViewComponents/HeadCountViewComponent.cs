using Microsoft.AspNetCore.Mvc;
using Razor_Pages_Project.Models;
using Razor_Pages_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_Pages_Project.ViewComponents
{
    public class HeadCountViewComponent : ViewComponent
    {
        private readonly IEmployeeRepository employeeRepository;

        public HeadCountViewComponent(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public IViewComponentResult Invoke(Dept? departmentName =null)
        {
            var result = employeeRepository.EmployeeCountByDepartment(departmentName);
            return View(result);
        }
    }
}
