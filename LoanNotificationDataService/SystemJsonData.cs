using LoanDataModel;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace LoanNotificationDataService
{
    public class SystemJsonData :     InterfaceLoanDataService
    {
    private List<SystemDataModel> Notiflist = new List<SystemDataModel>();
    private string _jsonFileName;
    public SystemJsonData()
    { _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/LoanSystemJSONDataFile.json";
PopulateJsonFile();
         }

private void SaveDataToJsonFile()
{
    string jsonData = JsonSerializer.Serialize(Notiflist, new JsonSerializerOptions
    {
    WriteIndented = true
    });

File.WriteAllText(_jsonFileName, jsonData);
}


private void PopulateJsonFile()
{
    if (!File.Exists(_jsonFileName))
    {
File.WriteAllText(_jsonFileName, "[]");
    }

    RetrieveDataFromJsonFile();

    if (Notiflist.Count <= 0)
    {
    Notiflist.Add(new SystemDataModel {Name = "Neo", Id = Guid.NewGuid(), Job = "Owner", Salary = 1000, Company = "PUP", LoanMonths = 12, InterestRate = 0.5, LoanAmount = 10000, TotalPayment = 15000
    });
    SaveDataToJsonFile();
    }
}
           
private void RetrieveDataFromJsonFile()
{ 
     string jsonData =          
     File.ReadAllText(_jsonFileName);

     Notiflist = JsonSerializer.Deserialize<List<SystemDataModel>>(jsonData,
        new JsonSerializerOptions
        {
PropertyNameCaseInsensitive = true
}) ?? 
     new List<SystemDataModel>();
}
public void Create(SystemDataModel loanDS)
{
    RetrieveDataFromJsonFile();
    Notiflist.Add(loanDS);
    SaveDataToJsonFile();
}
public void Update(SystemDataModel    loanDS)
{
    RetrieveDataFromJsonFile();
    var existing = Notiflist.FirstOrDefault(x => x.Id == loanDS.Id);

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
 
    SaveDataToJsonFile();
     }
}
    public void Delete(Guid Id)
{
    RetrieveDataFromJsonFile();
    var existing = Notiflist.FirstOrDefault(x => x.Id == Id);
    if (existing != null)
    {
    Notiflist.Remove(existing);
    SaveDataToJsonFile();
    }
}
public List<SystemDataModel> View()
    {
    RetrieveDataFromJsonFile();
    return Notiflist;
    }      
            
        }
    }
}
