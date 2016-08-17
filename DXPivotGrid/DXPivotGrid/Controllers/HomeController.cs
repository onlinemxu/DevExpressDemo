using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DXPivotGrid.Infrastructure;

namespace DXPivotGrid.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            var gateway = new DataGateway("(local)", "InsightSystem");
            var result = gateway.GetDataset("demo", "select * from AnalysisReports", CommandType.Text);

            ViewBag.Message = "DevExpress Pivot Grid Demo: " + result.Tables[0].Rows.Count;

            return View();
        }

        public ActionResult PivotGridPartial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateGridState()
        {
            ViewBag.Message = "PivotGrid state has been updated.";
            return View("Index");
        }
    }
}