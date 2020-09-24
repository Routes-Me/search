using Microsoft.Extensions.Options;
using RestSharp;
using SearchService.Abstraction;
using SearchService.Models;

namespace SearchService.Repository
{
    public class SearchRepository : ISearchRepository
    {
        private readonly AppSettings _appSettings;
        private readonly Dependencies _dependencies;
        public SearchRepository(IOptions<AppSettings> appSettings, IOptions<Dependencies> dependencies)
        {
            _appSettings = appSettings.Value;
            _dependencies = dependencies.Value;
        }
        public dynamic GetVehicles(string query, string context, Pagination pageInfo)
        {
            var client = new RestClient(_appSettings.Host + _dependencies.VehicleUrl + "?q=" + query + "&ctx=" + context + "&offset=" + pageInfo.offset + "&limit=" + pageInfo.limit);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
    }
}
