using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditApplication.Models
{
    public class CreditResponseModel: BaseResponseModel
    {
        public Nullable<Boolean> Decision { get; set; }
        public Nullable<UInt16> InterestRate { get; set; }
    }
}