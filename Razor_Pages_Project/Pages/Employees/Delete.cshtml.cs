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
    public class DeleteModel : PageModel
    {
        private readonly IEmployeeRepository employeeRepository;

        public DeleteModel(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [BindProperty]
        public Employee Employee { get; set; }
        public IActionResult OnGet(int id)
        {
            Employee = employeeRepository.GetEmployee(id);

            if(Employee == null)
            {
                return RedirectToPage("/NotFound");
            }
            else
            {
                return Page();
           }

        }

        public IActionResult OnPost()
        {
          Employee  DeletedEmployee = employeeRepository.Delete(Employee.Id);

            if(DeletedEmployee == null)
            {
                return RedirectToPage("/NotFound");
            }
           
                return RedirectToPage("Index");
           

        }
    }
}