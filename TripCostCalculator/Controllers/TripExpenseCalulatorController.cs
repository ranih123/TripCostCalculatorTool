using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TripCostCalculator.Models;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;

namespace TripCostCalculator.Controllers
{
    public class TripExpenseCalulatorController : ApiController
    {

        // POST: api/TripExpenseCalulator
        [ResponseType(typeof(TripExpenseResponse))]
        public IHttpActionResult PostTripExpenses(TripExpenseRequest request)
        {
            TripExpenseResponse result = CalculateTripExpense(request);
            if(request!=null)
            {
                result.Success = true;
            }
            else
            {
                result.Success = false;
            }
            return Ok(result);
        }

        /// <summary>
        /// Calculates the Trip Expense and returns a response expense list
        /// </summary>
        private TripExpenseResponse CalculateTripExpense(TripExpenseRequest request)
        {
            TripExpenseResponse result = new TripExpenseResponse();
            ExpenseService _service = new ExpenseService();
            List<TripExpenseResponseDetails> expenseResponeList = new List<TripExpenseResponseDetails>();
            expenseResponeList = _service.GetStudentExpenseDetails(request.TripExpenseRequestList);
            result.TripExpenseList = expenseResponeList;
            return result;
        }
        
       
    }
}
