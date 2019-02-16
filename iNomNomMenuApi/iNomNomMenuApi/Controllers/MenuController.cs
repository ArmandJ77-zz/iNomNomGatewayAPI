using AutoMapper;
using Domain.MenuItems.DTO;
using iNomNomMenuApi.Controllers.GatewayAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iNomNomMenuApi.Controllers
{
    public class MenuController : BaseController
    {
        public MenuController(IMapper mapper) : base(mapper)
        {
        }

        /// <summary>
        /// Gets a list of menu items
        /// </summary>
        [ProducesResponseType(typeof(List<MenuItemDto>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<List<MenuItemDto>> Get()
            => new List<MenuItemDto>();
    }
}
