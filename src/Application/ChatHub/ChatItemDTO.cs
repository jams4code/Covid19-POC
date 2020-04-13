using Covid19.Application.Common.Mappings;
using Covid19.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Application.ChatHub
{
    public class ChatItemDTO : IMapFrom<ChatItem>
    {
        public string User { get; set; }
        public string Message { get; set; }
    }
}
