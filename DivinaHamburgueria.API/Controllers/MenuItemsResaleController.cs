using Microsoft.AspNetCore.Mvc;

namespace DivinaHamburgueria.API.Controllers
{
    public class MenuItemsResaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
