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
            ErrorMessageDictionaryKey = errorMessageDictionaryKey;
        }

        public UmbracoRange(string errorMessageDictionaryKey,double minimum, double maximum): base(minimum, maximum)
        {
            ErrorMessageDictionaryKey = errorMessageDictionaryKey;
        }

        public UmbracoRange(string errorMessageDictionaryKey, int minimum, int maximum)
            : base(minimum, maximum)
        {
            ErrorMessageDictionaryKey = errorMessageDictionaryKey;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ErrorMessage = UmbracoValidationHelper.GetDictionaryItem(ErrorMessageDictionaryKey);

            var error   = FormatErrorMessage(metadata.DisplayName);
            var rule    = new ModelClientValidationRangeRule(error, Minimum, Maximum);

            yield return rule;
        }
    }
}
