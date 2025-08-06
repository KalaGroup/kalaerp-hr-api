using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.Currency;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

public class UpdateCurrencyRequestValidator : AbstractValidator<UpdateCurrencyRequest>
{
    private readonly KalaDbContext _context;
    public UpdateCurrencyRequestValidator(KalaDbContext context)
    {
        _context = context;

        RuleFor(x => x.CurrencyId)
            .NotEmpty().WithMessage("Currency ID is required.");

        RuleFor(x => x.CurrencyName)
            .NotEmpty().WithMessage("Currency name is required.")
            .MaximumLength(100).WithMessage("Currency name must not exceed 100 characters.")
            .Matches("^[a-zA-Z0-9 ]*$").WithMessage("Currency name must not contain special characters.")
            .MustAsync(BeUniqueCurrencyName).WithMessage("Currency name already exists.");

        RuleFor(x => x.CurrencySymbol)
       .NotEmpty().WithMessage("Currency symbol is required.")
       .Matches(@"^[\p{Sc}]$").WithMessage("Invalid currency symbol.")
       .MaximumLength(1).WithMessage("Currency symbol must be a single character.");


        RuleFor(x => x.CreatedBy)
            .NotEmpty().WithMessage("UpdatedBy is required.");
    }

    private async Task<bool> BeUniqueCurrencyName(UpdateCurrencyRequest request, string currencyName, CancellationToken cancellationToken)
    {
        return !await _context.CurrencyMasters
            .AnyAsync(c => c.CurrencyName.ToLower() == currencyName.ToLower() && c.CurrencyId != request.CurrencyId, cancellationToken);
    }
}

