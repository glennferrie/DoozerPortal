using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;

namespace ferrienet_api_backplane.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index(string id)
        {
            var account = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["ferrie-storage"].ConnectionString);
            var client = account.CreateCloudTableClient();
            var table = client.GetTableReference("apibackplane");
            table.CreateIfNotExists();
            
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}