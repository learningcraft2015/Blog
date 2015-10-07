using PROJECT.Core.Helpers;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PROJECT.Web.Controllers
{
    public class BaseController : Controller
    {
        public void PageTitle(string pageTitle)
        {
            ViewBag.Title = string.IsNullOrEmpty(pageTitle) ? "Untitled Page" : pageTitle;

        }

      
           
    }
}