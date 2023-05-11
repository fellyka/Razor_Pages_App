using Razor_Pages_App.Models;
using System.Collections.Generic;

namespace Razor_Pages_App.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployeeList();
        Employee GetEmployee(int id);
        Employee Update(Employee updatedEmployee);

    }
}
