
using System.Web.Mvc;
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
