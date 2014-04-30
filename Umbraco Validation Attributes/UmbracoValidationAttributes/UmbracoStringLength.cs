using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UmbracoValidationAttributes
{
    public class UmbracoStringLength : StringLengthAttribute, IClientValidatable
    {
        /// <summary>
        /// 
        /// </summary>
        public string ErrorMessageDictionaryKey { get; set; }

        public UmbracoStringLength(int maximumLength) : base(maximumLength)
        {
        }


        public override string FormatErrorMessage(string name)
        {
            ErrorMessage = UmbracoValidationHelper.FormatLengthErrorMessage(name, ErrorMessageDictionaryKey, MaximumLength, MinimumLength);
            return base.FormatErrorMessage(name);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var error   = UmbracoValidationHelper.FormatLengthErrorMessage(metadata.GetDisplayName(), ErrorMessageDictionaryKey, MaximumLength, MinimumLength);
            var rule    = new ModelClientValidationStringLengthRule(error, MinimumLength, MaximumLength);

            yield return rule;
        }
    }
}
