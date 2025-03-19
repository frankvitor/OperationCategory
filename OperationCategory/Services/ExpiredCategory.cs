using System;
using OperationCategory.Models;
using OperationCategory.services;

namespace OperationCategory.Services
{
    public class ExpiredCategory : ICategory
    {
        public string GetCategory(ITrade trade, DateTime referenceDate)
        {
            if(trade.NextPaymentDate < referenceDate.AddDays(-30))
            {
                return "EXPIRED";    
            }
            else
            { 
                return null; 
            }
        }
    }
}