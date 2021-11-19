using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebMvc.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
