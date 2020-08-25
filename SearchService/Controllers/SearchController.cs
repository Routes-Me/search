using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SearchService.Abstraction;
using SearchService.Models;

namespace SearchService.Controllers
{
    [ApiController]
    public class SearchController : BaseController
    {
        private readonly ISearchRepository _searchRepository;
        public SearchController(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        [HttpGet]
        [Route("search")]
        public IActionResult Get(string q, string cxt, [FromQuery] Pagination pageInfo)
        {

            if (cxt.ToLower() == "vehicle" || cxt.ToLower() == "vehicles")
            {
                var josnResponse = _searchRepository.GetVehicles(q, cxt, pageInfo);
                return Ok(josnResponse);
            }
            else
            {
                SearchResponse response = new SearchResponse();
                response.status = false;
                response.responseCode = ResponseCode.NotFound;
                response.message = "Result not found!!";
                return NotFound(response);
            }
        }
    }
}
