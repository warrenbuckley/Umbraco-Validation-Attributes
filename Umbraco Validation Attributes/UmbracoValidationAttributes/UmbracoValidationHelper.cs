using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Web;

namespace UmbracoValidationAttributes
{
    public static class UmbracoValidationHelper
    {
        public static UmbracoHelper UmbracoHelper { get; set; }

        static UmbracoValidationHelper()
        {
            //Ensure we have a context
            if (UmbracoContext.Current == null)
            {
                throw new Exception("We have no Umbraco context, are you sure you are running this in Umbraco?");
            }

            //Setup Umbraco Helper for our inheriting classes to use as needed
            UmbracoHelper = new UmbracoHelper(UmbracoContext.Current);
        }
    }
}
