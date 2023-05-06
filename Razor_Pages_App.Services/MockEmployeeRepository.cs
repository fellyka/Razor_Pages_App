using Razor_Pages_App.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace Razor_Pages_App.Services
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            { 
              new Employee(){ Id = 1, Name = "Felly KANYIKI", Email = "fellyka@sollers.co.za", Department = Dept.HR},
              new Employee(){ Id = 1, Name = "Rosette KANYIKI", Email = "rosetteka@sollers.co.za", Department = Dept.HR, PhotoPath = "EmployeeFemale1.jpg"},
              new Employee(){ Id = 1, Name = "Jovial KANYIKI", Email = "jovialka@sollers.co.za", Department = Dept.HR, PhotoPath = "EmployeeMale1.jpg"},
              new Employee(){ Id = 1, Name = "Kany KANYIKI", Email = "kanyka@sollers.co.za", Department = Dept.HR, PhotoPath = "EmployeeMale2.png" }
            };
        }

        IEnumerable<Employee> IEmployeeRepository.GetEmployeeList()
        {
            return _employeeList;
        }
    }
}
