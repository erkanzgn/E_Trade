using ETrade.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Order.Application.Interfaces
{
    public interface IOrderingRepository
    {
        public List<Ordering> GetOrderingByUserId(string id);
    }
}
