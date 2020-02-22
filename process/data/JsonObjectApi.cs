using System.Collections.Generic;
using NUnit.Framework;
using RestSharp;

namespace RestAPIFrame.process.data
{
    public class JsonObjectApi : JsonObject
    {
        public JsonObject PutAccept(string value)
        {
            Add("accept",value);
            return this;
        }

        public JsonObject PutPathParams(Dictionary<string, object> myHeaders)
        {
            Add("pathParams", myHeaders);
            return this;
        }
        
        public JsonObject PutQueryParams(Dictionary<string, object> myHeaders)
        {
            Add("queryParams", myHeaders);
            return this;
        }
        public JsonObject PutRequest( string value) 
        {
            Add("request",value);
        return this; 
        }

        public JsonObject PutEndpoint(string value)
        {
            Add("endpoint",value);
            return this;
        }

        public JsonObject PutHeaders(Dictionary<string, object> myHeaders)
        {
            Add("headers", myHeaders);
            return this;
        }

        public string GetRequest()
        {
            this.TryGetValue("request", out var request);
            return (string)request;
        }

        public Dictionary<string, object> GetHeaders()
        {
            this.TryGetValue("headers", out var myHeaders);
            return (Dictionary<string, object>) myHeaders;
        }

        public Dictionary<string, object> GetPathParams()
        {
            this.TryGetValue("pathParams", out var myHeaders);
            return (Dictionary<string, object>) myHeaders;
        }
        
        public Dictionary<string, object> GetQueryParams()
        {
            this.TryGetValue("queryParams", out var myHeaders);
            return (Dictionary<string, object>) myHeaders;
        }
        
        public string GetAccept()
        {

            this.TryGetValue("accept", out var accept);
            return (string)accept;
        }
        
        public string GetEndpoint()
        {
            this.TryGetValue("endpoint", out var  endpoint);
            return (string)endpoint;
        }
        
        [Test]
       public void TestJsonObjectApi()
        {
            JsonObjectApi testObject = new JsonObjectApi();
            Dictionary<string, object> myDictionary = new Dictionary<string, object>();
            myDictionary.Add("userName","trugaaa");
            myDictionary.Add("password","uSeregi");
            
            testObject.PutAccept("application/json");
            testObject.PutEndpoint("/endpoint");
            testObject.PutRequest("application/json");
            testObject.PutHeaders(myDictionary);
            testObject.PutPathParams(myDictionary);
            testObject.PutQueryParams(myDictionary);
            
            Assert.AreEqual(testObject.GetRequest(),"application/json");
            Assert.AreEqual(testObject.GetEndpoint(),"/endpoint");
            Assert.AreEqual(testObject.GetAccept(),"application/json");
            Assert.AreEqual(testObject.GetHeaders().Count,2);

            Dictionary<string, object> dic = testObject.GetHeaders();
            dic.TryGetValue("userName", out var username);
            dic.TryGetValue("password", out var password);
            Assert.AreEqual(username,"trugaaa");
            Assert.AreEqual(password,"uSeregi");
            
            dic = testObject.GetPathParams();
            dic.TryGetValue("userName", out var username1);
            dic.TryGetValue("password", out var  password1);
            Assert.AreEqual(username1,"trugaaa");
            Assert.AreEqual(password1,"uSeregi");
            
            dic = testObject.GetQueryParams();
            dic.TryGetValue("userName", out var username2);
            dic.TryGetValue("password", out var  password2);
            Assert.AreEqual(username2,"trugaaa");
            Assert.AreEqual(password2,"uSeregi");
        }
    }
}