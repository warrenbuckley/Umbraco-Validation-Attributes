using System.ComponentModel.DataAnnotations;
using UmbracoValidationAttributes;

namespace ExampleSite.ViewModels
{
    public class ContactFormViewModel
    {

        [UmbracoRequired(ErrorMessageDictionaryKey = "Site.Contact.Required")]
        [UmbracoDisplayName("Site.Contact.FirstName")]
        public string FirstName { get; set; }

        [UmbracoDisplayName("Site.Contact.Surname")]
        [UmbracoRemote("IsValid", "RemoteValidationSurface", ErrorMessageDictionaryKey = "Site.Contact.Surname.Remote", AdditionalFields = "FirstName")]
        public string Surname { get; set; }

        [UmbracoRequired(ErrorMessageDictionaryKey = "Site.Contact.Required")]
        [UmbracoEmail(ErrorMessageDictionaryKey = "Site.Contact.InvalidEmail")]
        [UmbracoDisplayName("Site.Contact.Email")]
        public string Email { get; set; }

        [UmbracoRequired(ErrorMessageDictionaryKey = "Site.Contact.Required")]
        [UmbracoDisplayName("Site.Contact.Message")]
        public string Message { get; set; }

        [UmbracoMustBeTrue(ErrorMessageDictionaryKey = "Site.Contact.Required")]
        [UmbracoDisplayName("Site.Contact.AgreeTerms")]
        public bool AcceptedTerms { get; set; }

        [UmbracoRange(18,30, ErrorMessageDictionaryKey = "Site.Contact.Age.Range")]
        [UmbracoDisplayName("Site.Contact.Age")]
        public int Age { get; set; }

        [UmbracoRequired(ErrorMessageDictionaryKey = "Site.Contact.Required")]
        [UmbracoDisplayName("Site.Contact.Password")]
        public string Password { get; set; }

        [UmbracoRequired(ErrorMessageDictionaryKey = "Site.Contact.Required")]
        [UmbracoDisplayName("Site.Contact.ConfirmPassword")]
        [UmbracoCompare("Password", ErrorMessageDictionaryKey = "Site.Contact.Compare")]
        public string ConfirmPassword { get; set; }
    }
}