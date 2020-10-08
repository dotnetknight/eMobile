using CQRS.Interfaces;
using eMobile.API.Commands;
using eMobile.API.Validators;
using eMobile.Domain.PhoneEntity;
using eMobile.Respository;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace eMobile.API.Handlers.CommandHandlers
{
    public class UpdatePhoneCommandHandler : ICommandHandlerAsync<UpdatePhoneCommand>
    {
        #region Properties
        private readonly IRepository<Phone> _phoneRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Constructor

        public UpdatePhoneCommandHandler(
            IRepository<Phone> phoneRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _phoneRepository = phoneRepository;
        }
        #endregion

        public Task HandleAsync(UpdatePhoneCommand command)
        {
            var phoneId = Convert.ToInt32(_httpContextAccessor.HttpContext.Request.RouteValues["Id"]);

            var phone = _phoneRepository.Get(phoneId);
            PhoneValidator.Validate(phone, phone.Id);

            phone.Name = command.Name;
            phone.Manufacturer = command.Manufacturer;
            phone.OS = command.OS;
            phone.Price = command.Price;
            phone.RAM = command.RAM;
            phone.Weight = command.Weight;
            phone.CPUModel = command.CPUModel;

            _phoneRepository.Update(phone);

            return Task.CompletedTask;
        }
    }
}
