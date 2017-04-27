using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithWebSite.Models.ZenithModels.customValidation
{
    class DateRange : ValidationAttribute
    {
        private DateTime _minDate;
        private DateTime _maxDate;


        public DateRange() : base("{0} is exceed over the range of valid date.")
        {
            _minDate = DateTime.Now.AddYears(-10);
            _maxDate = DateTime.Now.AddYears(10);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
               
                if (date < _minDate || date > _maxDate)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            
            return ValidationResult.Success;
        }
    }
}
