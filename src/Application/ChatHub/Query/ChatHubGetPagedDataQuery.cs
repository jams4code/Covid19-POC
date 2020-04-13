using AutoMapper;
using AutoMapper.QueryableExtensions;
using Covid19.Application.Common.Interfaces;
using Covid19.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Covid19.Application.ChatHub.Query
{
    public class ChatHubGetPagedDataQuery : IRequest<PagedData<ChatItemDTO>>
    {
        public PagingParameter PagingParameters { get; set; }

        public class ChatHubGetPagedDataQueryHandler : IRequestHandler<ChatHubGetPagedDataQuery, PagedData<ChatItemDTO>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public ChatHubGetPagedDataQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PagedData<ChatItemDTO>> Handle(ChatHubGetPagedDataQuery request, CancellationToken cancellationToken)
            {
                if (request.PagingParameters == null)
                {
                    request.PagingParameters = new PagingParameter();
                }
                Page page = new Page
                {
                    Size = request.PagingParameters.PageSize,
                    PageNumber = request.PagingParameters.PageNumber
                };

                int skip = page.GetSkip();
                int take = page.GetTake();
                page.SetMetadata(await _context.ChatItems.CountAsync());
                List<ChatItemDTO> chatItems = await _context.ChatItems
                    .ProjectTo<ChatItemDTO>(_mapper.ConfigurationProvider)
                    .OrderByDescending(t => t.Created)
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync(cancellationToken);
                PagedData<ChatItemDTO> pagedDate = new PagedData<ChatItemDTO>
                {
                    Page = page,
                    Data = chatItems
                };

                return pagedDate;
            }
        }
    }
}
