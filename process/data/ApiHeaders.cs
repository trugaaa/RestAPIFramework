using System;
using System.Collections.Generic;
using NUnit.Framework;
using RestSharp;

namespace RestAPIFrame.process.data
{
    public class ApiHeaders
    {
        public JsonObjectApi DataHeaders(string endpoint)
        {
            JsonObjectApi apiHeaders = new JsonObjectApi();
            apiHeaders.PutAccept("application/json");
            apiHeaders.PutRequest("application/json");
            apiHeaders.PutEndpoint(endpoint);
            return apiHeaders;
        }
        
        public JsonObjectApi DataHeadersWithPathId(string endpoint,int id)
        {
            JsonObjectApi apiHeaders = new ApiHeaders().DataHeaders(endpoint.Replace("/{id}/", "/"+ id +"/"));
            return apiHeaders;
        }

        public JsonObject DataHeadersWithIncludeDataInResponse(string endpoint, bool includeDataInResponse)
        {
            JsonObjectApi apiHeaders = new ApiHeaders().DataHeaders(endpoint);
            Dictionary<string, object>dictionary = new Dictionary<string, object>();
            dictionary.Add("includeDataInResponse",  includeDataInResponse);
            apiHeaders.PutHeaders(dictionary);
            return apiHeaders;
        }


        [Test]
        public void TestDataHeadersWithId()
        {
            string endpoint = "/endpoint/{id}/11/";
            int id = 11;
            JsonObjectApi obj =  DataHeadersWithPathId(endpoint, id);
            
            Console.WriteLine("Endpoint before replacing: "+ endpoint);
            Console.WriteLine("Id to replace:"+id);
            Console.WriteLine("Replaced id endpoint: "+ obj.GetEndpoint());
            Assert.AreEqual(obj.GetEndpoint(),"/endpoint/11/11/");
        }
    }
}