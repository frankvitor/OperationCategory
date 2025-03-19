using System;
using FluentValidation;
using OperationCategory.Models;

public class Validator : AbstractValidator<Trade>
{
    public Validator(DateTime referenceDate)
    {
        RuleFor(t => t.Value).GreaterThan(0).WithMessage("O valor precisa ser maior que Zero.");
    }
}