using System.Collections.Generic;
using System.Web.Mvc;

namespace UmbracoValidationAttributes
{
    public class UmbracoCompare : System.ComponentModel.DataAnnotations.CompareAttribute, IClientValidatable
    {
        /// <summary>
        /// 
        /// </summary>
        public string ErrorMessageDictionaryKey { get; set; }

        public UmbracoCompare(string otherProperty) : base(otherProperty)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            ErrorMessage = UmbracoValidationHelper.FormatCompareErrorMessage(name, ErrorMessageDictionaryKey, OtherProperty);
            return base.FormatErrorMessage(name);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {   
            var error   = UmbracoValidationHelper.FormatCompareErrorMessage(metadata.GetDisplayName(), ErrorMessageDictionaryKey, OtherPropertyDisplayName);
            var rule    = new ModelClientValidationEqualToRule(error, CompareAttribute.FormatPropertyForClientValidation(OtherProperty));

            yield return rule;
        }
    }
}
