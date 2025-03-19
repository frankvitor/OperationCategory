using FluentValidation.Results;
using OperationCategory.Models;
using OperationCategory.Services;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace OperationCategory.Services
{
    public class TradeHandler
    {
        private readonly TradeService _tradeService;
        private readonly Validator _validator;

        public TradeHandler(DateTime referenceDate)
        {
            _tradeService = new TradeService();
            _validator = new Validator(referenceDate);
        }

        public List<ITrade> CollectTrades(int numberOfOperations)
        {
            var trades = new List<ITrade>();

            for (int i = 0; i < numberOfOperations; i++)
            {
                Console.WriteLine($"Fale os dados da operação {i + 1} (valor setor data): ");
                var input = Console.ReadLine()?.Split(' ');

                double _value = double.Parse(input[0]);
                string _clientSector = input[1];
                DateTime _nextPaymentDate = DateTime.ParseExact(input[2], "MM/dd/yyyy", CultureInfo.InvariantCulture);

                var trade = new Trade(_value, _clientSector, _nextPaymentDate);

                ValidationResult result = _validator.Validate(trade);

                if (!result.IsValid)
                {
                    Console.WriteLine("Erros encontrados:");
                    foreach (var error in result.Errors)
                    {
                        Console.WriteLine($" - {error.ErrorMessage}");
                    }
                    continue;
                }

                trades.Add(trade);
            }

            return trades;
        }

        public void DisplayCategories(List<ITrade> trades, DateTime referenceDate)
        {
            Console.WriteLine("\nCategorias das operações:\n");

            foreach (var trade in trades)
            {
                Console.WriteLine(_tradeService.CategorizeTrade(trade, referenceDate));
            }
        }
    }   
}