using LoanDataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanNotificationDataService
{
    public class MediatorDataService
    {
        InterfaceLoanDataService _InterfaceLoanDataService;
        public MediatorDataService(InterfaceLoanDataService interfaceLoanDataService)
        {
            _InterfaceLoanDataService = interfaceLoanDataService;
        }


        public void Create(SystemDataModel loanDS)
        {
            _InterfaceLoanDataService.Create(loanDS);
        }
        public void Update(SystemDataModel loanDS) { 
_InterfaceLoanDataService.Update(loanDS);
}
        public void Delete(Guid Id) { 
_InterfaceLoanDataService.Delete(Id);
}
        public List<SystemDataModel> View()   
        {
            return _InterfaceLoanDataService.View();
        }

    }
}
