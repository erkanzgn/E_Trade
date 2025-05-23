using ETrade.Order.Application.Features.CQRS.Commands.AddressCommands;
using ETrade.Order.Application.Interfaces;
using ETrade.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                City = createAddressCommand.City,
                Detail1=createAddressCommand.Detail1,
                District = createAddressCommand.District,
                UserId = createAddressCommand.UserId,
                Country=createAddressCommand.Country,
                Description=createAddressCommand.Description,
                Detail2 = createAddressCommand.Detail2,
                Email=createAddressCommand.Email,
                Surname=createAddressCommand.Surname,
                Name=createAddressCommand.Name,
                Phone=createAddressCommand.Phone,
                ZipCode=createAddressCommand.ZipCode,
                Isdefault = createAddressCommand.Isdefault,
                IsInvoice = createAddressCommand.IsInvoice

            });
        }
    }
}
