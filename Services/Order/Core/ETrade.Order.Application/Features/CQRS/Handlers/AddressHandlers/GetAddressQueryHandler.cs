﻿using ETrade.Order.Application.Features.CQRS.Results.AddressResults;
using ETrade.Order.Application.Interfaces;
using ETrade.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            {
                AddressId = x.AddressId,
                City = x.City,
                Detail1 = x.Detail1,
                District = x.District,
                UserId = x.UserId,
                Detail2 = x.Detail2,
                Country = x.Country,
                Description = x.Description,
                Email = x.Email,
                Name = x.Name,
                Phone = x.Phone,
                Surname = x.Surname,
                ZipCode = x.ZipCode,
                Isdefault = x.Isdefault,
                IsInvoice = x.IsInvoice

            }).ToList();
        }
    }
}
