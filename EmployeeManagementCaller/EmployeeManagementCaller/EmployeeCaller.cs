using EmployeeManagementCaller.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementCaller
{
    public partial class EmployeeManagementCaller
    {
        public async Task<List<Employee>> GetEmployees()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "api/Employee"));
            return await GetAsync<List<Employee>>(requestUrl);
        }

        public async Task<Employee> GetEmployees(int Id)
        {
            string queryString = $"/{Id}";
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                $"api/Employee{queryString}"));
            return await GetAsync<Employee>(requestUrl);
        }

        public async Task<Employee> SaveEmployee(Employee model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "api/Employee"));
            return await PostAsync<Employee>(requestUrl, model);
        }

        public async Task<HttpResponseMessage> UpdateEmployee(int Id, Employee model)
        {
            string queryString = $"/{Id}";
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                $"api/Employee{queryString}"));
            return await PutAsync<Employee>(requestUrl, model);
        }

        public async Task<HttpResponseMessage> DeleteEmployee(int Id)
        {
            string queryString = $"/{Id}";
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                $"api/Employee{queryString}"));
            return await DeleteAsync(requestUrl);
        }
    }
}
