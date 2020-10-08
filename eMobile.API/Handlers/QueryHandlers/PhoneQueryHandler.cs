using AutoMapper;
using CQRS.Interfaces;
using eMobile.API.Queries;
using eMobile.API.Validators;
using eMobile.Domain.DimensionsEntity;
using eMobile.Domain.DisplayEntity;
using eMobile.Domain.MediaEntity;
using eMobile.Domain.PhoneEntity;
using eMobile.Models.Responses;
using eMobile.Models.ViewModels;
using eMobile.Respository;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.API.Handlers.QueryHandlers
{
    public class PhoneQueryHandler : IQueryHandlerAsync<PhoneQuery, PhoneQueryResponse>
    {
        #region Properties
        private readonly IRepository<Phone> _phoneRepository;
        private readonly IRepository<Dimensions> _dimensionsRepository;
        private readonly IRepository<Media> _mediaRepository;
        private readonly IRepository<Display> _displayRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor

        public PhoneQueryHandler(
            IRepository<Phone> phoneRepository,
            IRepository<Dimensions> dimensionsRepository,
            IRepository<Media> mediaRepository,
            IRepository<Display> displayRepository,
            IMapper mapper)
        {
            _phoneRepository = phoneRepository;
            _dimensionsRepository = dimensionsRepository;
            _mediaRepository = mediaRepository;
            _displayRepository = displayRepository;
            _mapper = mapper;
        }
        #endregion

        public Task<PhoneQueryResponse> HandleAsync(PhoneQuery query)
        {
            var phone = _phoneRepository.Get(query.Id);

            PhoneValidator.Validate(phone, query.Id);

            _dimensionsRepository.Get(phone.Id);
            _displayRepository.Get(phone.Id);
            _mediaRepository.GetAll().Where(m => m.PhoneId == query.Id);

            var mapped = _mapper.Map<PhoneViewModel>(phone);

            return Task.FromResult(new PhoneQueryResponse { Phone = mapped });
        }
    }
}
