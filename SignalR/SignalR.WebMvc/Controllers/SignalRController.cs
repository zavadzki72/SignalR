using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebMvc.Controllers
{
    public class SignalRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
