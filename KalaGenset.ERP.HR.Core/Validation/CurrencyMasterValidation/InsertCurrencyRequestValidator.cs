using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.Currency;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.CurrencyValidation
{
    public class InsertCurrencyRequestValidator : AbstractValidator<InsertCurrencyRequest>
    {
        private readonly KalaDbContext _context;
        /// <summary>
        /// Validates the properties of an <see cref="InsertCurrencyRequest"/> object to ensure they meet the required
        /// criteria.
        /// </summary>
        /// <remarks>This validator enforces the following rules: <list type="bullet">
        /// <item><description><c>CurrencyName</c> must be non-empty, no longer than 100 characters, contain only
        /// alphanumeric characters and spaces, and be unique.</description></item>
        /// <item><description><c>CurrencySymbol</c> must be non-empty and no longer than 10
        /// characters.</description></item> <item><description><c>CreatedBy</c> must be non-empty.</description></item>
        /// </list></remarks>
        /// <param name="context">The database context used to validate the uniqueness of the currency name.</param>
        public InsertCurrencyRequestValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.CurrencyName)
                .NotEmpty().WithMessage("Currency name is required.")
                .MaximumLength(100).WithMessage("Currency name must not exceed 100 characters.")
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage("Currency name must not contain special characters.")
                .MustAsync(BeUniqueCurrencyName).WithMessage("Currency name already exists.");

            RuleFor(x => x.CurrencySymbol)
                .NotEmpty().WithMessage("Currency symbol is required.")
             .MaximumLength(10).WithMessage("Currency symbol must not exceed 10 characters.")
            .Matches(@"^[\p{Sc}]$").WithMessage("Currency symbol must be a valid currency character.");

            RuleFor(x => x.CreatedBy)
           .NotEmpty().WithMessage("UpdatedBy is required.");
        }
        private async Task<bool> BeUniqueCurrencyName(string currencyName, CancellationToken cancellationToken)
        {
            return !await _context.CurrencyMasters
                .AnyAsync(c => c.CurrencyName.ToLower() == currencyName.ToLower(), cancellationToken);
        }
    }
}
    

