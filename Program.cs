using LoanBusinessLogic;
using LoanDataModel;
using System;
using System.Linq;

namespace LoanInterestNotif
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoanAppService service = new LoanAppService();
            bool running = true;

        while (running)
            {
                Console.Clear();
                Console.WriteLine("LOAN SYSTEM");
                Console.WriteLine("1. Create Loan Record");
                Console.WriteLine("2. View All Loan Records");
                Console.WriteLine("3. Update Loan Record");
                Console.WriteLine("4. Delete Loan Record");
                Console.WriteLine("5. Get Loan By ID");
                Console.WriteLine("6. Exit");
                Console.Write("Choose option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateLoan(service);
                        break;

                    case "2":
                        ViewLoans(service);
                        break;

                    case "3":
                        UpdateLoan(service);
                        break;

                    case "4":
                        DeleteLoan(service);
                        break;

                    case "5":
                        GetLoanById(service);
                        break;

                    case "6":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Pause();
                        break;
                }
            }
        }

        static void CreateLoan(LoanAppService service)
        {
            Console.Clear();

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Job: ");
            string job = Console.ReadLine();

            Console.Write("Salary: ");
            int salary = Convert.ToInt32(Console.ReadLine());

            Console.Write("Company: ");
            string company = Console.ReadLine();

            Console.Write("Loan Months: ");
            int loanMonths = Convert.ToInt32(Console.ReadLine());

            Console.Write("Interest Rate: ");
            double interestRate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Loan Amount: ");
            double loanAmount = Convert.ToDouble(Console.ReadLine());

            service.CreateNewLoan(
                name,
                job,
                salary,
                company,
                loanMonths,
                interestRate,
                loanAmount);

            Console.WriteLine("Loan created successfully.");
            Pause();
        }

        static void ViewLoans(LoanAppService service)
        {
            Console.Clear();

            var loans = service.GetLoan();

            foreach (var loan in loans)
            {
                Console.WriteLine($"ID: {loan.Id}");
                Console.WriteLine($"Name: {loan.Name}");
                Console.WriteLine($"Job: {loan.Job}");
                Console.WriteLine($"Salary: {loan.Salary}");
                Console.WriteLine($"Company: {loan.Company}");
                Console.WriteLine($"Loan Months: {loan.LoanMonths}");
                Console.WriteLine($"Interest Rate: {loan.InterestRate}");
                Console.WriteLine($"Loan Amount: {loan.LoanAmount}");
                Console.WriteLine($"Total Payment: {loan.TotalPayment}");
                Console.WriteLine("----------------------------------");
            }

            Pause();
        }

        static void GetLoanById(LoanAppService service)
        {
            Console.Clear();

            Console.Write("Enter Loan ID: ");

            if (!Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                Console.WriteLine("Invalid ID.");
                Pause();
                return;
            }

            var loan = service.GetLoanById(id);

            if (loan == null)
            {
                Console.WriteLine("Loan not found.");
            }
            else
            {
                Console.WriteLine($"ID: {loan.Id}");
                Console.WriteLine($"Name: {loan.Name}");
                Console.WriteLine($"Job: {loan.Job}");
                Console.WriteLine($"Salary: {loan.Salary}");
                Console.WriteLine($"Company: {loan.Company}");
                Console.WriteLine($"Loan Months: {loan.LoanMonths}");
                Console.WriteLine($"Interest Rate: {loan.InterestRate}");
                Console.WriteLine($"Loan Amount: {loan.LoanAmount}");
                Console.WriteLine($"Total Payment: {loan.TotalPayment}");
            }

            Pause();
        }
        static void UpdateLoan(LoanAppService service)
        {
            Console.Clear();

            Console.Write("Enter Loan ID: ");

            if (!Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                Console.WriteLine("Invalid ID.");
                Pause();
                return;
            }

            SystemDataModel loan = new SystemDataModel();

            loan.Id = id;

            Console.Write("Name: ");
            loan.Name = Console.ReadLine();

            Console.Write("Job: ");
            loan.Job = Console.ReadLine();

            Console.Write("Salary: ");
            loan.Salary = Convert.ToInt32(Console.ReadLine());

            Console.Write("Company: ");
            loan.Company = Console.ReadLine();

            Console.Write("Loan Months: ");
            loan.LoanMonths = Convert.ToInt32(Console.ReadLine());

            Console.Write("Interest Rate: ");
            loan.InterestRate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Loan Amount: ");
            loan.LoanAmount = Convert.ToDouble(Console.ReadLine());

            service.UpdateLoan(loan);

            Console.WriteLine("Updated successfully.");
            Pause();
        }

        static void DeleteLoan(LoanAppService service)
        {
            Console.Clear();

            Console.Write("Enter Loan ID: ");

            if (!Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                Console.WriteLine("Invalid ID.");
                Pause();
                return;
            }

            service.DeleteLoan(id);

            Console.WriteLine("Deleted successfully.");
            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
