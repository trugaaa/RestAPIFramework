using System;
using RestAPIFrame.process.data;
using RestSharp;

namespace RestAPIFrame.process
{
    public class ApiMethods
    {
        private RestClient _client;
        private bool _isLogsOn;
        public ApiMethods(string rootUrl, bool isLogsOn)
        {
            _client = new RestClient(rootUrl);
            _isLogsOn = isLogsOn;
        }
        private RestRequest RequestBuild(Method httpMethod ,JsonObjectApi headers,JsonObject requestBody)
        {

        RestRequest request = new RestRequest(headers.GetEndpoint(), httpMethod);

        request.OnBeforeDeserialization = requestContentType =>
        {
            requestContentType.ContentType = headers.GetAccept();
        };

        if (headers.GetHeaders() != null)
        {
            foreach (var (key, value) in headers.GetHeaders())
            {
                request.AddHeader(key, value.ToString());
            }
        }

        if (headers.GetPathParams()!=null)
        {
            foreach ( var (key, value) in headers.GetPathParams())
            {
                request.AddUrlSegment(key,value.ToString());
            }
        }
        
        if (headers.GetQueryParams()!=null)
        {
            foreach (var (key, value) in headers.GetPathParams())
            {
                request.AddQueryParameter(key,value.ToString());
            }
        }
        
        if (requestBody != null)
        {
            request.AddJsonBody(requestBody);
        }
        return request;
        }
        
        public  IRestResponse Post(JsonObjectApi headers, JsonObject requestBody)
        {
            IRestResponse response = _client.Execute(RequestBuild(Method.POST, headers,requestBody));
            Log(response,headers,requestBody);
            return response;
        }
        
        public  IRestResponse Put(JsonObjectApi headers, JsonObject requestBody)
        {
            IRestResponse response = _client.Execute(RequestBuild(Method.PUT, headers,requestBody));
            Log(response,headers,requestBody);
            return response;
        }
        
        public  IRestResponse Get(JsonObjectApi headers)
        {
            IRestResponse response = _client.Execute(RequestBuild(Method.GET, headers, null));
            Log(response,headers,null);
            return response;
        }
        
        public  IRestResponse Delete(JsonObjectApi headers)
        {
            IRestResponse response = _client.Execute(RequestBuild(Method.DELETE, headers, null));
            Log(response,headers,null);
            return response;
        }


        private void Log(IRestResponse response, JsonObjectApi headers, JsonObject body)
        {
            if (_isLogsOn )
            {
                Console.WriteLine("Request: ");
                Console.WriteLine("    URI: " + response.ResponseUri);
                Console.WriteLine("    Content.Type: "+headers.GetRequest());
                     if (headers.GetHeaders() != null)
                     {
                          
                         Console.WriteLine("    Headers:");
                         foreach (var (key, value) in headers.GetHeaders())
                         {
                             Console.WriteLine(key + " : " +value);
                         }
                     }
                     if (headers.GetPathParams()!=null)
                     {
                         Console.WriteLine("    Path parameters:");
                         foreach ( var (key, value) in headers.GetPathParams())
                         {
                             Console.WriteLine(key+ " : " +value);
                         }
                     }
                     if (headers.GetQueryParams()!=null)
                     {    
                         Console.WriteLine("    Query parameters:");
                         foreach (var (key, value) in headers.GetPathParams())
                         {
                             Console.WriteLine(key+ " : " +value);
                         }
                     }
                     if (body != null)
                     {
                         Console.WriteLine("    Body: ");
                         Console.WriteLine(body);
                     }

                     Console.WriteLine();
                     Console.WriteLine("Response: ");
                     Console.WriteLine("    Headers:");
                     Console.WriteLine(response.Headers.ToString());
               
                     if (response.Content != null)
                     {
                         Console.WriteLine("    Body: ");
                         Console.WriteLine(response.Content);
                     }
                      
                     Console.WriteLine("    Content.Type: "+response.ContentType);
                     Console.WriteLine("    HTTP Code: " + response.StatusCode);
            }
        }
    }
}