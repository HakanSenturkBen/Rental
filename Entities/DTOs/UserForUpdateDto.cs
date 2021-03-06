using Core.Entities;

namespace Entities.DTOs
{
    public class UserForUpdateDto : IDto
    {
        public int id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
