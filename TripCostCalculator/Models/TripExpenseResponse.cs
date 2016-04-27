using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TripCostCalculator.Models
{
    public class TripExpenseResponse
    {
        public List<TripExpenseResponseDetails> TripExpenseList { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}