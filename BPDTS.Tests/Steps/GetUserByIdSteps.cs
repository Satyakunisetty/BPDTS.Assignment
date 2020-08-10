using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BPDTS.Tests.Client;
using BPDTS.Tests.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Shouldly;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BPDTS.Tests.Steps
{
    [Binding]
    public class GetUserByIdSteps
    {
        private string _baseUrl;
        private readonly IBpdtsServiceClient _bpdtsServiceClient;
        private HttpResponseMessage _httpResponseMessage;
        private User _user;

        public GetUserByIdSteps()
        {
            _bpdtsServiceClient = new BpdtsServiceClient();
        }

        [Given(@"I get the api base url")]
        public void GivenIGetTheApiBaseUrl()
        {
            _baseUrl = "http://bpdts-test-app-v2.herokuapp.com";
        }

        [When(@"I call the user endpoint with (.*)")]
        public async Task WhenICallTheGetUserByIdEndpointWithUserId(string id)
        {
            _httpResponseMessage = await _bpdtsServiceClient.GetUserBy(_baseUrl, id);
        }

        [Then(@"I should get the (.*)")]
        public void ThenValidateStatusCode(HttpStatusCode httpStatusCode)
        {
            _httpResponseMessage.StatusCode.ShouldBe(httpStatusCode);
        }


        [Then(@"validate API response values like (.*),(.*),(.*),(.*),(.*),(.*),(.*) based on (.*)")]
        public async Task ThenValidateAPIResponseValues(string fname, string lname, string email, string ipAddress, string latitude, string longitude, string city, string userid)
        {
            var jsonResponse = await _httpResponseMessage.Content.ReadAsStringAsync();
            _user = JsonConvert.DeserializeObject<User>(jsonResponse);
            AssertResult(fname, lname, email, ipAddress, latitude, longitude, city);
        }

        [Then(@"validate (.*) in API response")]
        public async Task ThenValidateIdDoesnTExistInAPIResponse(string expectedErrorMessage)
        {
            var jsonResponse = await _httpResponseMessage.Content.ReadAsStringAsync();
            var result = JObject.Parse(jsonResponse);
            var actualErrorMessage = result["message"].ToString();
            actualErrorMessage.ShouldBe(expectedErrorMessage);
        }


        public void AssertResult(string fname, string lname, string email, string ipAddress, string latitude, string longitude, string city)
        {
            _user.First_name.Trim().ShouldBe(fname.Trim());
            _user.Last_name.Trim().ShouldBe(lname.Trim());
            _user.Email.Trim().ShouldBe(email.Trim());
            _user.Ip_address.Trim().ShouldBe(ipAddress.Trim());
            _user.Latitude.Trim().ShouldBe(latitude.Trim());
            _user.Longitude.Trim().ShouldBe(longitude.Trim());
            _user.City.Trim().ShouldBe(city.Trim());
        }

    }
}
