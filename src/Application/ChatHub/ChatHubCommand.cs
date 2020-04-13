using AutoMapper;
using Covid19.Application.Common.Interfaces;
using Covid19.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Covid19.Application.ChatHub
{
    public class ChatHubCommand : IRequest<ChatItemDTO>
    {
        public string User { get; set; }
        public string Message { get; set; }
    }

    public class ChatHubCommandHandler : IRequestHandler<ChatHubCommand, ChatItemDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ChatHubCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //public async Task SendMessage(string user, string message) --> Add Hub Inheritance to use that (before IRequestHandler)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", user, message);
        //}
        public async Task<ChatItemDTO> Handle(ChatHubCommand request, CancellationToken cancellationToken)
        {
            var user = request.User;
            var message = request.Message;
            var chatItem = new ChatItem
            {
                User = user,
                Message = message
            };
            await _context.ChatItems.AddAsync(chatItem);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ChatItemDTO>(chatItem);
        }
    }
}
