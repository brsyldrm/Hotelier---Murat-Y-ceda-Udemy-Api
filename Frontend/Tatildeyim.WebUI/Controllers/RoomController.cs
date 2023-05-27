using Microsoft.AspNetCore.Mvc;

namespace Tatildeyim.WebUI.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
