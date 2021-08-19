using CreditApplication.Controllers;
using CreditApplication.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace CreditApplication.Tests
{
    [TestClass]
    public class CreditControllerTest
    {
        CreditRequestModel inputData;
        [TestMethod]
        public void SpecialCase_AppliedAmt_2000()
        {
            var controller = new CreditController();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            inputData = new CreditRequestModel() { AppliedAmt = 2000, RepaymentTerm = 2, ExistingCreditAmt = 3000 };
            var result = controller.Index(inputData);
            var response = result.ExecuteAsync(new System.Threading.CancellationToken());
            string deserialized = response.Result.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("\"Please contact our customer care team.\"", deserialized);
        }
        [TestMethod]
        public void SpecialCase_AppliedAmt_39500()
        {
            var controller = new CreditController();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            inputData = new CreditRequestModel() { AppliedAmt = 39500, RepaymentTerm = 2, ExistingCreditAmt = 0 };
            var result = controller.Index(inputData);
            var response = result.ExecuteAsync(new System.Threading.CancellationToken());
            string deserialized = response.Result.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("\"Please contact our customer care team.\"", deserialized);
        }

        [TestMethod]
        public void SpecialCase_AppliedAmt_60000()
        {
            var controller = new CreditController();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            inputData = new CreditRequestModel() { AppliedAmt = 60000, RepaymentTerm = 2, ExistingCreditAmt = 0 };
            var result = controller.Index(inputData);
            var response = result.ExecuteAsync(new System.Threading.CancellationToken());
            string deserialized = response.Result.Content.ReadAsStringAsync().Result;
            Assert.AreEqual("\"Please contact our customer care team.\"", deserialized);
        }
        [TestMethod]
        public void SpecialCase_AppliedAmt_60001()
        {
            var controller = new CreditController();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            inputData = new CreditRequestModel() { AppliedAmt = 60001, RepaymentTerm = 2, ExistingCreditAmt = 0 };
            var result = controller.Index(inputData) as JsonResult<CreditResponseModel>;
            Assert.AreEqual((UInt16)Constants.SLAB4_INTERESTRATE, result.Content.InterestRate);
        }

        [TestMethod]
        public void SpecialCase_AppliedAmt_1999()
        {
            var controller = new CreditController();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            inputData = new CreditRequestModel() { AppliedAmt = 1999, RepaymentTerm = 2, ExistingCreditAmt = 0 };
            var result = controller.Index(inputData) as JsonResult<CreditResponseModel>;
            Assert.AreEqual(false, result.Content.Decision);
        }

        [TestMethod]
        public void SpecialCase_AppliedAmt_3000()
        {
            var controller = new CreditController();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            inputData = new CreditRequestModel() { AppliedAmt = 3000, RepaymentTerm = 2, ExistingCreditAmt = 10 };
            var result = controller.Index(inputData) as JsonResult<CreditResponseModel>;
            Assert.AreEqual(true, result.Content.Decision);
            Assert.AreEqual((UInt16)Constants.SLAB1_INTERESTRATE, result.Content.InterestRate);
        }
        [TestMethod]
        public void SpecialCase_AppliedAmt_40000()
        {
            var controller = new CreditController();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            inputData = new CreditRequestModel() { AppliedAmt = 40000, RepaymentTerm = 2, ExistingCreditAmt = 0 };
            var result = controller.Index(inputData) as JsonResult<CreditResponseModel>;
            Assert.AreEqual(true, result.Content.Decision);
            Assert.AreEqual((UInt16)Constants.SLAB3_INTERESTRATE, result.Content.InterestRate);
        }
        [TestMethod]
        public void SpecialCase_AppliedAmt_40010()
        {
            var controller = new CreditController();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            inputData = new CreditRequestModel() { AppliedAmt = 40010, RepaymentTerm = 4, ExistingCreditAmt = 10 };
            var result = controller.Index(inputData) as JsonResult<CreditResponseModel>;
            Assert.AreEqual(true, result.Content.Decision);
            Assert.AreEqual((UInt16)Constants.SLAB3_INTERESTRATE, result.Content.InterestRate);
        }
        [TestMethod]
        public void SpecialCase_AppliedAmt_69001()
        {
            var controller = new CreditController();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            inputData = new CreditRequestModel() { AppliedAmt = 69001, RepaymentTerm = 2, ExistingCreditAmt = 0 };
            var result = controller.Index(inputData) as JsonResult<CreditResponseModel>;
            Assert.AreEqual(false, result.Content.Decision);
        }
        [TestMethod]
        public void SpecialCase_ExistingCredit_69001()
        {
            var controller = new CreditController();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            inputData = new CreditRequestModel() { AppliedAmt = 68999, RepaymentTerm = 2, ExistingCreditAmt = 69001 };
            var result = controller.Index(inputData) as JsonResult<CreditResponseModel>;
            Assert.AreEqual(true, result.Content.Decision);
            Assert.AreEqual((UInt16)Constants.SLAB4_INTERESTRATE, result.Content.InterestRate);
        }
        [TestMethod]
        public void SpecialCase_ExistingCredit_001()
        {
            var controller = new CreditController();
            controller.Configuration = new System.Web.Http.HttpConfiguration();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            inputData = new CreditRequestModel() { AppliedAmt = 68999, RepaymentTerm = 2, ExistingCreditAmt = 001 };
            var result = controller.Index(inputData) as JsonResult<CreditResponseModel>;
            Assert.AreEqual(true, result.Content.Decision);
            Assert.AreEqual((UInt16)Constants.SLAB4_INTERESTRATE, result.Content.InterestRate);
        }
    }
}
