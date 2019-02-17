using Domain.User.DTO;

namespace Domain.Employees.DTO
{
    public class EmployeeDto
    {
        public UserDto User { get; set; }
        public PositionDto Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string GithubUser { get; set; }
        public string Birthdate { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public int Yearsworked { get; set; }
        public int Age { get; set; }
        public int DaysToBirthday { get; set; }
    }
}