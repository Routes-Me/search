using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchService.Models
{
    public class Response
    {
        public bool status { get; set; }
        public string message { get; set; }
        public ResponseCode responseCode { get; set; }
    }
    public enum ResponseCode
    {
        Success = 200,
        Error = 2,
        InternalServerError = 500,
        MovedPermanently = 301,
        NotFound = 404,
        BadRequest = 400,
        Conflict = 409,
        Created = 201,
        NotAcceptable = 406,
        Unauthorized = 401,
        RequestTimeout = 408,
        BadGateway = 502,
        ServiceUnavailable = 503,
        GatewayTimeout = 504,
        Permissionserror = 403,
        Forbidden = 403,
        TokenRequired = 499,
        InvalidToken = 498
    }

    public class SearchResponse : Response { }
    public class VehicleResponse : Response
    {
        public Pagination pagination { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public JObject data { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public JObject included { get; set; }
    }

    public class VehicleDetails
    {
        public List<VehiclesModel> vehicles { get; set; }
    }

    public class VehiclesModel
    {
        public int VehicleId { get; set; }
        public int? DeviceId { get; set; }
        public string PlateNumber { get; set; }
        public int? InstitutionId { get; set; }
        public int ModelYear { get; set; }
        public int? ModelId { get; set; }
    }

}
