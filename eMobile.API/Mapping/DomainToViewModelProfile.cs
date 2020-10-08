using AutoMapper;
using eMobile.API.Commands;
using eMobile.Domain.AddressEntity;
using eMobile.Domain.DimensionsEntity;
using eMobile.Domain.DisplayEntity;
using eMobile.Domain.MediaEntity;
using eMobile.Domain.OrderEntity;
using eMobile.Domain.PhoneEntity;
using eMobile.Domain.UsersEntity;
using eMobile.Models.ViewModels;

namespace eMobile.API.Mapping
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Dimensions, PhoneDimensionsViewModel>();
            CreateMap<Media, PhoneMediaViewModel>();
            CreateMap<Display, PhoneDisplayViewModel>();
            CreateMap<Phone, PhoneViewModel>();
            CreateMap<Orders, OrdersViewModel>();
            CreateMap<Users, UsersViewModel>();

            CreateMap<PhoneMedia, Media>();
            CreateMap<PhoneDisplay, Display>();
            CreateMap<PhoneDimensions, Dimensions>();

            CreateMap<Phone, UpdatePhoneCommand>();
            CreateMap<UpdatePhoneCommand, Phone>();

            CreateMap<UserAddress, Address>();
        }
    }
}
