using AutoMapper;
using CQRS.Interfaces;
using eMobile.API.Queries;
using eMobile.Domain.DimensionsEntity;
using eMobile.Domain.DisplayEntity;
using eMobile.Domain.MediaEntity;
using eMobile.Domain.OrderEntity;
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
    public class OrdersListQueryHandler : IQueryHandlerAsync<OrdersListQuery, OrdersListRespone>
    {
        #region Properties
        private readonly IRepository<Orders> _ordersRepository;
        private readonly IRepository<Phone> _phonesRepository;
        private readonly IMapper _mapper;
        private readonly IRepository<Dimensions> _dimensionsRepository;
        private readonly IRepository<Media> _mediaRepository;
        private readonly IRepository<Display> _displayRepository;
        #endregion

        #region Constructor
        public OrdersListQueryHandler(
            IRepository<Orders> ordersRepository,
            IRepository<Phone> phonesRepository,
            IRepository<Dimensions> dimensionsRepository,
            IRepository<Media> mediaRepository,
            IRepository<Display> displayRepository,
            IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _phonesRepository = phonesRepository;
            _dimensionsRepository = dimensionsRepository;
            _mediaRepository = mediaRepository;
            _displayRepository = displayRepository;
            _mapper = mapper;
        }
        #endregion

        public Task<OrdersListRespone> HandleAsync(OrdersListQuery query)
        {
            var orders = _ordersRepository.GetAll();
            var phones = _phonesRepository.GetAll();

            if (orders.FirstOrDefault() == null)
            {
                throw new OrderNotFound(System.Net.HttpStatusCode.NoContent, "Order not found");
            }

            List<PhoneViewModel> mappedPhoneList = new List<PhoneViewModel>();

            int orderIndex = 0;

            foreach (Orders order in orders)
            {
                for (int i = orderIndex; i < orders.Count();)
                {
                    var phone = phones
                  .Where(p => p.Id == order.PhoneId)
                  .FirstOrDefault();

                    _dimensionsRepository.Get(phone.Id);
                    _displayRepository.Get(phone.Id);
                    _mediaRepository.GetAll().Where(m => m.PhoneId == phone.Id);

                    mappedPhoneList.Add(_mapper.Map<PhoneViewModel>(phone));

                    orderIndex++;

                    break;
                }
            }

            return Task.FromResult(new OrdersListRespone
            {
                OrdersList = new List<OrdersViewModel> { new OrdersViewModel { Phones = mappedPhoneList } }
            });
        }
    }
}
