using EmercomDisp.BLL.Providers;
using EmercomDisp.Model.Models;
using EmercomDisp.Web.Controllers;
using EmercomDisp.Web.Models.Calls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EmercomDisp.Web.Tests
{
    [TestClass]
    public class SearchTests
    {
        private CallListController _controller;
        private Mock<ICallProvider> _callProvider;
        private List<Call> _calls = new List<Call>()
            {
                new Call()
                {
                    Id = 1,
                    Address = "testAddress1",
                    Reason = "testReason1",
                    Category = "Неотложный",
                    CallTime = new DateTime(2017, 12, 20, 18, 30, 00),
                    IncidentCause = "testCause1",
                    IncidentDescription = "testDescription1",
                    IsActive = false
                },
                new Call()
                {
                    Id = 2,
                    Address = "testAddress2",
                    Reason = "testReason2",
                    Category = "Срочный",
                    CallTime = new DateTime(2017, 12, 21, 18, 30, 00),
                    IncidentCause = "testCause2",
                    IncidentDescription = "testDescription2",
                    IsActive = false
                },
                new Call()
                {
                    Id = 3,
                    Address = "anotherAddress",
                    Reason = "testReason3",
                    Category = "Неотложный",
                    CallTime = new DateTime(2017, 12, 22, 18, 30, 00),
                    IncidentCause = "testCause3",
                    IncidentDescription = "testDescription3",
                    IsActive = false
                }
            };

        [TestInitialize]
        public void TestInitialize()
        {
            _callProvider = new Mock<ICallProvider>();
            _controller = new CallListController(_callProvider.Object);
            _callProvider.Setup(a => a.GetCalls())
                .Returns(_calls);
        }

        [TestMethod]
        public void Search_ModelType()
        {           
            var result = _controller.Search() as ViewResult;
            Assert.IsInstanceOfType(result.Model, typeof(CallListViewModel));
        }

        [TestMethod]
        public void Search_ViewName()
        {
            {
                var result = _controller.Search(null,"","") as PartialViewResult;
                Assert.AreEqual(result.ViewName, "_SearchResult");
            }
        }

        [TestMethod]
        public void Search_Null_AllCalls()
        {
            var result = _controller.Search(null, "", "") as PartialViewResult;
            var model = result.Model as CallListViewModel;
            Assert.AreEqual(model.CallList.Count(), 3);
        }

        [TestMethod]
        public void Search_Category_CallsByCategory()
        {
            var result = _controller.Search(null, "", "Неотложный") as PartialViewResult;
            var model = result.Model as CallListViewModel;
            Assert.AreEqual(model.CallList.Count(), 2);
        }

        [TestMethod]
        public void Search_Id_CallWithId()
        {
            var result = _controller.Search(2, "", "") as PartialViewResult;
            var model = result.Model as CallListViewModel;
            Assert.AreEqual(model.CallList.Single().Id, 2);
        }

        [TestMethod]
        public void Search_IdAndWrongAddress_Empty()
        {
            var result = _controller.Search(2, "wrongAddress", "") as PartialViewResult;
            var model = result.Model as CallListViewModel;
            Assert.AreEqual(model.CallList.Any(), false);
        }

        [TestMethod]
        public void Search_AddressPart_CallsContainsAddressString()
        {
            var result = _controller.Search(null, "test", "");
            var model = result.Model as CallListViewModel;
            Assert.AreEqual(model.CallList.Count(), 2);
        }

        [TestMethod]
        public void Search_WrongId_Empty()
        {
            var result = _controller.Search(0, "", "");
            var model = result.Model as CallListViewModel;
            Assert.AreEqual(model.CallList.Any(), false);
        }
    }
}
