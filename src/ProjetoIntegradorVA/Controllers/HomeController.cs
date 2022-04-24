using System;
using System.Web.Mvc;

namespace ProjetoIntegradorVA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Mascaras()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult TestingEnvVariable()
        {
            var envVar = Environment.GetEnvironmentVariable("FunctionalTests");
            if (envVar == null)
                throw new Exception("Environment Variable was not injected!!");

            return RedirectToAction("Index");
        }

        public ActionResult TestingConfigTransformVariable()
        {
            return Content(System.Configuration.ConfigurationManager.AppSettings["EnvironmentName"]);
        }
    }
}