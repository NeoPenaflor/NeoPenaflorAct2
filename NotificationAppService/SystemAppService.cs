using System;
using System.Collections.Generic;
using LoanNotificationDataService;
using LoanDataModel;

namespace NotificationAppService
{
    public class SystemAppService
    {

        MediatorDataService dataServFunctions = new MediatorDataService(new LoanDBData());

        public void Create(string name, string job, double slry, string compny, int LnMonths, double intRate)
        {
            SystemDataModel data = new SystemDataModel
            {
                Name = name,
                Id = Guid.NewGuid(),
                Job = job,
                Salary = slry,
                Company = compny,
                LoanMonths = LnMonths,
                InterestRate = intRate
            };

            dataServFunctions.Create(data);




        }

        //public SystemAppService(MediatorDataService mediatorService)
        //        { mediator = mediatorService;}
        //public void Create(SystemDataModel data)
        //        {mediator.Create(data);}
        //public List<SystemDataModel> GetAll()
        //        {return mediator.View();}
        //public void Update(SystemDataModel data)
        //        {mediator.Update(data);}
        //public void Delete(Guid id)
        //        {mediator.Delete(id);}
        //     }
    }
}
