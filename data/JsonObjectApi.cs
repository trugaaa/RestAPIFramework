using System;
using System.Collections.Generic;
using NUnit.Framework;
using RestSharp;

namespace RestAPIFrame.data
{
    public class JsonObjectApi : JsonObject
    {
        public JsonObject PutAccept(string value)
        {
            Add("accept",value);
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
            
            testObject.PutAccept("testAccept");
            testObject.PutEndpoint("/endpoint");
            testObject.PutRequest("request");
            testObject.PutHeaders(myDictionary);

            Assert.AreEqual(testObject.GetRequest(),"request");
            Assert.AreEqual(testObject.GetEndpoint(),"/endpoint");
            Assert.AreEqual(testObject.GetAccept(),"testAccept");
            Assert.AreEqual(testObject.GetHeaders().Count,2);

            Dictionary<string, object> dic = testObject.GetHeaders();
            dic.TryGetValue("userName", out var username);
            dic.TryGetValue("password", out var password);
            Assert.AreEqual(username,"trugaaa");
            Assert.AreEqual(password,"uSeregi");
        }
    }
}