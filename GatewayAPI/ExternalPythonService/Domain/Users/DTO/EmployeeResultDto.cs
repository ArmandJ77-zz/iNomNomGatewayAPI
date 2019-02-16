namespace ExternalPythonService.Domain.Users.DTO
{
    public class EmployeeResultDto
    {
        public User user { get; set; }
        public Position position { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public string github_user { get; set; }
        public string birth_date { get; set; }
        public string gender { get; set; }
        public string race { get; set; }
        public int years_worked { get; set; }
        public int age { get; set; }
        public int days_to_birthday { get; set; }
    }
}
