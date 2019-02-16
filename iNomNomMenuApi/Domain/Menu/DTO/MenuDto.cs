using Domain.MenuItems.DTO;
using System;
using System.Collections.Generic;

namespace Domain.Menu.DTO
{
    public class MenuDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public List<MenuItemDto> MenuItems { get; set; }
    }
}
