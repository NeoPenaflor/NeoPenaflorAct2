using LoanDataModel;
using System;
using System.Linq;
using System.Collections.Generic;

namespace LoanNotificationDataService
{
    public class SystemDataService : InterfaceLoanDataService

    {
    private List<SystemDataModel> data      = new List<SystemDataModel>();

    public void Create(SystemDataModel loanDS)
        {
            data.Add(loanDS);
        }

    public void Delete(Guid Id)
        {
        var existing =       data.FirstOrDefault(x => x.Id == Id);
            if (existing != null)
        {
        data.Remove(existing);
        }
        }
            
     public void Update(SystemDataModel loanDS)
        {
        var existing = data.FirstOrDefault(x => x.Id == loanDS.Id);
   

if (existing != null)
            {
existing.Name = loanDS.Name;
existing.Job = loanDS.Job;
existing.Salary = loanDS.Salary;
existing.Company = loanDS.Company;
existing.LoanMonths = loanDS.LoanMonths;
existing.InterestRate = loanDS.InterestRate;
existing.LoanAmount = loanDS.LoanAmount;
existing.TotalPayment = loanDS.TotalPayment;
            }      
        }

     public List<SystemDataModel> View()
        {
        return data;
        }
    }
}
