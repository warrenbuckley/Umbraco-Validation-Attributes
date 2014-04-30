using System;
using System.ComponentModel;

namespace UmbracoValidationAttributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class UmbracoDisplayNameAttribute : DisplayNameAttribute
    {
        // This is a positional argument
        public UmbracoDisplayNameAttribute(string dictionaryKey) : base(dictionaryKey)
        {
        }

        public override string DisplayName
        {
            get
            {
                return UmbracoValidationHelper.UmbracoHelper.GetDictionaryValue(base.DisplayName);
            }
        }
    }
}
