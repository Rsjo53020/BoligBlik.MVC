namespace BoligBlik.Application.DTO.User
{
    // DTO for deleting a user
    public class DeleteUserDTO
    {
        public DateOnly DeletedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public Guid UserId { get; set; }
        public string Reason { get; set; }
        public DateTime DeletionDate { get; set; }
    }
}
