using System.Collections.Generic;
using System.Data;

namespace Repositories.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DataSetDateTime DateCreated { get; set; }

        public ICollection<MenuItem> Items { get; set; }
    }
}
