using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AuthSample.Features.Validation
{
    public class DateModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var dobValidation = GetValueWithValidation(bindingContext, nameof(DateTime.Day), 1, 31)
                .Bind(day => GetValueWithValidation(bindingContext, nameof(DateTime.Month), 1, 12)
                    .Bind(month => GetValueWithValidation(bindingContext, nameof(DateTime.Year), 1900, DateTime.Today.Year)
                        .Bind(year => TryToParseDate($"{day}/{month}/{year}", ValidationMessages.InvalidDate))));

            if (dobValidation.IsFailure)
            {
                bindingContext.ModelState.TryAddModelError(bindingContext.FieldName, dobValidation.Error);

                bindingContext.Result = ModelBindingResult.Failed();

                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(dobValidation.Value);

            return Task.CompletedTask;
        }

        private static Result<DateTime> TryToParseDate(string date, string errorMessage)
        {
            return DateTime.TryParseExact(date, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dob)
                ? Result.Ok(dob)
                : Result.Failure<DateTime>($"{date} {errorMessage}");
        }

        private static Result<string> GetValueWithValidation(ModelBindingContext bindingContext, string name, int lower, int upper)
        {
            var result = bindingContext.ValueProvider.GetValue($"{bindingContext.FieldName}{name}");

            return result != ValueProviderResult.None && InRange(result.FirstValue, lower, upper)
                ? Result.Ok(result.FirstValue)
                : Result.Failure<string>($"{result.FirstValue} is not a valid value for {name}.");
        }

        private static bool InRange(string value, int lower, int upper)
        {
            var success = int.TryParse(value, out var parseResult);

            return success && Enumerable.Range(lower, upper - lower + 1).Contains(parseResult);
        }
    }
}
