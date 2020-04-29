using EmployeeManagementAPITest.Models;
using System;
using System.Threading;
namespace EmployeeManagementAPITest
{
    internal static class EmployeeCallerFactory
    {
        private static Uri apiUri;

        private static Lazy<EmployeeManagementCaller.EmployeeManagementCaller> restCaller = new Lazy<EmployeeManagementCaller.EmployeeManagementCaller>(
            () => new EmployeeManagementCaller.EmployeeManagementCaller(apiUri),
            LazyThreadSafetyMode.ExecutionAndPublication);

        static EmployeeCallerFactory()
        {
            apiUri = new Uri(ApplicationSettings.EmployeeManagementEndpoint);
        }

        public static EmployeeManagementCaller.EmployeeManagementCaller Instance
        {
            get
            {
                return restCaller.Value;
            }
        }


    }
}
