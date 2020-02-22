using System;
using System.Net;
using NUnit.Framework;
using RestAPIFrame.process;
using RestAPIFrame.process.data;
using RestSharp;

namespace RestAPIFrame
{
    public class Tests
    {
        private string ROOT_URL = "http://pcni-siteadmin-d-ws.azurewebsites.net/api/v1";
        private bool isLogsOn = true;
        
        private ApiHeaders _apiHeaders;
        private ApiMethods _apiMethods;
        [SetUp]
        public void Setup()
        {
            _apiHeaders = new ApiHeaders();
            _apiMethods = new ApiMethods(ROOT_URL,isLogsOn);
        }

        [Test]
        public void GetAllUsers()
        {

                IRestResponse response = _apiMethods.Get(_apiHeaders.DataHeaders("/users"));
                Assert.AreEqual(response.StatusCode,HttpStatusCode.OK);
        }
        

    }
}