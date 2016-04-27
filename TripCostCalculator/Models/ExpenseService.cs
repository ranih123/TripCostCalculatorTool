using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TripCostCalculator.Models
{
    public class ExpenseService
    {
        /// <summary>
        /// Gets the total Trip Cost for each Student
        /// </summary>
        public decimal GetTotalTripCostByStudent(TripExpenseRequestDetails _studentRequest)
        {

            decimal _sumTotal = 0;
            _sumTotal = _studentRequest.ExpenseAmount.Sum();
            return _sumTotal;
        }

        /// <summary>
        /// Gets the total Trip Cost for all Student
        /// </summary>
        public decimal GetTotalTripCost(List<TripExpenseRequestDetails> _studentRequest)
        {
            decimal _sumTotal = (decimal)_studentRequest.Select(x => x.ExpenseAmount.Sum()).Sum();
            return _sumTotal;
        }

        /// <summary>
        /// Gets the Average Trip Cost for all Student
        /// </summary>
        public decimal GetAverageofTotalTripCost(List<TripExpenseRequestDetails> _studentRequest)
        {

            decimal _sumTotal = GetTotalTripCost(_studentRequest);
            int _studentCount = _studentRequest.Count;
            decimal _AverageTotal = Convert.ToDecimal(Math.Round((decimal)(_sumTotal / _studentCount), 2));
            return _AverageTotal;
        }


        /// <summary>
        /// Gets the Response List for the student and the amout to be paid out.
        /// </summary>
        public List<TripExpenseResponseDetails> GetStudentExpenseDetails(List<TripExpenseRequestDetails> _studentRequest)
        {
            try
            {
                decimal _sumTotal = GetAverageofTotalTripCost(_studentRequest);
                TripExpenseResponse response = new TripExpenseResponse();
                var result = from request in _studentRequest
                               where (request.ExpenseAmount.Sum()) < _sumTotal
                               select new TripExpenseResponseDetails()
                               {
                                   StudentName = request.StudentName,
                                   AmounttobePaidOut = (_sumTotal - (request.ExpenseAmount.Sum()))

                               };
                return result.ToList();


            }
            catch
            {
                return null;
            }
        }

    }
}