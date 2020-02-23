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
        private Endpoints _endpoints;
        [SetUp]
        public void Setup()
        {
            _apiHeaders = new ApiHeaders();
            _apiMethods = new ApiMethods(ROOT_URL,isLogsOn);
            _endpoints  = new Endpoints();
        }

        [Test]
        public void GetAllUsers()
        {

                IRestResponse response = _apiMethods.Get(_apiHeaders.DataHeaders(_endpoints.Users));
                Assert.AreEqual(response.StatusCode,HttpStatusCode.OK);
        }
        

    }
}