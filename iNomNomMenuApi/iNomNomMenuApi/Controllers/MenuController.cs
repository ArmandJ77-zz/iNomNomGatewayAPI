using AutoMapper;
using Domain.MenuItems.DTO;
using iNomNomMenuApi.Controllers.GatewayAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repositories;

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
        /// Gets a list of menu items
        /// </summary>
        [ProducesResponseType(typeof(List<MenuItemDto>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<List<MenuItemDto>> Get()
        {
            var result = await  _context.Menus.Include(x => x.Items).ToListAsync();
            return null;
        }
    }
}
