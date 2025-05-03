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
    public class EfCargoOperationDal:GenericRepository<CargoOperation>,ICargoOperationDal
    {
        public EfCargoOperationDal(CargoContext cargoContext):base(cargoContext) 
        {
            
        }
    }
}
