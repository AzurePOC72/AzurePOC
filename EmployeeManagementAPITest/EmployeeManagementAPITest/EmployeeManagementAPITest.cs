using EmployeeManagementAPITest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
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
        [TestCategory("Get-Regression")]
        public async Task HappyPath_GetAllEmployeeAsync()
        {
            try
            {
                _testContext.WriteLine($"Endpoint called: {ApplicationSettings.EmployeeManagementEndpoint}");
                var data = await EmployeeCallerFactory.Instance.GetEmployees().ConfigureAwait(true);

                Assert.IsNotNull(data);
                Assert.AreEqual("Amal", data.FirstOrDefault().EmpName, "Employee Name");
                Assert.AreEqual("QA", data.FirstOrDefault().Department, "Employee Department");
                Assert.AreEqual("Amal@fiserv.com", data.FirstOrDefault().Email, "Employee Email");
            }
            catch (Exception ex)
            {
                _testContext.WriteLine(ex.Message);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Get-Regression")]
        public async Task HappyPath_GetEmployeeByID()
        {
            try
            {
                var data = await EmployeeCallerFactory.Instance.GetEmployees(2).ConfigureAwait(true);

                Assert.IsNotNull(data);
                Assert.AreEqual("Murugan", data.EmpName, "Employee Name");
                Assert.AreEqual("QA", data.Department, "Employee Department");
                Assert.AreEqual("Murugan@fiserv.com", data.Email, "Employee Email");
            }
            catch (Exception ex)
            {
                _testContext.WriteLine(ex.Message);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Post-Regression")]
        public async Task HappyPath_PostEmployee()
        {
            try
            {

                EmployeeManagementCaller.Model.Employee employee = new EmployeeManagementCaller.Model.Employee
                {
                    EmpName = "User1",
                    Department = "Finance",
                    Email = "User1@fiserv.com"
                };
                var postrspdata = await EmployeeCallerFactory.Instance.SaveEmployee(employee);
                var data = await EmployeeCallerFactory.Instance.GetEmployees(postrspdata.EmpId).ConfigureAwait(true);

                Assert.IsNotNull(data);
                Assert.AreEqual(postrspdata.EmpName, data.EmpName, "Employee Name");
                Assert.AreEqual(postrspdata.Department, data.Department, "Employee Department");
                Assert.AreEqual(postrspdata.Email, data.Email, "Employee Email");
            }
            catch (Exception ex)
            {
                _testContext.WriteLine(ex.Message);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Put-Regression")]
        public async Task HappyPath_UpdateEmployee()
        {
            try
            {
                EmployeeManagementCaller.Model.Employee employee = new EmployeeManagementCaller.Model.Employee
                {
                    EmpName = "User2",
                    Department = "Hr",
                    Email = "User1@fiserv.com"
                };
                var postrspdata = await EmployeeCallerFactory.Instance.SaveEmployee(employee);

                var data = await EmployeeCallerFactory.Instance.GetEmployees(postrspdata.EmpId).ConfigureAwait(true);

                Assert.IsNotNull(data);
                Assert.AreEqual(postrspdata.EmpName, data.EmpName, "Employee Name");
                Assert.AreEqual(postrspdata.Department, data.Department, "Employee Department");
                Assert.AreEqual(postrspdata.Email, data.Email, "Employee Email");

                EmployeeManagementCaller.Model.Employee employee_new = new EmployeeManagementCaller.Model.Employee
                {
                    EmpId = postrspdata.EmpId,
                    EmpName = "User3",
                    Department = "ETG",
                    Email = "User1@fiserv.com"
                };
                var Updaterspdata = await EmployeeCallerFactory.Instance.UpdateEmployee(postrspdata.EmpId, employee_new);

                var data2 = await EmployeeCallerFactory.Instance.GetEmployees(postrspdata.EmpId).ConfigureAwait(true);
                Assert.IsNotNull(data2);
                Assert.AreEqual(employee_new.EmpName, data2.EmpName, "Employee Name");
                Assert.AreEqual(employee_new.Department, data2.Department, "Employee Department");
                Assert.AreEqual(employee_new.Email, data2.Email, "Employee Email");
            }
            catch (Exception ex)
            {
                _testContext.WriteLine(ex.Message);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("Delete-Regression")]
        public async Task HappyPath_DeleteEmployee()
        {
            try
            {
                EmployeeManagementCaller.Model.Employee employee = new EmployeeManagementCaller.Model.Employee
                {
                    EmpName = "User4",
                    Department = "Hr",
                    Email = "User1@fiserv.com"
                };
                var postrspdata = await EmployeeCallerFactory.Instance.SaveEmployee(employee);

                var data = await EmployeeCallerFactory.Instance.GetEmployees(postrspdata.EmpId).ConfigureAwait(true);

                Assert.IsNotNull(data);
                Assert.AreEqual(postrspdata.EmpName, data.EmpName, "Employee Name");
                Assert.AreEqual(postrspdata.Department, data.Department, "Employee Department");
                Assert.AreEqual(postrspdata.Email, data.Email, "Employee Email");

                var deleteData = await EmployeeCallerFactory.Instance.DeleteEmployee(postrspdata.EmpId);

                var data2 = await EmployeeCallerFactory.Instance.GetEmployees(postrspdata.EmpId).ConfigureAwait(true);
                Assert.IsNull(data2);
            }
            catch (Exception ex)
            {
                _testContext.WriteLine(ex.Message);
                Assert.Fail(ex.Message);
            }
        }

    }
}
