//(Loan CONSOLE Interest+Notifications)
using NotificationAppService;
using System;
using System.Collections.Generic;
namespace LoanInterestNotif

{
    internal class Program
    {
        private static SystemAppService appService = new SystemAppService();
        static void Main(string[] args)
        
            {
                Console.WriteLine("Input your name");
                string name = Console.ReadLine();

                Console.WriteLine("Input your current job");
                string job = Console.ReadLine();

                Console.WriteLine("Input your current salary");
                int salary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input your current company");
                string company = Console.ReadLine();

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
                 }
    }  
}