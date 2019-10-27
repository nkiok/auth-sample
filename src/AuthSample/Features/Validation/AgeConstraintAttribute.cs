using System;
using System.ComponentModel.DataAnnotations;

namespace AuthSample.Features.Validation
{
    public class AgeConstraintAttribute : ValidationAttribute
    {
        public int AtLeastYears { get; set; }

        public AgeConstraintAttribute()
        {
            AtLeastYears = 0;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;

            var date = (DateTime)value;

            return date.AddYears(AtLeastYears) <= DateTime.Today;
        }
    }
}
