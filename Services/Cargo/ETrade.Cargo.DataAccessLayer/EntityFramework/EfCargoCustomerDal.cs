using ETrade.Cargo.DataAccessLayer.Abstract;
using ETrade.Cargo.DataAccessLayer.Concrete;
using ETrade.Cargo.DataAccessLayer.Repositories;
using ETrade.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal:GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        private readonly CargoContext _context;
        public EfCargoCustomerDal(CargoContext cargoContext, CargoContext context) : base(cargoContext)
        {
            _context = context;
        }

        public CargoCustomer GetCargocustomerById(string id)
        {
            var values=_context.CargoCustomers.Where(x=>x.UserCustomerId==id).FirstOrDefault();
            return values;
        }
    }
}
