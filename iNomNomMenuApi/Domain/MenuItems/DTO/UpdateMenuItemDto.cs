namespace Domain.MenuItems.DTO
{
    public class UpdateMenuItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int TimeToPrep { get; set; }
    }
}
