using AutoMapper;
using CQRS.Interfaces;
using eMobile.API.Queries;
using eMobile.Domain.DimensionsEntity;
using eMobile.Domain.DisplayEntity;
using eMobile.Domain.MediaEntity;
using eMobile.Domain.PhoneEntity;
using eMobile.Models.Responses;
using eMobile.Models.ViewModels;
using eMobile.Respository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMobile.API.Handlers.QueryHandlers
{
    public class PhoneListQueryHandler : IQueryHandlerAsync<PhoneListQuery, PhoneListResponse>
    {
        #region Properties
        private readonly IRepository<Phone> _phoneRepository;
        private readonly IRepository<Dimensions> _dimensionsRepository;
        private readonly IRepository<Media> _mediaRepository;
        private readonly IRepository<Display> _displayRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor

        public PhoneListQueryHandler(
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

        public Task<PhoneListResponse> HandleAsync(PhoneListQuery query)
        {
            var phones = _phoneRepository.GetAll();

            _dimensionsRepository.GetAll();
            _mediaRepository.GetAll();
            _displayRepository.GetAll();

            List<PhoneViewModel> mappedPhoneList = new List<PhoneViewModel>();

            foreach (Phone phone in phones)
            {
                mappedPhoneList.Add(_mapper.Map<PhoneViewModel>(phone));
            }

            return Task.FromResult(new PhoneListResponse { Phones = mappedPhoneList });
        }
    }
}