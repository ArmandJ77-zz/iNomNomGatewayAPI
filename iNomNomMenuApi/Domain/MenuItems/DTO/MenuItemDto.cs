namespace Domain.MenuItems.DTO
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int TimeToPrep { get; set; }
    }
}
