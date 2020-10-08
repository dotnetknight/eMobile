using AutoMapper;
using CQRS.Interfaces;
using eMobile.API.Queries;
using eMobile.API.Validators;
using eMobile.Domain.DimensionsEntity;
using eMobile.Domain.DisplayEntity;
using eMobile.Domain.MediaEntity;
using eMobile.Domain.OrderEntity;
using eMobile.Domain.PhoneEntity;
using eMobile.Models.Exceptions;
using eMobile.Models.Responses;
using eMobile.Models.ViewModels;
using eMobile.Respository;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.API.Handlers.QueryHandlers
{
    public class OrderedPhoneQueryHandler : IQueryHandlerAsync<OrderedPhoneQuery, OrderPhoneResponse>
    {
        #region Properties
        private readonly IRepository<Phone> _phoneRepository;
        private readonly IRepository<Orders> _ordersRepository;
        private readonly IRepository<Dimensions> _dimensionsRepository;
        private readonly IRepository<Media> _mediaRepository;
        private readonly IRepository<Display> _displayRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor

        public OrderedPhoneQueryHandler(
            IRepository<Phone> phoneRepository,
            IRepository<Orders> ordersRepository,
            IRepository<Dimensions> dimensionsRepository,
            IRepository<Media> mediaRepository,
            IRepository<Display> displayRepository,
            IMapper mapper)
        {
            _phoneRepository = phoneRepository;
            _ordersRepository = ordersRepository;
            _dimensionsRepository = dimensionsRepository;
            _mediaRepository = mediaRepository;
            _displayRepository = displayRepository;
            _mapper = mapper;
        }
        #endregion

        public Task<OrderPhoneResponse> HandleAsync(OrderedPhoneQuery query)
        {
            var order = _ordersRepository.Get(query.Id);

            if(order == null)
            {
                throw new OrderNotFound(System.Net.HttpStatusCode.NotFound, "Order not found");
            }
            
            var phone = _phoneRepository.Get(order.PhoneId);

            _dimensionsRepository.Get(phone.Id);
            _displayRepository.Get(phone.Id);
            _mediaRepository.GetAll().Where(m => m.PhoneId == phone.Id);

            var mapped = _mapper.Map<PhoneViewModel>(phone);

            return Task.FromResult(new OrderPhoneResponse { Phone = mapped });
        }
    }
}
