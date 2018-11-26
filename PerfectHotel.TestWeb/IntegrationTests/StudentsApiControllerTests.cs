using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using PerfectHotel.Web;
using PerfectHotel.Web.Models;
using Xunit;

namespace PerfectHotel.TestWeb.IntegrationTests
{
    public class StudentsApiControllerTests: IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public StudentsApiControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions()
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task CanGetStudents()
        {
            // The endpoint or route of the controller action
            var httpResponse = await _client.GetAsync("/api/students");

            // Must be successful
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var students = JsonConvert.DeserializeObject<IEnumerable<Student>>(stringResponse);
            var studentsList = students as IList<Student> ?? students.ToList();
            Assert.Contains(studentsList, p => p.FirstName == "SeedFirst1");
            Assert.Contains(studentsList, p => p.FirstName == "SeedFirst2");
        }
    }
}
