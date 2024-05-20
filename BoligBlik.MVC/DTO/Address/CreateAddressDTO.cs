using BoligBlik.MVC.DTO.PostalCodes;
using BoligBlik.MVC.DTO.Interfaces;

namespace BoligBlik.MVC.DTO.Address
{
    public class CreateAddressDTO /*: IEntity, IBaseEntity*/
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Floor { get; set; }
        public string DoorNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        //public PostalCodeDTO PostalCode { get; set; }
        //public Guid Id { get; set; }
        //public byte[] RowVersion { get; set; }
        //public Guid? CreateBy { get; set; }
        //public DateTime? CreatedAt { get; set; }
    }
}
