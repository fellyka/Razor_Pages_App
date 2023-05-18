using Razor_Pages_App.Models;
using System.Linq;
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
              new Employee(){ Id = 2, Name = "Rosette KANYIKI", Email = "rosetteka@sollers.co.za", Department = Dept.HR, PhotoPath = "EmployeeFemale1.jpg"},
              new Employee(){ Id = 3, Name = "Jovial KANYIKI", Email = "jovialka@sollers.co.za", Department = Dept.HR, PhotoPath = "EmployeeMale1.jpg"},
              new Employee(){ Id = 4, Name = "Kany KANYIKI", Email = "kanyka@sollers.co.za", Department = Dept.HR, PhotoPath = "EmployeeMale2.png" }
            };
        }

        public Employee GetEmployee(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == id);
            return employee;
        }

        public Employee Update(Employee updatedEmployee)
        {
            Employee employee = _employeeList.FirstOrDefault(e=> e.Id == updatedEmployee.Id);

            if(employee != null)
            {
                employee.Name = updatedEmployee.Name;
                employee.Email = updatedEmployee.Email;
                employee.Department = updatedEmployee.Department;
                employee.PhotoPath = updatedEmployee.PhotoPath;
            }

            return employee;
        }

        IEnumerable<Employee> IEmployeeRepository.GetEmployeeList()
        {
            return _employeeList;
        }
    }
}
