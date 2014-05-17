using System;
using System.ComponentModel;

namespace UmbracoValidationAttributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class UmbracoDisplayName : DisplayNameAttribute
    {
        // This is a positional argument
        public UmbracoDisplayName(string dictionaryKey)
            : base(UmbracoValidationHelper.UmbracoHelper.GetDictionaryValue(dictionaryKey))
        {
            
        }
    }
}
