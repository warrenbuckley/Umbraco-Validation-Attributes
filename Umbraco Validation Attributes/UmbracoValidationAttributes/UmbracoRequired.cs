using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UmbracoValidationAttributes
{
    public class UmbracoRequired : BaseUmbracoValidation, IClientValidatable
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //String is empty - it's required
            if (string.IsNullOrEmpty(Convert.ToString(value)))
            {
                //Get the error message to return
                var error = FormatErrorMessage(validationContext.DisplayName);

                //Return error
                return new ValidationResult(error);
            }

            //All good :)
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRequiredRule(this.FormatErrorMessage(metadata.GetDisplayName()));
        }

    }
}
