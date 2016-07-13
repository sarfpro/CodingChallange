using CodingChallengeService.Models;
using CodingChallengeService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CodingChallengeService.CustomException;

namespace CodingChallengeService.Controllers.API
{
    public class FilterServiceController : ApiController
    {
        private IFilterService _service = new FilterService();

        public FilterServiceController()
        {

        }
        // parmeterised constructor to test if said service is accessible
        public FilterServiceController(IFilterService service)
        {
            _service = service;
        }

        /// <summary>
        /// Returning HTTPResponseMessage instead of HttpActionResult to cater the
        /// custom error message handling
        /// </summary>
        /// <param name="request">Expected well formed json request 
        /// as refer RequestJsonSchema.json</param>
        /// <returns>Response object with list of espisodes refer ResposneSchema.json</returns>
        public HttpResponseMessage Post([FromBody]Request request)
        {
           
            try
            {
                var responseValue = _service.GetFilteredResponse(request);

                //return error if response is not well formed
                if (responseValue != null && responseValue.response.Count < 1)
                    return Request.CreateResponse<Error>(HttpStatusCode.BadRequest, new Error { error = "Could not decode request: JSON parsing failed" });
                return Request.CreateResponse(HttpStatusCode.OK, responseValue);
            }
            catch
            {

                return Request.CreateResponse<Error>(HttpStatusCode.BadRequest, new Error { error = "Could not decode request: JSON parsing failed" });
            }
            
                         
            
        }
    }
}
