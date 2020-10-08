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
    public class DeletePhoneCommandHandler : ICommandHandlerAsync<DeletePhoneCommand>
    {
        #region Properties
        private readonly IRepository<Phone> _phoneRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Constructor

        public DeletePhoneCommandHandler(
            IRepository<Phone> phoneRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _phoneRepository = phoneRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        public Task HandleAsync(DeletePhoneCommand command)
        {
            var phoneId = Convert.ToInt32(_httpContextAccessor.HttpContext.Request.RouteValues["Id"]);
            var phone = _phoneRepository.Get(phoneId);

            PhoneValidator.Validate(phone, phone.Id);

            _phoneRepository.Delete(phone);

            return Task.CompletedTask;
        }
    }
}