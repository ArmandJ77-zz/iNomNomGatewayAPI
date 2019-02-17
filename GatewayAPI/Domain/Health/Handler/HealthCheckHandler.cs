using AutoMapper;
using Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Threading.Tasks;

namespace Domain.Health.Handler
{
    public class HealthCheckHandler: BaseHandler, IHealthCheckHandler
    {
        public HealthCheckHandler(IMapper autoMapper, GatewayContext context) : base(autoMapper, context)
        {
        }

        public async Task<HealthDto> ExecuteAsync()
        {
            var response = new HealthDto(){ServiceStatus = "Up"};

            try
            {
                var entities = await Context.ClientAuthentications.ToListAsync();
                response.DbStatus = "Up";
            }
            catch (Exception e)
            {
                response.DbStatus = "Down";
            }

            return response;
        }
    }

    public interface IHealthCheckHandler
    {
        Task<HealthDto> ExecuteAsync();
    }
}
