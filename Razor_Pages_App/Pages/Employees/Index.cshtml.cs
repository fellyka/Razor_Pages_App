using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Razor_Pages_App.Models;
using Razor_Pages_App.Services;

using System.Collections;
using System.Collections.Generic;

namespace Razor_Pages_App.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;

        public IEnumerable<Employee> Employees { get; set; }

        public IndexModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void OnGet()
        {
            Employees = _employeeRepository.GetEmployeeList();
        }
    }
}
