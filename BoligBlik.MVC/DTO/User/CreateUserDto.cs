using System.ComponentModel.DataAnnotations;
using BoligBlik.MVC.DTO.Interfaces;

namespace BoligBlik.MVC.DTO.User
{
    // DTO for creating a user
    public class CreateUserDTO : IBaseEntity, IEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [MaxLength(50)]
        public string Role { get; set; }


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
