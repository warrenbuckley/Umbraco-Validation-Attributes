using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace UmbracoValidationAttributes
{
    public class UmbracoCompare : System.Web.Mvc.CompareAttribute, IClientValidatable
    {
        private readonly string _otherProperty;
        private readonly string _errorMessageDictionaryKey;


        public UmbracoCompare(string errorMessageDictionaryKey,string otherProperty)
            : base(otherProperty)
        {
            _otherProperty = otherProperty;
            _errorMessageDictionaryKey = errorMessageDictionaryKey;  
        }


        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ErrorMessage = UmbracoValidationHelper.GetDictionaryItem(_errorMessageDictionaryKey);

            var error = FormatErrorMessage(metadata.DisplayName);
            var rule = new ModelClientValidationEqualToRule(error, _otherProperty);

            yield return rule;
        }
    }
}
