using LoanDataModel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace LoanNotificationDataService
{
    public class LoanDBData : InterfaceLoanDataService
    {
        private string connectionString
      = "Data Source =localhost\\SQLEXPRESS; Initial Catalog = LoanData; Integrated Security = True; TrustServerCertificate=True;";
        private SqlConnection sqlConnection;
        public LoanDBData()
        {
            sqlConnection = new SqlConnection(connectionString);

            AddSeeds();
        }

        private void AddSeeds()
        {
            var existing = View();

            if (existing.Count == 0)
            {
                SystemDataModel adminAccount = new SystemDataModel { Name = "Neo", Id = Guid.NewGuid(), Job = "Owner", Salary = 1000, Company = "PUP", LoanMonths = 12, InterestRate = 0.5, LoanAmount = 10000, TotalPayment = 15000 };
                
                Create(adminAccount);
         
            }
        }

        public void Create(SystemDataModel loan)
        {
            var insertStatement = "INSERT INTO LoanVariablesTable VALUES (@Name, @Id, @Job, @Salary, @Company, @LoanMonths, @InterestRate, @LoanAmount, @TotalPayment)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@Name", loan.Name);
            insertCommand.Parameters.AddWithValue("@Id", loan.Id);
            insertCommand.Parameters.AddWithValue("@Job", loan.Job);
            insertCommand.Parameters.AddWithValue("@Salary", loan.Salary);
            insertCommand.Parameters.AddWithValue("@Company", loan.Company);
            insertCommand.Parameters.AddWithValue("@LoanMonths", loan.LoanMonths);
            insertCommand.Parameters.AddWithValue("@InterestRate", loan.InterestRate);
           
insertCommand.Parameters.AddWithValue("@LoanAmount", loan.LoanAmount);

insertCommand.Parameters.AddWithValue("@TotalPayment",loan.TotalPayment);

           sqlConnection.Open(); insertCommand.ExecuteNonQuery();
           sqlConnection.Close();
        }

        public List<SystemDataModel> View()
        {
            string selectStatement = "SELECT Name, Id, Job, Salary, Company, LoanMonths, InterestRate, LoanAmount, TotalPayment FROM LoanVariablesTable";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var LoanApp = new List<SystemDataModel>();

            while (reader.Read())
            {
                SystemDataModel Loan = new SystemDataModel();
                Loan.Id = Guid.Parse(reader["Id"].ToString());
                Loan.Name = reader["Name"].ToString();
                Loan.Job = reader["Job"].ToString();
                Loan.Salary = Convert.ToInt32(reader["Salary"]);
                Loan.Company = reader["Company"].ToString();
                Loan.LoanMonths = Convert.ToInt32(reader["LoanMonths"]);
                Loan.InterestRate = Convert.ToDouble(reader["InterestRate"]);
                Loan.LoanAmount = Convert.ToDouble(reader["LoanAmount"]);
                Loan.TotalPayment = Convert.ToDouble(reader["TotalPayment"]);
             LoanApp.Add(Loan);
            }

            sqlConnection.Close();
            return LoanApp;
        }
       


        public void Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Update(SystemDataModel loanDS)
        {
            throw new NotImplementedException();
        }
    }
}
