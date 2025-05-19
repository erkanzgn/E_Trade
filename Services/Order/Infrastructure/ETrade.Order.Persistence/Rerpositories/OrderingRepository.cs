using ETrade.Order.Application.Interfaces;
using ETrade.Order.Domain.Entities;
using ETrade.Order.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Order.Persistence.Rerpositories
{
    public class OrderingRepository : IOrderingRepository
    {
        private readonly OrderContext _orderContext;

        public OrderingRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public List<Ordering> GetOrderingByUserId(string id)
        {
          var values =_orderContext.Orderings.Where(x=>x.UserId==id).ToList();
            return values;
        }
    }
}
