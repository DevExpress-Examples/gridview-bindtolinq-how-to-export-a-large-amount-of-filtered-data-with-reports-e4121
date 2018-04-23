using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.Web.Mvc;
using DevExpress.Web.ASPxGridView;
using System.Data;
using WebReportRuntime;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using CS.Models;
using DevExpress.Data.Filtering;


namespace CS.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult DataBindingToLargeDatabasePartial() {
            return PartialView("GridViewPartial");
        }

        public ActionResult ExportTo(string filterString) {
            CriteriaOperator filterCriteria = CriteriaOperator.Parse(filterString);
            IList<Product> products = LargeDatabaseDataProvider.GetProductsByFilter(filterCriteria);

            XtraReport1 report = new XtraReport1();
            report.DataSource = products;
            ExportReport(report, "largeData", true, "Xlsx");
            return PartialView("GridViewPartial");
        }

        public void ExportReport(XtraReport report, string fileName, bool saveAsFile, string fileFormat) {
            using (MemoryStream stream = new MemoryStream()) {
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
