using System;
using System.Reflection;
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

        public static string FormatErrorMessage(string name, string errorMessageDictionaryKey)
        {
            //Get dictionary value for thge required error message
            var error = UmbracoHelper.GetDictionaryValue(errorMessageDictionaryKey);

            //Sanity checking it's not empty
            if (string.IsNullOrEmpty(error))
            {
                throw new Exception(string.Format("The dictionary key '{0}' for the required error message is empty or does not exist", errorMessageDictionaryKey));
            }

            // String replacment the token wiht our localised propertyname
            // The {{Field}} field is required
            error = error.Replace("{{Field}}", name);

            //Return the value
            return error;
        }

        public static string FormatRangeErrorMessage(string name, string errorMessageDictionaryKey, object min, object max)
        {
            //Get dictionary value for thge required error message
            var error = UmbracoHelper.GetDictionaryValue(errorMessageDictionaryKey);

            //Sanity checking it's not empty
            if (string.IsNullOrEmpty(error))
            {
                throw new Exception(string.Format("The dictionary key '{0}' for the required error message is empty or does not exist", errorMessageDictionaryKey));
            }

            //Convert object to int's
            var minVal = Convert.ToInt32(min);
            var maxVal = Convert.ToInt32(max);

            // String replacment the token wiht our localised propertyname
            // The field {{Field}} must be between {0} and {1}
            error = error.Replace("{{Field}}", name);
            error = string.Format(error, minVal, maxVal);

            //Return the value
            return error;
        }

        public static string FormatCompareErrorMessage(string name, string errorMessageDictionaryKey, string otherProperty)
        {
            //Get dictionary value for thge required error message
            var error = UmbracoHelper.GetDictionaryValue(errorMessageDictionaryKey);

            //Sanity checking it's not empty
            if (string.IsNullOrEmpty(error))
            {
                throw new Exception(string.Format("The dictionary key '{0}' for the required error message is empty or does not exist", errorMessageDictionaryKey));
            }

            //TODO - Somehow figure out
            //Get other property display name, but from UmbracoDisplay as getting C# property name
            

            // String replacment the token with our localised propertyname
            //'{{Field}}' and '{0}' do not match.
            error = error.Replace("{{Field}}", name);
            error = string.Format(error, otherProperty);

            //Return the value
            return error;
        }

        public static string FormatLengthErrorMessage(string name, string errorMessageDictionaryKey, int maxLength, int minLength)
        {
            //Get dictionary value for thge required error message
            var error = UmbracoHelper.GetDictionaryValue(errorMessageDictionaryKey);

            //Sanity checking it's not empty
            if (string.IsNullOrEmpty(error))
            {
                throw new Exception(string.Format("The dictionary key '{0}' for the required error message is empty or does not exist", errorMessageDictionaryKey));
            }


            // it's ok to pass in the minLength even for the error message without a {2} param since String.Format will just
            // ignore extra arguments

            // String replacment the token wiht our localised propertyname
            // The field {{Field}} must be less than {0} (MaxLength)
            // The field {{Field}} must be less than {0} (MaxLength) & greater than {1} (MinLength)
            error = error.Replace("{{Field}}", name);
            error = string.Format(error, maxLength, minLength);

            //Return the value
            return error;
        }
        
    }
}
