using LoanDataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanNotificationDataService
{
    public interface InterfaceLoanDataService
    {
        //lalagay ng 4 method add upd view delete

        void Create(SystemDataModel loanDS);
        void Update();
        void Delete();
        void View();

    }
}
