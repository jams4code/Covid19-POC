using Covid19.Application.ChatHub;
using Covid19.Application.ChatHub.Query;
using Covid19.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Covid19.WebUI.Controllers
{
    public class LiveController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<ChatItemDTO>> SendMessage(ChatHubCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet]
        public async Task<PagedData<ChatItemDTO>> GetAllMessage()
        {
            return await Mediator.Send(new ChatHubGetPagedDataQuery());
        }
    }
}
