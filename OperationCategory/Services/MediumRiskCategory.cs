using OperationCategory.Models;
using OperationCategory.services;

namespace OperationCategory.Services
{
    public class MediumRiskCategory : ICategory
    {
        public string GetCategory(ITrade trade, DateTime referenceDate)
        {
            if(trade.Value > 1000000 && trade.ClientSector.ToLower().Trim() == ("Public").ToLower())
            {
                return "MEDIUMRISK";
            }
            else 
            {
                return null;
            }
        }
    }
}
