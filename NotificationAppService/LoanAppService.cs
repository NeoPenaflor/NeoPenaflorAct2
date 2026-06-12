using LoanDataModel;
using LoanNotificationDataService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoanBusinessLogic
{
    public class LoanAppService
    {
        MediatorDataService dataServFunctions =
        new MediatorDataService(new LoanDBData());

    public List<SystemDataModel> GetLoan()
        {
            return dataServFunctions.View();
        }

        public SystemDataModel GetLoanById(Guid Id)
        {
            var loanList = dataServFunctions.View();

            return loanList.FirstOrDefault(x => x.Id == Id);
        }

        public void CreateNewLoan(
            string name,
            string job,
            int salary,
            string company,
            int loanMonths,
            double interestRate,
            double loanAmount)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name is required.");
            if (loanAmount <= 0)
                throw new Exception("Loan Amount must be greater than zero.");
            if (loanMonths <= 0)
                throw new Exception("Loan Months must be greater than zero.");
            double totalPayment =
                loanAmount + (loanAmount * interestRate * loanMonths);

            SystemDataModel loan = new SystemDataModel
            {
                Name = name,
                Id = Guid.NewGuid(),
                Job = job,
                Salary = salary,
                Company = company,
                LoanMonths = loanMonths,
                InterestRate = interestRate,
                LoanAmount = loanAmount,
                TotalPayment = totalPayment
            };

            dataServFunctions.Create(loan);
            }

        public void UpdateLoan(SystemDataModel loan)
        {
        if (loan == null)
                throw new Exception("Loan data is invalid.");

        if (loan.Id == Guid.Empty)
                throw new Exception("Loan ID is invalid.");

            loan.TotalPayment =
            loan.LoanAmount +
            (loan.LoanAmount * loan.InterestRate * loan.LoanMonths);
            dataServFunctions.Update(loan);
        }
        public void DeleteLoan(Guid Id)
        {
        dataServFunctions.Delete(Id);
        }
    }
}
