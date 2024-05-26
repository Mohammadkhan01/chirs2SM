using System;
using BLOG.WEB.Models.Domain;

namespace BLOG.WEB.Models.Domain
{
    public class Fees
    {
        public int FeesId { get; set; }
        public string FeesType { get; set; }
        public string FeesPurpose { get; set; }
        public bool MonthlyPay { get; set; }
        public int amount { get; set; }
     }
}

