using CQRS.Interfaces;
using eMobile.API.Commands;
using eMobile.API.Validators;
using eMobile.Domain.OrderEntity;
using eMobile.Domain.PhoneEntity;
using eMobile.Domain.UsersEntity;
using eMobile.Respository;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eMobile.API.Handlers.CommandHandlers
{
    public class PhoneOrderCommandHandler : ICommandHandlerAsync<PhoneOrderCommand>
    {
        #region Properties
        private readonly IRepository<Orders> _ordersRepository;
        private readonly IRepository<Users> _usersRepository;
        private readonly IRepository<Phone> _phoneRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Constructor
        public PhoneOrderCommandHandler(
            IRepository<Orders> ordersRepository,
            IRepository<Users> usersRepository,
            IRepository<Phone> phoneRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _ordersRepository = ordersRepository;
            _phoneRepository = phoneRepository;
            _usersRepository = usersRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        public Task HandleAsync(PhoneOrderCommand command)
        {
            var user = _usersRepository
                .GetAll()
                .Where(u => u.Email == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value)
                .FirstOrDefault();

            var phone = _phoneRepository.Get(command.PhoneId);

            PhoneValidator.Validate(phone, command.PhoneId);

            var order = new Orders
            {
                AddedDate = DateTime.Now,
                CreditCardNumber = command.CreditCardNumber,
                NameOnCard = command.NameOnCard,
                User = user,
                PhoneId = phone.Id
            };

            _ordersRepository.Insert(order);

            return Task.CompletedTask;
        }
    }
}
