using DevExpress.Data.Filtering;
using DevExpress.Web.Mvc;
using DevExpress.XtraReports.UI;
using E4121.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E4121.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EmailDataGenerator.Register();
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            return PartialView("_GridViewPartial");
        }

        public ActionResult ExportTo(string filterString)
        {
            CriteriaOperator filterCriteria = CriteriaOperator.Parse(filterString);
            IList<Email> emails = LargeDatabaseDataProvider.GetEmailsByFilter(filterCriteria);

            XtraReport1 report = new XtraReport1();
            report.DataSource = emails;
            ExportReport(report, "largeData", true, "Xlsx");
            return GridViewPartial();
        }

        public void ExportReport(XtraReport report, string fileName, bool saveAsFile, string fileFormat)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                report.ExportToXlsx(stream);

                string disposition = saveAsFile ? "attachment" : "inline";

                Response.Clear();
                Response.Buffer = false;
                Response.AppendHeader("Content-Type", string.Format("application/{0}", fileFormat));
                Response.AppendHeader("Content-Transfer-Encoding", "binary");
                Response.AppendHeader("Content-Disposition", string.Format("{0}; filename={1}.{2}", disposition, HttpUtility.UrlEncode(fileName).Replace("+", "%20"), fileFormat));
                Response.BinaryWrite(stream.ToArray());
                Response.End();
            }
        }
    }
}