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
    public class RemoveAddressCommandHandlers
    {
        private readonly IRepository<Address> _repository;

        public RemoveAddressCommandHandlers(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveAddressCommand command) 
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);

        }
    }
}
