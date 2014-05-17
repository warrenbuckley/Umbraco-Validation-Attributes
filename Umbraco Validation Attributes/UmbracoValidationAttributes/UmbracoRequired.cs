using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UmbracoValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class UmbracoRequired : RequiredAttribute, IClientValidatable
    {
        public UmbracoRequired(string errorMessageDictionaryKey)
        {
            ErrorMessage = UmbracoValidationHelper.GetDictionaryItem(errorMessageDictionaryKey);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var error   = FormatErrorMessage(metadata.DisplayName);
            var rule    = new ModelClientValidationRequiredRule(error);

            yield return rule;
        }
    }
}
