using System;
using System.Linq;
using EmployeeManagementAPITest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void HappyPath_GetAllEmployee()
        {
            try
            {
                var data = EmployeeCallerFactory.Instance.GetEmployees();

                Assert.IsNotNull(data);
                Assert.AreEqual("Amal", data.Result.FirstOrDefault().EmpName);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
