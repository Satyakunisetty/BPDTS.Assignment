using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BPDTS.Tests.Client;
using BPDTS.Tests.Model;
using Newtonsoft.Json;
using Shouldly;
using TechTalk.SpecFlow;

namespace BPDTS.Tests.Steps
{
    [Binding]
    public class GetUsersSteps
    {
        private readonly IBpdtsServiceClient _bpdtsServiceClient;
        private string _endpoint;
        private HttpResponseMessage _httpResponseMessage;

        public GetUsersSteps()
        {
            _bpdtsServiceClient = new BpdtsServiceClient();
        }

        [Given(@"The api base url is present")]
        public void GivenTheApiBaseUrlIsPresent()
        {
            _endpoint = "http://bpdts-test-app-v2.herokuapp.com";
        }

        [When(@"I call the endpoint")]
        public async Task WhenICallThisEndpoint()
        {
            _httpResponseMessage = await _bpdtsServiceClient.GetUsers(_endpoint);
        }


        [Then(@"I should get the OK status and get all user details")]
        public async Task ThenIShouldGetTheOKStatus()
        {
            
            //Validate Status code is 200
            _httpResponseMessage.StatusCode.ShouldBe(HttpStatusCode.OK);

            //Validate users count retrieved from response are greater than 0 
            var jsonResponse = await _httpResponseMessage.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<User>>(jsonResponse);
            users.Count.ShouldBeGreaterThan(0);
        }

    }
}
