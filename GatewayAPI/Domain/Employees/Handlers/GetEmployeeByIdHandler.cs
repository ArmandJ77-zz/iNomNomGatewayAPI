using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain.Infrastructure;
using Repositories;

namespace Domain.Employees.Handlers
{
    public class GetEmployeeByIdHandler: BaseHandler, IGetEmployeeByIdHandler
    {
        public GetEmployeeByIdHandler(IMapper autoMapper, GatewayContext context) : base(autoMapper, context)
        {
        }
    }

    public interface IGetEmployeeByIdHandler
    {
    }
}
