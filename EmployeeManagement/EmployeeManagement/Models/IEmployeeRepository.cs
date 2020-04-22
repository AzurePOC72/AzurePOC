using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeByID(int Id);
        Employee Add(Employee employee);
        Employee UpdateEmployee(Employee employeeChanges);
        Employee Delete(int Id);

    }
}
