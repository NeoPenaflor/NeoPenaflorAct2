using System;
﻿namespace LoanDataModel

{
    public class SystemDataModel
    {
    public string Name         { get;set; }
    public Guid Id             { get;set; }
    public string Job          { get;set; }
    public double Salary       { get;set; }
    public string Company      { get;set; }
    public int LoanMonths      { get;set; }
    public double InterestRate { get;set; }
    }
}

