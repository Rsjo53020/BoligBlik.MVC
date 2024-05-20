using BoligBlik.MVC.DTO.Interfaces;
using BoligBlik.MVC.DTO.PostalCodes;

namespace BoligBlik.MVC.DTO.Address
{
    public class UpdateAddressDTO : IEntity, IBaseEntity
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Floor { get; set; }
        public string DoorNumber { get; set; }
        public string PostalCodeNumber { get; set; }
        public string City { get; set; }
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
        public Guid? CreateBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; }
        public Guid? DeletedBy { get; set; }
    }
}
