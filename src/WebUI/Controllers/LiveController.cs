using Covid19.Application.ChatHub;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
