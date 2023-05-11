using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Razor_Pages_App.Models;
using Razor_Pages_App.Services;

namespace Razor_Pages_App.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EditModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public Employee Employee {get;set;}

        public IActionResult OnGet(int id)//Model binding will automatically bind the id with the route parameter
        {
          Employee = _employeeRepository.GetEmployee(id);

          if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(Employee employee)
        {
            Employee = _employeeRepository.Update(employee);
            return RedirectToPage("Index");
        }
   
    }
}
