using LoanDataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanNotificationDataService
{
    public interface InterfaceLoanDataService
    {
        SystemDataModel GetById(Guid Id);

        void Create(SystemDataModel loanDS);
        void Update(SystemDataModel loanDS);
        void Delete(Guid Id);
        List<SystemDataModel> View();

    }
}
