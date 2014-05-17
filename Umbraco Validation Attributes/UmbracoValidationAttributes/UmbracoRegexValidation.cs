using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UmbracoValidationAttributes
{
    public class UmbracoRegularExpression : RegularExpressionAttribute, IClientValidatable
    {
        public UmbracoRegularExpression(string errorMessageDictionaryKey,string pattern): base(pattern)
        {
            UmbracoValidationHelper.GetDictionaryItem(errorMessageDictionaryKey);
        }


        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var error           = FormatErrorMessage(metadata.DisplayName);
            var rule            = new ModelClientValidationRule();
            rule.ErrorMessage   = error;
            rule.ValidationType = "regex";

            rule.ValidationParameters.Add("pattern", this.Pattern);

            yield return rule;
        }
    }
}