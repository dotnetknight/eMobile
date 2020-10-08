using eMobile.Domain.MediaEntity;
using eMobile.Models.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace eMobile.API.Validators
{
    public static class MediaValidator
    {
        public static void Validate(IEnumerable<Media> media)
        {
            if (media.Count() == 0)
            {
                throw new MediaNotFound(System.Net.HttpStatusCode.NotFound, "No photos nor videos found for provided phone id");
            }
        }
    }
}
