using System;
using System.Net.Mail;
using System.Web.Mvc;
using ExampleSite.ViewModels;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace ExampleSite.Controllers.Surface
{
    public class RemoteValidationSurfaceController : SurfaceController
    {
        public JsonResult IsValid(string surname, string firstname)
        {
            return Json((surname != firstname), JsonRequestBehavior.AllowGet);
        }

    }
}
