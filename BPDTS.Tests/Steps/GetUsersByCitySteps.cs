using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BPDTS.Tests.Client;
using BPDTS.Tests.Model;
using Newtonsoft.Json;
using Shouldly;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Configuration;
using NUnit.Framework;

namespace BPDTS.Tests.Steps
{
    [Binding]
    public class GetUsersByCitySteps
    {

        private readonly IBpdtsServiceClient _bpdtsServiceClient;
        private HttpResponseMessage _httpResponseMessage;
        private List<User> _users;
        private string _baseUrl;

        public GetUsersByCitySteps()
        {
            _bpdtsServiceClient = new BpdtsServiceClient();
        }

        [Given(@"I have the api base url")]
        public void RetrieveApiBaseUrl()
        {

            _baseUrl = "http://bpdts-test-app-v2.herokuapp.com";
        }


        [When(@"I call the city endpoint using (.*)")]
        public async Task CallTheCityEndpoint(string cityName)
        {
            _httpResponseMessage = await _bpdtsServiceClient.GetUsersBy(_baseUrl, cityName);
        }

        [Then(@"I should get the OK status result from endpoint")]
        public void ValidateStatuscodefromEndpoint()
        {
            _httpResponseMessage.StatusCode.ShouldBe(HttpStatusCode.OK);
        }


        [Then(@"validate API response values like (.*),(.*),(.*), (.*),(.*), (.*),(.*) and (.*)")]
        public async Task ValidateAPIResponseValues(string id, string fname, string lname, string email, string ipAddress, string latitude, string longitude, int count)
        {
            var jsonResponse = await _httpResponseMessage.Content.ReadAsStringAsync();
            _users = JsonConvert.DeserializeObject<List<User>>(jsonResponse);

            //perform user details validation based on count flag
            if (count == 0)
            {
                if(_users.Count == 0)
                    Assert.IsTrue(true, "No results are found for the city name");
                else
                    Assert.IsFalse(true, "User details are not matched");
            }
            else
            {
                AssertResults(id, fname, lname, email, ipAddress, latitude, longitude);
            }
        }

        private void AssertResults(string id, string fname, string lname, string email, string ipAddress, string latitude,string longitude)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                Assert.IsFalse(true, $"User with the id {id} not found");
            }
            else
            {
                user.First_name.Trim().ShouldBe(fname.Trim());
                user.Last_name.Trim().ShouldBe(lname.Trim());
                user.Email.Trim().ShouldBe(email.Trim());
                user.Ip_address.Trim().ShouldBe(ipAddress.Trim());
                user.Latitude.Trim().ShouldBe(latitude.Trim());
                user.Longitude.Trim().ShouldBe(longitude.Trim());
            }
        }
    }
}
