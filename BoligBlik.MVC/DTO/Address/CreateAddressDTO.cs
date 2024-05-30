namespace BoligBlik.MVC.DTO.Address
{
    public class CreateAddressDTO 
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Floor { get; set; }
        public string DoorNumber { get; set; }
        public string City { get; set; }
        public string PostalCodeNumber { get; set; }
    }
}
