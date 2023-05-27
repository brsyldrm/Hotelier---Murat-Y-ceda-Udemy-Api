using Microsoft.AspNetCore.Mvc;

namespace Tatildeyim.WebUI.ViewComponents.Default
{
    public class _ReservationPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
