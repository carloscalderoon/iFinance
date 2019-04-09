using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using iFinance.Controllers;
using Moq;
using iFinance.Models;
using System.Linq;
using System.Collections.Generic;

namespace iFinance.Tests.Controllers
{
    [TestClass]
    public class MonthlyIncomesTest
    {
        //Moq Data
        MonthlyIncomesController controller;
        List<MonthlyIncome> monthlyIncomes;
        Mock<IMockMonthlyIncomes> mock;

        [TestInitialize]
        public void TestInitialize()
        {
            //create mock data
            monthlyIncomes = new List<MonthlyIncome>
            {
                new MonthlyIncome { Amount = 100, Origin = "Fake One", IncomeID = 1990},
                new MonthlyIncome { Amount = 100, Origin = "Fake Two", IncomeID = 1991},
                new MonthlyIncome { Amount = 100, Origin = "Fake Three", IncomeID = 1992}
            };

            //set up & populate mock object into controller
            mock = new Mock<IMockMonthlyIncomes>();
            mock.Setup(c => c.MonthlyIncomes).Returns(monthlyIncomes.AsQueryable());

            //initialize controller and inject mock object
            controller = new MonthlyIncomesController(mock.Object);
        }


        [TestMethod]
        public void IndexViewLoads()
        {
            //Arrange
            // Done in TestInitialize
            //Act
            ViewResult result = controller.Index() as ViewResult;
            //Assert
            Assert.AreEqual("Index:", result.ViewName);
        }
    }
}
