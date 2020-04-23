using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees;

        public MockEmployeeRepository()
        {
            _employees = new List<Employee>()
            {
                new Employee{EmpId=1,EmpName="Amal",Department="QA",Email="Amal@fiserv.com" },
                new Employee{EmpId=2,EmpName="Murugan",Department="QA",Email="Murugan@fiserv.com" },
                new Employee{EmpId=3,EmpName="Dinesh",Department="QA",Email="Dinesh@fiserv.com" }
            };
        }


        public Employee Add(Employee employee)
        {
            employee.EmpId = _employees.Max(x => x.EmpId) + 1;
            _employees.Add(employee);
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = _employees.FirstOrDefault(x => x.EmpId == Id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public Employee GetEmployeeByID(int Id)
        {
            return _employees.FirstOrDefault(x => x.EmpId == Id);
        }

        public Employee UpdateEmployee(Employee employeeChanges)
        {
            Employee employee = _employees.FirstOrDefault(x => x.EmpId == employeeChanges.EmpId);
            if (employee != null)
            {
                employee.EmpName = employeeChanges.EmpName;
                employee.Department = employeeChanges.Department;
                employee.Email = employeeChanges.Email;
            }
            return employee;
        }
    }
}
