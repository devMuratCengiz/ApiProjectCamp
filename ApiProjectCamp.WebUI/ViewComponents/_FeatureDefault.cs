using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebUI.ViewComponents
{
    public class _FeatureDefault: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
