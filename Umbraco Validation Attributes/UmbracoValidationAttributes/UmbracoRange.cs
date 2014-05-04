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

        public UmbracoRange(Type type, string minimum, string maximum): base(type, minimum, maximum)
        {
        }

        public UmbracoRange(double minimum, double maximum): base(minimum, maximum)
        {
        }

        public UmbracoRange(int minimum, int maximum): base(minimum, maximum)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            ErrorMessage = UmbracoValidationHelper.FormatRangeErrorMessage(name, ErrorMessageDictionaryKey, Minimum, Maximum);
            return base.FormatErrorMessage(name);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var error   = FormatErrorMessage(metadata.DisplayName);
            var rule    = new ModelClientValidationRangeRule(error, Minimum, Maximum);

            yield return rule;
        }
    }
}
