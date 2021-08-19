using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CreditApplication.Models
{
    public class CreditRequestModel
    {
        [Required]
        public Int32 AppliedAmt { get; set; }
        public Int16 RepaymentTerm { get; set; }        //months
        [Required]
        public Int32 ExistingCreditAmt { get; set; }
    }
}