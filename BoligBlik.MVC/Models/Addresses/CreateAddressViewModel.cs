using BoligBlik.MVC.DTO.PostalCodes;
using BoligBlik.MVC.DTO.Interfaces;

namespace BoligBlik.MVC.Models.Addresses
{
    public class CreateAddressViewModel : IEntity, IBaseEntity
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Floor { get; set; }
        public string DoorNumber { get; set; }
        public PostalCodeDTO PostalCode { get; set; }
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
