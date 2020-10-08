using CQRS.Interfaces;
using System.Collections.Generic;

namespace eMobile.API.Commands
{
    public class UpdateMediaCommand : ICommand
    {
        public List<PhoneMedia> Media { get; set; }
    }
}
