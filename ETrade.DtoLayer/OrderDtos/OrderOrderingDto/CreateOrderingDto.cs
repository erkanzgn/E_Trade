using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.DtoLayer.OrderDtos.OrderOrderingDto
{
    public class CreateOrderingDto
    {
        public string NameSurname { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
