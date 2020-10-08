using eMobile.Domain.PhoneEntity;
using System.Collections.Generic;

namespace eMobile.Domain.MediaEntity
{
    public class Media : BaseEntity
    {
        public Phone Phone { get; set; }
        public string Photo { get; set; }
        public string Video { get; set; }
        public int PhoneId { get; set; }
    }
}
