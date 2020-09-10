using Microsoft.Extensions.Options;
using RestSharp;
using SearchService.Abstraction;
using SearchService.Models;

namespace SearchService.Repository
{
    public class SearchRepository : ISearchRepository
    {
        private readonly IOptions<AppSettings> _appSettings;
        public SearchRepository(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }
        public dynamic GetVehicles(string query, string context, Pagination pageInfo)
        {

            var client = new RestClient(_appSettings.Value.VehicleEndpointUrl + "?q=" + query + "&ctx=" + context + "&offset=" + pageInfo.offset + "&limit=" + pageInfo.limit);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
    }
}
