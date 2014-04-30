using System;
using System.ComponentModel.DataAnnotations;
using Umbraco.Web;

namespace UmbracoValidationAttributes
{
    [Obsolete("Will be moving this out to a helper, so we inherit the native .NET attributes")]
    public class BaseUmbracoValidation : ValidationAttribute
    {

        public UmbracoHelper UmbracoHelper { get; set; }

        /// <summary>
        /// This is a dictionary key in Umbraco for the Error message so it can be translated.
        /// Recommened to have the following token {{Field}} so the property name can be translated into the message
        /// eg 'MySite.Errors.Required' The {{Field}} is required
        /// </summary>
        public string ErrorMessageDictionaryKey { get; set; }

        public BaseUmbracoValidation()
        {
            //Ensure we have a context
            if (UmbracoContext.Current == null)
            {
                throw new Exception("We have no Umbraco context, are you sure you are running this in Umbraco?");
            }

            //Setup Umbraco Helper for our inheriting classes to use as needed
            UmbracoHelper = new UmbracoHelper(UmbracoContext.Current);
        }

        public override string FormatErrorMessage(string name)
        {
            //Get dictionary value for thge required error message
            var error = UmbracoHelper.GetDictionaryValue(ErrorMessageDictionaryKey);

            //Sanity checking it's not empty
            if (string.IsNullOrEmpty(error))
            {
                throw new Exception(string.Format("The dictionary key '{0}' for the required error message is empty or does not exist", ErrorMessageDictionaryKey));
            }

            // String replacment the token wiht our localised propertyname
            // The {{Field}} field is required
            error = error.Replace("{{Field}}", name);

            //Return the value
            return error;
        }
    }
}
