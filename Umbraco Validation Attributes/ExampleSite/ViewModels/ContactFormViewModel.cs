
using System.ComponentModel.DataAnnotations;
using System.Web;
using UmbracoValidationAttributes;

namespace ExampleSite.ViewModels
{
    public class ContactFormViewModel
    {

        [UmbracoRequired("Site.Contact.Required")]
        [UmbracoDisplayName("Site.Contact.FirstName")]
        public string FirstName { get; set; }

        [UmbracoDisplayName("Site.Contact.Surname")]
        [UmbracoRemote("IsValid", "RemoteValidationSurface", ErrorMessageDictionaryKey = "Site.Contact.Surname.Remote", AdditionalFields = "FirstName")]
        public string Surname { get; set; }

        [UmbracoDataType(DataType.PhoneNumber, "Site.Contact.Phone.Type")]
        [UmbracoDisplayName("Site.Contact.Phone")]
        public string Phone { get; set; }

        [UmbracoRequired("Site.Contact.Required")]
        [UmbracoEmail(ErrorMessageDictionaryKey = "Site.Contact.InvalidEmail")]
        [UmbracoDisplayName("Site.Contact.Email")]
        public string Email { get; set; }

        [UmbracoRequired("Site.Contact.Required")]
        [UmbracoDisplayName("Site.Contact.Message")]
        public string Message { get; set; }

        [UmbracoMustBeTrue(ErrorMessageDictionaryKey = "Site.Contact.Required")]
        [UmbracoDisplayName("Site.Contact.AgreeTerms")]
        public bool AcceptedTerms { get; set; }

        [UmbracoRange("Site.Contact.Age.Range",18,30)]
        [UmbracoDisplayName("Site.Contact.Age")]
        public int Age { get; set; }

        [UmbracoRequired("Site.Contact.Required")]
        [UmbracoDisplayName("Site.Contact.Password")]
        [UmbracoRegularExpression("Site.Contact.Password.Regex", "^.*(?=.{8,})(?=.*[a-zA-Z])(?=.*\\d)(?=.*[!#$%&? \"]).*$")]
        public string Password { get; set; }

        [UmbracoRequired("Site.Contact.Required")]
        [UmbracoDisplayName("Site.Contact.ConfirmPassword")]
        [UmbracoCompare("Site.Contact.Compare", "Password")]
        public string ConfirmPassword { get; set; }

        [UmbracoStringLength("Site.Contact.StringLength",10, MinimumLength = 5)]
        public string StringLength { get; set; }

    }
}