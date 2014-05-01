using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UmbracoValidationAttributes
{
    public class UmbracoRegularExpression : RegularExpressionAttribute, IClientValidatable
    {
        public string ErrorMessageDictionaryKey { get; set; }

        public UmbracoRegularExpression(string pattern)
            : base(pattern)
        {

        }

        public override string FormatErrorMessage(string name)
        {
            ErrorMessage = UmbracoValidationHelper.GetDictionaryItem(ErrorMessageDictionaryKey);
            ErrorMessage = base.FormatErrorMessage(name);
            return ErrorMessage;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(System.Web.Mvc.ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
           {
               ErrorMessage = FormatErrorMessage(metadata.DisplayName),
               ValidationType = "regex"
           };

            rule.ValidationParameters.Add("pattern", this.Pattern);

            yield return rule;
        }
    }
}