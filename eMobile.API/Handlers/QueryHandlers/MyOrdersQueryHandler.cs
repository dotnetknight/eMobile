using AutoMapper;
using CQRS.Interfaces;
using eMobile.API.Queries;
using eMobile.Domain.DimensionsEntity;
using eMobile.Domain.DisplayEntity;
using eMobile.Domain.MediaEntity;
using eMobile.Domain.OrderEntity;
using eMobile.Domain.PhoneEntity;
using eMobile.Domain.UsersEntity;
using eMobile.Models.Exceptions;
using eMobile.Models.Responses;
using eMobile.Models.ViewModels;
using eMobile.Respository;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace eMobile.API.Handlers.QueryHandlers
{
    public class MyOrdersQueryHandler : IQueryHandlerAsync<MyOrdersQuery, MyOrdersResponse>
    {
        #region Properties
        private readonly IRepository<Orders> _ordersRepository;
        private readonly IRepository<Users> _userRepository;
        private readonly IRepository<Phone> _phonesRepository;
        private readonly IRepository<Dimensions> _dimensionsRepository;
        private readonly IRepository<Media> _mediaRepository;
        private readonly IRepository<Display> _displayRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public MyOrdersQueryHandler(
             IRepository<Orders> ordersRepository,
             IRepository<Phone> phonesRepository,
             IRepository<Dimensions> dimensionsRepository,
             IRepository<Media> mediaRepository,
             IRepository<Display> displayRepository,
             IRepository<Users> userRepository,
             IHttpContextAccessor httpContextAccessor,
             IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _phonesRepository = phonesRepository;
            _dimensionsRepository = dimensionsRepository;
            _mediaRepository = mediaRepository;
            _displayRepository = displayRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        public Task<MyOrdersResponse> HandleAsync(MyOrdersQuery query)
        {
            var user = _userRepository
                .GetAll()
                .Where(u => u.Email == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value)
                .FirstOrDefault();

            var orders = _ordersRepository.GetAll().Where(o => o.UserId == user.Id);

            if (orders.Count() == 0)
            {
                throw new OrderNotFound(System.Net.HttpStatusCode.NoContent, "There's not order made by you yet");
            }

            var phones = _phonesRepository.GetAll();

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

            return Task.FromResult(new MyOrdersResponse
            {
                OrdersList = new List<OrdersViewModel> { new OrdersViewModel { Phones = mappedPhoneList } }
            });
        }
    }
}
