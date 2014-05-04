using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UmbracoValidationAttributes
{
    public class UmbracoRegularExpression : RegularExpressionAttribute, IClientValidatable
    {
        public string ErrorMessageDictionaryKey { get; set; }

        public UmbracoRegularExpression(string pattern): base(pattern)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            ErrorMessage = UmbracoValidationHelper.GetDictionaryItem(ErrorMessageDictionaryKey);
            ErrorMessage = base.FormatErrorMessage(name);
            return ErrorMessage;
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