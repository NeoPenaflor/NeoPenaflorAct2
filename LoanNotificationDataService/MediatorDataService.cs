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


        public void Create(SystemDataModel LoanDS)
        {
            _InterfaceLoanDataService.Create(LoanDS);
        }
        public void Update( ) { }
        public void Delete() { }
        public void View()   { }

    }
}
