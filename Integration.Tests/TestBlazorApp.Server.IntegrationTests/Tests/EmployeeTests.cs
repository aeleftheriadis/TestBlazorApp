using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestBlazorApp.Server.IntegrationTests.Tests
{
    public class EmployeeTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public EmployeeTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddAuthentication(defaultScheme: "TestScheme")
                        .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                            "TestScheme", options => { });
                });
            })
                .CreateClient(new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false,
                });

            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(scheme: "TestScheme");
        }

        [Fact]
        public async Task All_Default_ReturnsEmployeesFromDatabase()
        {
            var response = await _client.GetAsync("/api/Employees/All");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("Mark", responseString);
            Assert.Contains("Evelin", responseString);
        }

        [Fact]
        public async Task Post_CorrectModel_ReturnsEmptyResult()
        {
            //Arrange
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/Employees");

            var model = new
            {
                Name ="New Employee",
                Age = "25",
                AccountNumber = "214-5874986532-21"
            };

            var jsonString = JsonSerializer.Serialize(model);

            postRequest.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Post_EmptyModel_ReturnsBadRequest()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/Employees");

            var model = new { };

            var jsonString = JsonSerializer.Serialize(model);

            postRequest.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Get_EmptyModel_ReturnsBadRequest()
        {

            var response = await _client.GetAsync("/api/Employees?employeeId=38f89278-a805-4e97-b515-853ffda1fb16");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("Mark", responseString);

        }
    }
}
