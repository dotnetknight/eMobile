using eMobile.Domain.PhoneEntity;
using eMobile.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace eMobile.Models.Responses
{
    public class FilterQueryResponse
    {
        public List<PhoneViewModel> FilteredPhones { get; set; }
    }
}
