using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SearchService.Abstraction;
using SearchService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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
