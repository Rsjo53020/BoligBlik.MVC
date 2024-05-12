namespace BoligBlik.Application.DTO.User
{
    // DTO for deleting a user
    public class DeleteUserDTO
    {
        public Guid UserId { get; set; }
        public DateTime DeletedAt { get; set; } = DateTime.UtcNow;
        public string Reason { get; set; }
    }

}
