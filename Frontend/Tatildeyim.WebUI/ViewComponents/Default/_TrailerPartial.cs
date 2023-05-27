using Microsoft.AspNetCore.Mvc;

namespace Tatildeyim.WebUI.ViewComponents.Default
{
    public class _TrailerPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
