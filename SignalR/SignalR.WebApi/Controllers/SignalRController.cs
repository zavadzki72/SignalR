using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.WebApi.Models.Hubs;
using System.Threading.Tasks;

namespace SignalR.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignalRController : ControllerBase
    {

        private readonly IHubContext<StreamingHub> _streaming;

        public SignalRController(IHubContext<StreamingHub> streaming)
        {
            _streaming = streaming;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromForm] string message)
        {
            await _streaming.Clients.All.SendAsync("Message", message);
            return NoContent();
        }
    }
}
