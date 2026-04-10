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


        void Create() { }
        void Update() { }
        void Delete() { }
        void View()   { }

    }
}
