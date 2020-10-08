using CQRS.Interfaces;
using eMobile.API.Commands;
using eMobile.API.Validators;
using eMobile.Domain.MediaEntity;
using eMobile.Respository;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.API.Handlers.CommandHandlers
{
    public class DeleteMediaCommandHandler : ICommandHandlerAsync<DeleteMediaCommand>
    {
        #region Properties
        private readonly IRepository<Media> _mediaRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Constructor

        public DeleteMediaCommandHandler(
            IRepository<Media> mediaRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _mediaRepository = mediaRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        public Task HandleAsync(DeleteMediaCommand command)
        {
            var phoneId = Convert.ToInt32(_httpContextAccessor.HttpContext.Request.RouteValues["Id"]);

            var medias = _mediaRepository
                .GetAll()
                .Where(m => m.PhoneId == phoneId);

            MediaValidator.Validate(medias);

            foreach(Media m in medias)
            {
                _mediaRepository.Delete(m);
            }

            return Task.CompletedTask;
        }
    }
}