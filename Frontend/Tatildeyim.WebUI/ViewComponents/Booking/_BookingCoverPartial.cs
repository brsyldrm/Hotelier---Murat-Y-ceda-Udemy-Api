using Microsoft.AspNetCore.Mvc;

namespace Tatildeyim.WebUI.ViewComponents.Booking
{
    public class _BookingCoverPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
