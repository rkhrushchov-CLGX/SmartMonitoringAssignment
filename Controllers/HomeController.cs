using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Service Management Page";

            return View(ServicesRepo.GetServicesList(GetServicesFilePath())); 
        }        

        public ActionResult GreateService()
        {
            return View();
        }

        public ActionResult EditService(int id)
        {
            return View(ServicesRepo.GetService(id, GetServicesFilePath()));
        }


        [HttpPost]
        public ActionResult EditService(Service srvc)
        {
            ServicesRepo.UpdateService(srvc, GetServicesFilePath());
            return RedirectToAction("Index");
        }

       
        [HttpPost]
        public ActionResult GreateService(Service srvc )
        {
            ServicesRepo.AddNewService(srvc, GetServicesFilePath());
            return RedirectToAction("Index");
        }

       
        [HttpPost]
        public ActionResult SaveService(Service srvc)
        {
            ServicesRepo.UpdateService(srvc, GetServicesFilePath());
            return RedirectToAction("Index");
        }

       
        public ActionResult DeleteService(int id)
        {
            ServicesRepo.DeleteService(id, GetServicesFilePath());
            return RedirectToAction("Index");
        }

        public ActionResult ServiceDetails(int id)
        {
            return View(ServicesRepo.GetService(id, GetServicesFilePath()));
        }

        private IEnumerable<Service> LoadServicesList()
        {          

            return ServicesRepo.GetServicesList(GetServicesFilePath());
        }

        private string GetServicesFilePath()
        {
            return Server.MapPath("~/App_Data/Services.json");
        }

        [HttpPost]
        public ActionResult Index(Service srvc)
        {
            ServicesRepo.UpdateService(srvc, GetServicesFilePath());
            return RedirectToAction("Index");
        }
    }
}
