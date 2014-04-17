using UmbracoValidationAttributes;

namespace ExampleSite.ViewModels
{
    public class ContactFormViewModel
    {

        [UmbracoRequired(ErrorMessageDictionaryKey = "Site.Contact.Required", PropertyDictionaryKey = "Site.Contact.FirstName")]
        public string FirstName { get; set; }

        public string Surname { get; set; }

        [UmbracoRequired(ErrorMessageDictionaryKey = "Site.Contact.Required", PropertyDictionaryKey = "Site.Contact.Email")]
        [UmbracoEmail(ErrorMessageDictionaryKey = "Site.Contact.InvalidEmail", PropertyDictionaryKey = "Site.Contact.Email")]
        public string Email { get; set; }

        [UmbracoRequired(ErrorMessageDictionaryKey = "Site.Contact.Required", PropertyDictionaryKey = "Site.Contact.Message")]
        public string Message { get; set; }

        [UmbracoMustBeTrue(ErrorMessageDictionaryKey = "Site.Contact.Required", PropertyDictionaryKey = "Site.Contact.AgreeTerms")]
        public bool AcceptedTerms { get; set; }
    }
}