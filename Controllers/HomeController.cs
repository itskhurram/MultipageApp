
using Microsoft.AspNetCore.Mvc;

namespace MultipageApp.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
