using System;
using OperationCategory.Models;

namespace OperationCategory.services
{
    public interface ICategory
    {
        string GetCategory(ITrade trade, DateTime refenceDate);
    }
    
}