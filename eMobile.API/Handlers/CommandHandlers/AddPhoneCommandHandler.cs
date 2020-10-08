using CQRS.Interfaces;
using eMobile.API.Commands;
using eMobile.Domain.DimensionsEntity;
using eMobile.Domain.DisplayEntity;
using eMobile.Domain.MediaEntity;
using eMobile.Domain.PhoneEntity;
using eMobile.Respository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMobile.API.Handlers.CommandHandlers
{
    public class AddPhoneCommandHandler : ICommandHandlerAsync<AddPhoneCommand>
    {
        #region Properties
        private readonly IRepository<Phone> _phoneRepository;
        #endregion

        #region Constructor
        public AddPhoneCommandHandler(IRepository<Phone> phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }
        #endregion

        public Task HandleAsync(AddPhoneCommand command)
        {
            List<Media> mediaList = new List<Media>();

            command.Media.ForEach(m => mediaList.Add(new Media { Photo = m.Photo, Video = m.Video, AddedDate = DateTime.Now }));

            Phone p = new Phone
            {
                Name = command.Name,
                Manufacturer = command.Manufacturer,
                Weight = command.Weight,
                CPUModel = command.CPUModel,
                RAM = command.RAM,
                OS = command.OS,
                Price = command.Price,
                Media = mediaList,
                AddedDate = DateTime.Now,

                Dimensions = new Dimensions
                {
                    Length = command.Dimensions.Length,
                    Width = command.Dimensions.Width,
                    Height = command.Dimensions.Height,
                    AddedDate = DateTime.Now
                },

                Display = new Display
                {
                    Size = command.Display.Size,
                    HorizontalResolution = command.Display.HorizontalResolution,
                    VerticalResolution = command.Display.VerticalResolution,
                    AddedDate = DateTime.Now,
                },
            };

            _phoneRepository.Insert(p);

            return Task.CompletedTask;
        }
    }
}