using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditApplication
{
    public static class Constants
    {
        public static Int32 MINIMUM_APPLIED_AMT = 2000;
        public static Int32 MAXIMUM_APPLIED_AMT = 69001;  // intentionally its set to 69001

        //Interest rate slab1
        public static Int32 SLAB1_MAXIMUM_FUTURE_DEBT = 20000;
        public static UInt16 SLAB1_INTERESTRATE = 3;


        //Interest rate slab2
        public static Int32 SLAB2_MINIMUM_FUTURE_DEBT = 20000;
        public static Int32 SLAB2_MAXIMUM_FUTURE_DEBT = 39000;
        public static UInt16 SLAB2_INTERESTRATE = 4;

        //Interest rate slab3
        public static Int32 SLAB3_MINIMUM_FUTURE_DEBT = 40000;
        public static Int32 SLAB3_MAXIMUM_FUTURE_DEBT = 59000;
        public static UInt16 SLAB3_INTERESTRATE = 5;

        //Interest rate slab4
        public static Int32 SLAB4_MINIMUM_FUTURE_DEBT = 60000;
        public static UInt16 SLAB4_INTERESTRATE = 6;
    }
}