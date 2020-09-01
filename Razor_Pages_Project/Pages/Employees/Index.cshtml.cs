using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Pages_Project.Models;
using Razor_Pages_Project.Services;

namespace Razor_Pages_Project.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeRepository employeeRepository;

        public IEnumerable<Employee> Employees { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public IndexModel(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public void OnGet()
        {
            Employees = employeeRepository.Search(SearchTerm);

        }
    }
}