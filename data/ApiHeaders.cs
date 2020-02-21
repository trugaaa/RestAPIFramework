using System.Net.Http.Headers;
using System.Net.Mime;

namespace RestAPIFrame.data
{
    public class ApiHeaders
    {
        public JsonObjectApi DataHeaders(string endpoint)
        {
            JsonObjectApi ApiHeaders = new JsonObjectApi();
            ApiHeaders.PutAccept(MediaTypeNames.Application.Json);
            ApiHeaders.PutRequest(MediaTypeNames.Application.Json);
            ApiHeaders.PutEndpoint(endpoint);
            return ApiHeaders;
        }
    }
}