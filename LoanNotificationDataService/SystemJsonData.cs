using LoanDataModel;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Text.Json;

namespace LoanNotificationDataService
{
    public class SystemJsonData : InterfaceLoanDataService
    {
        private List<SystemDataModel> Notiflist = new List<SystemDataModel>();

        private string _jsonFileName;

        public SystemJsonData()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/LoanSystemJSONDataFile.json";

            PopulateJsonFile();

        }
        private void PopulateJsonFile()
        {
            RetrieveDataFromJsonFile();

            if (Notiflist.Count <= 0)
            {
                Notiflist.Add(new SystemDataModel { Name = "Neo", Id = Guid.NewGuid(), Job = "Owner", Salary = 1000, LoanMonths = 12, InterestRate = 0.5 });

                SaveDataToJsonFile();
            }
        }

        private void SaveDataToJsonFile()
        {
            using (var outputStream = File.OpenWrite(_jsonFileName))
            {
                JsonSerializer.Serialize<List<SystemDataModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , Notiflist);
            }
        }

        private void RetrieveDataFromJsonFile()
        {
            using (var jsonFileReader = File.OpenText(_jsonFileName))
            {
                Notiflist = JsonSerializer.Deserialize<List<SystemDataModel>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
        }

        public void Create(SystemDataModel notif)
        {
            Notiflist.Add(notif);
            SaveDataToJsonFile();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void View()
        {
            throw new NotImplementedException();
        }

        public void Update(SystemDataModel loanDS)
        {
            throw new NotImplementedException();
        }

        List<SystemDataModel> InterfaceLoanDataService.View()
        {
            throw new NotImplementedException();
        }
    }
}
