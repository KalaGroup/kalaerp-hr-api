using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation
{
    public static class CustomValidation
    {
        public static IRuleBuilder<T, string> ApplyAlphaNumeric<T>(this IRuleBuilder<T, string> ruleBuilder,
        string fieldName, int maxLength = 100, bool allowSpaces = false)
        {
            string pattern = allowSpaces ? "^[a-zA-Z0-9 ]*$" : "^[a-zA-Z0-9]*$";
            string errorMessage = $"{fieldName} must not contain special characters{(allowSpaces ? "" : " or spaces")}.";

            return ruleBuilder
                .NotEmpty().WithMessage($"{fieldName} is required.")
                .MaximumLength(maxLength)
                .Matches(pattern).WithMessage(errorMessage);
        }

        public static IRuleBuilder<T, int?> MustBeValidId<T>(this IRuleBuilder<T, int?> ruleBuilder, string fieldName)
        {
            return ruleBuilder
                .GreaterThan(0).WithMessage($"{fieldName} must be greater than 0.");
        }

        public static IRuleBuilder<T, int> MustBePresentWhenNew<T>(this IRuleBuilder<T, int> ruleBuilder, string fieldName)
        {
            return ruleBuilder
                .GreaterThan(0).WithMessage($"{fieldName} must be greater than zero.");
        }

        public static IRuleBuilder<T, DateTime> MustBePastOrNowWhenNew<T>(this IRuleBuilder<T, DateTime> ruleBuilder, string fieldName)
        {
            return ruleBuilder
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage($"{fieldName} can't be in the future.");
        }
    }
}
