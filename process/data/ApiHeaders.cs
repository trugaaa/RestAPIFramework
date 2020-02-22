using System.Collections.Generic;
using System.Net.Mime;

namespace RestAPIFrame.data
{
    public class ApiHeaders
    {
        public JsonObjectApi DataHeaders(string endpoint)
        {
            JsonObjectApi apiHeaders = new JsonObjectApi();
            apiHeaders.PutAccept(MediaTypeNames.Application.Json);
            apiHeaders.PutRequest(MediaTypeNames.Application.Json);
            apiHeaders.PutEndpoint(endpoint);
            return apiHeaders;
        }
        
        public JsonObjectApi Id(string endpoint,int id)
        {
            JsonObjectApi apiHeaders = new ApiHeaders().DataHeaders(endpoint);
            Dictionary<string, object>dictionary = new Dictionary<string, object>();
            dictionary.Add("id",  id.ToString());
            apiHeaders.PutHeaders(dictionary);
            return apiHeaders;
        }
    }
}