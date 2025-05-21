using Dapper;
using ETrade.Discount.Context;
using ETrade.Discount.Dtos;

namespace ETrade.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values" +
                 " (@code,@rate,@isActive,@validDate )";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using (var connnection = _dapperContext.CreateConnection())
            {

                await connnection.ExecuteAsync(query, parameters);

            }

        }

        public async Task DeleteDiscountCouponAsync(int couponId)
        {
            string query = "delete from Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", couponId);
            using (var connnection = _dapperContext.CreateConnection())
            {

                await connnection.ExecuteAsync(query, parameters);

            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "select * from Coupons ";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }

        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int couponId)
        {
            string query = "select * from Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", couponId);
            using (var connection = _dapperContext.CreateConnection())
            {

                var values = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);
                return values;
            }
        }

        public async Task<ResultDiscountCouponDto> GetCodeDetailByCodeAsync(string code)
        {
            string query = "Select * from Coupons where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);

            using (var connection = _dapperContext.CreateConnection())
            {

                var values = await connection.QueryFirstOrDefaultAsync<ResultDiscountCouponDto>(query, parameters);
                return values;
            }
        }

        public async Task<int> GetDiscountCouponCount()
        {
            string query = "select Count(*) from Coupons ";
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);
                return values;
            }
        }

        public int GetDiscountCouponRate(string code)
        {
            string query = "Select Rate from Coupons where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);

            using (var connection = _dapperContext.CreateConnection())
            {

                var values =  connection.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code=@code, Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@couponId", updateCouponDto.CouponId);
            using (var connnection = _dapperContext.CreateConnection())
            {

                await connnection.ExecuteAsync(query, parameters);

            }
        }
    }
}
