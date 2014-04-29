using System;
using System.Net.Mail;
using System.Web.Mvc;
using ExampleSite.ViewModels;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace ExampleSite.Controllers.Surface
{
    public class ContactFormSurfaceController : SurfaceController
    {
        /// <summary>
        /// Renders the Contact Form
        /// @Html.Action("RenderContactForm","ContactFormSurface");
        /// </summary>
        /// <returns></returns>
        public ActionResult RenderContactForm()
        {
            //Return a partial view Form.cshtml in /Views/Partials/Contact/
            //With an empty/new ContactFormViewModel
            return PartialView("~/Views/Partials/Form.cshtml", new ContactFormViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HandleContactForm(ContactFormViewModel model)
        {
            //Check if the dat posted is valid (All required's & email set in email field)
            if (!ModelState.IsValid)
            {
                //Not valid - so lets return the user back to the view with the data they entered still prepopulated
                return CurrentUmbracoPage();
            }

            //Get Current Node
            var currentNodeId   = UmbracoContext.PageId;
            var currentNode     = Umbraco.TypedContent(currentNodeId);

            //Get Email Settings
            var emailTo             = currentNode.GetPropertyValue<string>("emailTo");
            var emailSubjectLine    = currentNode.GetPropertyValue<string>("subjectLine");
            var emailMessage        = currentNode.GetPropertyValue<string>("messageFormat");

            //Email Message Token Replacment
            emailMessage = TokenizeEmail(emailMessage, model);

            //Generate an email message object to send
            MailMessage email   = new MailMessage(model.Email, emailTo);
            email.Subject       = emailSubjectLine;
            email.Body          = emailMessage;
            email.IsBodyHtml    = false;

            try
            {
                //Connect to SMTP credentials set in web.config
                SmtpClient smtp = new SmtpClient();

                //Try & send the email with the SMTP settings
                smtp.Send(email);
            }
            catch (Exception ex)
            {
                //Throw an exception if there is a problem sending the email
                throw ex;
            }

            //Update success flag (in a TempData key)
            TempData["IsSuccessful"] = true;

            //All done - lets redirect to the current page & show our thanks/success message
            return RedirectToCurrentUmbracoPage();
        }


        /// <summary>
        /// Replace & tokenise email
        /// </summary>
        /// <param name="emailMessage"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public string TokenizeEmail(string emailMessage, ContactFormViewModel model)
        {
            if (string.IsNullOrEmpty(emailMessage))
            {
                return null;
            }

            //Easy string replacement
            emailMessage = emailMessage.Replace("{{FirstName}}", model.FirstName);
            emailMessage = emailMessage.Replace("{{Surname}}", model.Surname);
            emailMessage = emailMessage.Replace("{{Email}}", model.Email);
            emailMessage = emailMessage.Replace("{{Message}}", model.Message);
            emailMessage = emailMessage.Replace("{{AcceptedTerms}}", model.AcceptedTerms.ToString());

            return emailMessage;
        }

    }
}
