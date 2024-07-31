using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialMedia.Common.Validations
{
    public class OneCharacterIsBigLetterAttribute : ValidationAttribute
    {
        public OneCharacterIsBigLetterAttribute()
        {
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var target = value as string;

            if (string.IsNullOrEmpty(target))
            {
                return ValidationResult.Success;
            }
            var haveBig = target.Any(x => x >= 'A' && x <= 'Z');

            if (!haveBig)
            {
                return new ValidationResult("Must to be one character that is big letter");
            }
            return ValidationResult.Success;
        }
    }
}
