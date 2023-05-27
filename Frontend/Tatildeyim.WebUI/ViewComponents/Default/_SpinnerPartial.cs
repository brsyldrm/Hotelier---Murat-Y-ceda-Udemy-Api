using Microsoft.AspNetCore.Mvc;

namespace Tatildeyim.WebUI.ViewComponents.Default
{
    public class _SpinnerPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
