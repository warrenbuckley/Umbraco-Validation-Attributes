using System.ComponentModel.DataAnnotations;

namespace UmbracoValidationAttributes
{
    public class UmbracoRequired : RequiredAttribute
    {
        public string ErrorMessageDictionaryKey { get; set; }

        public override string FormatErrorMessage(string name)
        {
            //Get dictionary value for thge required error message
            //WB: UNSURE if this will double check our UmbContext exists or not
            ErrorMessage = UmbracoValidationHelper.UmbracoHelper.GetDictionaryValue(ErrorMessageDictionaryKey);

            return base.FormatErrorMessage(name);
        }
    }
}
