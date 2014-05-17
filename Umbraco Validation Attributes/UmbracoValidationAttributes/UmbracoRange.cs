using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UmbracoValidationAttributes
{
    public class UmbracoRange : RangeAttribute, IClientValidatable
    {
        /// <summary>
        /// 
        /// </summary>
        public string ErrorMessageDictionaryKey { get; set; }

        public UmbracoRange(string errorMessageDictionaryKey, Type type, string minimum, string maximum)
            : base(type, minimum, maximum)
        {
            ErrorMessage = UmbracoValidationHelper.GetDictionaryItem(errorMessageDictionaryKey);
        }

        public UmbracoRange(string errorMessageDictionaryKey,double minimum, double maximum): base(minimum, maximum)
        {
            ErrorMessage = UmbracoValidationHelper.GetDictionaryItem(errorMessageDictionaryKey);
        }

        public UmbracoRange(string errorMessageDictionaryKey, int minimum, int maximum)
            : base(minimum, maximum)
        {
            ErrorMessage = UmbracoValidationHelper.GetDictionaryItem(errorMessageDictionaryKey);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var error   = FormatErrorMessage(metadata.DisplayName);
            var rule    = new ModelClientValidationRangeRule(error, Minimum, Maximum);

            yield return rule;
        }
    }
}
