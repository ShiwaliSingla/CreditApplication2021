using CreditApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditApplication.BusinessLogic
{
    public class ProcessApplication
    {
        public static CreditResponseModel Process(CreditRequestModel creditRequest)
        {
            CreditResponseModel response = new CreditResponseModel();
            if(creditRequest.AppliedAmt > Constants.MINIMUM_APPLIED_AMT && creditRequest.AppliedAmt < Constants.MAXIMUM_APPLIED_AMT)  //Criteria1 matched
            {
                Int32 futureCredit = creditRequest.AppliedAmt + creditRequest.ExistingCreditAmt;
                if(futureCredit < Constants.SLAB1_MAXIMUM_FUTURE_DEBT)
                {
                    response.InterestRate = Constants.SLAB1_INTERESTRATE;
                    response.Decision = true;
                    return response;
                }
                
                if(futureCredit >=Constants.SLAB2_MINIMUM_FUTURE_DEBT && futureCredit <=Constants.SLAB2_MAXIMUM_FUTURE_DEBT)
                {
                    response.InterestRate = Constants.SLAB2_INTERESTRATE;
                    response.Decision = true;
                    return response;
                }

                if (futureCredit >= Constants.SLAB3_MINIMUM_FUTURE_DEBT && futureCredit <= Constants.SLAB3_MAXIMUM_FUTURE_DEBT)
                {
                    response.InterestRate = Constants.SLAB3_INTERESTRATE;
                    response.Decision = true;
                    return response;
                }
                                                        
                if (futureCredit > Constants.SLAB4_MINIMUM_FUTURE_DEBT)
                {
                    response.InterestRate = Constants.SLAB4_INTERESTRATE;
                    response.Decision = true;
                    return response;                         // this return statement is optional and is added to maintain consistency
                }

                //case falls outside given business requirements. A fallback case should be provided by BA.
                response.HasException = true;
                response.ExceptionComment = "Please contact our customer care team.";
                return response;
            }
            else
            {
                //special case of missing requriement. This is an open question to BA. Once answered, this hard coding will be removed. 
                if (creditRequest.AppliedAmt == 2000)
                {
                    response.HasException = true;
                    response.ExceptionComment = "Please contact our customer care team.";
                }
                else
                {
                    response.Decision = false;
                }
                return response;
            }
        }
    }
}