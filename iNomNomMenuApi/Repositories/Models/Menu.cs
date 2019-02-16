using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }

        public ICollection<MenuItem> Items { get; set; }
    }
}
