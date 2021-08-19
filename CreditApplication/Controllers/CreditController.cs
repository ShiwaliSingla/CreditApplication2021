using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using CreditApplication.BusinessLogic;
using CreditApplication.Models;

namespace CreditApplication.Controllers
{
    public class CreditController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Index([FromUri] CreditRequestModel creditRequest)
        {
            if (ModelState.IsValid)     //Validations passed
            {
                CreditResponseModel result = ProcessApplication.Process(creditRequest);
                if (result.HasException)
                    return Json(result.ExceptionComment);
                else
                    return Json(result);
            }
            else
            {
                return Json("Invalid input");
            }
        }
    }
}
