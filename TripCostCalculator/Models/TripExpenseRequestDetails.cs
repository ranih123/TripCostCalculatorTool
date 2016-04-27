using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TripCostCalculator.Models
{
    public class TripExpenseRequestDetails
    {
        public string StudentName { get; set; }
        public decimal[] ExpenseAmount { get; set; }
    }
    
}