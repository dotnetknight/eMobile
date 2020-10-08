using AutoMapper;
using CQRS.Interfaces;
using eMobile.API.Commands;
using eMobile.Domain.AddressEntity;
using eMobile.Domain.UsersEntity;
using eMobile.Respository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eMobile.API.Handlers.CommandHandlers
{
    public class AddUserCommandHandler : ICommandHandlerAsync<AddUserCommand>
    {
        #region Properties
        private readonly IRepository<Users> _userRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public AddUserCommandHandler(IRepository<Users> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        #endregion

        public Task HandleAsync(AddUserCommand command)
        {
            List<Address> addresses = new List<Address>();

            foreach(UserAddress userAddresses in command.Addresses)
            {
                var addressMap = _mapper.Map<Address>(userAddresses);
                addressMap.AddedDate = DateTime.Now;
                addresses.Add(addressMap);
            }

            var user = new Users
            {
                AddedDate = DateTime.Now,
                Address = addresses,
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Password = PasswordHash(command.Password)
            };

            _userRepository.Insert(user);

            return Task.CompletedTask;
        }

        public string PasswordHash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;

            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
                hashBytes = algorithm.ComputeHash(bytes);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
