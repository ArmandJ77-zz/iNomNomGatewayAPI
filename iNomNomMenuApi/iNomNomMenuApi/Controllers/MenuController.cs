using AutoMapper;
using Domain.MenuItems.DTO;
using iNomNomMenuApi.Controllers.GatewayAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Menu.DTO;
using Domain.Menu.Handlers;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Models;

namespace iNomNomMenuApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MenuController : BaseController
    {
        private readonly MenuContext _context;

        public MenuController(IMapper mapper, MenuContext context) : base(mapper)
        {
            _context = context;
        }

        /// <summary>
        /// Gets a list of menus including their menu items
        /// </summary>
        [ProducesResponseType(typeof(List<MenuDto>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<List<MenuDto>> Get([FromServices] IGetMenusHandler handler)
            => await handler.ExecuteAsync();
    }
}
