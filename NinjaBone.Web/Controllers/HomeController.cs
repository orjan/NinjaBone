using System.Web.Mvc;
using NinjaBone.Services.Ninja;

namespace NinjaBone.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INinjaService ninjaService;
        //
        // GET: /Home/

        public HomeController(INinjaService ninjaService)
        {
            this.ninjaService = ninjaService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ninjas()
        {
            return View(ninjaService.GetAllNinjas());
        }

    }
}