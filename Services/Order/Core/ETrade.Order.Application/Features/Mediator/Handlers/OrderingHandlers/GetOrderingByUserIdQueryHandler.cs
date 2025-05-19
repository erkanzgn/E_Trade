using ETrade.Order.Application.Features.Mediator.Queries.OrderingQueries;
using ETrade.Order.Application.Features.Mediator.Results.OrderingResults;
using ETrade.Order.Application.Interfaces;
using ETrade.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderinByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
    {
        private readonly IOrderingRepository _orderingRepository;

        public GetOrderingByUserIdQueryHandler(IOrderingRepository orderingRepository)
        {
            _orderingRepository = orderingRepository;
        }

        public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderinByUserIdQuery request, CancellationToken cancellationToken)
        {

            var values =  _orderingRepository.GetOrderingByUserId(request.Id);
            return values.Select(x => new GetOrderingByUserIdQueryResult
            {
                OrderDate = x.OrderDate,
                UserId = x.UserId,
                OrderingId = x.OrderingId,
                TotalPrice = x.TotalPrice,
            }).ToList();

        }
    }
}
