using BoligBlik.Application.DTO.Adress;

namespace BoligBlik.Application.DTO.User
{
    // DTO for creating a user
    public class CreateUserDTO
    {
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Role { get; set; }
        public AddressDTO Address { get; set; }
    }
}
