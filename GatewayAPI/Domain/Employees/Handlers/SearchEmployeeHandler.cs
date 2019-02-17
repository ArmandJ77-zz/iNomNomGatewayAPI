using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain.Infrastructure;
using Repositories;

namespace Domain.Employees.Handlers
{
    public class SearchEmployeeHandler: BaseHandler, ISearchEmployeeHandler
    {
        public SearchEmployeeHandler(IMapper autoMapper, GatewayContext context) : base(autoMapper, context)
        {
        }
    }

    public interface ISearchEmployeeHandler
    {
    }
}
