using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialMedia.Common.Validations
{
    public class OneCharacterIsSmallLetterAttribute : ValidationAttribute
    {
        public OneCharacterIsSmallLetterAttribute()
        {
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var target = value as string;

            if (string.IsNullOrEmpty(target))
            {
                return ValidationResult.Success;
            }
            var haveSmall = target.Any(x => x >= 'a' && x <= 'z');

            if (!haveSmall)
            {
                return new ValidationResult("Must to be one character that is small letter");
            }
            return ValidationResult.Success;
        }
    }
}
