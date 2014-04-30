using System;
using System.Web.Mvc;
using Umbraco.Web;

namespace UmbracoValidationAttributes
{
    public class UmbracoRemoteAttribute : RemoteAttribute
    {
        public UmbracoHelper UmbracoHelper { get; set; }
        public string ErrorMessageDictionaryKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UmbracoRemoteAttribute()
        {
            SetUmbracoItems();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="routeName"></param>
        public UmbracoRemoteAttribute(string routeName): base(routeName)
        {
            SetUmbracoItems();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="controller"></param>
        public UmbracoRemoteAttribute(string action, string controller):base(action, controller)
        {
            SetUmbracoItems();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="controller"></param>
        /// <param name="areaName"></param>
        public UmbracoRemoteAttribute(string action, string controller, string areaName): base(action, controller, areaName)
        {
            SetUmbracoItems();
        }

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override string FormatErrorMessage(string name)
        {
            //Get dictionary value for thge required error message
            ErrorMessage = UmbracoHelper.GetDictionaryValue(ErrorMessageDictionaryKey);

            return base.FormatErrorMessage(name);
        }
    
    
    }
}