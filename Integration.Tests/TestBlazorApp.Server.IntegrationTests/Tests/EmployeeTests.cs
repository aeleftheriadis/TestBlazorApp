using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task All_WhenCalled_ReturnsEmployeesFromDatabase()
        {
            var response = await _client.GetAsync("/api/Employees/All");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Mark", responseString);
            Assert.Contains("Evelin", responseString);
        }

        [Fact]
        public async Task Post_WhenCalled_ReturnsEmptyResult()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/Employees");

            var formModel = new
            {
                Name ="New Employee",
                Age = "25",
                AccountNumber = "214-5874986532-21"
            };

            var jsonString = JsonSerializer.Serialize(formModel);

            postRequest.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(postRequest);

            response.EnsureSuccessStatusCode();
        }

        //[Fact]
        //public async Task Post_WhenCalled_ReturnsError()
        //{
        //    var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/Employees");



        //    var jsonString = JsonSerializer.Serialize(formModel);

        //    postRequest.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

        //    var response = await _client.SendAsync(postRequest);

        //    response.EnsureSuccessStatusCode();
        //}
    }
}
