using AutoMapper;
using iNomNomMenuApi;
using Microsoft.AspNetCore.Hosting;
using Repositories;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace IntegrationTests
{
    public class BaseIntegrationTest
    {
        public MenuContext MenuContext { get; set; }
        public HttpClient Client { get; set; }

        public BaseIntegrationTest()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            Mapper.Reset();
            var server = new TestServer(builder);
            MenuContext = server.Host.Services.GetService(typeof(MenuContext)) as MenuContext;
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
