using Microsoft.AspNetCore.Mvc;

namespace NLayer.API.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
