using Microsoft.AspNetCore.Mvc;

namespace Tatildeyim.WebUI.ViewComponents.Default
{
    public class _NavbarPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
