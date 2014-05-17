using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UmbracoValidationAttributes
{
    public class UmbracoStringLength : StringLengthAttribute, IClientValidatable
    {

        public UmbracoStringLength(string errorMessageDictionaryKey, int maximumLength) : base(maximumLength)
        {
            ErrorMessage = UmbracoValidationHelper.GetDictionaryItem(errorMessageDictionaryKey);
        }


        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var error   = FormatErrorMessage(metadata.DisplayName);
            var rule    = new ModelClientValidationStringLengthRule(error, MinimumLength, MaximumLength);

            yield return rule;
        }
    }
}
