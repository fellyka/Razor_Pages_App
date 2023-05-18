using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Razor_Pages_App.Models;
using Razor_Pages_App.Services;

using System;
using System.IO;

namespace Razor_Pages_App.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepository = employeeRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public Employee Employee {get;set;}

        [BindProperty]
        public IFormFile Photo { get; set; }

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
            if(Photo != null)
            {
                if(employee.PhotoPath != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", employee.PhotoPath);
                    System.IO.File.Delete(filePath);
                }
                employee.PhotoPath = ProcessUploadedFile();
            }
            Employee = _employeeRepository.Update(employee);
            return RedirectToPage("Index");
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var filseStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(filseStream);
                }
            }

            return uniqueFileName;
        }
   
    }
}
