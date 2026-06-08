//(Loan CONSOLE Interest+Notifications)
using LoanDataModel;
using LoanNotificationDataService;
using System;
using System.Collections.Generic;

namespace LoanInterestNotif
{
    internal class Program
    {
    static void Main(string[] args)
            {
        SystemDataService service = 
        new SystemDataService();
            bool running = true;

            while (running)
            {
        Console.Clear();
Console.WriteLine("LOAN");
Console.WriteLine("1. Create Loan Record");
Console.WriteLine("2. View All Loan Records");
Console.WriteLine("3. Update Loan Record");
Console.WriteLine("4. Delete Loan Record");
Console.WriteLine("5. Exit");
Console.Write("Choose option: ");
string choice = Console.ReadLine();
                
switch (choice)
{
 case "1": CreateLoan(service);  break;
 case "2": ViewLoans(service);   break;
 case "3": UpdateLoan(service);  break;                   
 case "4": DeleteLoan(service);  break;              
 case "5": running = false;
                    Console.WriteLine("Exit program");
break; default:                       Console.WriteLine("Invalid choice.");
Pause(); break;
                }
            }
        }
static void CreateLoan(SystemDataService service)
        {
           Console.Clear();
Console.WriteLine("CREATE LOAN RECORD");
SystemDataModel 
       loan = new SystemDataModel();
       loan.Id = Guid.NewGuid();
      
Console.WriteLine("Input your name");
loan.Name = Console.ReadLine();
Console.WriteLine("Input your current job");
loan.Job = Console.ReadLine();
Console.WriteLine("Input your current salary"); 
loan.Salary = Convert.ToDecimal(Console.ReadLine());
Console.WriteLine("Input your current company");
loan.Company = Console.ReadLine();
       
 
               Console.WriteLine("Select how long do you want to loan the money");
                Console.WriteLine("1. 3 months");
                Console.WriteLine("2. 6 months");
                Console.WriteLine("3. 9 months");
                Console.WriteLine("4. 12 months");

                int choice = Convert.ToInt32(Console.ReadLine());
                int loanMonths = 0;

                switch (choice)
                {
                    case 1:
                        loanMonths = 3;
                        break;

                    case 2:
                        loanMonths = 6;
                        break;

                    case 3:
                        loanMonths = 9;
                        break;

                    case 4:
                        loanMonths = 12;
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        return;
                }

                double interestRate;
                switch (loanMonths)
                {
                    case 3:
                        interestRate = 0.05;
                        break;

                    case 6:
                        interestRate = 0.10;
                        break;

                    case 9:
                        interestRate = 0.15;
                        break;

                    case 12:
                        interestRate = 0.20;
                        break;

                    default:
                        interestRate = 0;
                        break;
                }

Console.WriteLine($"Loan term: {loanMonths} months");
Console.WriteLine($"Interest rate: {interestRate * 100}%");
Console.WriteLine("Input how much is your loan:");
      double loanAmount= Convert.ToDouble(Console.ReadLine());
      double interestAmount= 
loanAmount*interestRate;
      double totalPayment= 
loanAmount+interestAmount;
      double monthlyPayment= 
totalPayment/loanMonths;

Console.WriteLine("Loan Amount: " + loanAmount);
Console.WriteLine("Interest Amount: " + interestAmount);
Console.WriteLine("Total to Pay: " + totalPayment);
Console.WriteLine("Monthly Pay: " + monthlyPayment);
Console.WriteLine("Loan Approved");
Console.WriteLine("Your loan due is in " + loanMonths + " months.");
loan.LoanMonths = loanMonths;
            loan.InterestRate = interestRate;
            loan.LoanAmount = (decimal)loanAmount;
            loan.TotalPayment = (decimal)totalPayment;

            service.Create(loan);

Console.WriteLine("Loan saved success.");
            Pause();
        }

        static void ViewLoans(SystemDataService service)
        {
            Console.Clear();
Console.WriteLine("VIEW LOAN RECORDS ");

         List<SystemDataModel> loans = service.View();

            if (loans.Count == 0)
            {
Console.WriteLine("No records");
            }
            else
            {
            foreach (var loan in loans)
            {
                    
                    Console.WriteLine($"ID: {loan.Id}");                  Console.WriteLine($"Name: {loan.Name}");                Console.WriteLine($"Job: {loan.Job}");                    Console.WriteLine($"Salary:{loan.Salary}");                  Console.WriteLine($"Company: {loan.Company}");                 Console.WriteLine($"Loan Months: {loan.LoanMonths}");                   Console.WriteLine($"Interest Rate: {loan.InterestRate}");
Console.WriteLine($"Loan Amount: {loan.LoanAmount}");                  Console.WriteLine($"Total Payment: {loan.TotalPayment}");
                }             
            }           
        }

        static void UpdateLoan(SystemDataService service)
        {
            Console.Clear();
Console.WriteLine("UPDATE RECORD");
List<SystemDataModel> loans = service.View();
        if (loans.Count == 0)
            {
Console.WriteLine("No records available.");
                
                return;
            }
Console.WriteLine("Existing Records:");
        foreach (var loan in loans)
            {
              Console.WriteLine($"{loan.Id} - {loan.Name}");
            }
Console.Write("Enter ID to update: ");
            string inputId = Console.ReadLine();

            if (Guid.TryParse(inputId, out Guid id))
            {
                var existing = loans.Find(x => x.Id == id);

                if (existing != null)
                {
SystemDataModel updatedLoan = 
new SystemDataModel();
updatedLoan.Id = existing.Id;

Console.Write("Enter New Name: ");
        updatedLoan.Name = Console.ReadLine();

Console.Write("Enter New Job: ");
        updatedLoan.Job = Console.ReadLine();

Console.Write("Enter New Salary: ");
                    updatedLoan.Salary = Convert.ToDecimal(Console.ReadLine());

Console.Write("Enter New Company: ");
                    updatedLoan.Company = Console.ReadLine();

Console.Write("Enter New Loan Months: ");
                  updatedLoan.LoanMonths = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter New Interest Rate: ");
                updatedLoan.InterestRate = Convert.ToDouble(Console.ReadLine());

Console.Write("Enter New Loan Amount: ");
                  updatedLoan.LoanAmount = Convert.ToDecimal(Console.ReadLine());

Console.Write("Enter New Total Payment: ");
                updatedLoan.TotalPayment = Convert.ToDecimal(Console.ReadLine());
            service.Update(updatedLoan);



                   Console.WriteLine("Loan record updated successfully.");
                }
                else
                {
                    Console.WriteLine("Record not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }          
        }

        static void DeleteLoan(SystemDataService service)
        {
            Console.Clear();
Console.WriteLine("DELETE LOAN RECORD ");

            List<SystemDataModel> loans = service.View();

            if (loans.Count == 0)
            {
Console.WriteLine("No records available.");               
                return;
            }

Console.WriteLine("Existing Records:");
            foreach (var loan in loans)
            {
                Console.WriteLine($"{loan.Id} - {loan.Name}");
            }

Console.Write("Enter ID to delete: ");
            string inputId = Console.ReadLine();

            if (Guid.TryParse(inputId, out Guid id))
            {
                service.Delete(id);
Console.WriteLine("Loan record deleted");
            }
            else
            {
                Console.WriteLine("Invalid ID format.");
            }           
        }

        static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press anything to continue");
            Console.ReadKey();
        }
    }
}
                