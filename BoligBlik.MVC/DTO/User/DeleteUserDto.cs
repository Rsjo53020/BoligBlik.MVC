using BoligBlik.MVC.DTO.Interfaces;

namespace BoligBlik.MVC.DTO.User
{
    // DTO for deleting a user
    public class DeleteUserDTO : IBaseEntity, IEntity
    {
        public string Reason { get; set; }

        public Guid? CreateBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; }
        public Guid? DeletedBy { get; set; }
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
    }

}
