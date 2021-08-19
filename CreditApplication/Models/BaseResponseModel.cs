using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditApplication.Models
{    
    public class BaseResponseModel
    {
        [JsonIgnore]
        public Boolean HasException { get; set; }
        [JsonIgnore]
        public String ExceptionComment { get; set; }
    }
}