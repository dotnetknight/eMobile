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
    public class UpdateMediaCommandHandler : ICommandHandlerAsync<UpdateMediaCommand>
    {
        #region Properties
        private readonly IRepository<Media> _mediaRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Constructor
        public UpdateMediaCommandHandler(
            IRepository<Media> mediaRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mediaRepository = mediaRepository;
        }
        #endregion

        public Task HandleAsync(UpdateMediaCommand command)
        {
            var phoneId = Convert.ToInt32(_httpContextAccessor.HttpContext.Request.RouteValues["Id"]);

            var mediaResult = _mediaRepository
                .GetAll()
                .Where(m => m.PhoneId == phoneId);

            MediaValidator.Validate(mediaResult);

            int mediaResultIndex = 0;

            foreach (Media media in mediaResult)
            {
                for (int i = mediaResultIndex; i < mediaResult.Count();)
                {
                    media.Photo = command.Media[i].Photo;
                    media.Video = command.Media[i].Video;

                    _mediaRepository.Update(media);
                    mediaResultIndex++;

                    break;
                }
            }

            return Task.CompletedTask;
        }
    }
}
