using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TripCostCalculator.Models
{
    public class TripExpenseRequest
    {
        public List<TripExpenseRequestDetails> TripExpenseRequestList { get; set; }
        public string requesttype { get; set; }

    }
}