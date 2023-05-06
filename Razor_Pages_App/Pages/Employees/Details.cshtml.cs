using Microsoft.AspNetCore.Mvc.RazorPages;

using Razor_Pages_App.Models;
using Razor_Pages_App.Services;

namespace Razor_Pages_App.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        public readonly IEmployeeRepository _employeeRepository;

        public DetailsModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee Employee { get; private set; }

        public void OnGet(int? id)
        {
            Employee  = _employeeRepository.GetEmployee(id ?? 1 );
        }
    }
}