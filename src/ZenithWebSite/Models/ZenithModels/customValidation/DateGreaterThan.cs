using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZenithWebSite.Models.ZenithModels.customValidation
{
    class DateGreaterThan : ValidationAttribute
    {
        private readonly string _dateFrom;
        

        public DateGreaterThan(string dateFrom) : base("{0} is not later.")
        {
            _dateFrom = dateFrom;
            
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime dateTo = (DateTime)value;
                DateTime dateFrom = (DateTime)validationContext.ObjectType.GetProperty(_dateFrom).GetValue(validationContext.ObjectInstance, null);

                if (dateTo <= dateFrom)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            
            return ValidationResult.Success;
        }
    }
}
