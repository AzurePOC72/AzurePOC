using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmployeeManagement.Controllers;
using EmployeeManagement.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementTest
{
    [TestClass]
    public class EmployeeManagementTest
    {
        private MockEmployeeRepository _mockEmployeeRepository; 

        [TestInitialize]
        public void MyTestIni()
        {
            _mockEmployeeRepository = new MockEmployeeRepository();
        }

        [TestMethod]
        public void HappyPath_GetAllEmployeesAsync()
        {
            ActionContext actionContext = new ActionContext();
            EmployeeController employeeController = new EmployeeController(_mockEmployeeRepository);
            try
            {
                var employeeRsp = employeeController.Get();
                
                Assert.IsNotNull(employeeRsp);
                Assert.AreEqual(6, employeeRsp?.Count());
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void HappyPath_GetEmployeesbyID()
        {

            EmployeeController employeeController = new EmployeeController(_mockEmployeeRepository);
            try
            {
                Employee employeeRsp = employeeController.Get(1);
                Assert.IsNotNull(employeeRsp);
                Assert.AreEqual(1, employeeRsp.EmpId);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
