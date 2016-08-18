using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DXPivotGrid.Infrastructure;
using DXPivotGrid.Models;

namespace DXPivotGrid.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var report = Report;

            ViewBag.Message = $"Dataset table name: [{report.ReportDataSet.Tables[0].TableName}], row count: {report.ReportDataSet.Tables[0].Rows.Count} ";

            return View(Report);
        }

        public ActionResult PivotGridPartial()
        {
            return PartialView(Report);
        }

        [HttpPost]
        public ActionResult PivotGridCustomCallback(string flag)
        {
            ViewBag.Action = flag;
            return PartialView("PivotGridPartial", Report);
        }

        [HttpPost]
        public ActionResult UpdateGridState()
        {
            ViewBag.Message = "PivotGrid state has been updated.";
            return View("Index");
        }

        private AnalysisReport Report
        {
            get
            {
                if (Session["report"] == null)
                {
                    var gateway = new DataGateway("(local)", "InsightWarehouse");
                    var result = gateway.GetDataset("GLTran", "select * from v_AcctTran", CommandType.Text);
                    var report = PrepareReport();
                    report.ReportDataSet = result;

                    Session["report"] = report;
                }
                return (AnalysisReport) Session["report"];
            }
        }

        private AnalysisReport PrepareReport()
        {
            var report = new AnalysisReport
            {
                DataSource = "",
                DataSourceType = TenantServiceType.Warehouse

            };

            return report;
        }
    }
}