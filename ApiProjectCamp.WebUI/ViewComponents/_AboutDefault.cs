using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebUI.ViewComponents
{
    public class _AboutDefault : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
