using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BPDTS.Tests.Client
{
    public interface IBpdtsServiceClient
    {
        Task<HttpResponseMessage> GetUsers(string endpoint);
        Task<HttpResponseMessage> GetUserBy(string baseUrl, string id);
        Task<HttpResponseMessage> GetUsersBy(string baseUrl, string city);
    }
    public class BpdtsServiceClient: IBpdtsServiceClient
    {
        public async Task<HttpResponseMessage> GetUsers(string endpoint)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{endpoint}/users");
            return response;
        }

        public async Task<HttpResponseMessage> GetUserBy(string baseUrl, string id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{baseUrl}/user/{id}");
            return response;
        }
        
        public async Task<HttpResponseMessage> GetUsersBy(string baseUrl, string city)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{baseUrl}/city/{city}/users");
            return response;
        }
    }
}
