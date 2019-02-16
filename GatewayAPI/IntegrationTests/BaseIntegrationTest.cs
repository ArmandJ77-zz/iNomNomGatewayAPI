using AutoMapper;
using GatewayAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using Repositories;
using System.Net.Http;

namespace IntegrationTests
{
    public class BaseIntegrationTest
    {
        public GatewayContext MenuContext { get; set; }
        public HttpClient Client { get; set; }

        public BaseIntegrationTest()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            Mapper.Reset();
            var server = new TestServer(builder);
            Client = server.CreateClient();
            MenuContext = server.Host.Services.GetService(typeof(GatewayContext)) as GatewayContext;

        }

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            BuildDb();
        }

        private void BuildDb()
        {
        }
    }
}
