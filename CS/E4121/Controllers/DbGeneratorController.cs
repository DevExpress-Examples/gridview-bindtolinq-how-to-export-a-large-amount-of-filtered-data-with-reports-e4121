using E4121.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E4121.Controllers
{
    public class DbGeneratorController : Controller
    {
        public ActionResult Create()
        {
            return new JsonResult
            {
                Data = DatabaseGenerator.TryCreateDatabase(GetTableKey())
            };
        }
        public ActionResult GetRecordCount()
        {
            return new JsonResult
            {
                Data = DatabaseGenerator.GetCreatingDatabaseRecordCount(GetTableKey())
            };
        }

        string GetTableKey()
        {
            return Request.Params["tableKey"];
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = new ContentResult()
            {
                Content = filterContext.Exception.Message,
                ContentType = "text/plain"
            };
            filterContext.ExceptionHandled = true;
            Response.StatusCode = 500;
        }
    }
}