using EmployeeManagementAPITest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementAPITest
{
    [TestClass]
    public class EmployeeManagementAPITest
    {
        private static TestContext _testContext;

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            _testContext = testContext;
        }

        [TestInitialize]
        public void MyTestInitialize()
        {
            ApplicationSettings.EmployeeManagementEndpoint = _testContext.Properties["ApiEndpoint"].ToString();
        }

        [TestMethod]
        public async Task HappyPath_GetAllEmployeeAsync()
        {
            try
            {
                _testContext.WriteLine($"Endpoint called: {ApplicationSettings.EmployeeManagementEndpoint}");
                var data = await EmployeeCallerFactory.Instance.GetEmployees().ConfigureAwait(true);

                Assert.IsNotNull(data);
                Assert.AreEqual(3, data.Count, "Employee Count");
                Assert.AreEqual("Amal", data.FirstOrDefault().EmpName, "Employee Name");
                Assert.AreEqual("QA", data.FirstOrDefault().Department, "Employee Department");
                Assert.AreEqual("Amal@fiserv.com", data.FirstOrDefault().Email, "Employee Email");
            }
            catch (Exception ex)
            {
                _testContext.WriteLine(ex.Message);
                _testContext.WriteLine(ex.InnerException.Message);
                Assert.Fail(ex.Message);
            }
        }
    }
}
