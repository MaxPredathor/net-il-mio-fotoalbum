using Microsoft.AspNetCore.Mvc;

namespace net_il_mio_fotoalbum.Controllers
{
    public class Categories : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
