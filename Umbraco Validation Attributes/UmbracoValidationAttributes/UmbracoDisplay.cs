using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web;

namespace UmbracoValidationAttributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class UmbracoDisplayNameAttribute : DisplayNameAttribute
    {
        public UmbracoHelper UmbracoHelper { get; set; }

        // This is a positional argument
        public UmbracoDisplayNameAttribute(string dictionaryKey)
            : base(dictionaryKey)
        {
            //Ensure we have a context
            if (UmbracoContext.Current == null)
            {
                throw new Exception("We have no Umbraco context, are you sure you are running this in Umbraco?");
            }

            //Setup Umbraco Helper for our inheriting classes to use as needed
            UmbracoHelper = new UmbracoHelper(UmbracoContext.Current);
        }

        public override string DisplayName
        {
            get
            {
                return UmbracoHelper.GetDictionaryValue(base.DisplayName);
            }
        }
    }
}
