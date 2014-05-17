using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UmbracoValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class UmbracoDataType : DataTypeAttribute, IClientValidatable
    {
        public UmbracoDataType(DataType type, string errorMessageDictionaryKey)
            : base(type)
        {
            ErrorMessage = UmbracoValidationHelper.GetDictionaryItem(errorMessageDictionaryKey);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(System.Web.Mvc.ModelMetadata metadata, ControllerContext context)
        {
            // Kodus to "Chad" http://stackoverflow.com/a/9914117
            yield return new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.DisplayName),
                ValidationType = this.DataType.ToString().ToLower()
            };
        }
    }
}