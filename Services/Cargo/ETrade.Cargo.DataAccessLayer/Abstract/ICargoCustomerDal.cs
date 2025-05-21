using ETrade.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Cargo.DataAccessLayer.Abstract
{
    public interface ICargoCustomerDal:IGenericDal<CargoCustomer>
    {
        CargoCustomer GetCargocustomerById(string id);
    }
}
