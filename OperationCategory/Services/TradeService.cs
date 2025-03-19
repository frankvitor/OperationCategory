using System;
using System.Collections.Generic;
using OperationCategory.Models;
using OperationCategory.services;

namespace OperationCategory.Services
{
    public class TradeService
    {
        private readonly List<ICategory> _category;

        public TradeService()
        {
            _category = new List<ICategory>
            {
                new ExpiredCategory(),
                new HighRiskCategory(),
                new MediumRiskCategory()
            };
        }

        public string CategorizeTrade(ITrade trade, DateTime referenceDate)
        {
            foreach (var regra in _category)
            {
                var category = regra.GetCategory(trade, referenceDate);
                if (category != null)
                {
                    return category;
                }
            }
            return "NÃO IDENTIFICADO";
        }
    }
}
