using System;
using System.Web.Mvc;
using Umbraco.Web;

namespace UmbracoValidationAttributes
{
    public class UmbracoRemoteAttribute : RemoteAttribute
    {
        public UmbracoHelper UmbracoHelper { get; set; }
        public string ErrorMessageDictionaryKey { get; set; }

        public UmbracoRemoteAttribute(): base()
        {
            SetUmbracoItems();
        }

        public UmbracoRemoteAttribute(string routeName)
            : base(routeName)
        {
            SetUmbracoItems();
        }

        public UmbracoRemoteAttribute(string action, string controller):base(action, controller){
            SetUmbracoItems();
        }

        public UmbracoRemoteAttribute(string action, string controller, string areaName): base(action, controller, areaName)
        {
            SetUmbracoItems();
        }

        private void SetUmbracoItems()
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
            ErrorMessage = UmbracoHelper.GetDictionaryValue(ErrorMessageDictionaryKey);

            return base.FormatErrorMessage(name);
        }
    
    
    }
}