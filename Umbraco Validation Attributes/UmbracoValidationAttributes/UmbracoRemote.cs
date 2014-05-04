using System.Collections.Generic;
using System.Web.Mvc;

namespace UmbracoValidationAttributes
{
    public class UmbracoRemote : RemoteAttribute, IClientValidatable
    {
        /// <summary>
        /// 
        /// </summary>
        public string ErrorMessageDictionaryKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UmbracoRemote()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="routeName"></param>
        public UmbracoRemote(string routeName): base(routeName)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="controller"></param>
        public UmbracoRemote(string action, string controller):base(action, controller)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="controller"></param>
        /// <param name="areaName"></param>
        public UmbracoRemote(string action, string controller, string areaName): base(action, controller, areaName)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override string FormatErrorMessage(string name)
        {
            //Get dictionary value for thge required error message
            //WB: UNSURE if this will double check our UmbContext exists or not
            ErrorMessage = UmbracoValidationHelper.FormatErrorMessage(name, ErrorMessageDictionaryKey);

            return base.FormatErrorMessage(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var error   = FormatErrorMessage(metadata.DisplayName);
            var rule    = new ModelClientValidationRemoteRule(error, GetUrl(context), HttpMethod, FormatAdditionalFieldsForClientValidation(metadata.PropertyName));

            yield return rule;
        }
    
    
    }
}