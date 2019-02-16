using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace Repositories
{
    public class MenuContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> Items { get; set; }

        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
