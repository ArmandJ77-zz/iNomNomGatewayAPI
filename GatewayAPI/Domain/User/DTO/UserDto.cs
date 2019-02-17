using System;

namespace Domain.User.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsValid { get; set; }
        public bool IsDeleted { get; set; }
    }
}
