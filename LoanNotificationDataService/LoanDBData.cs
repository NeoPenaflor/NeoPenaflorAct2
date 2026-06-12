using System.Linq;
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
            var insertStatement = "INSERT INTO LoanVariablesTable (Name,Id,Job,Salary,Company,LoanMonths,InterestRate,LoanAmount, TotalPayment) VALUES (@Name, @Id, @Job, @Salary, @Company, @LoanMonths, @InterestRate, @LoanAmount, @TotalPayment)";

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
    var deleteStatement = "DELETE FROM LoanVariablesTable WHERE Id = @Id";

    SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
    deleteCommand.Parameters.AddWithValue("@Id", Id);

    sqlConnection.Open();
    deleteCommand.ExecuteNonQuery();
    sqlConnection.Close();
        }

        public void Update(SystemDataModel loanDS)
        {
            var updateStatement = "UPDATE LoanVariablesTable SET Name = @Name, Job = @Job, Salary = @Salary, Company = @Company, LoanMonths = @LoanMonths, InterestRate = @InterestRate, LoanAmount = @LoanAmount, TotalPayment = @TotalPayment WHERE Id = @Id";

    SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

    updateCommand.Parameters.AddWithValue("@Id", loanDS.Id);
    updateCommand.Parameters.AddWithValue("@Name", loanDS.Name);
    updateCommand.Parameters.AddWithValue("@Job", loanDS.Job);
    updateCommand.Parameters.AddWithValue("@Salary", loanDS.Salary);
    updateCommand.Parameters.AddWithValue("@Company", loanDS.Company);
    updateCommand.Parameters.AddWithValue("@LoanMonths", loanDS.LoanMonths);
    updateCommand.Parameters.AddWithValue("@InterestRate", loanDS.InterestRate);
    updateCommand.Parameters.AddWithValue("@LoanAmount", loanDS.LoanAmount);
    updateCommand.Parameters.AddWithValue("@TotalPayment", loanDS.TotalPayment);

    sqlConnection.Open();
    updateCommand.ExecuteNonQuery();
    sqlConnection.Close();



        }
        public SystemDataModel GetById(Guid Id)
        {
        return View().FirstOrDefault(x => x.Id == Id);
        }
    }
}
