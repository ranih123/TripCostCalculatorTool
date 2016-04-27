using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripCostCalculator.Models;
using System.Collections.Generic;
using System.Linq;


namespace TripCostCalculator.Tests
{
    [TestClass]
    public class TripExpenseServiceTest
    {
        [TestMethod]
        public void GetStudentExpenseDetailsTest()
        {
            List<TripExpenseRequestDetails> tpRequest = GetTestRequestData();
            ExpenseService _service = new ExpenseService();
            List<TripExpenseResponseDetails> tpResponseActual = new List<TripExpenseResponseDetails>();
            tpResponseActual = _service.GetStudentExpenseDetails(tpRequest);
            List<TripExpenseResponseDetails> tpResponseExpected = GetTestExpectedData();
            bool isEqual = true;
            if (tpResponseActual.Count == tpResponseExpected.Count)
            {
                for (int i = 0; i < tpResponseExpected.Count; i++)
                {
                    if (!(tpResponseActual[i].AmounttobePaidOut == tpResponseExpected[i].AmounttobePaidOut && tpResponseActual[i].StudentName == tpResponseExpected[i].StudentName))
                    {
                        isEqual = false;
                    }
                }
            }
            else
                isEqual = false;
            if(!isEqual)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void GetAverageofTotalTripCosttpRequestTest()
        {;
            List<TripExpenseRequestDetails> tpRequest = GetTestRequestData();
            ExpenseService _service = new ExpenseService();
            decimal expected = 72.39M;
            decimal actual = _service.GetAverageofTotalTripCost(tpRequest);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTotalTripCostByStudentTest()
        {
            List<TripExpenseRequestDetails> tpRequest = GetTestRequestData();
            ExpenseService _service = new ExpenseService();
            decimal expected = 53.54M;
            decimal actual = _service.GetTotalTripCostByStudent(tpRequest[0]);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTotalTripCostTest()
        {
            List<TripExpenseRequestDetails> tpRequest = GetTestRequestData();
            ExpenseService _service = new ExpenseService();
            decimal expected = 217.18M;
            decimal actual = _service.GetTotalTripCost(tpRequest);
            Assert.AreEqual(expected, actual);
        }

        private List<TripExpenseRequestDetails> GetTestRequestData()
        {
            List<TripExpenseRequestDetails> tripExpenselist = new List<TripExpenseRequestDetails>();
            TripExpenseRequestDetails tp2 = new TripExpenseRequestDetails();
            tp2.StudentName = "Louis";
            tp2.ExpenseAmount = new decimal[] { 5.75M, 35.00M, 12.79M };
            tripExpenselist.Add(tp2);

            tp2 = new TripExpenseRequestDetails();
            tp2.StudentName = "Carter";
            tp2.ExpenseAmount = new decimal[] { 12.00M, 15.00M, 23.23M };
            tripExpenselist.Add(tp2);


            tp2 = new TripExpenseRequestDetails();
            tp2.StudentName = "David";
            tp2.ExpenseAmount = new decimal[] { 10.00M, 20.00M, 38.41M, 45.00M };
            tripExpenselist.Add(tp2);
            return tripExpenselist;
        }
        private List<TripExpenseResponseDetails> GetTestExpectedData()
        {
            List<TripExpenseResponseDetails> tripExpenselist = new List<TripExpenseResponseDetails>();
            TripExpenseResponseDetails tp2 = new TripExpenseResponseDetails();
            tp2.StudentName = "Louis";
            tp2.AmounttobePaidOut = 18.85M;
            tripExpenselist.Add(tp2);

            tp2 = new TripExpenseResponseDetails();
            tp2.StudentName = "Carter";
            tp2.AmounttobePaidOut = 22.16M;
            tripExpenselist.Add(tp2);
            return tripExpenselist;
        }
    }
}
