using CodingChallengeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingChallengeService.Service
{
    public class FilterService : IFilterService
    {
        public Response GetFilteredResponse(Request request)
        {
            List<Episode> returnValue = new List<Episode>();
            Response response = new Response();
            //Filter response for DRM = truw and Episodecount > 0
            if (request != null && request.Payload != null && request.Payload.Count > 0)
            {
                returnValue = request.Payload.Where(x => x.Drm == true && x.EpisodeCount > 0)
                                             .Select(s => new Episode { image = s.Image.ShowImage, slug = s.Slug, title = s.Title })
                                             .Skip(request.Skip).Take(request.Take).ToList();
            }
            response.response = returnValue;
            //
            return response;
        }

    }
}