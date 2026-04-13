using System;
using System.Collections.Generic;
using LoanNotificationDataService;
using LoanDataModel;

﻿namespace NotificationAppService
{
    public class SystemAppService
    { 
private readonly MediatorDataService mediator;

public SystemAppService(MediatorDataService mediatorService)
        { mediator = mediatorService;}
public void Create(SystemDataModel data)
        {mediator.Create(data);}
public List<SystemDataModel> GetAll()
        {return mediator.View();}
public void Update(SystemDataModel data)
        {mediator.Update(data);}
public void Delete(Guid id)
        {mediator.Delete(id);}
     }
}
