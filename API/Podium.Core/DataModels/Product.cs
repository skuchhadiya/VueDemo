using Podium.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Podium.Core
{
    public class Product
    {
        public string Lender { set; get; }

        public int InterestRate { get; set; }

        public MortgageTypeEnum MortgageType  {get;set;}

        public int LoanToValuePercentage { get; set; }
    }
}
