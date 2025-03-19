using FluentValidation.Results;
using OperationCategory.Models;
using OperationCategory.Services;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace OperationCategory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Data de referência (MM/DD/YYYY): ");
             if (!DateTime.TryParse(Console.ReadLine(), out DateTime referenceDate))
            {
                Console.WriteLine("Data inválida. Use o formato MM/DD/YYYY.");
                return;
            }

            var tradeHandler = new TradeHandler(referenceDate);
    
            Console.WriteLine("DIgite o número de operações: ");
            if (!int.TryParse(Console.ReadLine(), out int numberOfOperations) || numberOfOperations <= 0)
            {
                Console.WriteLine("Número inválido.");
                return;
            }
    
            var trades = tradeHandler.CollectTrades(numberOfOperations);
            
            tradeHandler.DisplayCategories(trades, referenceDate);
        }
    }
}