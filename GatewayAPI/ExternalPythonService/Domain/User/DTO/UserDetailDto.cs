namespace ExternalPythonService.Domain.User.DTO
{
    public class UserDetailDto
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public bool is_active { get; set; }
        public bool is_staff { get; set; }
    }
}