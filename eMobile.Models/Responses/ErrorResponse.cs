using eMobile.Models.Models;
using System.Collections.Generic;

namespace eMobile.Models.Responses
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
