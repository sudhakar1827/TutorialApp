using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace asp.netCoreIntro.Controllers
{
    public class BookController : Controller
    {
        public IActionResult books()
        {
            return View();
        }
    }
}
