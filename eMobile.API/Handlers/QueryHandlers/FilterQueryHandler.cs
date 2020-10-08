using AutoMapper;
using CQRS.Interfaces;
using eMobile.API.Queries;
using eMobile.Domain.DimensionsEntity;
using eMobile.Domain.DisplayEntity;
using eMobile.Domain.MediaEntity;
using eMobile.Domain.PhoneEntity;
using eMobile.Models.Exceptions;
using eMobile.Models.Responses;
using eMobile.Models.ViewModels;
using eMobile.Respository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.API.Handlers.QueryHandlers
{
    public class FilterQueryHandler : IQueryHandlerAsync<FilterQuery, FilterQueryResponse>
    {
        #region Properties
        private readonly IRepository<Phone> _phoneRepository;
        private readonly IRepository<Dimensions> _dimensionsRepository;
        private readonly IRepository<Media> _mediaRepository;
        private readonly IRepository<Display> _displayRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor

        public FilterQueryHandler(
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

        public Task<FilterQueryResponse> HandleAsync(FilterQuery query)
        {
            var phones = _phoneRepository
                .GetAll()
                .Where(p => (query.Name != null && p.Name
                .ToLower()
                .Contains(query.Name.ToLower())) ||
                (query.Manufacturer != null && p.Manufacturer
                .ToLower()
                .Contains(query.Manufacturer.ToLower())) ||
                (p.Price >= query.PriceFrom && p.Price <= query.PriceTo))
                .Skip((query.Page - 1) * query.Limit)
                .Take(query.Limit);

            if (phones.Count() == 0)
            {
                throw new NoResultsFound(System.Net.HttpStatusCode.NoContent, "No results match your criteria");
            }

            List<PhoneViewModel> mappedPhoneList = new List<PhoneViewModel>();

            _dimensionsRepository.GetAll();
            _mediaRepository.GetAll();
            _displayRepository.GetAll();

            foreach (Phone phone in phones)
            {
                mappedPhoneList.Add(_mapper.Map<PhoneViewModel>(phone));
            }

            return Task.FromResult(new FilterQueryResponse { FilteredPhones = mappedPhoneList });
        }
    }
}