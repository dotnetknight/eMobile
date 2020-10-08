using AutoMapper;
using CQRS.Interfaces;
using eMobile.API.Queries;
using eMobile.API.Validators;
using eMobile.Domain.MediaEntity;
using eMobile.Models.Responses;
using eMobile.Models.ViewModels;
using eMobile.Respository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.API.Handlers.QueryHandlers
{
    public class PhoneMediaQueryHandler : IQueryHandlerAsync<PhoneMediaQuery, PhoneMediaResonse>
    {
        #region Properties
        private readonly IRepository<Media> _mediaRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor

        public PhoneMediaQueryHandler(
            IRepository<Media> mediaRepository,
            IMapper mapper)
        {
            _mediaRepository = mediaRepository;
            _mapper = mapper;
        }
        #endregion

        public Task<PhoneMediaResonse> HandleAsync(PhoneMediaQuery query)
        {
            var media = _mediaRepository
                .GetAll()
                .Where(m => m.PhoneId == query.Id);

            MediaValidator.Validate(media);

            return Task.FromResult(new PhoneMediaResonse { Media = _mapper.Map<List<PhoneMediaViewModel>>(media) });
        }
    }
}