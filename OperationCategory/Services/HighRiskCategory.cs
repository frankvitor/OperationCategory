using System;
using OperationCategory.Models;
using OperationCategory.services;

namespace OperationCategory.Services
{
    public class HighRiskCategory : ICategory
    {
        public string GetCategory(ITrade trade, DateTime referenceDate)
        {
            if(trade.Value > 1000000 && trade.ClientSector.ToLower().Trim() == ("Private").ToLower())
            {
                return "HIGHRISK";
            } 
            else 
            {
                return null;
            }
        }
    }
}