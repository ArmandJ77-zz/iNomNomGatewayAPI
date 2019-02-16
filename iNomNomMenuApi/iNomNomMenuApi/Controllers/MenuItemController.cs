using AutoMapper;
using Domain.MenuItems.DTO;
using Domain.MenuItems.Handlers;
using iNomNomMenuApi.Controllers.GatewayAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iNomNomMenuApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MenuItemController: BaseController
    {
        public MenuItemController(IMapper mapper) : base(mapper)
        {
        }

        /// <summary>
        /// Get a menu item by id
        /// </summary>
        [ProducesResponseType(typeof(MenuItemDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("/{id}")]
        public async Task<MenuItemDto> Get([FromRoute] int id, [FromServices] IGetMenuItemHandler handler)
            => await handler.ExecuteAsync(id);

        /// <summary>
        /// Get list of menu items
        /// </summary>
        [ProducesResponseType(typeof(List<MenuItemDto>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("/{pagesize}/{page}")]
        public async Task<List<MenuItemDto>> Get([FromRoute] int pagesize, [FromRoute] int page, [FromServices] IGetMenuItemListHandler handler)
            => await handler.ExecuteAsync(page, pagesize);

        /// <summary>
        /// Create menu item
        /// </summary>
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPost]
        public async Task<int> Post([FromBody] CreateMenuItemDto dto, [FromServices] ICreateMenuItemHandler handler)
            => await handler.ExecuteAsync(dto);

        /// <summary>
        /// Update menu item
        /// </summary>
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPut]
        public async Task<int> Put([FromBody] UpdateMenuItemDto dto, [FromServices] IUpdateMenuItemHandler handler)
            => await handler.ExecuteAsync(dto);

        /// <summary>
        /// Delete a menu item by id
        /// </summary>
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpDelete("/{id}")]
        public async Task<int> Put([FromRoute] int id, [FromServices] IDeleteMenuItemHandler handler)
            => await handler.ExecuteAsync(id);
    }
}
