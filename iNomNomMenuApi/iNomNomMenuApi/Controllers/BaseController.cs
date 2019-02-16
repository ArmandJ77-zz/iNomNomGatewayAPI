namespace iNomNomMenuApi.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    namespace GatewayAPI.Controllers
    {
        public class BaseController : Controller
        {
            public IMapper Map { get; }

            public BaseController(IMapper mapper)
            {
                Map = mapper;
            }
        }
    }
}
