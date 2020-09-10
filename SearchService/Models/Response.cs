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
        public int statusCode { get; set; }
    }

    public class ReturnResponse
    {
        public static dynamic ErrorResponse(string message, int statusCode)
        {
            Response response = new Response();
            response.status = true;
            response.message = message;
            response.statusCode = statusCode;
            return response;
        }
    }
}
