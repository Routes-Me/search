using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchService.Abstraction;
using SearchService.Models;

namespace SearchService.Controllers
{
    [ApiController]
    public class SearchController : ControllerBase
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
                dynamic response = _searchRepository.GetVehicles(q, cxt, pageInfo);
                return StatusCode((int)response.statusCode, response);
            }
            else
            {
                return ReturnResponse.ErrorResponse(CommonMessage.ResultNotFound, StatusCodes.Status404NotFound);
            }
        }
    }
}
