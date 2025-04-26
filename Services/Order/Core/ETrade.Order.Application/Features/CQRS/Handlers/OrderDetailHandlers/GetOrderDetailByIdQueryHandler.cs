using ETrade.Order.Application.Features.CQRS.Queries.AddressQueries;
using ETrade.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using ETrade.Order.Application.Features.CQRS.Results.AddressResults;
using ETrade.Order.Application.Features.CQRS.Results.OrderDetailResults;
using ETrade.Order.Application.Interfaces;
using ETrade.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
               OrderDetailId=values.OrderDetailId,
               OrderingId=values.OrderingId,
               ProductId=values.ProductId,
               ProductAmount=values.ProductAmount,
               ProductName=values.ProductName,
               ProductPrice=values.ProductPrice,    
               ProductTotalPrice=values.ProductTotalPrice,
            };
        }
    }
}
